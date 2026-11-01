using cs_msg;
using LocalGameServer.Storage;

namespace LocalGameServer.Protocol;

// 单人房间的物品、掉落和挖掘状态。
public sealed partial class LocalWorldItems(ServerLog log, string session, ushort gameMode, bool challengesEnabled)
{
    private const int InvalidParameter = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
    private const int MaximumDrops = 2048;
    private static long nextDropId = 0x4000000000000000;
    private readonly LocalInventory inventory = new();
    private readonly LocalWorldChallenges challenges = new(log, session, challengesEnabled);
    private sealed record Drop(CSDropItemDesc Item, CSPosition Position);
    private readonly Dictionary<ulong, Drop> drops = new();
    private readonly Dictionary<(int X, int Y, int Z), int> blocks = new();
    private readonly Dictionary<(int X, int Y, int Z), int> placements = new();
    private readonly Dictionary<(int X, int Y, int Z), uint> tileVersions = new();
    private readonly Dictionary<ushort, int> attributes = new();
    private CSBlockIDPos? digging;
    private byte teamIndex;
    private static LocalWorldCatalog Catalog => LocalWorldCatalog.Current;
    private readonly bool survival = gameMode == (ushort)ECSGameMode.CS_ARCADE_SURVIVAL_NORMAL;

    public CSBagItemInfo InventorySnapshot() => inventory.Snapshot();
    public List<GameResponse> InitialChallenges() => challenges.InitialResponses();

    public List<GameResponse>? HandleChallenges(GameRequest request, ulong actorId)
    {
        var responses = challenges.Handle(request, inventory);
        if (responses?.Any(item => item.Command == (int)ECSMsgCmdID.CS_RSP_BAG_CHANGE) == true)
            responses.Add(HandAttributes(actorId));
        return responses;
    }

    public List<GameResponse>? Handle(GameRequest request, LocalAccount account, ulong roomId)
    {
        var survivalResponses = HandleSurvival(request, account.Gid);
        if (survivalResponses != null) return survivalResponses;
        if (challengesEnabled && Hp <= 0 && request.Body is CSReqMakeItems or CSReqPutBlock or
            CSReqBeginDigBlock or CSReqFinishDigBlock or CSReqPickUpDropItem)
            return [Error("请先复活")];
        switch (request.Body)
        {
            case CSReqMakeItems make:
                return Craft(make, account.Gid);
            case CSReqPutBlock put:
                return PutBlock(put, account.Gid);
            case CSReqUgcGiveItem give:
                var itemId = give.resID <= int.MaxValue ? (int)give.resID : 0;
                var count = give.count <= ushort.MaxValue ? (int)give.count : 0;
                var result = inventory.Add(itemId, count, out var changed);
                log.Write(session, "item_granted", new { result, itemId, count }, true);
                var granted = new List<GameResponse>
                {
                    GameResponse.Of<CSRspUgcGiveItem>((int)ECSMsgCmdID.CS_RSP_UGC_GIVE_ITEM,
                        rsp => rsp.result = result)
                };
                LocalInventory.AppendChanges(granted, changed);
                if (result == 0) granted.Add(HandAttributes(account.Gid));
                if (result == 0) challenges.Record(granted, "GetItems", itemId, count);
                return granted;
            case CSReqTriggerDestroyAllItems clear:
                var clearResult = clear.actorID == account.Gid ? 0 : InvalidParameter;
                var cleared = new List<GameResponse>();
                if (clearResult == 0)
                {
                    LocalInventory.AppendChanges(cleared, inventory.Clear());
                    cleared.Add(HandAttributes(account.Gid));
                }
                cleared.Add(GameResponse.Of<CSRspTriggerDestroyAllItems>(
                    (int)ECSMsgCmdID.CS_RSP_TRIGGER_DESTROY_ALL_ITEMS, rsp => rsp.result = clearResult));
                log.Write(session, "inventory_cleared", new { result = clearResult, clear.actorID }, true);
                return cleared;
            case CSReqUgcCreateItem create:
                if (!ValidMetricPosition(create.position) ||
                    !TryPlanDrops([(create.resID, create.count)], create.position, out var plan))
                    return [Error("掉落物参数或数量无效")];
                log.Write(session, "drop_created", new { create.resID, create.count,
                    position = create.position, source = "tutorial" }, true);
                return Spawn(plan);
            case CSReqPickUpDropItem pickup:
                return Pickup(pickup, account.Gid);
            case CSReqUpdateDropItemPos update:
                if (update.roomGID != roomId || !ValidMetricPosition(update.entityPos) ||
                    !drops.TryGetValue(update.dropObjID, out var drop)) return [];
                drops[update.dropObjID] = drop with { Position = Copy(update.entityPos) };
                return [GameResponse.Of<CSRspUpdateDropItemPos>((int)ECSMsgCmdID.CS_RSP_UPDATE_DROP_ITEM_POS,
                    rsp =>
                    {
                        rsp.roomGID = roomId;
                        rsp.dropObjID = update.dropObjID;
                        rsp.entityPos = Copy(update.entityPos);
                        rsp.moveType = update.moveType;
                    })];
            case CSReqDelDropItem delete:
                var deleted = drops.Remove(delete.objId);
                var deletion = new List<GameResponse>
                {
                    GameResponse.Of<CSRspDelDropItem>((int)ECSMsgCmdID.CS_RSP_DEL_DROP_ITEM,
                        rsp => { rsp.objId = delete.objId; rsp.result = deleted ? 0 :
                            (int)ECSErrorCode.CS_ERR_DROP_ITEM_NOT_FOUND; })
                };
                if (deleted) deletion.Add(GameResponse.Of<CSRspDropItemLeaveView>(
                    (int)ECSMsgCmdID.CS_RSP_DROP_ITEM_LEAVE_VIEW,
                    rsp => { rsp.count = 1; rsp.dropItems[0] = delete.objId; }));
                return deletion;
            case CSReqDragItem drag:
                var dragResult = inventory.Drag(drag, out var moved);
                var movement = new List<GameResponse>
                {
                    GameResponse.Of<CSRspDragItem>((int)ECSMsgCmdID.CS_RSP_DRAG_ITEM,
                        rsp => rsp.errCode = dragResult)
                };
                LocalInventory.AppendChanges(movement, moved);
                if (dragResult == 0) movement.Add(HandAttributes(account.Gid));
                log.Write(session, "inventory_moved", new
                {
                    result = dragResult,
                    source = new { drag.srcItem.container, drag.srcItem.index, drag.srcItem.resID },
                    destination = new { drag.dstItem.container, drag.dstItem.index, drag.dstItem.resID },
                    slots = LocalInventory.Describe(moved)
                }, true);
                return movement;
            case CSReqGripItem grip:
                var gripResult = inventory.Grip(grip.item);
                var held = new List<GameResponse>
                {
                    GameResponse.Of<CSRspGripItem>((int)ECSMsgCmdID.CS_RSP_GRIP_ITEM, rsp =>
                    {
                        rsp.errCode = gripResult;
                        rsp.actorID = account.Gid;
                        rsp.item = new CSGripItem { resID = grip.item.resID, index = grip.item.index };
                    })
                };
                if (gripResult == 0) held.Add(HandAttributes(account.Gid));
                return held;
            case CSReqBeginDigBlock begin:
                if (!ValidBlock(begin.blockIDPos)) return [Error("挖掘目标无效")];
                digging = new CSBlockIDPos { blockID = begin.blockIDPos.blockID,
                    blockPos = Copy(begin.blockIDPos.blockPos) };
                return [];
            case CSReqFinishDigBlock finish:
                return FinishDig(finish, account.Gid);
            case CSReqAreaBlockUpdate area:
                return AreaUpdate(area, account.Gid);
            case CSReqUgcChangeActorAttr change:
                if (change.actorID != account.Gid || change.count < 0 || change.count > change.attrInfo.Length ||
                    change.attrInfo.Take(change.count).Any(point => !Enum.IsDefined(typeof(ECSAttrType), (int)point.attrType)))
                    return [Error("属性目标或类型无效")];
                foreach (var point in change.attrInfo.Take(change.count))
                    attributes[point.attrType] = point.attrValue;
                SyncVitals();
                log.Write(session, "player_attributes", new { change.actorID,
                    values = change.attrInfo.Take(change.count).ToArray() }, true);
                // 此请求用属性通知下发结果。
                return [AttributeResponse(account.Gid, change.attrInfo.Take(change.count)
                    .Select(point => new CSAttrPoint { attrType = point.attrType, attrValue = point.attrValue }).ToArray())];
            case CSReqUgcExchangeTeam team:
                var teamResult = team.roomGID == roomId && team.actorID == account.Gid && team.teamIdx < 16
                    ? 0 : InvalidParameter;
                if (teamResult == 0) teamIndex = team.teamIdx;
                return [GameResponse.Of<CSRspUgcExchangeTeam>((int)ECSMsgCmdID.CS_RSP_UGC_EXCHANGE_TEAM,
                    rsp => { rsp.result = teamResult; rsp.actorID = account.Gid; rsp.teamIdx = teamIndex; })];
            default:
                return null;
        }
    }

    private List<GameResponse> PutBlock(CSReqPutBlock request, ulong actorId)
    {
        var key = Key(request.blockPos);
        var result = 0;
        var itemId = 0;
        var repeated = false;
        CSItemData[] changed = [];
        if (!ValidBlockPosition(request.blockPos) || request.blockID <= 0 ||
            request.blockID > ushort.MaxValue ||
            !Catalog.Blocks.TryGetValue(request.blockID, out var definition) ||
            !Catalog.Items.ContainsKey(definition.ItemId))
            result = (int)ECSErrorCode.CS_ERR_BLOCK_POS_INVALID;
        else
        {
            itemId = definition.ItemId;
            if (blocks.TryGetValue(key, out var current) && current != 0)
            {
                // 同一放置包重传不重复扣物品。
                repeated = current == request.blockID && placements.GetValueOrDefault(key) == current;
                if (!repeated) result = (int)ECSErrorCode.CS_ERR_BLOCK_ALREADY_EXIST;
            }
            else if (blocks.Count >= 65536 && !blocks.ContainsKey(key))
                result = InvalidParameter;
            else
            {
                result = inventory.ConsumeHeld(itemId, out changed);
                if (result == 0)
                {
                    blocks[key] = request.blockID;
                    placements[key] = request.blockID;
                    AdvanceVersion(request.blockPos);
                }
            }
        }
        log.Write(session, "block_placed", new
        {
            result, request.blockID, itemId, repeated,
            position = new { request.blockPos.x, request.blockPos.y, request.blockPos.z },
            tileVersion = Version(request.blockPos)
        }, true);
        var responses = new List<GameResponse>();
        LocalInventory.AppendChanges(responses, changed);
        if (result == 0 && !repeated) responses.Add(HandAttributes(actorId));
        // 工作台等重要方块须等回包才落到地图。
        responses.Add(GameResponse.Of<CSRspPutBlock>((int)ECSMsgCmdID.CS_RSP_PUT_BLOCK, rsp =>
        {
            rsp.result = result;
            rsp.accountGID = actorId;
            rsp.blockPos = Copy(request.blockPos);
            rsp.blockID = request.blockID;
            rsp.tileVersion = Version(request.blockPos);
        }));
        if (result == 0 && !repeated) challenges.Record(responses, "PutBlockReferItemID", itemId, 1);
        return responses;
    }

    private List<GameResponse> Craft(CSReqMakeItems request, ulong actorId)
    {
        var result = (int)ECSErrorCode.CS_ERR_MAKE_INVALID_ID;
        CSItemData[] changed = [];
        Catalog.Recipes.TryGetValue(request.makeID, out var recipe);
        if (recipe != null)
        {
            var verify = request.blockVerify;
            if (!recipe.UsableInit || recipe.Blueprint != 0 || recipe.Gold != 0)
                result = (int)ECSErrorCode.CS_ERR_SERVR_IS_NOT_OPEN;
            else if (!ValidBlockPosition(verify.position) || !recipe.InHands &&
                     (!recipe.WorkbenchBlocks.Contains(verify.blockID) ||
                      blocks.TryGetValue(Key(verify.position), out var known) && known != verify.blockID))
                result = (int)ECSErrorCode.CS_ERR_MAKE_INVALID_PARAM;
            else
                result = inventory.Craft(recipe, request.makeDesc, request.reDoCnt, out changed);
        }
        log.Write(session, "item_crafted", new
        {
            result, request.makeID, requestedCount = request.reDoCnt,
            successCount = result == 0 ? request.reDoCnt : 0,
            targetId = recipe?.TargetId ?? 0,
            targetCount = result == 0 ? recipe!.TargetCount * request.reDoCnt : 0,
            request.blockVerify.blockID,
            slots = LocalInventory.Describe(changed)
        }, true);
        var responses = new List<GameResponse>();
        LocalInventory.AppendChanges(responses, changed);
        if (result == 0) responses.Add(HandAttributes(actorId));
        // 客户端从成功回包触发制作完成事件。
        responses.Add(GameResponse.Of<CSRspMakeItems>((int)ECSMsgCmdID.CS_RSP_MAKE_ITEMS, rsp =>
        {
            rsp.errCode = result;
            rsp.makeID = request.makeID;
            rsp.successCnt = result == 0 ? request.reDoCnt : 0;
        }));
        if (result == 0)
        {
            var count = recipe!.TargetCount * request.reDoCnt;
            challenges.Record(responses, "GetItems", recipe.TargetId, count);
            challenges.Record(responses, "ItemMake", recipe.TargetId, count);
        }
        return responses;
    }

    private List<GameResponse> Pickup(CSReqPickUpDropItem request, ulong actorId)
    {
        var result = (int)ECSErrorCode.CS_ERR_DROP_ITEM_NOT_FOUND;
        var item = new CSDropItemDesc { objID = request.item.objID };
        CSItemData[] changed = [];
        if (drops.TryGetValue(request.item.objID, out var drop))
        {
            item = drop.Item;
            result = request.item.itemID == item.itemID && request.item.count == item.count
                ? inventory.Add(item.itemID, item.count, out changed) : InvalidParameter;
            if (result == 0) drops.Remove(item.objID);
        }
        log.Write(session, "drop_picked_up", new { result, item.itemID, item.count, item.objID }, true);
        var responses = new List<GameResponse>();
        LocalInventory.AppendChanges(responses, changed);
        // 客户端从拾取回包触发教程事件。
        responses.Add(GameResponse.Of<CSRspPickUpDropItem>((int)ECSMsgCmdID.CS_RSP_PICKUP_DROP_ITEM,
            rsp => { rsp.actorID = actorId; rsp.item = item; rsp.errCode = result; }));
        if (result == 0) responses.Add(HandAttributes(actorId));
        if (result == 0) challenges.Record(responses, "GetItems", item.itemID, item.count);
        return responses;
    }

    private List<GameResponse> FinishDig(CSReqFinishDigBlock request, ulong actorId)
    {
        var target = request.blockIDPos;
        var result = ValidBlock(target) && request.digCount > 0 &&
            request.relatedNum <= request.relatedIDPos.Length && request.relatedNum <= 32 ? 0 : InvalidParameter;
        var key = Key(target.blockPos);
        // 完成包重传只应答，不重复掉落。
        if (result == 0 && blocks.GetValueOrDefault(key, -1) == 0)
            return [DigResponse(0, actorId, target.blockPos, Version(target.blockPos))];
        if (result == 0 && (digging == null || digging.blockID != target.blockID ||
            Key(digging.blockPos) != key || blocks.TryGetValue(key, out var blockId) && blockId != target.blockID))
            result = (int)ECSErrorCode.CS_ERR_DIG_BLOCK_INVALID_PARAM;
        var targets = new List<CSBlockIDPos> { target };
        if (result == 0)
        {
            var seen = new HashSet<(int, int, int)> { key };
            foreach (var related in request.relatedIDPos.Take(request.relatedNum))
            {
                if (!ValidBlock(related)) { result = InvalidParameter; break; }
                if (seen.Add(Key(related.blockPos)) && blocks.GetValueOrDefault(Key(related.blockPos), -1) != 0)
                    targets.Add(related);
            }
        }
        var planned = new List<Drop>();
        if (result == 0)
        {
            foreach (var block in targets)
            {
                var pos = block.blockPos;
                var dropPosition = new CSPosition { x = pos.x * 1000 + 500,
                    y = pos.y * 1000 + 500, z = pos.z * 1000 + 500 };
                if (!TryPlanDrops(Catalog.RollBlockDrops(block.blockID, survival), dropPosition, out var entries) ||
                    planned.Count + entries.Count > 100 || drops.Count + planned.Count + entries.Count > MaximumDrops)
                { result = InvalidParameter; break; }
                planned.AddRange(entries);
            }
        }
        log.Write(session, "block_dug", new { result, target.blockID, gameMode,
            position = new { target.blockPos.x, target.blockPos.y, target.blockPos.z },
            relatedCount = targets.Count - 1, dropCount = result == 0 ? planned.Count : 0,
            dropItems = planned.Where(_ => result == 0).GroupBy(drop => drop.Item.itemID)
                .Select(group => new { itemId = group.Key, count = group.Sum(drop => drop.Item.count) }).ToArray()
        }, true);
        if (result != 0) return [DigResponse(result, actorId, target.blockPos, Version(target.blockPos))];
        digging = null;
        var responses = new List<GameResponse>();
        foreach (var block in targets)
        {
            blocks[Key(block.blockPos)] = 0;
            placements.Remove(Key(block.blockPos));
            responses.Add(DigResponse(0, actorId, block.blockPos, AdvanceVersion(block.blockPos)));
        }
        responses.AddRange(Spawn(planned));
        if (challengesEnabled)
        {
            WearTool(responses, actorId, Math.Clamp(request.digCount, 1, 1000));
            Exhaust(Math.Clamp(request.digCount, 1, 1000) * 0.025, responses, actorId);
        }
        return responses;
    }

    private List<GameResponse> AreaUpdate(CSReqAreaBlockUpdate request, ulong actorId)
    {
        var low = request.leftDownBlockPos;
        var high = request.rightTopBlockPos;
        var dx = (long)high.x - low.x + 1;
        var dy = (long)high.y - low.y + 1;
        var dz = (long)high.z - low.z + 1;
        var valid = ValidBlockPosition(low) && ValidBlockPosition(high) &&
            dx is > 0 and <= 4096 && dy is > 0 and <= 4096 && dz is > 0 and <= 4096 &&
            dx * dy * dz <= 4096 && blocks.Count + dx * dy * dz <= 65536 &&
            (request.blockID == 0 || Catalog.Blocks.ContainsKey(request.blockID)) &&
            request.count <= request.bitMask.Length &&
            (request.count == 0 || request.count * 32 >= dx * dy * dz);
        if (valid)
        {
            var index = 0;
            for (var y = low.y; y <= high.y; y++)
            for (var z = low.z; z <= high.z; z++)
            for (var x = low.x; x <= high.x; x++, index++)
                if (request.count == 0 || (request.bitMask[index / 32] & (1u << (index % 32))) != 0)
                {
                    blocks[(x, y, z)] = request.blockID;
                    placements.Remove((x, y, z));
                }
        }
        log.Write(session, "area_blocks_updated", new { result = valid ? 0 : InvalidParameter,
            low, high, request.blockID }, true);
        if (valid && request.isBroadcast == 0) return [];
        return [GameResponse.Of<CSRspAreaBlockUpdate>((int)ECSMsgCmdID.CS_RSP_AREA_BLOCK_UPDATE, rsp =>
        {
            rsp.result = valid ? 0 : InvalidParameter;
            rsp.accountGID = actorId;
            rsp.leftDownBlockPos = Copy(low);
            rsp.rightTopBlockPos = Copy(high);
            rsp.blockID = request.blockID;
            if (!valid) return;
            rsp.count = request.count;
            Array.Copy(request.bitMask, rsp.bitMask, request.count);
        })];
    }

    private bool TryPlanDrops(IEnumerable<(int Id, int Count)> items, CSPosition position, out List<Drop> plan)
    {
        plan = [];
        foreach (var (id, count) in items)
        {
            if (count <= 0 || count > ushort.MaxValue || !Catalog.Items.TryGetValue(id, out var item)) return false;
            var remaining = count;
            while (remaining > 0)
            {
                if (plan.Count >= 100 || drops.Count + plan.Count >= MaximumDrops) return false;
                var accepted = Math.Min(remaining, item.Stack);
                plan.Add(new(new CSDropItemDesc { itemID = id, count = accepted }, Copy(position)));
                remaining -= accepted;
            }
        }
        return true;
    }

    private List<GameResponse> Spawn(List<Drop> plan)
    {
        if (plan.Count == 0) return [];
        foreach (var drop in plan)
        {
            drop.Item.objID = checked((ulong)Interlocked.Increment(ref nextDropId));
            drops.Add(drop.Item.objID, drop);
        }
        return [GameResponse.Of<CSRspDropItemEnterView>((int)ECSMsgCmdID.CS_RSP_DROP_ITEM_ENTER_VIEW, rsp =>
        {
            rsp.mode = 1;
            rsp.count = checked((ushort)plan.Count);
            for (var i = 0; i < plan.Count; i++)
                rsp.dropItems[i] = new CSDropItemViewInfo { position = plan[i].Position, itemDesc = plan[i].Item };
        })];
    }

    private GameResponse HandAttributes(ulong actorId)
    {
        Catalog.Items.TryGetValue(inventory.GripItemId, out var item);
        return AttributeResponse(actorId,
        [
            new CSAttrPoint { attrType = (ushort)ECSAttrType.CS_ATTR_HARVEST_LEVEL,
                attrValue = attributes.GetValueOrDefault((ushort)ECSAttrType.CS_ATTR_HARVEST_LEVEL, 1) +
                    (item?.HarvestLevel ?? 0) },
            new CSAttrPoint { attrType = (ushort)ECSAttrType.CS_ATTR_EFFICIENCY_PROPER,
                attrValue = attributes.GetValueOrDefault((ushort)ECSAttrType.CS_ATTR_EFFICIENCY_PROPER, 1000) +
                    (item?.Efficiency ?? 0) * 1000 }
        ]);
    }

    private static GameResponse AttributeResponse(ulong actorId, CSAttrPoint[] values) =>
        GameResponse.Of<CSRspActorAttrChange>((int)ECSMsgCmdID.CS_RSP_ACTOR_ATTR_CHANGE, rsp =>
        { rsp.actorID = actorId; rsp.count = checked((ushort)values.Length); Array.Copy(values, rsp.values, values.Length); });

    private uint AdvanceVersion(CSPosition position)
    {
        var tile = Tile(position);
        var version = tileVersions.GetValueOrDefault(tile) + 1;
        tileVersions[tile] = version;
        return version;
    }

    private uint Version(CSPosition position) => tileVersions.GetValueOrDefault(Tile(position));
    private static (int, int, int) Tile(CSPosition p) => (p.x >> 4, p.y >> 4, p.z >> 4);
    private static (int, int, int) Key(CSPosition p) => (p.x, p.y, p.z);
    private static CSPosition Copy(CSPosition p) => new() { x = p.x, y = p.y, z = p.z };
    private static bool ValidBlock(CSBlockIDPos block) => ValidBlockPosition(block.blockPos) &&
        Catalog.Blocks.ContainsKey(block.blockID);
    private static bool ValidBlockPosition(CSPosition p) => p.x is >= -1000000 and <= 1000000 &&
        p.z is >= -1000000 and <= 1000000 && p.y is >= -100000 and <= 100000;
    private static bool ValidMetricPosition(CSPosition p) => p.x is >= -1000000000 and <= 1000000000 &&
        p.z is >= -1000000000 and <= 1000000000 && p.y is >= -100000000 and <= 100000000;

    private static GameResponse DigResponse(int result, ulong actorId, CSPosition position, uint version) =>
        GameResponse.Of<CSRspFinishDigBlock>((int)ECSMsgCmdID.CS_RSP_FINISH_DIG_BLOCK, rsp =>
        { rsp.result = result; rsp.playerID = actorId; rsp.blockPos = Copy(position); rsp.tileVersion = version; });

    private static GameResponse Error(string message) => GameResponse.Of<CSRspShowErrorMsg>(64, rsp =>
    { rsp.errNo = InvalidParameter; rsp.errMsg = LocalAccount.TextBytes(message, 64); });
}

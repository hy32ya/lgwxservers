using cs_msg;
using LocalGameServer.Storage;

namespace LocalGameServer.Protocol;

// 当前房间的背包；变更成功后统一推送。
public sealed class LocalInventory
{
    public const ushort BagCapacity = 32;
    public const ushort QuickbarCapacity = 7;
    private readonly record struct Slot(byte Container, ushort Index);
    private sealed record Stack(int Id, int Count, int Durability);
    private Dictionary<Slot, Stack> slots = new();
    private ushort gripIndex;
    private static LocalWorldCatalog Catalog => LocalWorldCatalog.Current;
    public int GripItemId => slots.GetValueOrDefault(new(2, gripIndex))?.Id ?? 0;

    public void Save(WorldSave save)
    {
        save.GripIndex = gripIndex;
        save.Inventory = slots.Select(p => new SavedSlot(p.Key.Container, p.Key.Index,
            p.Value.Id, p.Value.Count, p.Value.Durability)).ToList();
    }

    public void Restore(WorldSave save)
    {
        var restored = new Dictionary<Slot, Stack>();
        foreach (var entry in save.Inventory)
        {
            var slot = new Slot(entry.Container, entry.Index);
            if (!Valid(slot) || !Catalog.Items.TryGetValue(entry.ItemId, out var item) ||
                entry.Count <= 0 || entry.Count > item.Stack || entry.Durability < 0 ||
                entry.Durability > item.Durability || !restored.TryAdd(slot,
                    new(entry.ItemId, entry.Count, entry.Durability)))
                throw new InvalidDataException("背包存档无效，原文件已保留。");
        }
        slots = restored;
        gripIndex = save.GripIndex < QuickbarCapacity ? save.GripIndex : ushort.MaxValue;
    }

    public CSItemData[] WearHeld(int times, out int destroyed)
    {
        destroyed = 0;
        var slot = new Slot(2, gripIndex);
        if (times <= 0 || !slots.TryGetValue(slot, out var stack) || stack.Durability <= 0 ||
            !Catalog.Items.TryGetValue(stack.Id, out var item) || item.WearPerUse <= 0) return [];
        var remaining = Math.Max(0, stack.Durability - (long)item.WearPerUse * times);
        var next = new Dictionary<Slot, Stack>(slots);
        if (remaining == 0) { next.Remove(slot); destroyed = stack.Id; }
        else next[slot] = stack with { Durability = (int)remaining };
        return Commit(next);
    }

    public int Add(int itemId, int count, out CSItemData[] changed)
        => AddMany([(itemId, count)], out changed);

    public int AddMany(IEnumerable<(int ItemId, int Count)> items, out CSItemData[] changed)
    {
        changed = [];
        var next = new Dictionary<Slot, Stack>(slots);
        foreach (var (itemId, count) in items)
        {
            var result = PlanAdd(next, itemId, count);
            if (result != 0) return result;
        }
        changed = Commit(next);
        return 0;
    }

    private static int PlanAdd(Dictionary<Slot, Stack> next, int itemId, int count)
    {
        if (count <= 0 || count > ushort.MaxValue || !Catalog.Items.TryGetValue(itemId, out var item))
            return (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        var remaining = count;
        var keys = AllSlots().ToArray();
        foreach (var key in keys)
        {
            if (!next.TryGetValue(key, out var stack) || stack.Id != itemId) continue;
            var accepted = Math.Min(remaining, item.Stack - stack.Count);
            if (accepted <= 0) continue;
            next[key] = stack with { Count = stack.Count + accepted };
            remaining -= accepted;
            if (remaining == 0) break;
        }
        foreach (var key in keys)
        {
            if (remaining == 0) break;
            if (next.ContainsKey(key)) continue;
            var accepted = Math.Min(remaining, item.Stack);
            next[key] = new(itemId, accepted, item.Durability);
            remaining -= accepted;
        }
        if (remaining != 0) return (int)ECSErrorCode.CS_ERR_BAG_ITEM_FULL;
        return 0;
    }

    public int Craft(LocalWorldCatalog.CraftingRecipeDefinition recipe, CSMakeItemDesc materials,
        int repetitions, out CSItemData[] changed)
    {
        changed = [];
        if (repetitions is <= 0 or > 1000 || recipe.TargetCount <= 0 ||
            (long)recipe.TargetCount * repetitions > ushort.MaxValue ||
            !Catalog.Items.ContainsKey(recipe.TargetId) || recipe.Sources.Length is < 1 or > 4 ||
            materials.srcCount != recipe.Sources.Length || materials.srcCount > materials.srcItems.Length)
            return (int)ECSErrorCode.CS_ERR_MAKE_INVALID_PARAM;

        for (var i = 0; i < recipe.Sources.Length; i++)
        {
            var source = recipe.Sources[i];
            var group = materials.srcItems[i];
            var isTag = source.ItemId == 0;
            if (source.Count <= 0 || (long)source.Count * repetitions > int.MaxValue ||
                isTag && source.Tag <= 0 || group.isTag != (isTag ? 1 : 0) ||
                group.itemCnt is <= 0 or > 16 || group.itemCnt > group.Items.Length)
                return (int)ECSErrorCode.CS_ERR_RECIPE_MATERIAL_MISMATCH;
            long total = 0;
            var seen = new HashSet<int>();
            foreach (var item in group.Items.Take(group.itemCnt))
            {
                if (item.count <= 0 || !seen.Add(item.itemID) ||
                    !Matches(source, item.itemID))
                    return (int)ECSErrorCode.CS_ERR_RECIPE_MATERIAL_MISMATCH;
                total += item.count;
            }
            // 请求中的材料数量对应单次制作。
            if (total != source.Count) return (int)ECSErrorCode.CS_ERR_RECIPE_MATERIAL_MISMATCH;
        }

        var next = new Dictionary<Slot, Stack>(slots);
        // 先预留指定材料，再取同标签材料。
        foreach (var i in Enumerable.Range(0, recipe.Sources.Length)
                     .OrderBy(i => recipe.Sources[i].ItemId == 0))
        {
            var source = recipe.Sources[i];
            var remaining = source.Count * repetitions;
            var group = materials.srcItems[i];
            var candidates = group.Items.Take(group.itemCnt).Select(item => item.itemID)
                .Concat(next.Values.Select(stack => stack.Id).Where(id => Matches(source, id)).Order())
                .Distinct().ToArray();
            foreach (var itemId in candidates)
            {
                foreach (var slot in AllSlots())
                {
                    if (!next.TryGetValue(slot, out var stack) || stack.Id != itemId) continue;
                    var consumed = Math.Min(remaining, stack.Count);
                    if (consumed == stack.Count) next.Remove(slot);
                    else next[slot] = stack with { Count = stack.Count - consumed };
                    remaining -= consumed;
                    if (remaining == 0) break;
                }
                if (remaining == 0) break;
            }
            if (remaining != 0) return (int)ECSErrorCode.CS_ERR_RECIPE_MATERIAL_NOT_ENOUGH;
        }
        var result = PlanAdd(next, recipe.TargetId, recipe.TargetCount * repetitions);
        // 材料和成品一起提交，失败不扣物品。
        if (result == 0) changed = Commit(next);
        return result;
    }

    private static bool Matches(LocalWorldCatalog.CraftingSource source, int itemId) =>
        Catalog.Items.TryGetValue(itemId, out var item) &&
        (source.ItemId != 0 ? source.ItemId == itemId : item.Tags.Contains(source.Tag));

    public CSItemData[] Clear()
    {
        gripIndex = 0;
        return Commit(new());
    }

    public int Drag(CSReqDragItem request, out CSItemData[] changed)
    {
        changed = [];
        var source = request.srcItem;
        var destination = request.dstItem;
        var src = new Slot(source.container, source.index);
        var dst = new Slot(destination.container, destination.index);
        if (!Valid(src) || !Valid(dst) || source.count <= 0 ||
            !slots.TryGetValue(src, out var sourceStack) || sourceStack.Id != source.resID || source.count > sourceStack.Count)
            return (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        var to = slots.GetValueOrDefault(dst);
        if ((to?.Id ?? 0) != destination.resID) return (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        if (src == dst) return 0;
        var next = new Dictionary<Slot, Stack>(slots);
        if (to == null || to.Id == sourceStack.Id && Catalog.Items[sourceStack.Id].Type == 2)
        {
            var moved = Math.Min(source.count, Catalog.Items[sourceStack.Id].Stack - (to?.Count ?? 0));
            if (moved <= 0) return (int)ECSErrorCode.CS_ERR_BAG_ITEM_FULL;
            next[dst] = sourceStack with { Count = (to?.Count ?? 0) + moved };
            if (moved == sourceStack.Count) next.Remove(src);
            else next[src] = sourceStack with { Count = sourceStack.Count - moved };
        }
        else
        {
            if (source.count != sourceStack.Count) return (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
            next[src] = to;
            next[dst] = sourceStack;
        }
        changed = Commit(next);
        return 0;
    }

    public int Grip(CSGripItem item)
    {
        if (item.resID == 0)
        {
            gripIndex = ushort.MaxValue;
            return 0;
        }
        if (item.index >= QuickbarCapacity || slots.GetValueOrDefault(new(2, item.index))?.Id != item.resID)
            return (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        gripIndex = item.index;
        return 0;
    }

    public int ConsumeHeld(int itemId, out CSItemData[] changed)
        => Consume(new CSItem { container = 2, index = gripIndex, resID = itemId }, out changed);

    public int Consume(CSItem item, out CSItemData[] changed)
    {
        changed = [];
        var slot = new Slot(item.container, item.index);
        if (!Valid(slot) || !slots.TryGetValue(slot, out var stack) || stack.Id != item.resID || stack.Count <= 0)
            return (int)ECSErrorCode.CS_ERR_BAG_ITEM_NOT_ENOUGH;
        var next = new Dictionary<Slot, Stack>(slots);
        if (stack.Count == 1) next.Remove(slot);
        else next[slot] = stack with { Count = stack.Count - 1 };
        changed = Commit(next);
        return 0;
    }

    public CSBagItemInfo Snapshot()
    {
        var result = new CSBagItemInfo();
        result.bag.capacity = BagCapacity;
        result.shortcut.capacity = QuickbarCapacity;
        foreach (var pair in slots.OrderBy(pair => pair.Key.Container).ThenBy(pair => pair.Key.Index))
        {
            var data = ToWire(pair.Key, pair.Value);
            if (pair.Key.Container == 1) result.bag.data[result.bag.count++] = data;
            else result.shortcut.data[result.shortcut.count++] = data;
        }
        result.gripIndex.resID = GripItemId;
        result.gripIndex.index = gripIndex;
        return result;
    }

    public static void AppendChanges(List<GameResponse> responses, CSItemData[] changed)
    {
        if (changed.Length == 0) return;
        responses.Add(GameResponse.Of<CSRspBagChange>((int)ECSMsgCmdID.CS_RSP_BAG_CHANGE, rsp =>
        {
            rsp.count = changed.Length;
            Array.Copy(changed, rsp.data, changed.Length);
        }));
    }

    public static object Describe(CSItemData[] changed) => changed.Select(item => new
    {
        item.container, item.index,
        itemId = item.type == 1 ? item.data.equip.resID : item.type == 2 ? item.data.prop.resID : 0,
        count = item.type == 1 ? 1 : item.type == 2 ? item.data.prop.count : 0
    }).ToArray();

    private CSItemData[] Commit(Dictionary<Slot, Stack> next)
    {
        var changed = slots.Keys.Union(next.Keys).OrderBy(key => key.Container).ThenBy(key => key.Index)
            .Where(key => slots.GetValueOrDefault(key) != next.GetValueOrDefault(key))
            .Select(key => ToWire(key, next.GetValueOrDefault(key))).ToArray();
        slots = next;
        return changed;
    }

    private static CSItemData ToWire(Slot slot, Stack? stack)
    {
        var result = new CSItemData { container = slot.Container, index = slot.Index };
        if (stack == null) return result;
        result.type = Catalog.Items[stack.Id].Type;
        if (result.data.select(result.type) is CSEquipItem equip)
        {
            equip.resID = stack.Id;
            equip.durability = stack.Durability;
        }
        else if (result.data.select(result.type) is CSPropItem prop)
        {
            prop.resID = stack.Id;
            prop.count = checked((ushort)stack.Count);
        }
        return result;
    }

    private static bool Valid(Slot slot) => slot.Container switch
    {
        1 => slot.Index < BagCapacity,
        2 => slot.Index < QuickbarCapacity,
        _ => false
    };

    private static IEnumerable<Slot> AllSlots()
    {
        for (ushort i = 0; i < QuickbarCapacity; i++) yield return new(2, i);
        for (ushort i = 0; i < BagCapacity; i++) yield return new(1, i);
    }
}

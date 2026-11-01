using cs_msg;
using LocalGameServer.Storage;

namespace LocalGameServer.Protocol;

// 单人房间的触发器及运行状态。
public sealed class LocalWorldSession(ServerLog log, string session, ushort gameMode, ulong workId)
{
    private readonly LocalWorldItems items = new(log, session, gameMode,
        gameMode == (ushort)ECSGameMode.CS_ARCADE_SURVIVAL_NORMAL && workId != 6586798813005807620UL);
    private bool relayedFirstFrame;
    private uint worldTime = 8 * 60 * 60;
    private CSPosition position = new();
    private CSAngle angle = new();
    private int actionType;
    private readonly Dictionary<int, byte> playerStates = new();
    private CSPosition? rebirthPosition;
    private bool hasPosition;
    public uint ArchiveProgress { get; set; }
    public uint WorldTime => worldTime;
    public CSPosition EntryPosition(CSPosition fallback) => hasPosition ? position : fallback;
    public CSPosition SpawnPosition(CSPosition fallback) => rebirthPosition ?? fallback;
    public CSPlayerAttrPoints PlayerAttributes(LocalAccount account) => items.PlayerAttributes(account);
    public List<GameResponse> Advance(ulong actorId) => items.Advance(actorId, playerStates);

    public void Enter(CSPosition fallback)
    {
        if (!hasPosition) position = fallback;
        rebirthPosition ??= fallback;
        hasPosition = true;
        items.StartClock();
    }

    public WorldSave Save(ulong gid)
    {
        var save = new WorldSave { WorkId = workId, Gid = gid, Mode = gameMode,
            SavedAt = DateTimeOffset.UtcNow, WorldTime = worldTime, ArchiveProgress = ArchiveProgress,
            Position = hasPosition ? new(position.x, position.y, position.z) : null,
            RebirthPosition = rebirthPosition is { } p ? new(p.x, p.y, p.z) : null };
        items.Save(save);
        return save;
    }

    public void Restore(WorldSave save)
    {
        if (save.FormatVersion != 1 || save.WorkId != workId || save.Mode != gameMode)
            throw new InvalidDataException("世界存档版本或编号无效。");
        items.Restore(save);
        worldTime = save.WorldTime % 86400;
        ArchiveProgress = save.ArchiveProgress;
        if (save.Position is { } p)
        { position = new() { x = p.X, y = p.Y, z = p.Z }; hasPosition = true; }
        if (save.RebirthPosition is { } spawn)
            rebirthPosition = new() { x = spawn.X, y = spawn.Y, z = spawn.Z };
    }

    public CSBagItemInfo InventorySnapshot() => items.InventorySnapshot();
    public List<GameResponse> InitialResponses(ulong actorId) =>
        [.. items.InitialChallenges(), .. items.InitialSurvival(actorId)];

    public List<GameResponse>? Handle(GameRequest request, LocalAccount account, ulong roomId, bool entered)
    {
        var challengeResponses = items.HandleChallenges(request, account.Gid);
        if (challengeResponses != null) return challengeResponses;

        // 加载阶段也会查询载具和上报动作。
        if (!entered && request.Body is not (CSReqDiyVehicleBagInGame or CSReqActorAction)) return null;
        var itemResponses = entered ? items.Handle(request, account, roomId) : null;
        if (itemResponses != null) return itemResponses;
        switch (request.Body)
        {
            case CSReqPlayerRebirth rebirth:
                var revived = items.Rebirth(rebirth, account.Gid, rebirthPosition ?? position);
                if (revived[0].Union.select(revived[0].Command) is CSRspPlayerRebirth { result: 0 })
                { position = rebirthPosition ?? position; playerStates.Clear(); }
                return revived;
            case CSReqTriggerFrameSync trigger:
                var frame = trigger.frameSync;
                if (frame.senderActorID != account.Gid || frame.eventContextCount > frame.eventContexts.Length)
                    return [Invalid("触发器发送者或数量无效")];
                // 非本地执行的触发器须经服务端回传。
                log.Write(session, "trigger_frame_relay", new
                {
                    roomId, frame.senderActorID, frame.frameCount, frame.eventContextCount,
                    triggers = frame.eventContexts.Take(frame.eventContextCount)
                        .Select(item => new { item.groupIndex, item.triggerIndex, item.instanceIDHash }).ToArray()
                }, !relayedFirstFrame);
                relayedFirstFrame = true;
                return [GameResponse.Of<CSRspTriggerFrameSync>((int)ECSMsgCmdID.CS_RSP_TRIGGER_FRAME_SYNC,
                    rsp => rsp.frameSync = frame)];
            case CSReqNpcTaskInfo:
                return [GameResponse.Of<CSRspNpcTaskInfo>((int)ECSMsgCmdID.CS_RSP_NPC_TASK_INFO,
                    rsp => rsp.result = 0)];
            case CSReqWorldTime time:
                return [GameResponse.Of<CSRspWorldTime>((int)ECSMsgCmdID.CS_RSP_WORLD_TIME, rsp =>
                {
                    rsp.errCode = 0;
                    rsp.worldID = time.worldId;
                    rsp.worldType = time.worldType;
                    rsp.worldTime = worldTime;
                })];
            case CSReqTriggerUpdateWorldTime time:
                var timeResult = time.roomGID == roomId && time.hour is >= 0 and < 24 &&
                    time.min is >= 0 and < 60 && time.sec is >= 0 and < 60
                    ? 0 : (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                if (timeResult == 0) worldTime = (uint)(time.hour * 3600 + time.min * 60 + time.sec);
                return [GameResponse.Of<CSRspTriggerUpdateWorldTime>(
                    (int)ECSMsgCmdID.CS_RSP_TRIGGER_UPDATE_WORLD_TIME, rsp => rsp.result = timeResult)];
            case CSReqActorMove move when move.actorID == account.Gid:
                position = move.moveInfo.currPos;
                angle = move.moveInfo.angle;
                return [];
            case CSReqActorStop stop when stop.actorID == account.Gid:
                position = stop.stopInfo.currPos;
                angle = stop.stopInfo.angle;
                return [];
            case CSReqActorAction action when action.actorID == account.Gid:
                actionType = action.actionType;
                return [];
            case CSReqPlayerStateUpdate state:
                playerStates[state.stateType] = state.stateValue;
                return [];
            case CSReqJumpBegin jump:
                position = jump.currPos;
                return [];
            case CSReqJumpFinish jump:
                position = jump.currPos;
                return [];
            case CSReqNotifyOpenVoice voice:
                return [GameResponse.Of<CSRspNotifyOpenVoice>((int)ECSMsgCmdID.CS_RSP_NOTIFY_OPEN_VOICE,
                    rsp => { rsp.accountGID = account.Gid; rsp.isOpen = voice.isOpen; })];
            case CSReqGetCellVersion cells:
                return [GameResponse.Of<CSRspGetCellVersion>((int)ECSMsgCmdID.CS_RSP_GET_CELL_VERSION, rsp =>
                {
                    rsp.result = cells.count >= 0 && cells.count <= cells.cellList.Length &&
                        cells.count <= rsp.cellList.Length ? 0 : (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                    if (rsp.result != 0) return;
                    // 本地地图暂无服务端差异。
                    rsp.count = cells.count;
                    for (var i = 0; i < cells.count; i++)
                    {
                        rsp.cellList[i].cellPos = cells.cellList[i];
                        rsp.cellList[i].status = 0;
                        rsp.cellList[i].count = 0;
                    }
                })];
            case CSReqDiyVehicleBagInGame:
                return [GameResponse.Of<CSRspDiyVehicleBagInGame>((int)ECSMsgCmdID.CS_RSP_DIY_VEHICLE_BAG_IN_GAME,
                    rsp => { rsp.result = 0; rsp.count = 0; })];
            case CSReqGetLegoSetShowcase:
                return [GameResponse.Of<CSRspGetLegoSetShowcase>((int)ECSMsgCmdID.CS_RSP_GET_LEGOSET_SHOWCASE,
                    rsp => { rsp.result = 0; rsp.count = 0; })];
            default:
                return null;
        }
    }

    private static GameResponse Invalid(string message) => GameResponse.Of<CSRspShowErrorMsg>(64, rsp =>
    {
        rsp.errNo = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        rsp.errMsg = LocalAccount.TextBytes(message, 64);
    });
}

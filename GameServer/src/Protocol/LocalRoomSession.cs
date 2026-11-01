using cs_msg;
using LocalGameServer.Storage;
using LocalGameServer.Transport;

namespace LocalGameServer.Protocol;

// 每条连接维护自己的本地房间。
public sealed class LocalRoomSession(ServerSettings settings, ServerLog log, string session)
{
    // 房主拥有客户端定义的七项权限。
    private const ushort OwnerAuthContent = 0x007F;
    private const byte OwnerRoomIndex = 1;
    private static long nextRoomId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    private LocalRoom? room;
    private readonly WorldSaveStore saves = new(settings.DataDirectory);
    public List<GameResponse> PendingResponses { get; private set; } = [];

    private sealed class LocalRoom
    {
        public ulong Id;
        public ushort Mode;
        public ulong WorkId;
        public uint Version;
        public byte WorkTag;
        public byte IsPublic;
        public byte MaxPlayers;
        public byte Difficulty;
        public ushort JoinAuthId;
        public byte[] Name = [];
        public byte[] Description = [];
        public byte[] Password = [];
        public byte[] WorkName = [];
        public bool Started;
        public bool Entered;
        public uint Seed;
        public ulong OwnerGid;
        public bool HasSave;
        public long LastSave;
        public Dictionary<int, CSUgcResData[]> ResourceTables = new();
        public required LocalWorldSession World;
        public uint ShortId => (uint)(Id % 900000 + 100000);
    }

    private void Reset() => room = null;

    public async Task CloseAsync(CancellationToken ct)
    {
        if (room is { } current) await SaveAsync(current, ct);
        Reset();
    }

    private async Task SaveAsync(LocalRoom current, CancellationToken ct)
    {
        if (!current.Started || !current.Entered && !current.HasSave || current.Mode is not (302 or 303) ||
            current.WorkId == 6586798813005807620UL) return;
        await saves.SaveAsync(current.World.Save(current.OwnerGid), ct);
        current.LastSave = Environment.TickCount64;
        current.HasSave = true;
    }

    public async Task<List<GameResponse>?> HandleAsync(GameRequest request, LocalAccount account, CancellationToken ct)
    {
        var oldRoom = room;
        var elapsed = room?.Entered == true ? room.World.Advance(account.Gid) : [];
        if (request.Body is CSReqLeaveRoom or CSReqExitMultiGame && room != null)
            await SaveAsync(room, ct);
        var responses = Handle(request, account);
        if (request.Body is CSReqCreateRoom && room != null && room != oldRoom)
        {
            if (room.Mode is 302 or 303 && room.WorkId != 6586798813005807620UL)
            {
                var save = await saves.LoadAsync(room.WorkId, account.Gid, ct);
                if (save != null)
                {
                    if (save.Gid != account.Gid) throw new InvalidDataException("存档玩家不匹配。");
                    room.World.Restore(save); room.HasSave = true;
                    log.Write(session, "world_save_loaded", new { room.WorkId, account.Gid, save.SavedAt }, true);
                }
            }
        }
        if (room?.Entered == true && (Environment.TickCount64 - room.LastSave >= 5000 ||
            request.Body is CSReqMakeItems or CSReqPutBlock or CSReqFinishDigBlock or CSReqPickUpDropItem or
                CSReqDragItem or CSReqUseItems or CSReqChallengeAward or CSReqUgcGiveItem or
                CSReqTriggerDestroyAllItems or CSReqPlayerRebirth or CSReqUpdateArchiveProgress or
                CSReqSkillAttack or CSReqDamageEvent or CSReqUgcChangeActorAttr))
            await SaveAsync(room, ct);
        PendingResponses = responses == null ? elapsed : [];
        if (responses == null) return null;
        if (responses != null) elapsed.AddRange(responses);
        return elapsed;
    }

    public List<GameResponse>? Handle(GameRequest request, LocalAccount account)
    {
        switch (request.Body)
        {
            case CSReqCreateRoom create:
                return [CreateRoom(create, account)];
            case CSReqStartGame start:
                return [StartGame(start)];
            case CSReqLeaveRoom:
                var oldId = room?.Id ?? 0;
                Reset();
                log.Write(session, "leave_room", new { roomId = oldId }, true);
                return [GameResponse.Of<CSRspLeaveRoom>((int)ECSMsgCmdID.CS_RSP_LEAVE_ROOM,
                    rsp => { rsp.result = 0; rsp.roomGID = oldId; })];
            case CSReqLoadingProgress loading:
                if (room == null || loading.roomGID != room.Id || loading.gameMode != room.Mode)
                    return [];
                return [GameResponse.Of<CSRspLoadingProgress>((int)ECSMsgCmdID.CS_RSP_LOADING_PROGRESS, rsp =>
                {
                    rsp.roomGID = room.Id;
                    rsp.accountKey.accountGID = account.Gid;
                    rsp.accountKey.deviceType = (byte)ECSDeviceType.CS_ANDROID_DEVICE_TYPE;
                    rsp.progress = (byte)Math.Min((int)loading.progress, 100);
                })];
            case CSReqPreEnterWorld pre:
                if (room == null || !room.Started) return null;
                return [GameResponse.Of<CSRspPreEnterWorld>((int)ECSMsgCmdID.CS_RSP_PRE_ENTER_WORLD, rsp =>
                {
                    rsp.worldID = pre.worldId;
                    rsp.worldType = pre.worldType;
                    rsp.seed = room.Seed;
                })];
            case CSReqEnterWorld enter:
                var entry = EnterWorld(enter, account);
                var entered = new List<GameResponse> { entry };
                if (entry.Union.select(entry.Command) is CSRspEnterWorld { result: 0 })
                    entered.AddRange(room!.World.InitialResponses(account.Gid));
                return entered;
            case CSReqMultiGameReady:
                return [GameResponse.Of<CSRspMultiGameReady>((int)ECSMsgCmdID.CS_RSP_MULTIGAME_READY,
                    rsp => rsp.result = room?.Entered == true ? 0 : (int)ECSErrorCode.CS_ERR_PLAYER_NOT_IN_ROOM)];
            case CSReqExitMultiGame exit:
                if (room != null) room.Entered = false;
                return [GameResponse.Of<CSRspExitMultiGame>((int)ECSMsgCmdID.CS_RSP_EXIT_MULTIGAME,
                    rsp => { rsp.result = 0; rsp.callBack = exit.callBack; })];
            case CSReqSetUgcData tables:
                var tableResult = (int)ECSErrorCode.CS_ERR_PLAYER_NOT_IN_ROOM;
                if (room != null)
                {
                    room.ResourceTables[tables.type] = tables.allUgcData.Take(tables.count).ToArray();
                    tableResult = 0;
                }
                return [GameResponse.Of<CSRspSetUgcData>((int)ECSMsgCmdID.CS_RSP_UGC_SET_EDIT_DATA,
                    rsp => { rsp.result = tableResult; rsp.type = tables.type; })];
            case CSReqUpdateArchiveProgress progress when room != null && progress.workID == room.WorkId:
                room.World.ArchiveProgress = progress.progress;
                return [GameResponse.Of<CSRspUpdateArchiveProgress>((int)ECSMsgCmdID.CS_RSP_UPDATE_ARCHIVE_PROGRESS,
                    rsp => { rsp.workID = progress.workID; rsp.progress = progress.progress; })];
            case CSReqGetRoomLst:
                return [GameResponse.Of<CSRspGetRoomLst>((int)ECSMsgCmdID.CS_RSP_GET_ROOM_LST,
                    rsp => { rsp.result = 0; rsp.count = 0; })];
            case CSReqGetRoomDescInfo desc:
                return [GameResponse.Of<CSRspGetRoomDescInfo>((int)ECSMsgCmdID.CS_RSP_GET_ROOM_DESC_INFO, rsp =>
                {
                    rsp.result = room != null && desc.roomGID == room.Id && desc.gameMode == room.Mode
                        ? 0 : (int)ECSErrorCode.CS_ERR_PLAYER_NOT_IN_ROOM;
                    if (rsp.result != 0) return;
                    rsp.descInfo.roomGID = room!.Id;
                    rsp.descInfo.mapFileName = Text(room.WorkName, 32);
                    rsp.descInfo.maxPlayerCount = room.MaxPlayers;
                    rsp.descInfo.author = LocalAccount.TextBytes(account.RoleName ?? "本地玩家", 32);
                    rsp.descInfo.roomDesc = Text(room.Description, 423);
                })];
            default:
                return room?.World.Handle(request, account, room.Id, room.Entered);
        }
    }

    private GameResponse CreateRoom(CSReqCreateRoom request, LocalAccount account)
    {
        var result = !account.HasRole ? (int)ECSErrorCode.CS_ERR_NEED_CREATE_ROLE :
            room != null ? (int)ECSErrorCode.CS_ERR_CREATE_UGC_ROOM_PLAYER_IS_ALREADY_IN_ROOM : 0;
        var detail = request.roomConfigDetail.select(request.gameMode);
        var workId = detail switch
        {
            CSSurvivalRoomConfigDetail survivalConfig => survivalConfig.workID,
            CSUgcRoomConfigDetail ugcConfig => ugcConfig.config.baseConfig.workBaseInfo.workID,
            _ => 0UL
        };
        var created = new LocalRoom { Mode = request.gameMode, OwnerGid = account.Gid,
            World = new(log, session, request.gameMode, workId) };
        if (result == 0)
        {
            switch (detail)
            {
                case CSSurvivalRoomConfigDetail survival:
                    created.WorkId = survival.workID;
                    created.WorkTag = (byte)ECSWorkTag.CS_WORK_TAG_SURVIVAL;
                    created.IsPublic = survival.isPublic;
                    created.MaxPlayers = survival.maxPlayerNum;
                    created.Difficulty = survival.difficultyLevel;
                    created.JoinAuthId = survival.joinAuthID;
                    created.Name = Text(survival.roomName, 32);
                    created.WorkName = Text(survival.workName, 32);
                    created.Description = Text(survival.roomDesc, 423);
                    created.Password = Text(survival.password, 8);
                    break;
                case CSUgcRoomConfigDetail ugc:
                    var config = ugc.config.baseConfig;
                    created.WorkId = config.workBaseInfo.workID;
                    created.Version = config.workBaseInfo.version;
                    created.WorkTag = config.workBaseInfo.workTag;
                    created.IsPublic = ugc.isPublic;
                    created.MaxPlayers = config.maxPlayerNum;
                    created.Name = Text(config.roomName, 32);
                    created.WorkName = Text(config.workBaseInfo.workName, 32);
                    created.Description = Text(config.roomDesc, 423);
                    created.Password = Text(config.password, 8);
                    break;
                default:
                    result = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                    break;
            }
            if (result == 0 && (created.WorkId == 0 || created.MaxPlayers is < 1 or > 20))
                result = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
            if (result == 0)
            {
                created.Id = checked((ulong)Interlocked.Increment(ref nextRoomId));
                created.Seed = (uint)(created.WorkId ^ (created.WorkId >> 32));
                room = created;
            }
        }
        log.Write(session, "create_room", new { result, request.gameMode,
            roomId = result == 0 ? created.Id : 0, workId = created.WorkId,
            joinAuthId = created.JoinAuthId, ownerAuthContent = result == 0 ? OwnerAuthContent : 0,
            ownerRoomIndex = result == 0 ? OwnerRoomIndex : 0 }, true);
        return GameResponse.Of<CSRspCreateRoom>((int)ECSMsgCmdID.CS_RSP_CREATE_ROOM, rsp =>
        {
            rsp.result = result;
            rsp.gameMode = request.gameMode;
            if (result != 0) return;
            rsp.workID = created.WorkId;
            rsp.isPublic = created.IsPublic;
            rsp.version = created.Version;
            rsp.roomGID = created.Id;
            rsp.roomShortID = created.ShortId;
            rsp.maxPlayerNum = created.MaxPlayers;
            rsp.roomName = created.Name;
            rsp.description = created.Description;
            rsp.password = created.Password;
            rsp.difficultyLevel = created.Difficulty;
            rsp.workTag = created.WorkTag;
            rsp.playerCount = 1;
            rsp.playerInfo[0] = new CSRoomPlayer
            {
                accGID = account.Gid, objID = account.Gid,
                devType = (byte)ECSDeviceType.CS_ANDROID_DEVICE_TYPE,
                roleName = LocalAccount.TextBytes(account.RoleName!, 32),
                teamIdx = 0, memberIdx = 0, ugcRoomIndex = OwnerRoomIndex,
                downloadStatus = 100, gender = (byte)account.Style.gender,
                level = account.Level, authContent = OwnerAuthContent
            };
        });
    }

    private GameResponse StartGame(CSReqStartGame request)
    {
        var result = room == null ? (int)ECSErrorCode.CS_ERR_PLAYER_NOT_IN_ROOM :
            room.Mode != request.gameMode ? (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM : 0;
        if (result == 0) room!.Started = true;
        log.Write(session, "start_game", new { result, request.gameMode, roomId = room?.Id }, true);
        return GameResponse.Of<CSRspStartGame>((int)ECSMsgCmdID.CS_RSP_START_GAME, rsp =>
        {
            rsp.result = result;
            rsp.gameMode = request.gameMode;
            rsp.roomGID = room?.Id ?? 0;
            rsp.isOldWorldRole = room?.HasSave == true ? (byte)1 : (byte)0;
        });
    }

    private GameResponse EnterWorld(CSReqEnterWorld request, LocalAccount account)
    {
        var result = room?.Started != true ? (int)ECSErrorCode.CS_ERR_PLAYER_NOT_IN_ROOM :
            room.Mode != request.gameMode ? (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM : 0;
        if (result == 0)
        {
            room!.Entered = true;
            room.World.Enter(request.pos);
        }
        log.Write(session, "enter_world", new { result, request.gameMode, workId = room?.WorkId,
            account.Gid, joinAuthId = room?.JoinAuthId,
            ownerAuthContent = result == 0 ? OwnerAuthContent : 0,
            ownerRoomIndex = result == 0 ? OwnerRoomIndex : 0 }, true);
        return GameResponse.Of<CSRspEnterWorld>((int)ECSMsgCmdID.CS_RSP_ENTER_WORLD, rsp =>
        {
            rsp.result = result;
            rsp.gameMode = request.gameMode;
            if (result != 0) return;
            rsp.gameData.worldID = room!.WorkId;
            rsp.gameData.worldType = 1;
            rsp.gameData.pos = room.World.EntryPosition(request.pos);
            rsp.gameData.rebirthPos = room.World.SpawnPosition(request.pos);
            rsp.gameData.authContent = OwnerAuthContent;
            rsp.gameData.teamInfo.teamID = room.Id;
            rsp.gameData.bagInfo = room.World.InventorySnapshot();
            rsp.gameData.attrPoints = room.World.PlayerAttributes(account);
            rsp.worldData.worldTime = room.World.WorldTime;
        });
    }

    private static byte[] Text(byte[] value, int capacity) =>
        LocalAccount.TextBytes(WireReader.CString(value), capacity);
}

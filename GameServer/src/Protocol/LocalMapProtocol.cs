using cs_msg;
using LocalGameServer.Storage;
using LocalGameServer.Transport;

namespace LocalGameServer.Protocol;

public sealed class LocalMapProtocol(LocalMapStorage maps, AccountStore store, ServerLog log, string session)
{
    private const int Invalid = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
    private const int Missing = (int)ECSErrorCode.CS_ERR_WORK_NOT_EXIST;
    private readonly Dictionary<long, ulong> cellWorks = new();
    private readonly HashSet<long> signedCells = new();
    private readonly Dictionary<long, bool> activeCells = new();
    private ulong uploadWork;

    public async Task<GameResponse> OwnedWorksResponseAsync(LocalAccount account, CancellationToken ct)
    {
        var works = (await store.GetWorksAsync(account.Gid, ct))
            .Where(w => w is { UploadedAt: > 0, WorkType: 1, GameMode: 302 or 303 } && maps.HasMainFile(w.Id))
            .OrderByDescending(w => w.UploadedAt).ThenByDescending(w => w.Id).Take(200).ToArray();
        log.Write(session, "work_list_sent", new
        { account.Gid, survivalCount = works.Length, workIds = works.Select(w => w.Id).ToArray() }, true);
        // 28 也触发客户端原生资源初始化，空列表仍需发送。
        return GameResponse.Of<CSRspGetAllMyWorkList>((int)ECSMsgCmdID.CS_RSP_GET_ALL_MY_WORK_LIST, rsp =>
        {
            rsp.ugc.num = 0; rsp.download.num = 0;
            rsp.survival.num = (ushort)works.Length;
            for (var i = 0; i < works.Length; i++)
                rsp.survival.workIDList[i] = new CSWorkSimplyDesc
                { workID = works[i].Id, lastPlayTime = works[i].UploadedAt };
        });
    }

    public async Task<List<GameResponse>?> HandleAsync(GameRequest request, LocalAccount account, CancellationToken ct)
    {
        switch (request.Body)
        {
            case CSReqCosSignature signature:
                var signed = await maps.SignAsync(signature, account.Gid, session, ct);
                if (((CSRspCosSignature)signed.Union.select(signed.Command)).result == 0 && signature.isUpload == 1)
                {
                    uploadWork = signature.workID;
                    if (signature.fileSuffix == 2)
                        foreach (var file in signature.dlcData.Take(signature.dlcCount))
                        { cellWorks[file.newID] = signature.workID; signedCells.Add(file.newID); }
                }
                return [signed];
            case CSReqFinishUploadPrivateMapData finish:
                var finishResult = await maps.FinishAsync(account.Gid, finish.workID,
                    WireReader.CString(finish.workName), true, ct);
                log.Write(session, "map_upload_finished", new { result = finishResult, finish.workID, finish.reason }, true);
                return [GameResponse.Of<CSRspFinishUploadPrivateMapData>(
                    (int)ECSMsgCmdID.CS_RSP_FINISH_UPLOAD_PRIVATE_MAP_DATA, rsp =>
                    { rsp.result = finishResult; rsp.curWorkID = finish.workID; })];
            case CSReqDeleteWorkID delete:
                var deleteResult = await maps.DeleteAsync(account.Gid, delete.workID, ct);
                log.Write(session, "delete_work", new { result = deleteResult, delete.workID, delete.reason }, true);
                return [GameResponse.Of<CSRspDeleteWorkID>((int)ECSMsgCmdID.CS_RSP_DELETE_WORK_ID, rsp =>
                { rsp.result = deleteResult; rsp.workID = delete.workID; rsp.reason = delete.reason; })];
            case CSReqGetMySurvivalWork query:
                var works = new List<LocalWork>();
                foreach (var id in query.workIDs.Take(query.count).Distinct())
                {
                    var work = await store.GetWorkAsync(account.Gid, id, ct);
                    if (work is { Deleted: false, UploadedAt: > 0, WorkType: 1, GameMode: 302 or 303 } &&
                        maps.HasMainFile(work.Id)) works.Add(work);
                }
                log.Write(session, "survival_works_queried", new
                { requested = query.count, count = works.Count, workIds = works.Select(w => w.Id).ToArray() }, true);
                return [GameResponse.Of<CSRspGetMySurvivalWork>((int)ECSMsgCmdID.CS_RSP_GET_MY_SURVIVAL_WORK, rsp =>
                {
                    rsp.result = 0; rsp.count = works.Count;
                    for (var i = 0; i < works.Count; i++) rsp.survival[i] = Describe(works[i], account);
                })];
            case CSReqBeginUploadAreaCompressFile beginCell:
                var beginWork = cellWorks.GetValueOrDefault(beginCell.id, uploadWork);
                var beginInfo = await store.GetWorkAsync(account.Gid, beginWork, ct);
                var beginResult = beginInfo is { Deleted: false, GameMode: 302 or 303 } ? 0 : Missing;
                if (beginResult == 0)
                {
                    cellWorks[beginCell.id] = beginWork;
                    activeCells[beginCell.id] = signedCells.Remove(beginCell.id);
                }
                return [GameResponse.Of<CSRspBeginUploadAreaCompressFile>(
                    (int)ECSMsgCmdID.CS_RSP_BEGIN_UPLOAD_AREA_COMPRESS_FILE, rsp =>
                    { rsp.result = beginResult; rsp.id = beginCell.id; })];
            case CSReqFinishUploadAreaCompressFile finishCell:
                var cellResult = Invalid;
                if (cellWorks.TryGetValue(finishCell.id, out var cellWork) && finishCell.result == 0 &&
                    activeCells.TryGetValue(finishCell.id, out var transferred))
                    cellResult = transferred
                        ? maps.CellAvailable(account.Gid, cellWork, finishCell.id, true) ? 0 : Invalid
                        : await maps.MarkEmptyCellAsync(account.Gid, cellWork, finishCell.id, ct);
                log.Write(session, "map_cell_finished", new { result = cellResult, id = finishCell.id });
                return [GameResponse.Of<CSRspFinishUploadAreaCompressFile>(
                    (int)ECSMsgCmdID.CS_RSP_FINISH_UPLOAD_AREA_COMPRESS_FILE, rsp =>
                    { rsp.result = cellResult; rsp.id = finishCell.id; })];
            case CSReqGetAreaCompressFileList cells:
                // 当前仅有房主，不存在其他客户端的待上传区块。
                return [GameResponse.Of<CSRspGetAreaCompressFileList>(
                    (int)ECSMsgCmdID.CS_RSP_GET_AREA_COMPRESS_FILE_LIST, rsp =>
                    { rsp.workID = cells.workID; rsp.reason = cells.reason; rsp.fileDescInfo.count = 0; })];
            case CSReqBeginConvertWorkForAreaManage begin:
                var before = await store.GetWorkAsync(account.Gid, begin.workID, ct);
                var beforeResult = before is { Deleted: false, UploadedAt: > 0 } && begin.isUgcWork == 0 && begin.version == 0
                    ? 0 : Invalid;
                return [GameResponse.Of<CSRspBeginConvertWorkForAreaManage>(
                    (int)ECSMsgCmdID.CS_RSP_BEGIN_CONVERT_WORK_FOR_AREA_MANAGE, rsp =>
                    { rsp.result = beforeResult; rsp.workID = begin.workID; rsp.isUgcWork = begin.isUgcWork; rsp.version = begin.version; })];
            case CSReqFinishConvertWorkForAreaManage convert:
                var convertResult = convert.result != 0 || convert.isUgcWork != 0 || convert.version != 0 ? Invalid :
                    await maps.FinishAsync(account.Gid, convert.workID, "", true, ct);
                return [GameResponse.Of<CSRspFinishConvertWorkForAreaManage>(
                    (int)ECSMsgCmdID.CS_RSP_FINISH_CONVERT_WORK_FOR_AREA_MANAGE, rsp =>
                    { rsp.result = convertResult; rsp.workID = convert.workID; rsp.isUgcWork = convert.isUgcWork; rsp.version = convert.version; })];
            case CSReqDownloadMapResult download:
                log.Write(session, "map_download_result", new { download.result, download.reason,
                    workId = download.workBaseInfo.workID });
                return [GameResponse.Of<CSRspDownloadMapResult>((int)ECSMsgCmdID.CS_RSP_DOWNLOAD_MAP_RESULT, rsp =>
                {
                    rsp.result = download.result; rsp.reason = download.reason; rsp.workBaseInfo = download.workBaseInfo;
                    rsp.accKey.accountGID = account.Gid; rsp.accKey.deviceType = (byte)ECSDeviceType.CS_ANDROID_DEVICE_TYPE;
                })];
            default:
                return null;
        }
    }

    public async Task RecordRoomAsync(CSReqCreateRoom request, LocalAccount account, CancellationToken ct)
    {
        if (request.roomConfigDetail.select(request.gameMode) is not CSSurvivalRoomConfigDetail detail) return;
        var work = await store.GetWorkAsync(account.Gid, detail.workID, ct);
        if (work is not { Deleted: false }) return;
        await store.UpdateWorkAsync(account.Gid, detail.workID, w =>
        {
            w.Name = WireReader.CString(detail.workName);
            w.Difficulty = detail.difficultyLevel; w.MaxPlayers = detail.maxPlayerNum;
        }, ct);
    }

    private static CSSurvivalGameDesc Describe(LocalWork work, LocalAccount account) => new()
    {
        lastPlaytime = work.UploadedAt, isWorkAreaManage = work.AreaManaged ? (byte)1 : (byte)0,
        workBaseInfo = new CSWorkBaseInfo
        {
            workID = work.Id, workType = work.WorkType, gameMode = work.GameMode,
            workName = LocalAccount.TextBytes(work.Name.Length > 0 ? work.Name : work.Id.ToString(), 32),
            workTag = (byte)(work.GameMode == 303 ? ECSWorkTag.CS_WORK_TAG_CREATIVE : ECSWorkTag.CS_WORK_TAG_SURVIVAL),
            accountGID = account.Gid, deviceType = (byte)ECSDeviceType.CS_ANDROID_DEVICE_TYPE,
            roleName = LocalAccount.TextBytes(account.RoleName ?? "", 32),
            createTime = work.CreatedAt, workSize = work.FileSize,
            maxPlayerNum = work.MaxPlayers, difficultyLevel = work.Difficulty
        }
    };
}

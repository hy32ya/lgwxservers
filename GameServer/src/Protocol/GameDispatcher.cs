using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using cs_msg;
using LocalGameServer.Storage;
using LocalGameServer.Transport;

namespace LocalGameServer.Protocol;

public sealed class GameDispatcher(ServerSettings settings, AccountStore store, LocalMapStorage maps, ServerLog log,
    string session, LocalAccount account)
{
    private bool accountLoggedIn;
    private bool workListSent;
    private LocalAccount account = account;
    private readonly LocalRoomSession rooms = new(settings, log, session);
    private readonly LocalMapProtocol mapRequests = new(maps, store, log, session);
    private readonly LocalParkProtocol park = new(settings, log, session);

    private static readonly Dictionary<int, int> ResponseCommands = BuildResponseMap();

    private static Dictionary<int, int> BuildResponseMap()
    {
        var names = Enum.GetNames<ECSMsgCmdID>().ToHashSet(StringComparer.Ordinal);
        var result = new Dictionary<int, int>();
        foreach (var name in names.Where(n => n.StartsWith("CS_REQ_", StringComparison.Ordinal)))
        {
            var responseName = "CS_RSP_" + name[7..];
            if (names.Contains(responseName))
                result[(int)Enum.Parse<ECSMsgCmdID>(name)] = (int)Enum.Parse<ECSMsgCmdID>(responseName);
        }
        return result;
    }

    public static bool TokenMatches(string? actual, string expected) => actual != null &&
        CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(actual), Encoding.UTF8.GetBytes(expected));

    public async Task<List<GameResponse>> HandleAsync(GameRequest request, CancellationToken ct)
    {
        var responses = new List<GameResponse>();
        if (request.Command == (int)ECSMsgCmdID.CS_REQ_ACCOUNT_LOGIN && request.Body is CSReqAccountLogin login)
        {
            await rooms.CloseAsync(ct);
            var accepted = TokenMatches(WireReader.CString(login.accessToken), settings.LocalToken);
            accountLoggedIn = accepted;
            workListSent = false;
            account = await store.GetAsync(account.Gid, ct);
            var result = !accepted ? (int)ECSErrorCode.CS_ERR_ACCOUNT_NOT_AUTH :
                account.HasRole ? 0 : (int)ECSErrorCode.CS_ERR_NEED_CREATE_ROLE;
            responses.Add(GameResponse.Of<CSRspAccountLogin>(2, rsp =>
            {
                rsp.result = result;
                rsp.accountGID = account.Gid;
                rsp.roleInfo = account.ToRole();
                rsp.nickName = LocalAccount.TextBytes(account.RoleName ?? "本地玩家", 40);
                rsp.loginType = 0;
                rsp.guides.isAllFinished = account.GuidesFinished ? (byte)1 : (byte)0;
                var finishedGuides = account.FinishedGuides.Where(n => n is >= 0 and <= ushort.MaxValue)
                    .Take(100).ToArray();
                rsp.guides.count = (byte)finishedGuides.Length;
                for (var i = 0; i < finishedGuides.Length; i++)
                {
                    rsp.guides.guides[i].guideID = (ushort)finishedGuides[i];
                    rsp.guides.guides[i].isFinished = 1;
                }
            }));
            if (accepted)
            {
                responses.Add(maps.ConfigResponse());
                responses.Add(TimeResponse());
                if (result == 0) await AddWorkListAsync(responses, ct);
            }
            log.Write(session, "account_login", new { gid = account.Gid, account.ClientIp,
                result, hasRole = account.HasRole }, true);
            return responses;
        }

        if (!accountLoggedIn)
            return [ErrorResponse(request, (int)ECSErrorCode.CS_ERR_ACCOUNT_NOT_AUTH, "请先登录本地账号")];

        account = await store.GetAsync(account.Gid, ct);
        var parkResponses = await park.HandleAsync(request, account.Gid, ct);
        if (parkResponses != null) return parkResponses;
        var mapResponses = await mapRequests.HandleAsync(request, account, ct);
        if (mapResponses != null) return mapResponses;
        var roomResponses = await rooms.HandleAsync(request, account, ct);
        responses.AddRange(rooms.PendingResponses);
        if (roomResponses != null)
        {
            if (request.Body is CSReqCreateRoom createRoom &&
                roomResponses.Any(r => r.Command == (int)ECSMsgCmdID.CS_RSP_CREATE_ROOM &&
                    r.Union.select(r.Command) is CSRspCreateRoom { result: 0 }))
                await mapRequests.RecordRoomAsync(createRoom, account, ct);
            return roomResponses;
        }
        var lobbyResponse = LobbyQueries.Handle(request);
        if (lobbyResponse != null) return [.. responses, lobbyResponse];
        switch (request.Body)
        {
            case CSReqCheckRoleName check:
                var nameResult = await store.CheckNameAsync(WireReader.CString(check.roleName), account.Gid, ct);
                responses.Add(GameResponse.Of<CSRspCheckRoleName>(61, rsp =>
                { rsp.result = nameResult; rsp.cbData = check.cbData; }));
                break;
            case CSReqCreateRole create:
                var created = await store.CreateRoleAsync(account.Gid, WireReader.CString(create.roleName),
                    create.roleStyle, ct);
                account = created.Account;
                responses.Add(GameResponse.Of<CSRspCreateRole>(6, rsp =>
                { rsp.result = created.Result; rsp.accountGID = account.Gid; rsp.roleInfo = account.ToRole(); }));
                log.Write(session, "create_role", new { gid = account.Gid, result = created.Result,
                    name = account.RoleName }, true);
                if (created.Result == 0) await AddWorkListAsync(responses, ct);
                break;
            case CSReqRoleLogin roleLogin:
                var roleResult = roleLogin.accountGID != account.Gid
                    ? (int)ECSErrorCode.CS_ERR_ACCOUNT_NOT_AUTH
                    : account.HasRole ? 0 : (int)ECSErrorCode.CS_ERR_NEED_CREATE_ROLE;
                responses.Add(GameResponse.Of<CSRspRoleLogin>(4, rsp =>
                { rsp.result = roleResult; rsp.roleInfo = account.ToRole(); }));
                if (roleResult == 0)
                {
                    responses.Add(TimeResponse());
                    await AddWorkListAsync(responses, ct);
                }
                break;
            case CSReqPing ping:
                responses.Add(GameResponse.Of<CSRspPing>(242, rsp => rsp.timestamp = ping.timestamp));
                break;
            case CSReqCheckUic text:
                responses.Add(LocalTextCheck.Respond(text, log, session));
                break;
            case CSReqLogForGame statistics:
                log.Write(session, "game_statistics", new { statistics.weaponCnt, statistics.runDistance,
                    statistics.flyDistance, statistics.swimDistance });
                responses.Add(GameResponse.Of<CSRspLogForGame>((int)ECSMsgCmdID.CS_RSP_LOG_FOR_GAME,
                    rsp => rsp.errCode = 0));
                break;
            case CSReqAccountLogout:
                accountLoggedIn = false;
                workListSent = false;
                await rooms.CloseAsync(ct);
                responses.Add(GameResponse.Of<CSRspAccountLogout>(12, rsp => rsp.result = 0));
                break;
            case CSReqModWorkLevel workLevel when workLevel.mask == 0:
                responses.Add(GameResponse.Of<CSRspModWorkLevel>((int)ECSMsgCmdID.CS_RSP_MOD_WORK_LEVEL,
                    rsp => { rsp.result = 0; rsp.level = 0; }));
                break;
            case CSReqGetNewWorkID work:
                var details = work.getWorkIDDetail.select(work.gameMode);
                var workType = details is CSUGCEditGetWorkID editId ? editId.workType : (byte)ECSWorkType.CS_WORK_TYPE_MAP;
                var reason = details is CSUGCEditGetWorkID editReason ? editReason.reason :
                    details is CSSurvivalGetWorkID survivalReason ? survivalReason.reason : (byte)0;
                var validWork = account.HasRole && details != null && workType is >= 1 and <= 3;
                var workId = validWork ? await store.AllocateWorkAsync(account.Gid, work.gameMode, workType, reason, ct) : 0;
                responses.Add(GameResponse.Of<CSRspGetNewWorkID>((int)ECSMsgCmdID.CS_RSP_GET_NEW_WORK_ID, rsp =>
                {
                    rsp.result = validWork ? 0 : (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                    rsp.gameMode = work.gameMode; rsp.workType = workType; rsp.reason = reason; rsp.workID = workId;
                }));
                log.Write(session, "allocate_work", new { workId, work.gameMode, workType, reason }, true);
                break;
            case CSReqReconnectReady:
                responses.Add(GameResponse.Of<CSRspReconnectReady>(63,
                    rsp => rsp.result = (int)ECSErrorCode.CS_ERR_RECONNECT_READY_NOT_PLAYING));
                break;
            case CSReqGetCurrencyBalance balance:
                responses.Add(GameResponse.Of<CSRspGetCurrencyBalance>(115, rsp =>
                {
                    if (balance.type > 3) { rsp.num = 0; return; }
                    rsp.num = 1;
                    rsp.bananceList[0].type = balance.type;
                    rsp.bananceList[0].balance = balance.type switch
                    { 0 => account.Coins, 1 => account.Diamonds, 2 => account.Gold, _ => account.Coupons };
                }));
                break;
            case CSReqWorkshopList workshop:
                responses.Add(GameResponse.Of<CSRspWorkshopList>(78, rsp =>
                {
                    rsp.result = 0;
                    rsp.index = workshop.index;
                    rsp.type = workshop.type;
                    rsp.tag = workshop.tag;
                    rsp.workType = workshop.workType;
                    rsp.count = 0; // 本地工坊暂无作品。
                }));
                break;
            case CSReqGetMyEditWork edit when edit.count == 0:
                responses.Add(GameResponse.Of<CSRspGetMyEditWork>(41, rsp => rsp.result = 0));
                break;
            case CSReqGetMyDownloadWork download when download.count == 0:
                responses.Add(GameResponse.Of<CSRspGetMyDownloadWork>(45, rsp => rsp.result = 0));
                break;
            case CSReqGetInvitedNum:
                responses.Add(GameResponse.Of<CSRspGetInvitedNum>(8782, rsp => rsp.result = 0));
                break;
            case CSReqAllCareerTask:
                responses.Add(GameResponse.Of<CSRspAllCareerTask>(642, rsp => rsp.result = 0));
                break;
            case CSReqUpdateGuideEvent:
                // 引导事件和奖励表暂未配置。
                responses.Add(GameResponse.Of<CSRspUpdateGuideEvent>(2603, rsp => rsp.errCode = 0));
                break;
            case CSReqFinishGuide finish:
                if (finish.guideID is < 0 or > ushort.MaxValue || finish.isAllFinished > 1)
                    responses.Add(ErrorResponse(request, (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM, "引导参数无效"));
                else
                {
                    await store.FinishGuideAsync(account.Gid, finish, ct);
                    responses.Add(GameResponse.Of<CSRspFinishGuide>(2605, rsp => rsp.errCode = 0));
                }
                break;
            default:
                // 单向统计上报，无需应答。
                if (request.Command is 125 or 1501 or 4000 or 9104)
                    log.Write(session, "telemetry", new { request.Command, type = request.Body?.GetType().Name });
                else
                {
                    log.Write(session, "unimplemented", new { request.Command,
                        name = Enum.GetName(typeof(ECSMsgCmdID), request.Command), type = request.Body?.GetType().Name }, true);
                    responses.Add(ErrorResponse(request, (int)ECSErrorCode.CS_ERR_SYSTEM_IS_DISABLED,
                        $"本地服务尚未实现请求 {request.Command}"));
                }
                break;
        }
        return responses;
    }

    private async Task AddWorkListAsync(List<GameResponse> responses, CancellationToken ct)
    {
        if (workListSent) return;
        responses.Add(await mapRequests.OwnedWorksResponseAsync(account, ct));
        responses.Add(await park.InitialResponseAsync(account.Gid, ct));
        workListSent = true;
    }

    public Task CloseAsync(CancellationToken ct) => rooms.CloseAsync(ct);

    private static GameResponse TimeResponse()
    {
        var now = DateTimeOffset.UtcNow;
        // 1500 使用通知消息，时间值放在内层。
        return GameResponse.Of<CSNotifyTimeSync>((int)ECSMsgCmdID.CS_RSP_SYNC_TIME, rsp =>
        {
            rsp.timesync.sec = (int)now.ToUnixTimeSeconds();
            rsp.timesync.usec = (int)(now.Ticks % TimeSpan.TicksPerSecond / 10);
        });
    }

    private static GameResponse ErrorResponse(GameRequest request, int error, string message)
    {
        if (ResponseCommands.TryGetValue(request.Command, out var command))
        {
            var union = new CSMsgRspBody();
            var body = union.select(command);
            var type = body?.GetType();
            var field = type?.GetField("result") ?? type?.GetField("errCode") ?? type?.GetField("errNo");
            if (body != null && field?.FieldType == typeof(int))
            {
                field.SetValue(body, error);
                foreach (var name in new[] { "cbData", "index", "type", "tag", "workType" })
                {
                    var sourceField = request.Body?.GetType().GetField(name);
                    var destinationField = type!.GetField(name);
                    if (sourceField != null && destinationField?.FieldType == sourceField.FieldType)
                        destinationField.SetValue(body, sourceField.GetValue(request.Body));
                }
                return new GameResponse(command, union);
            }
        }
        return GameResponse.Of<CSRspShowErrorMsg>(64, rsp =>
        { rsp.errNo = error; rsp.errMsg = LocalAccount.TextBytes(message, 64); });
    }
}

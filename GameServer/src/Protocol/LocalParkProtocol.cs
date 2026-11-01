using cs_msg;
using LocalGameServer.Storage;
using LocalGameServer.Transport;
using System.Text.Json;

namespace LocalGameServer.Protocol;

// 乐园初始化与五组布局存储。
public sealed class LocalParkProtocol(ServerSettings settings, ServerLog log, string session)
{
    private readonly WorldSaveStore files = new(settings.DataDirectory);
    private ParkSave? state;
    private string PathFor(ulong gid) => System.IO.Path.Combine("parks", gid + ".json");

    public sealed class ParkSave
    {
        public byte ShowCase { get; set; }
        public Dictionary<uint, ushort> Inventory { get; set; } = new();
        public List<ParkLayout> Layouts { get; set; } = Enumerable.Range(1, 5)
            .Select(i => new ParkLayout { Name = "方案" + i }).ToList();
    }

    public sealed class ParkLayout
    {
        public string Name { get; set; } = "";
        public List<ParkBuilding> Buildings { get; set; } = [];
    }

    public sealed record ParkBuilding(ushort X, ushort Z, byte Rotation, uint Id);

    private async Task<ParkSave> LoadAsync(ulong gid, CancellationToken ct)
    {
        if (state != null) return state;
        state = await files.ReadAsync<ParkSave>(PathFor(gid), ct);
        if (state == null)
        {
            var created = new ParkSave();
            created.Layouts[0].Buildings = new(LocalWorldCatalog.Current.ParkStarter);
            created.Inventory = created.Layouts[0].Buildings.GroupBy(b => b.Id)
                .ToDictionary(g => g.Key, g => checked((ushort)g.Count()));
            // 原引导在第三步放置 14 号建筑。
            created.Inventory[14] = (ushort)(created.Inventory.GetValueOrDefault(14u) + 1);
            await files.WriteAsync(PathFor(gid), created, ct);
            state = created;
        }
        if (state.Layouts.Count != 5 || state.ShowCase >= 5)
            throw new InvalidDataException("乐园存档无效，原文件已保留。");
        return state;
    }

    public async Task<GameResponse> InitialResponseAsync(ulong gid, CancellationToken ct)
    {
        var park = await LoadAsync(gid, ct);
        log.Write(session, "park_initialized", new { gid, park.ShowCase, landSize = 44 }, true);
        return GameResponse.Of<CSRspLegoZoneData>((int)ECSMsgCmdID.CS_RSP_LEGO_ZONE_DATA, rsp =>
        {
            // 44 是原表首级土地尺寸。
            rsp.placeLargeX = 44; rsp.placeLargeZ = 44; rsp.prosStageID = 1;
            rsp.showCaseIndex = park.ShowCase; rsp.caseCount = 5;
            rsp.matchingCase = Describe(park.Layouts[park.ShowCase]);
            for (var i = 0; i < 5; i++) rsp.matchingCaseNames[i] = LocalAccount.TextBytes(park.Layouts[i].Name, 32);
            rsp.storageDesc.storageMaxSize = 1000;
            var stock = park.Inventory.OrderBy(p => p.Key).ToArray();
            rsp.storageDesc.storageItem.count = checked((ushort)stock.Length);
            for (var i = 0; i < stock.Length; i++) rsp.storageDesc.storageItem.data[i] = new()
            { resID = checked((int)stock[i].Key), count = stock[i].Value, index = (ushort)i };
            rsp.maxProsperity = park.Layouts.Max(Prosperity);
            rsp.goldChest.id = 1; rsp.diamondChest.id = 2;
        });
    }

    private static CSMatchingCase Describe(ParkLayout layout)
    {
        var result = new CSMatchingCase { name = LocalAccount.TextBytes(layout.Name, 32),
            count = checked((ushort)layout.Buildings.Count), prosperity = Prosperity(layout) };
        for (var i = 0; i < layout.Buildings.Count; i++)
        {
            var b = layout.Buildings[i];
            result.buildingInfos[i] = new() { posX = b.X, posZ = b.Z, rotateType = b.Rotation, resID = b.Id };
        }
        return result;
    }

    public async Task<List<GameResponse>?> HandleAsync(GameRequest request, ulong gid, CancellationToken ct)
    {
        if (request.Body is CSReqLegoZoneData) return [await InitialResponseAsync(gid, ct)];
        if (request.Body is not (CSReqGetMatchingCase or CSReqSetLegoZoneMatchingCase or
            CSReqRenameMatchingCase or CSReqSetShowCaseIndex)) return null;
        var park = await LoadAsync(gid, ct);
        var invalid = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
        switch (request.Body)
        {
            case CSReqGetMatchingCase get:
                return [GameResponse.Of<CSRspGetMatchingCase>((int)ECSMsgCmdID.CS_RSP_GET_MATCHING_CASE, rsp =>
                {
                    rsp.result = get.caseIndex < 5 ? 0 : invalid; rsp.caseIndex = get.caseIndex;
                    if (rsp.result == 0) rsp.matchingCase = Describe(park.Layouts[get.caseIndex]);
                })];
            case CSReqSetLegoZoneMatchingCase set:
                var buildings = set.building.buildingInfos.Take(set.building.count).ToArray();
                var setResult = set.index < 5 && set.building.count <= 1000 &&
                    set.building.count <= set.building.buildingInfos.Length && set.suitInfo.count == 0 &&
                    buildings.All(b => b.posX <= 44 && b.posZ <= 44 && b.rotateType <= 3 &&
                        LocalWorldCatalog.Current.ParkBuildings.ContainsKey(b.resID)) &&
                    buildings.GroupBy(b => b.resID).All(g => g.Count() <= park.Inventory.GetValueOrDefault(g.Key))
                    ? 0 : invalid;
                if (setResult == 0)
                {
                    var next = Copy(park);
                    next.Layouts[set.index].Buildings = buildings
                        .Select(b => new ParkBuilding(b.posX, b.posZ, b.rotateType, b.resID)).ToList();
                    await files.WriteAsync(PathFor(gid), next, ct); state = next;
                }
                return [GameResponse.Of<CSRspSetLegoZoneMatchingCase>((int)ECSMsgCmdID.CS_RSP_SET_LEGO_ZONE_MATCHING_CASE,
                    rsp => { rsp.result = setResult; rsp.seq = set.seq; rsp.index = set.index;
                        if (setResult == 0) rsp.prosperity = Prosperity(state!.Layouts[set.index]); })];
            case CSReqRenameMatchingCase rename:
                var name = WireReader.CString(rename.newName).Trim();
                var renameResult = rename.index < 5 && name.Length is > 0 and <= 20 &&
                    !name.Any(char.IsControl) ? 0 : invalid;
                if (renameResult == 0)
                {
                    var next = Copy(park); next.Layouts[rename.index].Name = name;
                    await files.WriteAsync(PathFor(gid), next, ct); state = next;
                }
                return [GameResponse.Of<CSRspRenameMatchingCase>((int)ECSMsgCmdID.CS_RSP_RENAME_MATCHING_CASE, rsp =>
                { rsp.result = renameResult; rsp.index = rename.index; rsp.newName = LocalAccount.TextBytes(name, 32); })];
            case CSReqSetShowCaseIndex show:
                var showResult = show.caseIndex < 5 ? 0 : invalid;
                if (showResult == 0)
                {
                    var next = Copy(park); next.ShowCase = show.caseIndex;
                    await files.WriteAsync(PathFor(gid), next, ct); state = next;
                }
                return [GameResponse.Of<CSRspSetShowCaseIndex>((int)ECSMsgCmdID.CS_RSP_SET_SHOW_CASE_INDEX,
                    rsp => { rsp.result = showResult; rsp.caseIndex = show.caseIndex; })];
            default:
                return null;
        }
    }

    private static ParkSave Copy(ParkSave value) => JsonSerializer.Deserialize<ParkSave>(
        JsonSerializer.Serialize(value))!;

    private static uint Prosperity(ParkLayout layout) => checked((uint)layout.Buildings.Sum(b =>
        (long)(LocalWorldCatalog.Current.ParkBuildings.GetValueOrDefault(b.Id)?.Prosperity ?? 0)));
}

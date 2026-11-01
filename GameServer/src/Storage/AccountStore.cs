using System.Net;
using System.Text;
using System.Text.Json;
using cs_msg;

namespace LocalGameServer.Storage;

public sealed class LocalAccount
{
    public string OpenId { get; set; } = "";
    public string ClientIp { get; set; } = "";
    public ushort Platform { get; set; }
    public ulong Gid { get; set; }
    public string? RoleName { get; set; }
    public CSRoleStyle Style { get; set; } = new();
    public byte Level { get; set; } = 1;
    public uint Experience { get; set; }
    public int Coins { get; set; }
    public int Gold { get; set; }
    public int Diamonds { get; set; }
    public int Coupons { get; set; }
    public uint CreatedAt { get; set; }
    public bool GuidesFinished { get; set; }
    public List<int> FinishedGuides { get; set; } = [];
    public bool HasRole => !string.IsNullOrEmpty(RoleName);

    public CSRoleInfo ToRole() => new()
    {
        accountGID = Gid,
        actorID = Gid,
        deviceType = (byte)ECSDeviceType.CS_ANDROID_DEVICE_TYPE,
        roleName = TextBytes(RoleName ?? "", 32),
        roleStyle = Style,
        level = Level,
        exp = Experience,
        money = new CSMoney { inGameCoin = Coins, gold = Gold, diamond = Diamonds, coupon = Coupons },
        maxOwnedWorkNum = 10,
        createTime = CreatedAt
    };

    public static byte[] TextBytes(string value, int capacity)
    {
        var result = new byte[capacity];
        var encoder = Encoding.UTF8.GetEncoder();
        encoder.Convert(value.AsSpan(), result.AsSpan(0, capacity - 1), true, out _, out _, out _);
        return result;
    }
}

public sealed class AccountDatabase
{
    public int FormatVersion { get; set; } = 1;
    public ulong NextGid { get; set; }
    public List<LocalAccount> Accounts { get; set; } = [];
    public ulong NextWorkId { get; set; } = 0x1000000000000000;
    public List<LocalWork> Works { get; set; } = [];
}

public sealed class LocalWork
{
    public ulong Id { get; set; }
    public ulong OwnerGid { get; set; }
    public ushort GameMode { get; set; }
    public byte WorkType { get; set; }
    public byte Reason { get; set; }
    public string Name { get; set; } = "";
    public uint CreatedAt { get; set; }
    public uint UploadedAt { get; set; }
    public uint FileSize { get; set; }
    public byte Difficulty { get; set; }
    public byte MaxPlayers { get; set; } = 10;
    public bool AreaManaged { get; set; }
    public bool Deleted { get; set; }
    public List<long> EmptyCells { get; set; } = [];
}

// 单进程存储：读取副本，同盘原子写入。
public sealed class AccountStore : IDisposable
{
    private static readonly JsonSerializerOptions JsonOptions = new() { IncludeFields = true, WriteIndented = true };
    private readonly SemaphoreSlim gate = new(1, 1);
    private readonly ServerSettings settings;
    private readonly string path;
    private readonly FileStream processLock;
    private AccountDatabase database;

    public AccountStore(ServerSettings settings)
    {
        this.settings = settings;
        Directory.CreateDirectory(settings.DataDirectory);
        path = Path.Combine(settings.DataDirectory, "accounts.json");
        processLock = new FileStream(Path.Combine(settings.DataDirectory, "server.lock"), FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None);
        try
        {
            database = File.Exists(path)
                ? JsonSerializer.Deserialize<AccountDatabase>(File.ReadAllText(path), JsonOptions)
                    ?? throw new InvalidDataException("accounts.json is empty.")
                : new AccountDatabase { NextGid = settings.FirstAccountGid };
            if (database.Accounts != null)
                foreach (var account in database.Accounts)
                    if (!string.IsNullOrEmpty(account.ClientIp))
                    {
                        if (!IPAddress.TryParse(account.ClientIp, out var address) ||
                            address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
                            throw new InvalidDataException("accounts.json 的 ClientIp 无效；原文件未覆盖。");
                        account.ClientIp = NormalizeIp(address);
                    }
            if (database.FormatVersion != 1 || database.Accounts is null ||
                database.Accounts.Any(a => a.Gid == 0 || string.IsNullOrWhiteSpace(a.OpenId) ||
                    a.Style is null || a.FinishedGuides is null) || database.Works is null ||
                database.Accounts.Select(a => a.Gid).Distinct().Count() != database.Accounts.Count ||
                database.Accounts.Where(a => string.IsNullOrEmpty(a.ClientIp))
                    .GroupBy(a => (a.OpenId, a.Platform)).Any(group => group.Count() > 1) ||
                database.Accounts.Where(a => !string.IsNullOrEmpty(a.ClientIp))
                    .GroupBy(a => a.ClientIp, StringComparer.Ordinal).Any(group => group.Count() > 1) ||
                database.Works.Any(w => w.Id == 0 || !database.Accounts.Any(a => a.Gid == w.OwnerGid)) ||
                database.Works.Select(w => w.Id).Distinct().Count() != database.Works.Count)
                throw new InvalidDataException("Invalid accounts.json; it has not been overwritten.");
            database.NextGid = Math.Max(database.NextGid, settings.FirstAccountGid);
            if (database.Accounts.Count > 0)
                database.NextGid = Math.Max(database.NextGid, checked(database.Accounts.Max(a => a.Gid) + 1));
            database.NextWorkId = Math.Max(database.NextWorkId, 0x1000000000000000UL);
            if (database.Works.Count > 0)
                database.NextWorkId = Math.Max(database.NextWorkId, checked(database.Works.Max(w => w.Id) + 1));
        }
        catch { processLock.Dispose(); throw; }
    }

    private static LocalAccount Copy(LocalAccount source) => JsonSerializer.Deserialize<LocalAccount>(
        JsonSerializer.SerializeToUtf8Bytes(source, JsonOptions), JsonOptions)!;

    private static string NormalizeIp(IPAddress address) =>
        (address.IsIPv4MappedToIPv6 ? address.MapToIPv4() : address).ToString();

    public async Task<LocalAccount> GetOrCreateByIpAsync(IPAddress address, string openId,
        ushort platform, CancellationToken ct)
    {
        var clientIp = NormalizeIp(address);
        await gate.WaitAsync(ct);
        try
        {
            // 只按来源 IP 查找，不区分端口和登录按钮。
            var found = database.Accounts.FirstOrDefault(a => a.ClientIp == clientIp);
            if (found != null) return Copy(found);
            var account = new LocalAccount
            {
                OpenId = openId, ClientIp = clientIp, Platform = platform, Gid = database.NextGid,
                Level = settings.StartingLevel, Coins = settings.StartingCoins, Gold = settings.StartingGold,
                Diamonds = settings.StartingDiamonds, Coupons = settings.StartingCoupons,
                CreatedAt = checked((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            };
            var previousNext = database.NextGid;
            database.NextGid = checked(database.NextGid + 1);
            database.Accounts.Add(account);
            try { await SaveAsync(ct); }
            catch { database.Accounts.Remove(account); database.NextGid = previousNext; throw; }
            return Copy(account);
        }
        finally { gate.Release(); }
    }

    public async Task<LocalAccount> GetAsync(ulong gid, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try { return Copy(database.Accounts.Single(a => a.Gid == gid)); }
        finally { gate.Release(); }
    }

    public async Task<ulong> AllocateWorkAsync(ulong ownerGid, ushort gameMode, byte workType,
        byte reason, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var account = database.Accounts.Single(a => a.Gid == ownerGid);
            if (!account.HasRole) throw new InvalidOperationException("请先创建角色。");
            var previousNext = database.NextWorkId;
            var work = new LocalWork { Id = previousNext, OwnerGid = ownerGid,
                GameMode = gameMode, WorkType = workType, Reason = reason,
                CreatedAt = checked((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds()) };
            database.NextWorkId = checked(previousNext + 1);
            database.Works.Add(work);
            try { await SaveAsync(ct); }
            catch { database.Works.Remove(work); database.NextWorkId = previousNext; throw; }
            return work.Id;
        }
        finally { gate.Release(); }
    }

    private static LocalWork CopyWork(LocalWork source) => JsonSerializer.Deserialize<LocalWork>(
        JsonSerializer.SerializeToUtf8Bytes(source, JsonOptions), JsonOptions)!;

    public async Task<List<LocalWork>> GetWorksAsync(ulong ownerGid, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            return database.Works.Where(w => w.OwnerGid == ownerGid && !w.Deleted)
                .Select(CopyWork).ToList();
        }
        finally { gate.Release(); }
    }

    public async Task<LocalWork?> GetWorkAsync(ulong ownerGid, ulong id, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var work = database.Works.FirstOrDefault(w => w.Id == id && w.OwnerGid == ownerGid);
            return work == null ? null : CopyWork(work);
        }
        finally { gate.Release(); }
    }

    public async Task<bool> UpdateWorkAsync(ulong ownerGid, ulong id, Action<LocalWork> update,
        CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var work = database.Works.FirstOrDefault(w => w.Id == id && w.OwnerGid == ownerGid);
            if (work == null) return false;
            var previous = CopyWork(work);
            try { update(work); await SaveAsync(ct); }
            catch { database.Works[database.Works.IndexOf(work)] = previous; throw; }
            return true;
        }
        finally { gate.Release(); }
    }

    public static int ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return (int)ECSErrorCode.CS_ERR_ROLE_NAME_IS_EMPTY;
        if (Encoding.UTF8.GetByteCount(name) > 31) return (int)ECSErrorCode.CS_ERR_ROLE_NAME_EXCEED_MAX_LENGTH;
        if (name.Any(char.IsControl)) return (int)ECSErrorCode.CS_ERR_ROLE_NAME_CONTAINS_ILLEGAL_CHARACTERS;
        return 0;
    }

    public async Task<int> CheckNameAsync(string name, ulong ownGid, CancellationToken ct)
    {
        var error = ValidateName(name);
        if (error != 0) return error;
        await gate.WaitAsync(ct);
        try { return NameUsed(name, ownGid) ? (int)ECSErrorCode.CS_ERR_ROLE_NAME_ALREADY_EXIST : 0; }
        finally { gate.Release(); }
    }

    private bool NameUsed(string name, ulong ownGid) => database.Accounts.Any(a =>
        a.Gid != ownGid && string.Equals(a.RoleName, name, StringComparison.OrdinalIgnoreCase));

    public async Task<(int Result, LocalAccount Account)> CreateRoleAsync(ulong gid, string name,
        CSRoleStyle style, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var account = database.Accounts.Single(a => a.Gid == gid);
            var error = account.HasRole ? (int)ECSErrorCode.CS_ERR_CREATE_TOO_MANY_ROLE : ValidateName(name);
            if (error == 0 && NameUsed(name, gid)) error = (int)ECSErrorCode.CS_ERR_ROLE_NAME_ALREADY_EXIST;
            if (error != 0) return (error, Copy(account));
            var previous = Copy(account);
            account.RoleName = name;
            account.Style = style;
            account.CreatedAt = checked((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            try { await SaveAsync(ct); }
            catch { database.Accounts[database.Accounts.IndexOf(account)] = previous; throw; }
            return (0, Copy(account));
        }
        finally { gate.Release(); }
    }

    public async Task FinishGuideAsync(ulong gid, CSReqFinishGuide request, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var account = database.Accounts.Single(a => a.Gid == gid);
            var previous = Copy(account);
            if (!account.FinishedGuides.Contains(request.guideID)) account.FinishedGuides.Add(request.guideID);
            account.FinishedGuides = account.FinishedGuides.TakeLast(100).ToList();
            account.GuidesFinished |= request.isAllFinished == 1;
            try { await SaveAsync(ct); }
            catch { database.Accounts[database.Accounts.IndexOf(account)] = previous; throw; }
        }
        finally { gate.Release(); }
    }

    private async Task SaveAsync(CancellationToken ct)
    {
        var temporary = path + ".tmp";
        try
        {
            await using (var stream = new FileStream(temporary, FileMode.Create, FileAccess.Write, FileShare.None,
                4096, FileOptions.WriteThrough | FileOptions.Asynchronous))
            {
                await JsonSerializer.SerializeAsync(stream, database, JsonOptions, ct);
                await stream.FlushAsync(ct);
                stream.Flush(true);
            }
            File.Move(temporary, path, true);
        }
        finally { if (File.Exists(temporary)) File.Delete(temporary); }
    }

    public void Dispose() { processLock.Dispose(); gate.Dispose(); }
}

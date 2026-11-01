using System.Net;
using System.Text.Json;

namespace LocalGameServer;

public sealed class ServerSettings
{
    public string ListenAddress { get; set; } = "0.0.0.0";
    public int Port { get; set; } = 2001;
    public int MapPort { get; set; } = 2002;
    public string MapPublicAddress { get; set; } = "";
    public long MaxMapFileBytes { get; set; } = 256L * 1024 * 1024;
    public int MaxConnections { get; set; } = 32;
    public int MaxFrameBytes { get; set; } = 1024 * 1024;
    public int HandshakeTimeoutSeconds { get; set; } = 30;
    public int IdleTimeoutSeconds { get; set; } = 180;
    public string DataDirectory { get; set; } = "data";
    public string LogDirectory { get; set; } = "logs";
    public long MaxLogFileBytes { get; set; } = 8 * 1024 * 1024;
    public int MaxLogFiles { get; set; } = 8;
    public bool CaptureFrames { get; set; } = true;
    public bool CaptureDecodedPayloads { get; set; } = true;
    // 握手占位标识，账号由来源 IP 决定。
    public string LocalOpenId { get; set; } = "00000000000000000000000000001001";
    public string LocalToken { get; set; } = "local-test-token-1001";
    public ulong FirstAccountGid { get; set; } = 1001;
    // 仅控制是否接受其他握手标识。
    public bool AllowOtherAccounts { get; set; }
    // SYN 使用 ServiceId，AUTH 使用登录应用号。
    public uint[] AppIds { get; set; } = [255];
    public uint TypeId { get; set; } = 100000;
    public uint ZoneId { get; set; } = 11;
    public ulong ServerId { get; set; }
    public byte StartingLevel { get; set; } = 1;
    public int StartingCoins { get; set; }
    public int StartingGold { get; set; }
    public int StartingDiamonds { get; set; }
    public int StartingCoupons { get; set; }

    public static ServerSettings Load(string path)
    {
        var settings = JsonSerializer.Deserialize<ServerSettings>(File.ReadAllText(path),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new InvalidDataException("server.json is empty.");
        if (!IPAddress.TryParse(settings.ListenAddress, out _) || settings.Port is < 1 or > 65535 ||
            settings.MaxConnections is < 1 or > 1024 || settings.MaxFrameBytes is < 4096 or > 16777216 ||
            settings.HandshakeTimeoutSeconds is < 1 or > 600 || settings.IdleTimeoutSeconds is < 5 or > 86400 ||
            settings.MaxLogFiles is < 1 or > 128 || settings.MaxLogFileBytes < 65536 ||
            settings.FirstAccountGid == 0 || string.IsNullOrWhiteSpace(settings.LocalOpenId) ||
            string.IsNullOrEmpty(settings.LocalToken) || settings.AppIds is not { Length: > 0 })
            throw new InvalidDataException("Invalid server.json setting.");
        if (string.IsNullOrWhiteSpace(settings.MapPublicAddress))
            throw new InvalidDataException("请先设置 MapPublicAddress，或运行 tools/server_list_tool.py configure --host 电脑实际IP。");
        if (settings.MapPort is < 1 or > 65535 || settings.MapPort == settings.Port ||
            settings.MaxMapFileBytes is < 1 or > 1073741824 ||
            !Uri.TryCreate("http://" + settings.MapPublicAddress, UriKind.Absolute, out var mapUri) ||
            mapUri.AbsolutePath != "/" || mapUri.Query.Length != 0 || mapUri.Fragment.Length != 0 ||
            mapUri.UserInfo.Length != 0 || mapUri.Port != settings.MapPort ||
            mapUri.Host is "0.0.0.0" or "::" or "[::]" ||
            System.Text.Encoding.UTF8.GetByteCount(settings.MapPublicAddress) > 99)
            throw new InvalidDataException("Invalid map storage setting.");
        var configDirectory = Path.GetDirectoryName(Path.GetFullPath(path))!;
        settings.DataDirectory = Path.GetFullPath(settings.DataDirectory, configDirectory);
        settings.LogDirectory = Path.GetFullPath(settings.LogDirectory, configDirectory);
        return settings;
    }
}

using System.Globalization;
using System.Text;

namespace LocalGameServer.Transport;

public sealed record TgcpAccount(ushort Category, byte IdKind, byte[] EncodedId, string OpenId, ulong Gid)
{
    public static TgcpAccount Read(WireReader reader)
    {
        var category = reader.U16();
        var kind = reader.U8();
        byte[] encoded;
        string openId;
        switch (kind)
        {
            case 1:
                var smallId = reader.U32();
                encoded = new WireWriter().U32(smallId).ToArray();
                openId = smallId.ToString(CultureInfo.InvariantCulture);
                break;
            case 2:
                var longId = reader.U64();
                encoded = new WireWriter().U64(longId).ToArray();
                openId = longId.ToString(CultureInfo.InvariantCulture);
                break;
            case 3:
                var length = reader.U32();
                if (length is < 1 or > 256) throw new InvalidDataException("Invalid TGCP OpenId size.");
                var value = reader.Bytes((int)length);
                encoded = new WireWriter().U32(length).Bytes(value).ToArray();
                openId = WireReader.CString(value);
                break;
            default:
                throw new InvalidDataException($"Unsupported TGCP account ID kind {kind}.");
        }
        var gid = reader.U64(); // 账号结构最高版本为 4。
        return new TgcpAccount(category, kind, encoded, openId, gid);
    }

    public byte[] Encode(ulong gid) => new WireWriter().U16(Category).U8(IdKind)
        .Bytes(EncodedId).U64(gid).ToArray();
}

public sealed record TgcpAuth(ushort Type, string AppId, byte[] Data)
{
    // MSDKv3：接口值 0x7FFF，线上值 0xFFFF。
    public const ushort MsdkV3WireType = 0xFFFF;

    public static TgcpAuth Read(WireReader reader) => new(reader.U16(),
        WireReader.CString(reader.Blob16(64)), reader.Blob16(4096));

    public string? AccessToken()
    {
        if (Type != MsdkV3WireType) return null; // 其他渠道的认证格式不同。
        var reader = new WireReader(Data);
        string? accessToken = null;
        for (var i = 0; i < 4; i++)
        {
            var present = reader.U8();
            if (present == 0) continue;
            if (present != 1) throw new InvalidDataException("Invalid MSDKv3 token presence flag.");
            var token = WireReader.CString(reader.Blob16(i == 0 ? 3072 : 256));
            reader.U32();
            reader.U32();
            reader.U64();
            if (i == 0) accessToken = token;
        }
        reader.End();
        return accessToken;
    }
}

public sealed record TgcpSyn(byte KeyType, byte Algorithm, uint AppId, uint ClientType,
    TgcpAccount Account, TgcpAuth? EmbeddedAuth, byte RouteType, ulong RouteId, uint ZoneId, bool HadRelay)
{
    public static TgcpSyn Read(byte[] extension)
    {
        var reader = new WireReader(extension);
        var keyType = reader.U8();
        if (keyType is not (0 or 2))
            throw new NotSupportedException($"Key making {keyType} is not implemented; this client uses Server (2).");
        var algorithm = reader.U8();
        if (algorithm is not (0 or 3) || (algorithm == 3 && keyType != 2))
            throw new NotSupportedException($"Unsupported TGCP encryption {algorithm}/key type {keyType}.");
        var appId = reader.U32();
        var clientType = reader.U32();
        var account = TgcpAccount.Read(reader);
        var relay = reader.U8();
        if (relay > 1) throw new InvalidDataException("Invalid relay flag.");
        if (relay != 0)
        {
            // 读取旧中继信息，本次新建会话。
            reader.U32(); // 中继请求类型。
            reader.U32();
            reader.Bytes(16);
            reader.U64();
        }
        var embedded = reader.U8();
        if (embedded > 1) throw new InvalidDataException("Invalid embedded auth flag.");
        var auth = embedded == 1 ? TgcpAuth.Read(reader) : null;
        reader.U8(); // 版本 ≥5 的预留字段。
        var routeType = reader.U8();
        var route = ReadRoute(reader, routeType);
        reader.U32(); // 版本 ≥5 的客户端扩展。
        reader.End();
        return new TgcpSyn(keyType, algorithm, appId, clientType, account, auth,
            routeType, route.Id, route.Zone, relay == 1);
    }

    public static (ulong Id, uint Zone) ReadRoute(WireReader reader, byte routeType) => routeType switch
    {
        0 or 3 => (0, 0),
        1 => (reader.U32(), reader.U32()),
        2 or 4 => (reader.U64(), 0),
        _ => throw new InvalidDataException($"Unknown route type {routeType}.")
    };
}

using System.Buffers.Binary;
using cs_msg;
using tsf4g_tdr_csharp;

namespace LocalGameServer.Protocol;

public sealed record GameRequest(int Command, long Timestamp, tsf4g_csharp_interface? Body, byte[] Payload);
public sealed record GameResponse(int Command, CSMsgRspBody Union)
{
    public static GameResponse Of<T>(int command, Action<T> initialize) where T : class
    {
        var union = new CSMsgRspBody();
        var selected = union.select(command);
        if (selected is not T body)
            throw new InvalidOperationException($"响应 {command} 类型不符：协议为 " +
                $"{selected?.GetType().Name ?? "无对应消息"}，代码指定 {typeof(T).Name}。");
        initialize(body);
        return new GameResponse(command, union);
    }
}

public static class GameCodec
{
    public static GameRequest Decode(byte[] payload)
    {
        var headLength = StructLength(payload, 0);
        var headerBytes = payload.AsSpan(0, headLength).ToArray();
        var head = new CSMsgReqHead();
        var used = 0;
        Check(head.unpackTLV(ref headerBytes, headerBytes.Length, ref used), "request header");
        if (used != headLength || !head.has_cmdID() || head.cmdID <= 0)
            throw new InvalidDataException("Invalid game request header.");
        var bodyLength = StructLength(payload, headLength);
        if (headLength + bodyLength != payload.Length)
            throw new InvalidDataException("Trailing bytes in game request.");
        var bodyBytes = payload.AsSpan(headLength, bodyLength).ToArray();
        var union = new CSMsgReqBody();
        long selector = head.cmdID;
        used = 0;
        Check(union.unpackTLV(ref selector, ref bodyBytes, bodyBytes.Length, ref used), "request body");
        if (selector != head.cmdID || used != bodyLength)
            throw new InvalidDataException($"Game command/body mismatch: head={head.cmdID}, union={selector}.");
        return new GameRequest(head.cmdID, head.timestamp, union.select(head.cmdID), payload);
    }

    private static int StructLength(byte[] bytes, int offset)
    {
        if (offset < 0 || bytes.Length - offset < 5 || bytes[offset] is not (0x99 or 0xAA))
            throw new InvalidDataException("Invalid TDR TLV magic/length.");
        var length = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(offset + 1, 4));
        if (length < 5 || length > bytes.Length - offset)
            throw new InvalidDataException("Invalid TDR TLV struct length.");
        return length;
    }

    public static byte[] Encode(GameResponse response, int maximum)
    {
        var headerBytes = new byte[64];
        var head = new CSMsgRspHead { cmdID = response.Command };
        var headUsed = 0;
        Check(head.packTLV(ref headerBytes, headerBytes.Length, ref headUsed, false), "response header");
        var bodyBytes = new byte[maximum - headUsed - 64];
        var bodyUsed = 0;
        Check(response.Union.packTLV(response.Command, ref bodyBytes, bodyBytes.Length, ref bodyUsed, false),
            "response body");
        var result = new byte[headUsed + bodyUsed];
        headerBytes.AsSpan(0, headUsed).CopyTo(result);
        bodyBytes.AsSpan(0, bodyUsed).CopyTo(result.AsSpan(headUsed));
        return result;
    }

    private static void Check(TdrError.ErrorType error, string stage)
    {
        if (error != TdrError.ErrorType.TDR_NO_ERROR)
            throw new InvalidDataException($"TDR {stage}: {error}");
    }
}

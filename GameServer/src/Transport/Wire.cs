using System.Buffers.Binary;
using System.Text;

namespace LocalGameServer.Transport;

public sealed class WireReader(byte[] bytes)
{
    public int Position { get; private set; }
    public int Remaining => bytes.Length - Position;
    public byte U8() => Bytes(1)[0];
    public ushort U16() => BinaryPrimitives.ReadUInt16BigEndian(Bytes(2));
    public uint U32() => BinaryPrimitives.ReadUInt32BigEndian(Bytes(4));
    public ulong U64() => BinaryPrimitives.ReadUInt64BigEndian(Bytes(8));

    public byte[] Bytes(int count)
    {
        if (count < 0 || count > Remaining) throw new InvalidDataException("Truncated TGCP field.");
        var result = bytes.AsSpan(Position, count).ToArray();
        Position += count;
        return result;
    }

    public byte[] Blob16(int maximum)
    {
        var length = U16();
        if (length > maximum) throw new InvalidDataException("TGCP field exceeds its schema limit.");
        return Bytes(length);
    }

    public void End()
    {
        if (Remaining != 0) throw new InvalidDataException($"Unexpected TGCP extension ({Remaining} bytes).");
    }

    public static string CString(byte[] value)
    {
        var length = Array.IndexOf(value, (byte)0);
        return new UTF8Encoding(false, true).GetString(value, 0, length < 0 ? value.Length : length);
    }
}

public sealed class WireWriter
{
    private readonly MemoryStream stream = new();
    public WireWriter U8(byte value) { stream.WriteByte(value); return this; }
    public WireWriter U16(ushort value)
    {
        Span<byte> buffer = stackalloc byte[2];
        BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
        stream.Write(buffer);
        return this;
    }
    public WireWriter U32(uint value)
    {
        Span<byte> buffer = stackalloc byte[4];
        BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
        stream.Write(buffer);
        return this;
    }
    public WireWriter U64(ulong value)
    {
        Span<byte> buffer = stackalloc byte[8];
        BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
        stream.Write(buffer);
        return this;
    }
    public WireWriter Bytes(byte[] value) { stream.Write(value); return this; }
    public byte[] ToArray() => stream.ToArray();
}

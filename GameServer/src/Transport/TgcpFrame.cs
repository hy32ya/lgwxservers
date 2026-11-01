using System.Buffers.Binary;
using System.Net.Sockets;

namespace LocalGameServer.Transport;

public sealed record TgcpFrame(ushort Schema, ushort Version, ushort Command, byte Encryption,
    uint Sequence, byte[] Extension, byte[] Body, byte[] Wire)
{
    public const int BaseSize = 21;
    public const ushort Magic = 0x3366;

    public static async Task<TgcpFrame?> ReadAsync(NetworkStream stream, int maximum, CancellationToken cancellation)
    {
        var header = new byte[BaseSize];
        var first = await stream.ReadAsync(header.AsMemory(0, 1), cancellation);
        if (first == 0) return null;
        await stream.ReadExactlyAsync(header.AsMemory(1), cancellation);
        var reader = new WireReader(header);
        if (reader.U16() != Magic)
            throw new InvalidDataException($"Not the supported binary TGCP protocol: {Convert.ToHexString(header)}");
        var schema = reader.U16();
        var version = reader.U16();
        var command = reader.U16();
        var encryption = reader.U8();
        var sequence = reader.U32();
        var headerLength = reader.U32();
        var bodyLength = reader.U32();
        if (headerLength < BaseSize || headerLength > 8192 || (ulong)headerLength + bodyLength > (ulong)maximum)
            throw new InvalidDataException("Invalid TGCP frame length.");
        var wire = new byte[checked((int)(headerLength + bodyLength))];
        header.CopyTo(wire, 0);
        await stream.ReadExactlyAsync(wire.AsMemory(BaseSize), cancellation);
        return new TgcpFrame(schema, version, command, encryption, sequence,
            wire.AsSpan(BaseSize, (int)headerLength - BaseSize).ToArray(),
            wire.AsSpan((int)headerLength).ToArray(), wire);
    }

    public static byte[] Encode(ushort schema, ushort version, ushort command, byte encryption,
        uint sequence, byte[] extension, byte[] body) => new WireWriter()
        .U16(Magic).U16(schema).U16(version).U16(command).U8(encryption).U32(sequence)
        .U32((uint)(BaseSize + extension.Length)).U32((uint)body.Length)
        .Bytes(extension).Bytes(body).ToArray();
}

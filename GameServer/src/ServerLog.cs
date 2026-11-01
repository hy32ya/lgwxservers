using System.Text;
using System.Text.Json;

namespace LocalGameServer;

// 原始帧和明文共用日志容量，超限轮转。
public sealed class ServerLog : IDisposable
{
    private readonly object gate = new();
    private readonly ServerSettings settings;
    private StreamWriter writer;
    private long bytes;
    private bool disposed;
    private string Current => Path.Combine(settings.LogDirectory, "server.jsonl");

    public ServerLog(ServerSettings settings)
    {
        this.settings = settings;
        Directory.CreateDirectory(settings.LogDirectory);
        bytes = File.Exists(Current) ? new FileInfo(Current).Length : 0;
        writer = Open();
    }

    private StreamWriter Open() => new(new FileStream(Current, FileMode.Append, FileAccess.Write,
        FileShare.Read), new UTF8Encoding(false)) { AutoFlush = true };

    public void Write(string session, string kind, object details, bool console = false)
    {
        var line = JsonSerializer.Serialize(new { time = DateTimeOffset.Now, session, kind, details });
        var size = Encoding.UTF8.GetByteCount(line) + 2;
        if (size > settings.MaxLogFileBytes)
        {
            line = JsonSerializer.Serialize(new { time = DateTimeOffset.Now, session,
                kind = "entry_exceeds_log_quota", originalKind = kind, originalBytes = size });
            size = Encoding.UTF8.GetByteCount(line) + 2;
        }
        lock (gate)
        {
            if (disposed) return;
            if (bytes + size > settings.MaxLogFileBytes)
            {
                writer.Dispose();
                for (var i = settings.MaxLogFiles - 1; i >= 1; i--)
                {
                    var from = i == 1 ? Current : Current + "." + (i - 1);
                    var to = Current + "." + i;
                    if (File.Exists(from)) File.Move(from, to, true);
                }
                if (settings.MaxLogFiles == 1) File.Delete(Current);
                bytes = 0;
                writer = Open();
            }
            writer.WriteLine(line);
            bytes += size;
            if (console) Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{session}] {kind}: {JsonSerializer.Serialize(details)}");
        }
    }

    public void Frame(string session, string direction, ushort command, byte[] wire)
    {
        if (settings.CaptureFrames)
            Write(session, "frame", new { direction, command = $"0x{command:X4}", length = wire.Length,
                wireBase64 = Convert.ToBase64String(wire) });
    }

    public void Payload(string session, string direction, int command, byte[] bytes, string? type = null)
    {
        if (settings.CaptureDecodedPayloads)
            Write(session, "payload", new { direction, command, type, length = bytes.Length,
                payloadBase64 = Convert.ToBase64String(bytes) });
    }

    public void Dispose()
    {
        lock (gate)
        {
            if (disposed) return;
            disposed = true;
            writer.Dispose();
        }
    }
}

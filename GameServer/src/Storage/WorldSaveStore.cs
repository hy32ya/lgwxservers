using System.Collections.Concurrent;
using System.Text.Json;

namespace LocalGameServer.Storage;

// 每个世界、玩家独立存档。
public sealed class WorldSaveStore(string dataDirectory)
{
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> Gates = new(StringComparer.OrdinalIgnoreCase);
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public Task<WorldSave?> LoadAsync(ulong workId, ulong gid, CancellationToken ct) =>
        ReadAsync<WorldSave>(Path.Combine("worlds", workId.ToString(), gid + ".json"), ct);

    public Task SaveAsync(WorldSave value, CancellationToken ct) =>
        WriteAsync(Path.Combine("worlds", value.WorkId.ToString(), value.Gid + ".json"), value, ct);

    public async Task<T?> ReadAsync<T>(string relative, CancellationToken ct)
    {
        var path = Path.Combine(dataDirectory, relative);
        var gate = Gates.GetOrAdd(path, _ => new(1, 1));
        await gate.WaitAsync(ct);
        try
        {
            if (!File.Exists(path)) return default;
            await using var file = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<T>(file, Options, ct)
                ?? throw new InvalidDataException("存档内容为空：" + relative);
        }
        finally { gate.Release(); }
    }

    public async Task WriteAsync<T>(string relative, T value, CancellationToken ct)
    {
        var path = Path.Combine(dataDirectory, relative);
        var gate = Gates.GetOrAdd(path, _ => new(1, 1));
        await gate.WaitAsync(ct);
        var temporary = path + ".tmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await using (var file = new FileStream(temporary, FileMode.Create, FileAccess.Write, FileShare.None,
                4096, FileOptions.WriteThrough | FileOptions.Asynchronous))
            {
                await JsonSerializer.SerializeAsync(file, value, Options, ct);
                await file.FlushAsync(ct);
                file.Flush(true);
            }
            File.Move(temporary, path, true);
        }
        finally
        {
            try { if (File.Exists(temporary)) File.Delete(temporary); }
            finally { gate.Release(); }
        }
    }
}

public sealed class WorldSave
{
    public int FormatVersion { get; set; } = 1;
    public ulong WorkId { get; set; }
    public ulong Gid { get; set; }
    public ushort Mode { get; set; }
    public DateTimeOffset SavedAt { get; set; }
    public SavePosition? Position { get; set; }
    public SavePosition? RebirthPosition { get; set; }
    public uint WorldTime { get; set; } = 28800;
    public List<SavedSlot> Inventory { get; set; } = [];
    public ushort GripIndex { get; set; }
    public Dictionary<ushort, int> Attributes { get; set; } = new();
    public Dictionary<int, int> ChallengeProgress { get; set; } = new();
    public HashSet<int> ChallengeRewards { get; set; } = [];
    public int TrackedChallenge { get; set; }
    public double Hunger { get; set; } = 20;
    public double Oxygen { get; set; } = 100;
    public double Exhaustion { get; set; }
    public uint ArchiveProgress { get; set; }
}

public sealed record SavePosition(int X, int Y, int Z);
public sealed record SavedSlot(byte Container, ushort Index, int ItemId, int Count, int Durability);

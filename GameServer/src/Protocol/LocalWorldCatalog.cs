using System.Reflection;
using System.Text.Json;

namespace LocalGameServer.Protocol;

// 客户端原表及本地生存掉落配置。
public sealed class LocalWorldCatalog
{
    private static readonly Lazy<LocalWorldCatalog> shared = new(Load);
    public static LocalWorldCatalog Current => shared.Value;
    public Dictionary<int, ItemDefinition> Items { get; set; } = new();
    public Dictionary<int, BlockDropDefinition> Blocks { get; set; } = new();
    public Dictionary<int, DropEventDefinition> Events { get; set; } = new();
    public Dictionary<int, DropOptionDefinition> Options { get; set; } = new();
    public Dictionary<int, CraftingRecipeDefinition> Recipes { get; set; } = new();
    public Dictionary<int, TreeDropDefinition> SurvivalTreeDrops { get; set; } = new();
    public Dictionary<int, ChallengeDefinition> Challenges { get; set; } = new();
    public Dictionary<uint, ParkBuildingDefinition> ParkBuildings { get; set; } = new();
    public List<LocalParkProtocol.ParkBuilding> ParkStarter { get; set; } = [];
    public sealed class ParkBuildingDefinition
    {
        public uint Prosperity { get; set; }
    }

    public sealed class ChallengeDefinition
    {
        public int Id { get; set; }
        public string Event { get; set; } = "";
        public int Target { get; set; }
        public bool IsTag { get; set; }
        public int Count { get; set; }
        public int[] Prerequisites { get; set; } = [];
        public ChallengeReward[] Rewards { get; set; } = [];
    }

    public sealed class ChallengeReward
    {
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public sealed class TreeDropDefinition
    {
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public sealed class ItemDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Label { get; set; } = "";
        public byte Type { get; set; }
        public int Stack { get; set; } = 1;
        public int Durability { get; set; }
        public int WearPerUse { get; set; } = 10;
        public string Category { get; set; } = "";
        public int FoodLevel { get; set; }
        public int Saturation { get; set; }
        public int BuffId { get; set; }
        public int Cooldown { get; set; }
        public int CooldownGroup { get; set; }
        public int HarvestLevel { get; set; }
        public int Efficiency { get; set; }
        public int[] Tags { get; set; } = [];
    }

    public sealed class CraftingSource
    {
        public int ItemId { get; set; }
        public int Tag { get; set; }
        public int Count { get; set; }
    }

    public sealed class CraftingRecipeDefinition
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public int TargetCount { get; set; }
        public bool InHands { get; set; }
        public int[] WorkbenchBlocks { get; set; } = [];
        public int Gold { get; set; }
        public int Blueprint { get; set; }
        public bool UsableInit { get; set; }
        public CraftingSource[] Sources { get; set; } = [];
    }

    public sealed class WeightedId
    {
        public int Id { get; set; }
        public int Factor { get; set; }
    }

    public sealed class BlockDropDefinition
    {
        public int ItemId { get; set; }
        public int FirstId { get; set; }
        public bool Enabled { get; set; }
        public bool Self { get; set; }
        public List<WeightedId> Events { get; set; } = [];
    }

    public sealed class DropEventDefinition
    {
        public bool Probability { get; set; }
        public List<WeightedId> Choices { get; set; } = [];
    }

    public sealed class DropOptionItem
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Factor { get; set; }
    }

    public sealed class DropOptionDefinition
    {
        public bool Probability { get; set; }
        public List<DropOptionItem> Items { get; set; } = [];
    }

    private static LocalWorldCatalog Load()
    {
        using var source = Assembly.GetExecutingAssembly().GetManifestResourceStream("LocalGameServer.WorldCatalog")
            ?? throw new InvalidDataException("缺少内置物品表。");
        return JsonSerializer.Deserialize<LocalWorldCatalog>(source)
            ?? throw new InvalidDataException("内置物品表为空。");
    }

    public List<(int Id, int Count)> RollBlockDrops(int blockId, bool survival)
    {
        var result = new List<(int, int)>();
        if (!Blocks.TryGetValue(blockId, out var block) || !block.Enabled) return result;
        // 生存砍树替换整树掉落，不叠加发放。
        if (survival && SurvivalTreeDrops.TryGetValue(blockId, out var tree))
        {
            if (Items.ContainsKey(tree.ItemId) && tree.Count is > 0 and <= ushort.MaxValue)
                result.Add((tree.ItemId, tree.Count));
            return result;
        }
        if (block.Self && Items.ContainsKey(block.ItemId)) result.Add((block.ItemId, 1));
        foreach (var eventId in Select(block.Events, false, item => item.Factor))
        {
            if (!Events.TryGetValue(eventId.Id, out var dropEvent)) continue;
            foreach (var optionId in Select(dropEvent.Choices, dropEvent.Probability, item => item.Factor))
            {
                if (!Options.TryGetValue(optionId.Id, out var option)) continue;
                foreach (var item in Select(option.Items, option.Probability, item => item.Factor))
                {
                    if (!Items.ContainsKey(item.Id) || item.Min < 0 || item.Max < item.Min) continue;
                    var count = (int)Random.Shared.NextInt64(item.Min, (long)item.Max + 1);
                    if (count > 0) result.Add((item.Id, count));
                }
            }
        }
        return result;
    }

    private static IEnumerable<T> Select<T>(IReadOnlyList<T> items, bool probability, Func<T, int> factor)
    {
        if (probability)
        {
            foreach (var item in items)
                if (Random.Shared.Next(10000) < Math.Clamp(factor(item), 0, 10000)) yield return item;
            yield break;
        }
        var total = items.Sum(item => (long)Math.Max(0, factor(item)));
        if (total == 0) yield break;
        var selected = Random.Shared.NextInt64(total);
        foreach (var item in items)
        {
            selected -= Math.Max(0, factor(item));
            if (selected >= 0) continue;
            yield return item;
            yield break;
        }
    }
}

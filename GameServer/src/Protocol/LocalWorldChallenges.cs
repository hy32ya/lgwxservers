using cs_msg;
using LocalGameServer.Storage;

namespace LocalGameServer.Protocol;

// 按成功的物品操作推进房间任务。
public sealed class LocalWorldChallenges(ServerLog log, string session, bool enabled)
{
    private readonly Dictionary<int, int> progress = new();
    private readonly HashSet<int> collected = new();
    private int trackingId;
    private static LocalWorldCatalog Catalog => LocalWorldCatalog.Current;

    public void Save(WorldSave save)
    {
        save.ChallengeProgress = new(progress);
        save.ChallengeRewards = new(collected);
        save.TrackedChallenge = trackingId;
    }

    public void Restore(WorldSave save)
    {
        progress.Clear(); collected.Clear();
        foreach (var (id, value) in save.ChallengeProgress)
            if (Catalog.Challenges.TryGetValue(id, out var task))
                progress[id] = Math.Clamp(value, 0, task.Count);
        foreach (var id in save.ChallengeRewards)
            if (Catalog.Challenges.ContainsKey(id)) collected.Add(id);
        trackingId = save.TrackedChallenge;
    }

    public List<GameResponse> InitialResponses() => enabled ? [InfoResponse()] : [];

    private GameResponse InfoResponse() => GameResponse.Of<CSRspChallengeInfo>(
        (int)ECSMsgCmdID.CS_RSP_CHALLENGE_INFO, rsp =>
        {
            var entries = enabled ? Catalog.Challenges.Values.OrderBy(item => item.Id)
                .Select(Snapshot).ToArray() : [];
            rsp.result = 0;
            rsp.trackChallengeID = trackingId;
            rsp.count = checked((ushort)entries.Length);
            Array.Copy(entries, rsp.challengeInfo, entries.Length);
        });

    private bool Unlocked(LocalWorldCatalog.ChallengeDefinition definition) =>
        definition.Prerequisites.All(id => Catalog.Challenges.TryGetValue(id, out var previous) &&
            progress.GetValueOrDefault(id) >= previous.Count);

    private CSChallenge Snapshot(LocalWorldCatalog.ChallengeDefinition definition) => new()
    {
        challengeID = definition.Id,
        value = progress.GetValueOrDefault(definition.Id),
        state = collected.Contains(definition.Id) ? (byte)3 :
            progress.GetValueOrDefault(definition.Id) >= definition.Count ? (byte)2 :
            Unlocked(definition) ? (byte)1 : (byte)0
    };

    public List<GameResponse>? Handle(GameRequest request, LocalInventory inventory)
    {
        switch (request.Body)
        {
            case CSReqChallengeTrack track:
                var result = track.challengeID > 0 && track.bit is 1 or 2
                    ? 0 : (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                if (result == 0)
                {
                    if (track.bit == 1) trackingId = track.challengeID;
                    else if (trackingId == track.challengeID) trackingId = 0;
                }
                log.Write(session, "challenge_track", new { result, track.challengeID, track.bit }, true);
                return [GameResponse.Of<CSRspChallengeTrack>((int)ECSMsgCmdID.CS_RSP_CHALLENGE_TRACK,
                    rsp => { rsp.result = result; rsp.challengeID = track.challengeID; rsp.bit = track.bit; })];
            case CSReqChallengeInfo info when info.mask == 0:
                return [InfoResponse()];
            case CSReqChallengeAward award:
                return Award(award.challengeID, inventory);
            default:
                return null;
        }
    }

    public void Record(List<GameResponse> responses, string eventType, int itemId, int count)
    {
        if (!enabled || count <= 0) return;
        var changed = new List<CSChallenge>();
        foreach (var definition in Catalog.Challenges.Values.OrderBy(item => item.Id))
        {
            var previous = progress.GetValueOrDefault(definition.Id);
            if (definition.Event != eventType || previous >= definition.Count || !Unlocked(definition)) continue;
            var matches = definition.IsTag ? Catalog.Items.TryGetValue(itemId, out var item) &&
                item.Tags.Contains(definition.Target) : itemId == definition.Target;
            if (!matches) continue;
            progress[definition.Id] = (int)Math.Min(definition.Count, (long)previous + count);
            var state = Snapshot(definition);
            changed.Add(state);
            log.Write(session, "challenge_progress", new
            {
                challengeId = definition.Id, eventType, itemId, count,
                value = state.value, target = definition.Count, state = state.state
            }, true);
        }
        if (changed.Count == 0) return;
        responses.Add(GameResponse.Of<CSRspChallengeChange>((int)ECSMsgCmdID.CS_RSP_CHALLENGE_CHANGE, rsp =>
        {
            rsp.count = checked((ushort)changed.Count);
            Array.Copy(changed.ToArray(), rsp.challengeInfo, changed.Count);
        }));
    }

    private List<GameResponse> Award(int id, LocalInventory inventory)
    {
        var result = (int)ECSErrorCode.CS_ERR_TASK_INVALID_ID;
        CSItemData[] changed = [];
        var responses = new List<GameResponse>();
        Catalog.Challenges.TryGetValue(id, out var definition);
        if (enabled && definition != null)
        {
            if (collected.Contains(id)) result = (int)ECSErrorCode.CS_ERR_CHALLENGE_HAVE_AWARD;
            else if (progress.GetValueOrDefault(id) < definition.Count)
                result = (int)ECSErrorCode.CS_ERR_TASK_TARGET_NOT_FINISH;
            else if (definition.Rewards.Any(item => !Catalog.Items.ContainsKey(item.ItemId)))
                result = (int)ECSErrorCode.CS_ERR_SERVR_IS_NOT_OPEN;
            else
            {
                result = inventory.AddMany(definition.Rewards.Select(item => (item.ItemId, item.Count)), out changed);
                if (result == (int)ECSErrorCode.CS_ERR_BAG_ITEM_FULL)
                    result = (int)ECSErrorCode.CS_ERR_CHALLENGE_BAG_FULL;
                if (result == 0) collected.Add(id);
            }
        }
        LocalInventory.AppendChanges(responses, changed);
        responses.Add(GameResponse.Of<CSRspChallengeAward>((int)ECSMsgCmdID.CS_RSP_CHALLENGE_AWARD, rsp =>
        {
            rsp.result = result;
            rsp.challengeInfo = definition != null && enabled ? Snapshot(definition) : new() { challengeID = id };
        }));
        log.Write(session, "challenge_awarded", new { challengeId = id, result }, true);
        if (result == 0)
            foreach (var reward in definition!.Rewards) Record(responses, "GetItems", reward.ItemId, reward.Count);
        return responses;
    }
}

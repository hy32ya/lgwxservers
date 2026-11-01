using cs_msg;
using LocalGameServer.Storage;

namespace LocalGameServer.Protocol;

// 普通生存的基础消耗；教程另走触发器。
public sealed partial class LocalWorldItems
{
    private double hunger = 20;
    private double oxygen = 100;
    private double exhaustion;
    private double starvationSeconds;
    private double recoverySeconds;
    private double drowningSeconds;
    private long lastTick;
    private readonly Dictionary<int, long> foodCooldowns = new();
    private readonly HashSet<uint> attacks = [];
    private readonly Queue<uint> attackOrder = new();
    private int Hp => Value(ECSAttrType.CS_ATTR_CURRENT_HP, challengesEnabled ? 200 : 100);
    private int MaxHp => Value(ECSAttrType.CS_ATTR_MAX_HP, challengesEnabled ? 200 : 100);
    private int MaxHunger => Value(ECSAttrType.CS_ATTR_MAX_HUNGER, challengesEnabled ? 20 : 100);
    private int MaxOxygen => Value(ECSAttrType.CS_ATTR_MAX_OXYGEN, 100);
    private int Value(ECSAttrType type, int fallback) => attributes.GetValueOrDefault((ushort)type, fallback);
    private void Set(ECSAttrType type, int value) => attributes[(ushort)type] = value;

    public void StartClock() => lastTick = Environment.TickCount64;

    public List<GameResponse> InitialSurvival(ulong actorId) => challengesEnabled && Hp <= 0
        ? [GameResponse.Of<CSRspActorDie>((int)ECSMsgCmdID.CS_RSP_ACTOR_DIE,
            rsp => { rsp.actorID = actorId; rsp.dieState = (byte)ECSDieState.CS_DEAD_STATE_DEAD; })] : [];

    public void Save(WorldSave save)
    {
        inventory.Save(save); challenges.Save(save);
        save.Attributes = new(attributes);
        save.Hunger = hunger; save.Oxygen = oxygen; save.Exhaustion = exhaustion;
    }

    public void Restore(WorldSave save)
    {
        inventory.Restore(save); challenges.Restore(save);
        attributes.Clear();
        foreach (var (type, value) in save.Attributes) attributes[type] = value;
        hunger = Math.Clamp(save.Hunger, 0, MaxHunger);
        oxygen = Math.Clamp(save.Oxygen, 0, MaxOxygen);
        exhaustion = Math.Clamp(save.Exhaustion, 0, 4);
        starvationSeconds = recoverySeconds = drowningSeconds = 0;
        Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, (int)Math.Ceiling(hunger));
        Set(ECSAttrType.CS_ATTR_CURRENT_OXYGEN, (int)Math.Ceiling(oxygen));
    }

    private void SyncVitals()
    {
        Set(ECSAttrType.CS_ATTR_MAX_HP, Math.Clamp(MaxHp, 1, 1000000));
        Set(ECSAttrType.CS_ATTR_MAX_HUNGER, Math.Clamp(MaxHunger, 1, 1000000));
        Set(ECSAttrType.CS_ATTR_MAX_OXYGEN, Math.Clamp(MaxOxygen, 1, 1000000));
        Set(ECSAttrType.CS_ATTR_CURRENT_HP, Math.Clamp(Hp, 0, MaxHp));
        if (attributes.TryGetValue((ushort)ECSAttrType.CS_ATTR_CURRENT_HUNGER, out var h))
            hunger = Math.Clamp(h, 0, MaxHunger);
        if (attributes.TryGetValue((ushort)ECSAttrType.CS_ATTR_CURRENT_OXYGEN, out var o))
            oxygen = Math.Clamp(o, 0, MaxOxygen);
        Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, (int)Math.Ceiling(hunger));
        Set(ECSAttrType.CS_ATTR_CURRENT_OXYGEN, (int)Math.Ceiling(oxygen));
    }

    public CSPlayerAttrPoints PlayerAttributes(LocalAccount account) => new()
    {
        maxHp = MaxHp, currentHp = Hp, maxHunger = MaxHunger,
        currentHunger = challengesEnabled ? (int)Math.Ceiling(hunger) :
            Value(ECSAttrType.CS_ATTR_CURRENT_HUNGER, 100),
        maxOxygen = MaxOxygen, currentOxygen = challengesEnabled ? (int)Math.Ceiling(oxygen) : 100,
        maxSp = 100, currSp = 100, currentEnergy = 100,
        speedStealth = 2500, speedRun = challengesEnabled ? 5000 : 5800,
        speedSprint = challengesEnabled ? 7500 : 8000, speedSwim = 3000,
        jumpPower = 8000, physicalAttack = 10, attackDistance = 3000, attackSpeed = 1000,
        tapDistance = 7000, upTapDistance = 7000, downTapDistance = 5000,
        oxygenConsume = challengesEnabled ? 25 : 0,
        harvestLevel = Value(ECSAttrType.CS_ATTR_HARVEST_LEVEL, 1), damageLevel = 1,
        efficiencyProper = Value(ECSAttrType.CS_ATTR_EFFICIENCY_PROPER, 1000), criticalHitDamage = 1500,
        currentInGameCoin = account.Coins, currentExpLevel = account.Level,
        currentExpValue = (int)Math.Min(account.Experience, (uint)int.MaxValue)
    };

    public List<GameResponse> Advance(ulong actorId, IReadOnlyDictionary<int, byte> states)
    {
        var now = Environment.TickCount64;
        var elapsed = lastTick == 0 ? 0 : Math.Clamp((now - lastTick) / 1000d, 0, 10);
        lastTick = now;
        var result = new List<GameResponse>();
        if (!challengesEnabled || Hp <= 0 || elapsed <= 0) return result;
        var previousHunger = (int)Math.Ceiling(hunger);
        var previousOxygen = (int)Math.Ceiling(oxygen);
        var dash = states.GetValueOrDefault((int)ECSPlayerStateType.CS_PLAYER_STATE_DASH) != 0;
        var swim = states.GetValueOrDefault((int)ECSPlayerStateType.CS_PLAYER_STATE_SWIM) != 0;
        // 本地节奏：静置九十秒消耗一点，疾跑和游泳额外消耗。
        hunger = Math.Max(0, hunger - elapsed * (1d / 90 + (dash ? 1d / 45 : swim ? 1d / 60 : 0)));
        var underWater = states.GetValueOrDefault((int)ECSPlayerStateType.CS_PLAYER_STATE_DROWNING) != 0;
        oxygen = Math.Clamp(oxygen + elapsed * (underWater ? -25 : 100), 0, MaxOxygen);
        var values = new List<CSAttrPoint>();
        if (previousHunger != (int)Math.Ceiling(hunger))
            values.Add(new() { attrType = (ushort)ECSAttrType.CS_ATTR_CURRENT_HUNGER, attrValue = (int)Math.Ceiling(hunger) });
        if (previousOxygen != (int)Math.Ceiling(oxygen))
            values.Add(new() { attrType = (ushort)ECSAttrType.CS_ATTR_CURRENT_OXYGEN, attrValue = (int)Math.Ceiling(oxygen) });
        Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, (int)Math.Ceiling(hunger));
        Set(ECSAttrType.CS_ATTR_CURRENT_OXYGEN, (int)Math.Ceiling(oxygen));
        if (values.Count > 0) result.Add(AttributeResponse(actorId, values.ToArray()));
        starvationSeconds = hunger <= 0 ? starvationSeconds + elapsed : 0;
        recoverySeconds = hunger >= MaxHunger * .9 && Hp < MaxHp ? recoverySeconds + elapsed : 0;
        drowningSeconds = underWater && oxygen <= 0 ? drowningSeconds + elapsed : 0;
        while (starvationSeconds >= 8 && Hp > 0)
        { starvationSeconds -= 8; ChangeHp(result, actorId, -1, ECSAttrChangeCauseType.CS_ATTR_CHANGE_HUNGER); }
        while (drowningSeconds >= 1 && Hp > 0)
        { drowningSeconds -= 1; ChangeHp(result, actorId, -4, ECSAttrChangeCauseType.CS_ATTR_CHANGE_DROWNING); }
        while (recoverySeconds >= 8 && Hp > 0 && Hp < MaxHp)
        { recoverySeconds -= 8; ChangeHp(result, actorId, 1, ECSAttrChangeCauseType.CS_ATTR_CHANGE_HUNGER_CIRCLE); }
        return result;
    }

    private void Exhaust(double value, List<GameResponse> responses, ulong actorId)
    {
        var previous = (int)Math.Ceiling(hunger);
        exhaustion += value;
        while (exhaustion >= 4) { exhaustion -= 4; hunger = Math.Max(0, hunger - 1); }
        Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, (int)Math.Ceiling(hunger));
        if (previous != (int)Math.Ceiling(hunger))
            responses.Add(AttributeResponse(actorId, [new CSAttrPoint
            { attrType = (ushort)ECSAttrType.CS_ATTR_CURRENT_HUNGER, attrValue = (int)Math.Ceiling(hunger) }]));
    }

    private void ChangeHp(List<GameResponse> result, ulong actorId, int delta, ECSAttrChangeCauseType cause)
    {
        var previous = Hp;
        var hp = (int)Math.Clamp((long)previous + delta, 0, MaxHp);
        Set(ECSAttrType.CS_ATTR_CURRENT_HP, hp);
        result.Add(GameResponse.Of<CSRspDamageEvent>((int)ECSMsgCmdID.CS_RSP_DAMAGE_EVENT, rsp =>
        { rsp.actorID = actorId; rsp.eventType = (int)cause; rsp.currHp = hp; }));
        if (previous > 0 && hp == 0)
            result.Add(GameResponse.Of<CSRspActorDie>((int)ECSMsgCmdID.CS_RSP_ACTOR_DIE, rsp =>
            { rsp.actorID = actorId; rsp.dieState = (byte)ECSDieState.CS_DEAD_STATE_DEAD; rsp.reason = (int)cause; }));
    }

    private void WearTool(List<GameResponse> result, ulong actorId, int times)
    {
        var changed = inventory.WearHeld(times, out var destroyed);
        LocalInventory.AppendChanges(result, changed);
        if (destroyed == 0) return;
        result.Add(GameResponse.Of<CSRspBagItemDestory>((int)ECSMsgCmdID.CS_RSP_BAG_ITEM_DESTORY,
            rsp => { rsp.destroyItemID = destroyed; rsp.reason = 1; }));
        result.Add(HandAttributes(actorId));
    }

    private List<GameResponse>? HandleSurvival(GameRequest request, ulong actorId)
    {
        if (!challengesEnabled) return null;
        switch (request.Body)
        {
            case CSReqDamageEvent damage:
                if (damage.actorID != actorId || damage.hurtHp <= 0 ||
                    damage.eventType is not (6 or 7 or 9 or 11 or 12))
                    return [Error("伤害参数无效")];
                // 饥饿、溺水由服务端计时，避免重复扣血。
                var hurt = new List<GameResponse>();
                if (Hp > 0) ChangeHp(hurt, actorId, -Math.Min(damage.hurtHp, MaxHp),
                    (ECSAttrChangeCauseType)damage.eventType);
                log.Write(session, "survival_damage", new { actorId, damage.eventType, damage.hurtHp, hp = Hp }, true);
                return hurt;
            case CSReqSkillAttack attack:
                var valid = attack.casterID == actorId && attack.skillID > 0 && Hp > 0;
                var result = new List<GameResponse>
                {
                    GameResponse.Of<CSRspSkillAttack>((int)ECSMsgCmdID.CS_RSP_SKILL_ATTACK, rsp =>
                    {
                        rsp.result = valid ? 0 : InvalidParameter;
                        rsp.skillIdx = attack.skillIdx; rsp.skillID = attack.skillID;
                        rsp.comboNo = attack.comboNo; rsp.casterID = attack.casterID;
                    })
                };
                if (valid && attacks.Add(attack.skillIdx))
                {
                    attackOrder.Enqueue(attack.skillIdx);
                    while (attackOrder.Count > 256) attacks.Remove(attackOrder.Dequeue());
                    WearTool(result, actorId, 1); Exhaust(.3, result, actorId);
                }
                return result;
            case CSReqUseItems use:
                return Eat(use.item, actorId);
            default:
                return null;
        }
    }

    private List<GameResponse> Eat(CSItem source, ulong actorId)
    {
        var result = InvalidParameter;
        CSItemData[] changed = [];
        Catalog.Items.TryGetValue(source.resID, out var item);
        var now = Environment.TickCount64;
        // 药水及附加效果尚未实现，保留物品。
        if (Hp > 0 && item is { Category: "Food", FoodLevel: > 0, BuffId: 0 } &&
            now >= foodCooldowns.GetValueOrDefault(item.CooldownGroup))
        {
            result = inventory.Consume(source, out changed);
            if (result == 0)
            {
                hunger = Math.Min(MaxHunger, hunger + item.FoodLevel / 1000d);
                exhaustion = Math.Max(0, exhaustion - item.Saturation / 1000d);
                Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, (int)Math.Ceiling(hunger));
                foodCooldowns[item.CooldownGroup] = now + Math.Max(0, item.Cooldown);
            }
        }
        var responses = new List<GameResponse>();
        LocalInventory.AppendChanges(responses, changed);
        if (result == 0)
        {
            responses.Add(AttributeResponse(actorId, [new CSAttrPoint
            { attrType = (ushort)ECSAttrType.CS_ATTR_CURRENT_HUNGER, attrValue = (int)Math.Ceiling(hunger) }]));
            responses.Add(HandAttributes(actorId));
        }
        responses.Add(GameResponse.Of<CSRspUseItems>((int)ECSMsgCmdID.CS_RSP_USE_ITEMS,
            rsp => { rsp.errCode = result; rsp.actorID = actorId; rsp.resID = source.resID; }));
        log.Write(session, "survival_eat", new { result, source.resID, hunger }, true);
        return responses;
    }

    public List<GameResponse> Rebirth(CSReqPlayerRebirth request, ulong actorId, CSPosition spawn)
    {
        var valid = challengesEnabled && Hp <= 0 && request.rebirthType == (ushort)ECSRebirthType.CS_REBIRTH_ORIGINAL_POINT;
        if (valid)
        {
            Set(ECSAttrType.CS_ATTR_CURRENT_HP, MaxHp);
            hunger = MaxHunger; oxygen = MaxOxygen; exhaustion = 0;
            Set(ECSAttrType.CS_ATTR_CURRENT_HUNGER, MaxHunger);
            Set(ECSAttrType.CS_ATTR_CURRENT_OXYGEN, MaxOxygen);
            starvationSeconds = recoverySeconds = drowningSeconds = 0;
            StartClock();
        }
        return [GameResponse.Of<CSRspPlayerRebirth>((int)ECSMsgCmdID.CS_RSP_PLAYER_REBIRTH, rsp =>
        {
            rsp.result = valid ? 0 : InvalidParameter; rsp.actorID = actorId; rsp.rebirthType = request.rebirthType;
            rsp.hp = Hp; rsp.hunger = (int)Math.Ceiling(hunger); rsp.oxygen = (int)Math.Ceiling(oxygen);
            rsp.rebirthPos = Copy(spawn);
        })];
    }
}

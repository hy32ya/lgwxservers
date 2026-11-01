// 每次新建对象，替代 Unity 共享对象池。
namespace cs_msg;

public static class CSRspActorAction_Creator { public static CSRspActorAction Create() => new(); }
public static class CSRspActorMove_Creator { public static CSRspActorMove Create() => new(); }
public static class CSRspCircuitBlockChange_Creator { public static CSRspCircuitBlockChange Create() => new(); }
public static class CSRspDirectCast_Creator { public static CSRspDirectCast Create() => new(); }
public static class CSRspGetCellVersion_Creator { public static CSRspGetCellVersion Create() => new(); }
public static class CSRspGetTileData_Creator { public static CSRspGetTileData Create() => new(); }
public static class CSRspMonsterEnterView_Creator { public static CSRspMonsterEnterView Create() => new(); }
public static class CSRspSkillCast_Creator { public static CSRspSkillCast Create() => new(); }
public static class CSRspSkillCharge_Creator { public static CSRspSkillCharge Create() => new(); }
public static class CSRspSkillHit_Creator { public static CSRspSkillHit Create() => new(); }
public static class CSRspTriggerFrameSync_Creator { public static CSRspTriggerFrameSync Create() => new(); }
public static class CSRspTriggerTimerSync_Creator { public static CSRspTriggerTimerSync Create() => new(); }
public static class CSTileQuadruple_Creator { public static CSTileQuadruple Create() => new(); }

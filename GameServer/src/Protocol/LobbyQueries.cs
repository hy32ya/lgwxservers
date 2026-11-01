using cs_msg;

namespace LocalGameServer.Protocol;

// 未配置的活动关闭，列表返回本地空数据。
public static class LobbyQueries
{
    public static GameResponse? Handle(GameRequest request) => request.Body switch
    {
        CSReqGetCloudArchive query => GameResponse.Of<CSRspGetCloudArchive>(
            (int)ECSMsgCmdID.CS_RSP_GET_CLOUD_ARCHIVE, rsp =>
            {
                // 当前没有 UGC 角色云存档。
                rsp.result = query.mask == 0 ? 0 : (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                rsp.count = 0;
            }),
        CSReqGetResLottery => GameResponse.Of<CSRspGetResLottery>((int)ECSMsgCmdID.CS_RSP_GET_LOTTERY_CONF,
            rsp => rsp.result = 0),
        CSReqGetResCalendar => GameResponse.Of<CSRspGetResCalendar>((int)ECSMsgCmdID.CS_RSP_GET_CALENDAR,
            rsp => rsp.result = 0),
        CSReqGetResRandLottery => GameResponse.Of<CSRspGetResRandLottery>((int)ECSMsgCmdID.CS_RSP_GET_RAND_LOTTERY_CONF,
            rsp => rsp.result = 0),
        CSReqGetFlashCardExchangeCfg => GameResponse.Of<CSRspGetFlashCardExchangeCfg>(
            (int)ECSMsgCmdID.CS_RSP_GET_FLASH_CARD_EXCHANGE_CFG, rsp => rsp.count = 0),
        CSReqGetInviteActivityStatusInfo => GameResponse.Of<CSRspGetInviteActivityStatusInfo>(
            (int)ECSMsgCmdID.CS_RSP_GET_INVITE_ACTIVITY_STATUS_INFO, rsp => rsp.successCount = 0),
        CSReqGetResGloableBoss => GameResponse.Of<CSRspGetResGloableBoss>((int)ECSMsgCmdID.CS_RSP_GET_GLOABLE_BOSS_CONF,
            rsp => rsp.result = 0),
        CSReqGetRecentFavoriteWorks favorites => GameResponse.Of<CSRspGetRecentFavoriteWorks>(
            (int)ECSMsgCmdID.CS_RSP_GET_RECENT_FAVORITE_WORKS, rsp =>
            { rsp.owner = favorites.owner; rsp.workCount = 0; }),
        CSReqBatchGetWorkBriefInfo => GameResponse.Of<CSRspBatchGetWorkBriefInfo>(
            (int)ECSMsgCmdID.CS_RSP_BATCH_GET_WORK_BRIEF_INFO, rsp => rsp.count = 0),
        CSReqGetLandData => GameResponse.Of<CSRspGetLandData>((int)ECSMsgCmdID.CS_RSP_GET_LAND_DATA,
            rsp => { rsp.errCode = 0; rsp.level = 1; }),
        CSReqGetZoneCollection => GameResponse.Of<CSRspGetZoneCollection>((int)ECSMsgCmdID.CS_RSP_GET_ZONE_COLLECTION,
            rsp => rsp.rewardCount = 0),
        CSReqGetZoneBuyInfo => GameResponse.Of<CSRspGetZoneBuyInfo>((int)ECSMsgCmdID.CS_RSP_GET_ZONE_BUY_INFO,
            _ => { }),
        CSReqZonePlayerLimitedDiscount => GameResponse.Of<CSRspZonePlayerLimitedDiscount>(
            (int)ECSMsgCmdID.CS_RSP_ZONE_PLAYER_LIMITED_DISCOUNT, rsp => rsp.count = 0),
        CSReqGetFriendEventInfo => GameResponse.Of<CSRspGetFriendEventInfo>((int)ECSMsgCmdID.CS_RSP_GET_FRIEND_EVENT_INFO,
            rsp => rsp.errCode = 0),
        CSReqGetLegoZoneTaskInfo => GameResponse.Of<CSRspGetLegoZoneTaskInfo>((int)ECSMsgCmdID.CS_RSP_GET_LEGO_ZONE_TASK_INFO,
            rsp => { rsp.errCode = 0; rsp.taskInfo.startTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); }),
        CSReqGetResPlayerReturnAct => GameResponse.Of<CSRspGetResPlayerReturnAct>(
            (int)ECSMsgCmdID.CS_RSP_GET_PLAYER_RETURN_ACT, rsp => rsp.result = 0),
        CSReqGiveMinifigureInfo => GameResponse.Of<CSRspGiveMinifigureInfo>((int)ECSMsgCmdID.CS_RSP_GIVE_MINIFIGURE_INFO,
            rsp => rsp.count = 0),
        CSReqGetVehicleShop => GameResponse.Of<CSRspGetVehicleShop>((int)ECSMsgCmdID.CS_RSP_GET_VEHICLE_SHOP,
            rsp => rsp.errCode = 0),
        CSReqGetSuitShop => GameResponse.Of<CSRspGetSuitShop>((int)ECSMsgCmdID.CS_RSP_GET_SUIT_SHOP,
            rsp => rsp.errCode = 0),
        CSReqAllDayTaskInfo => GameResponse.Of<CSRspAllDayTaskInfo>((int)ECSMsgCmdID.CS_RSP_ALL_DAY_TASK_INFO,
            rsp => { rsp.result = 0; rsp.count = 0; }),
        CSReqPullActiveTaskInfo tasks => GameResponse.Of<CSRspPullActiveTaskInfo>(
            (int)ECSMsgCmdID.CS_RSP_PULL_ACTIVE_TASK_INFO, rsp => rsp.type = tasks.type),
        CSReqGetNewBpData => GameResponse.Of<CSRspGetNewBpData>((int)ECSMsgCmdID.CS_RSP_GET_NEW_BP_DATA,
            rsp => rsp.result = 0),
        CSReqSeasonTimeCfg => GameResponse.Of<CSRspSeasonTimeCfg>((int)ECSMsgCmdID.CS_RSP_SEASON_TIME_CFG,
            rsp => rsp.result = 0),
        CSReqSeasonGrowCfg => GameResponse.Of<CSRspSeasonGrowCfg>((int)ECSMsgCmdID.CS_RSP_SEASON_GROW_CFG,
            rsp => rsp.result = 0),
        CSReqGetMyCreatorInfo => GameResponse.Of<CSRspGetMyCreatorInfo>((int)ECSMsgCmdID.CS_RSP_GET_MY_CREATOR_INFO,
            rsp => rsp.errCode = 0),
        CSReqAllSimpleActivityInfo => GameResponse.Of<CSRspAllSimpleActivityInfo>(
            (int)ECSMsgCmdID.CS_RSP_All_SIMPLE_ACTIVITY_INFO, rsp => { rsp.result = 0; rsp.count = 0; }),
        _ => null
    };
}

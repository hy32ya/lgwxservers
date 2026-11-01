namespace cs_msg;

public class MACROS_CS_PUB_DEF
{
	public const int CS_ERRMSG_LEN = 256;

	public const int CS_WORLD_ID_LEN = 64;

	public const int CS_PLAYER_NAME_LEN = 32;

	public const int CS_ACTOR_BUFF_COUNT = 64;

	public const int CS_MAX_ENCHANT_COUNT = 4;

	public const int CS_MAX_ENCHANT_TYPE_COUNT = 5;

	public const int CS_PERMANENT_DURABILITY = int.MaxValue;

	public const int CS_FASHION_BAG_MAX_COUNT = 500;

	public const int CS_USER_SUIT_MAX_COUNT = 20;

	public const int CS_MAX_ROLE_NAME_LENGTH = 32;

	public const int CS_MAX_TEXT_NODE_LEN = 120;

	public const int CS_MAX_CLIENT_LOADING_TIME_OUT = 180;

	public const int CS_MAX_TEXT_NODE_NUM = 8;

	public const int CS_MAX_MOD_ID_COUNT_IN_MAP = 25;

	public const int CS_ACTIVITY_URL_LEN = 60;

	public const int CS_SHOP_PRICE_COUNT = 3;

	public const int CS_MAX_WAITING_AREA_FILE_COUNT = 40;

	public const int CS_ACTIVITY_DESC_LEN = 64;

	public const int CS_ACTIVITY_URL_PARAM_LEN = 256;

	public const int CS_MAX_ITEM_EXCHANGE_CONSUME_COUNT = 6;

	public const int CS_MAX_ITEM_EXCHANGE_TARGET_COUNT = 3;

	public const int CS_MAX_GIFT_BAG_OUTPUT_COUNT = 20;

	public const int CS_MAX_CD_TIME_SYNC_COUNT = 10;

	public const int CS_USER_SUIT_NAME_LEN = 32;

	public const int CS_VEHICLE_BAG_MAX_COUNT = 1000;

	public const int CS_DIY_VEHICLE_MAX_COUNT = 200;

	public const int CS_CREATIVE_UGC_EDIT = 201;

	public const int CS_CREATIVE_UGC_GAMING = 202;

	public const int CS_CREATIVE_UGC_BUILD = 203;

	public const int CS_ARCADE_SURVIVAL_NORMAL = 302;

	public const int CS_ARCADE_SURVIVAL_CREATIVE = 303;

	public const int CS_SURVIVAL_GAME_LEVEL_SIMPLE = 0;

	public const int CS_SURVIVAL_GAME_LEVEL_NORMAL = 1;

	public const int CS_SURVIVAL_GAME_LEVEL_DIFFICULT = 2;

	public const int CS_CD_TIME_USABLE = 1;

	public const int CS_CD_TIME_SKILL = 2;

	public const int CS_CD_TIME_BUILDING = 3;

	public const int CS_TRIGGER_VAR_TYPE_SINGLE = 1;

	public const int CS_TRIGGER_VAR_TYPE_ARRAY = 2;

	public const int CS_ENTER_VIEW_MODE_NONE = 0;

	public const int CS_ENTER_VIEW_MODE_CREATE = 1;

	public const int CS_ENTER_VIEW_MODE_EXIST = 2;

	public const int CS_WEATHER_ID_UNDEFINE = 0;

	public const int CS_WEATHER_ID_SUNNY = 1;

	public const int CS_WEATHER_ID_RAINY = 2;

	public const int CS_WEATHER_ID_WINDY = 3;

	public const int CS_WEATHER_ID_CLOUDY = 4;

	public const int CS_WEATHER_ID_THUNDERING = 5;

	public const int CS_TEXT_STRING_CONTENT = 1;

	public const int CS_TEXT_ITEM_ID = 2;

	public const int CS_TEXT_MONSTER_ID = 3;

	public const int CS_TEXT_PLAYER_OBJID = 4;

	public const int CS_TEXT_ATTACK_PLAYER_OBJID = 5;

	public const int CS_TEXT_TARGET_PLAYER_OBJID = 6;

	public const int CS_TEXT_ITEM_COUNT = 7;

	public const int CS_TEXT_WORK_ID = 8;

	public const int CS_TEXT_ACCOUNT_GID = 9;

	public const int CS_DEAD_STATE_NULL = 0;

	public const int CS_DEAD_STATE_DOWN = 1;

	public const int CS_DEAD_STATE_DEAD = 2;

	public const int CS_ACCOUNT_TYPE_WECHAT = 4098;

	public const int CS_ACCOUNT_TYPE_QQ = 4099;

	public const int CS_BLOCKID_UPDATE_DOOR = 1;

	public const int CS_BLOCKID_UPDATE_CULTIVATE = 2;

	public const int CS_BLOCKID_UPDATE_FURNACE = 3;

	public const int CS_PK_DOWN_NULL = 0;

	public const int CS_PK_DOWN_RESCUER = 1;

	public const int CS_PK_DOWN_BE_RESCUED = 2;

	public const int CS_PK_DOWN_WAIT_RESCUE = 3;

	public const int CS_CURRENCY_INGAME_COIN = 0;

	public const int CS_CURRENCY_DIAMOND = 1;

	public const int CS_CURRENCY_GOLD = 2;

	public const int CS_CURRENCY_COUPON = 3;

	public const int CS_AMMO_NEED_HAVE_CONSUME = 0;

	public const int CS_AMMO_NEED_HAVE_NOT_CONSUME = 1;

	public const int CS_AMMO_NOT_NEED_HAVE = 2;

	public const int CS_STORAGE_ITEM_TYPE_OTHER = 0;

	public const int CS_STORAGE_ITEM_TYPE_NORMAL = 1;

	public const int CS_STORAGE_ITEM_TYPE_FRAGMENT = 2;

	public const int CS_STORAGE_ITEM_TYPE_GIFT_BAG = 3;

	public const int CS_CURRENCY_RESID_INGAME_COIN = 10000001;

	public const int CS_CURRENCY_RESID_GOLD = 10000002;

	public const int CS_CURRENCY_RESID_DIAMOND = 10000003;

	public const int CS_CURRENCY_RESID_COUPON = 10000004;

	public const int CS_ACHV_INTEGRAL_RESID_SURVIVAL = 20000001;

	public const int CS_ACHV_INTEGRAL_RESID_UGC = 20000002;

	public const int CS_ACHV_INTEGRAL_RESID_EDIT = 20000003;

	public const int CS_ACHV_INTEGRAL_RESID_COL = 20000004;

	public const int CS_CAREER_EXP_RESID = 30000001;

	public const int CS_IN_GAMING_EXPERIENCE_POINT_RESID = 40000001;

	public const int CS_NEW_BATTLE_PASS_EXP_RESID = 50000001;

	public const int CS_INVITE_ACTIVITY_SCORE_RESID = 60000001;

	public const int CS_MAY_DAY_ACTIVITY_TREES_EXP_RESID = 60000002;

	public const int CS_TASK_STATE_NULL = 0;

	public const int CS_TASK_STATE_ACCESS = 1;

	public const int CS_TASK_STATE_SUBMIT = 2;

	public const int CS_TASK_STATE_END = 3;

	public const int CS_FUNCTION_TYPE_MODDEV = 1;

	public const int CS_KICKOUT_REASON_DEFAULT = 0;

	public const int CS_KICKOUT_REASON_ROOM_CLOSE = 1;

	public const int CS_KICKOUT_REASON_DONLOAD_TIMEOUT = 2;

	public const int CS_KICKOUT_REASON_LOADING_TIMEOUT = 3;

	public const int CS_OPERA_ADD = 0;

	public const int CS_OPERA_DEL = 1;

	public const int CS_OPERA_REPLACE = 2;

	public const int CS_OPERA_SELL = 3;

	public const int CS_RITE_FIRST_CRAFTING_TABLE = 1;

	public const int CS_RITE_FIRST_ENCHANT_TABLE = 2;

	public const int CS_RITE_FIRST_ALCHEMY_TABLE = 4;

	public const int CS_RITE_FIRST_FURNACE_TABLE = 8;

	public const int CS_RITE_FIRST_TROLLCLUB_RECIPE = 16;

	public const int CS_RITE_FIRST_SWORDMEDUSA_RECIPE = 32;

	public const int CS_RITE_FIRST_MINERHELMET_RECIPE = 64;

	public const int CS_RITE_FIRST_JETPACK_RECIPE = 128;

	public const int CS_RITE_FIRST_RESURRECTIONSCROLL_RECIPE = 256;

	public const int CS_RITE_FIRST_POTIONOFSTRENGTH_RECIPE = 512;

	public const int CS_RITE_FIRST_FROZENBOTTLE_RECIPE = 1024;

	public const int CS_RITE_FIRST_CARBOOSTER_RECIPE = 2048;

	public const int CS_IDIP_PLATID_IOS = 0;

	public const int CS_IDIP_PLATID_ANDROID = 1;

	public const int CS_DIY_VEHICLE_POS_UNDEFINE = 0;

	public const int CS_DIY_VEHICLE_POS_TEMPLATE = 1;

	public const int CS_DIY_VEHICLE_POS_PART1 = 2;

	public const int CS_DIY_VEHICLE_POS_PART2 = 3;

	public const int CS_DIY_VEHICLE_POS_PART3 = 4;

	public const int CS_DIY_VEHICLE_POS_PART4 = 5;

	public const int CS_DIY_VEHICLE_POS_PART5 = 6;

	public const int CS_DIY_VEHICLE_POS_MAX = 7;
}

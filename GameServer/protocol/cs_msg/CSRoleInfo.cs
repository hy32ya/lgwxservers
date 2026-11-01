using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSRoleInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong accountGID;

	public byte deviceType;

	public byte[] roleName;

	public byte level;

	public uint exp;

	public CSRoleStyle roleStyle;

	public ulong actorID;

	public CSFashion fashion;

	public CSMoney money;

	public CSRoleBuildingPaperInfo buildingPaperInfo;

	public int score;

	public uint signState;

	public CSStorageDesc storageDesc;

	public CSRedPointInfo redPointInfo;

	public uint functionCtrl;

	public byte workAudit;

	public byte maxOwnedWorkNum;

	public CSEditWorkInfo ugcEditWork;

	public CSSurvivalGameInfo survivalGameInfo;

	public CSDownloadWorkInfo ugcDwnloadWork;

	public byte accountAuthType;

	public uint shareState;

	public CSGlobalItemCDTime globalItemCDTime;

	public CSVehicle vehicleBag;

	public uint createTime;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roleName = 32u;

	public CSRoleInfo()
	{
		roleName = new byte[32];
		roleStyle = new CSRoleStyle();
		fashion = new CSFashion();
		money = new CSMoney();
		buildingPaperInfo = new CSRoleBuildingPaperInfo();
		storageDesc = new CSStorageDesc();
		redPointInfo = new CSRedPointInfo();
		ugcEditWork = new CSEditWorkInfo();
		survivalGameInfo = new CSSurvivalGameInfo();
		ugcDwnloadWork = new CSDownloadWorkInfo();
		globalItemCDTime = new CSGlobalItemCDTime();
		vehicleBag = new CSVehicle();
	}

	public void set_has_accountGID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_accountGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_accountGID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_deviceType()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_deviceType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_deviceType()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_roleName()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_roleName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_roleName()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_level()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_level()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_level()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_exp()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_exp()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_exp()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_roleStyle()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_roleStyle()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_roleStyle()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_actorID()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_actorID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_actorID()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_fashion()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_fashion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_fashion()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_money()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_money()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_money()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_buildingPaperInfo()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_buildingPaperInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_buildingPaperInfo()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_score()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_score()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_score()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_signState()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_signState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_signState()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_storageDesc()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_storageDesc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_storageDesc()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_redPointInfo()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_redPointInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_redPointInfo()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_functionCtrl()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_functionCtrl()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_functionCtrl()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_workAudit()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_workAudit()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_workAudit()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_maxOwnedWorkNum()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_maxOwnedWorkNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_maxOwnedWorkNum()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_ugcEditWork()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_ugcEditWork()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_ugcEditWork()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_survivalGameInfo()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_survivalGameInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_survivalGameInfo()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_ugcDwnloadWork()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_ugcDwnloadWork()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_ugcDwnloadWork()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_accountAuthType()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_accountAuthType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_accountAuthType()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_shareState()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_shareState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_shareState()
	{
		return (has_bits_[0] & 0x200000) != 0;
	}

	public void set_has_globalItemCDTime()
	{
		has_bits_[0] |= 4194304u;
	}

	private void clear_has_globalItemCDTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4194305);
	}

	public bool has_globalItemCDTime()
	{
		return (has_bits_[0] & 0x400000) != 0;
	}

	public void set_has_vehicleBag()
	{
		has_bits_[0] |= 8388608u;
	}

	private void clear_has_vehicleBag()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8388609);
	}

	public bool has_vehicleBag()
	{
		return (has_bits_[0] & 0x800000) != 0;
	}

	public void set_has_createTime()
	{
		has_bits_[0] |= 16777216u;
	}

	private void clear_has_createTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16777217);
	}

	public bool has_createTime()
	{
		return (has_bits_[0] & 0x1000000) != 0;
	}

	private int requiredFieldNum()
	{
		return 0;
	}

	public string getLastLostRequiredFields()
	{
		return string.Empty;
	}

	public TdrError.ErrorType construct()
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		accountGID = 0uL;
		deviceType = 0;
		level = 0;
		exp = 0u;
		errorType = roleStyle.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		actorID = 0uL;
		errorType = fashion.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = money.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = buildingPaperInfo.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		score = 0;
		signState = 0u;
		errorType = storageDesc.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = redPointInfo.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		functionCtrl = 0u;
		workAudit = 0;
		maxOwnedWorkNum = 0;
		errorType = ugcEditWork.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = survivalGameInfo.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = ugcDwnloadWork.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		accountAuthType = 0;
		shareState = 0u;
		errorType = globalItemCDTime.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = vehicleBag.construct();
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		createTime = 0u;
		return errorType;
	}

	public TdrError.ErrorType packTLV(ref byte[] buffer, int size, ref int used, bool useVarInt)
	{
		if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		TdrWriteBuf destBuf = new TdrWriteBuf(ref buffer, size);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = ((!useVarInt) ? destBuf.writeUInt8(153) : destBuf.writeUInt8(170));
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = destBuf.getUsedSize();
		destBuf.writeInt32(used, usedSize);
		return errorType;
	}

	public TdrError.ErrorType packTLV(ref TdrWriteBuf destBuf, bool useVarInt)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		if (useVarInt)
		{
			uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(accountGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src2 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(accountGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(deviceType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src4 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num = TdrTypeUtil.cstrlen(roleName);
		if (num >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(roleName, num);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src5 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src5, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(level);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src7 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(exp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src8 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(exp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src9 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize2 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = roleStyle.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src10 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src10, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src11 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src11);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(actorID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src12 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(actorID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src13 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src13);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize3 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = fashion.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src14 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src14, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src15 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src15);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize4 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = money.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src16 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src16, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src17 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize5 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = buildingPaperInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src18 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src18, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src19 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src19);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(score);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src20 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src20);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(score);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src21 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src21);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(signState);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src22 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src22);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(signState);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src23 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src23);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize6 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = storageDesc.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src24 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src24, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src25 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src25);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize7 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = redPointInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src26 = destBuf.getUsedSize() - usedSize7 - 4;
		errorType = destBuf.writeInt32(src26, usedSize7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src27 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src27);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(functionCtrl);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src28 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src28);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(functionCtrl);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src29 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src29);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(workAudit);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src30 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src30);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(maxOwnedWorkNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src31 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src31);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize8 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = ugcEditWork.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src32 = destBuf.getUsedSize() - usedSize8 - 4;
		errorType = destBuf.writeInt32(src32, usedSize8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src33 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src33);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize9 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = survivalGameInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src34 = destBuf.getUsedSize() - usedSize9 - 4;
		errorType = destBuf.writeInt32(src34, usedSize9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src35 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src35);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize10 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = ugcDwnloadWork.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src36 = destBuf.getUsedSize() - usedSize10 - 4;
		errorType = destBuf.writeInt32(src36, usedSize10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src37 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src37);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(accountAuthType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src38 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src38);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(shareState);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src39 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src39);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(shareState);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src40 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src40);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize11 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = globalItemCDTime.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src41 = destBuf.getUsedSize() - usedSize11 - 4;
		errorType = destBuf.writeInt32(src41, usedSize11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src42 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src42);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize12 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = vehicleBag.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src43 = destBuf.getUsedSize() - usedSize12 - 4;
		errorType = destBuf.writeInt32(src43, usedSize12);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src44 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src44);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(createTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src45 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src45);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(createTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref byte[] buffer, int size, ref int used)
	{
		if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		if (size < TdrTLV.TLV_MSG_MIN_SIZE)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		TdrReadBuf srcBuf = new TdrReadBuf(ref buffer, size);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		byte dest = 0;
		bool flag = true;
		errorType = srcBuf.readUInt8(ref dest);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		switch (dest)
		{
		case 170:
			flag = true;
			break;
		case 153:
			flag = false;
			break;
		default:
			return TdrError.ErrorType.TDR_ERR_BAD_TLV_MAGIC;
		}
		int dest2 = 0;
		srcBuf.readInt32(ref dest2);
		if (size < dest2)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		errorType = unpackTLV(ref srcBuf, dest2 - TdrTLV.TLV_MSG_MIN_SIZE, flag);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = srcBuf.getUsedSize();
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref TdrReadBuf srcBuf, int length, bool useVarInt)
	{
		if (srcBuf == null || length <= 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		uint dest = 0u;
		uint num = 0u;
		int num2 = 0;
		int usedSize = srcBuf.getUsedSize();
		while (srcBuf.getUsedSize() < usedSize + length)
		{
			errorType = srcBuf.readVarUInt32(ref dest);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			switch (TdrTLV.getFieldId(dest))
			{
			case 1u:
				if (!has_accountGID())
				{
					set_has_accountGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref accountGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref accountGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
				if (!has_deviceType())
				{
					set_has_deviceType();
				}
				errorType = srcBuf.readUInt8(ref deviceType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
			{
				if (!has_roleName())
				{
					set_has_roleName();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref roleName, dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roleName[dest5] = 0;
				break;
			}
			case 4u:
				if (!has_level())
				{
					set_has_level();
				}
				errorType = srcBuf.readUInt8(ref level);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 5u:
				if (!has_exp())
				{
					set_has_exp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref exp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref exp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6u:
			{
				if (!has_roleStyle())
				{
					set_has_roleStyle();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 > 0)
				{
					errorType = roleStyle.unpackTLV(ref srcBuf, dest3, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 7u:
				if (!has_actorID())
				{
					set_has_actorID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref actorID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref actorID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
			{
				if (!has_fashion())
				{
					set_has_fashion();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					errorType = fashion.unpackTLV(ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 9u:
			{
				if (!has_money())
				{
					set_has_money();
				}
				int dest9 = 0;
				errorType = srcBuf.readInt32(ref dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest9 > 0)
				{
					errorType = money.unpackTLV(ref srcBuf, dest9, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 10u:
			{
				if (!has_buildingPaperInfo())
				{
					set_has_buildingPaperInfo();
				}
				int dest11 = 0;
				errorType = srcBuf.readInt32(ref dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest11 > 0)
				{
					errorType = buildingPaperInfo.unpackTLV(ref srcBuf, dest11, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 11u:
				if (!has_score())
				{
					set_has_score();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref score);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref score);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 12u:
				if (!has_signState())
				{
					set_has_signState();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref signState);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref signState);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 13u:
			{
				if (!has_storageDesc())
				{
					set_has_storageDesc();
				}
				int dest13 = 0;
				errorType = srcBuf.readInt32(ref dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest13 > 0)
				{
					errorType = storageDesc.unpackTLV(ref srcBuf, dest13, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 14u:
			{
				if (!has_redPointInfo())
				{
					set_has_redPointInfo();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 > 0)
				{
					errorType = redPointInfo.unpackTLV(ref srcBuf, dest8, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 15u:
				if (!has_functionCtrl())
				{
					set_has_functionCtrl();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref functionCtrl);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref functionCtrl);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 16u:
				if (!has_workAudit())
				{
					set_has_workAudit();
				}
				errorType = srcBuf.readUInt8(ref workAudit);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 20u:
				if (!has_maxOwnedWorkNum())
				{
					set_has_maxOwnedWorkNum();
				}
				errorType = srcBuf.readUInt8(ref maxOwnedWorkNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 17u:
			{
				if (!has_ugcEditWork())
				{
					set_has_ugcEditWork();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 > 0)
				{
					errorType = ugcEditWork.unpackTLV(ref srcBuf, dest2, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 18u:
			{
				if (!has_survivalGameInfo())
				{
					set_has_survivalGameInfo();
				}
				int dest12 = 0;
				errorType = srcBuf.readInt32(ref dest12);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest12 > 0)
				{
					errorType = survivalGameInfo.unpackTLV(ref srcBuf, dest12, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 19u:
			{
				if (!has_ugcDwnloadWork())
				{
					set_has_ugcDwnloadWork();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					errorType = ugcDwnloadWork.unpackTLV(ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 21u:
				if (!has_accountAuthType())
				{
					set_has_accountAuthType();
				}
				errorType = srcBuf.readUInt8(ref accountAuthType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 22u:
				if (!has_shareState())
				{
					set_has_shareState();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref shareState);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref shareState);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 23u:
			{
				if (!has_globalItemCDTime())
				{
					set_has_globalItemCDTime();
				}
				int dest10 = 0;
				errorType = srcBuf.readInt32(ref dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest10 > 0)
				{
					errorType = globalItemCDTime.unpackTLV(ref srcBuf, dest10, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 24u:
			{
				if (!has_vehicleBag())
				{
					set_has_vehicleBag();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 > 0)
				{
					errorType = vehicleBag.unpackTLV(ref srcBuf, dest6, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 25u:
				if (!has_createTime())
				{
					set_has_createTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref createTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref createTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			default:
			{
				uint typeId = TdrTLV.getTypeId(dest);
				errorType = TdrTLV.skipUnknownFields(ref srcBuf, (TdrTLV.TdrTLVTypeId)typeId);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			}
		}
		if (srcBuf.getUsedSize() > usedSize + length)
		{
			return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
		}
		if (num2 < requiredFieldNum())
		{
			return TdrError.ErrorType.TDR_ERR_LOST_REQUIRED_FIELD;
		}
		return errorType;
	}

	public TdrError.ErrorType visualize(ref string buffer, int indent, char separator)
	{
		return TdrError.ErrorType.TDR_ERR_METHOD_NOT_IMPLEMENTED;
	}

	public TdrError.ErrorType visualize(ref TdrVisualBuf destBuf, int indent, char separator)
	{
		return TdrError.ErrorType.TDR_ERR_METHOD_NOT_IMPLEMENTED;
	}
}

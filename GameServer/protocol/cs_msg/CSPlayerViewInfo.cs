using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSPlayerViewInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong objID;

	public ulong accountGID;

	public byte devType;

	public byte[] name;

	public CSRoleStyle roleStyle;

	public CSMoveInfo moveInfo;

	public CSPlayerViewAttr viewAttr;

	public CSBuffList buffList;

	public CSEquipInfo equip;

	public CSWearFashion fashion;

	public byte isHaveHook;

	public CSHookViewInfo hookInfo;

	public CSEnergy energyState;

	public byte pkDownState;

	public CSRecoverPkDown pkDownInfo;

	public CSTeamViewInfo teamInfo;

	public CSSleepViewInfo sleepInfo;

	public byte showFashion;

	public CSViewVehicleInfo vehicleInfo;

	public byte talentLevel;

	public int curTitleID;

	public CSPosition rebirthPos;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_name = 32u;

	public CSPlayerViewInfo()
	{
		name = new byte[32];
		roleStyle = new CSRoleStyle();
		moveInfo = new CSMoveInfo();
		viewAttr = new CSPlayerViewAttr();
		buffList = new CSBuffList();
		equip = new CSEquipInfo();
		fashion = new CSWearFashion();
		hookInfo = new CSHookViewInfo();
		energyState = new CSEnergy();
		pkDownInfo = new CSRecoverPkDown();
		teamInfo = new CSTeamViewInfo();
		sleepInfo = new CSSleepViewInfo();
		vehicleInfo = new CSViewVehicleInfo();
		rebirthPos = new CSPosition();
	}

	public void set_has_objID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_objID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_objID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_accountGID()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_accountGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_accountGID()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_devType()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_devType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_devType()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_name()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_name()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_name()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_roleStyle()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_roleStyle()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_roleStyle()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_moveInfo()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_moveInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_moveInfo()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_viewAttr()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_viewAttr()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_viewAttr()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_buffList()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_buffList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_buffList()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_equip()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_equip()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_equip()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_fashion()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_fashion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_fashion()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_isHaveHook()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_isHaveHook()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_isHaveHook()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_hookInfo()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_hookInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_hookInfo()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_energyState()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_energyState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_energyState()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_pkDownState()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_pkDownState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_pkDownState()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_pkDownInfo()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_pkDownInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_pkDownInfo()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_teamInfo()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_teamInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_teamInfo()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_sleepInfo()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_sleepInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_sleepInfo()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_showFashion()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_showFashion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_showFashion()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_vehicleInfo()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_vehicleInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_vehicleInfo()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_talentLevel()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_talentLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_talentLevel()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_curTitleID()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_curTitleID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_curTitleID()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_rebirthPos()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_rebirthPos()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_rebirthPos()
	{
		return (has_bits_[0] & 0x200000) != 0;
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
		return TdrError.ErrorType.TDR_NO_ERROR;
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
			errorType = destBuf.writeVarUInt64(objID);
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
			errorType = destBuf.writeUInt64(objID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src3);
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
			uint src4 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src4);
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
		uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(devType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src6);
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
		int num = TdrTypeUtil.cstrlen(name);
		if (num >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(name, num);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src7 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src7, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src8 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src8);
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
		int src9 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src9, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src10 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src10);
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
		errorType = moveInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src11 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src11, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src12 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src12);
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
		errorType = viewAttr.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src13 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src13, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src14 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src14);
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
		errorType = buffList.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src15 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src15, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src16 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src16);
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
		errorType = equip.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src17 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src17, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src18 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src18);
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
		errorType = fashion.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src19 = destBuf.getUsedSize() - usedSize7 - 4;
		errorType = destBuf.writeInt32(src19, usedSize7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src20 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src20);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isHaveHook);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (1 < isHaveHook)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (isHaveHook == 1)
		{
			uint src21 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src21);
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
			errorType = hookInfo.packTLV(ref destBuf, useVarInt);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			int src22 = destBuf.getUsedSize() - usedSize8 - 4;
			errorType = destBuf.writeInt32(src22, usedSize8);
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
		int usedSize9 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = energyState.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src24 = destBuf.getUsedSize() - usedSize9 - 4;
		errorType = destBuf.writeInt32(src24, usedSize9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src25 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src25);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(pkDownState);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src26 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src26);
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
		errorType = pkDownInfo.packTLV((int)pkDownState, ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src27 = destBuf.getUsedSize() - usedSize10 - 4;
		errorType = destBuf.writeInt32(src27, usedSize10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src28 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src28);
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
		errorType = teamInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src29 = destBuf.getUsedSize() - usedSize11 - 4;
		errorType = destBuf.writeInt32(src29, usedSize11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src30 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src30);
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
		errorType = sleepInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src31 = destBuf.getUsedSize() - usedSize12 - 4;
		errorType = destBuf.writeInt32(src31, usedSize12);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src32 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src32);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(showFashion);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src33 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src33);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize13 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = vehicleInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src34 = destBuf.getUsedSize() - usedSize13 - 4;
		errorType = destBuf.writeInt32(src34, usedSize13);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src35 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src35);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(talentLevel);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src36 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src36);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(curTitleID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src37 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src37);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(curTitleID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src38 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src38);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize14 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = rebirthPos.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src39 = destBuf.getUsedSize() - usedSize14 - 4;
		errorType = destBuf.writeInt32(src39, usedSize14);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
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
				if (!has_objID())
				{
					set_has_objID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref objID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref objID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
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
			case 3u:
				if (!has_devType())
				{
					set_has_devType();
				}
				errorType = srcBuf.readUInt8(ref devType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 4u:
			{
				if (!has_name())
				{
					set_has_name();
				}
				int dest11 = 0;
				errorType = srcBuf.readInt32(ref dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest11 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref name, dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				name[dest11] = 0;
				break;
			}
			case 5u:
			{
				if (!has_roleStyle())
				{
					set_has_roleStyle();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 > 0)
				{
					errorType = roleStyle.unpackTLV(ref srcBuf, dest8, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 6u:
			{
				if (!has_moveInfo())
				{
					set_has_moveInfo();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					errorType = moveInfo.unpackTLV(ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 7u:
			{
				if (!has_viewAttr())
				{
					set_has_viewAttr();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 > 0)
				{
					errorType = viewAttr.unpackTLV(ref srcBuf, dest2, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 8u:
			{
				if (!has_buffList())
				{
					set_has_buffList();
				}
				int dest14 = 0;
				errorType = srcBuf.readInt32(ref dest14);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest14 > 0)
				{
					errorType = buffList.unpackTLV(ref srcBuf, dest14, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 9u:
			{
				if (!has_equip())
				{
					set_has_equip();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 > 0)
				{
					errorType = equip.unpackTLV(ref srcBuf, dest5, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 10u:
			{
				if (!has_fashion())
				{
					set_has_fashion();
				}
				int dest9 = 0;
				errorType = srcBuf.readInt32(ref dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest9 > 0)
				{
					errorType = fashion.unpackTLV(ref srcBuf, dest9, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 11u:
				if (!has_isHaveHook())
				{
					set_has_isHaveHook();
				}
				errorType = srcBuf.readUInt8(ref isHaveHook);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 12u:
			{
				if (!has_hookInfo())
				{
					set_has_hookInfo();
				}
				int dest10 = 0;
				errorType = srcBuf.readInt32(ref dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest10 > 0)
				{
					errorType = hookInfo.unpackTLV(ref srcBuf, dest10, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				isHaveHook = 1;
				break;
			}
			case 13u:
			{
				if (!has_energyState())
				{
					set_has_energyState();
				}
				int dest15 = 0;
				errorType = srcBuf.readInt32(ref dest15);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest15 > 0)
				{
					errorType = energyState.unpackTLV(ref srcBuf, dest15, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 14u:
				if (!has_pkDownState())
				{
					set_has_pkDownState();
				}
				errorType = srcBuf.readUInt8(ref pkDownState);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 15u:
			{
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 > 0)
				{
					long selector = 0L;
					errorType = pkDownInfo.unpackTLV(ref selector, ref srcBuf, dest6, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					pkDownState = (byte)selector;
				}
				break;
			}
			case 16u:
			{
				if (!has_teamInfo())
				{
					set_has_teamInfo();
				}
				int dest12 = 0;
				errorType = srcBuf.readInt32(ref dest12);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest12 > 0)
				{
					errorType = teamInfo.unpackTLV(ref srcBuf, dest12, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 17u:
			{
				if (!has_sleepInfo())
				{
					set_has_sleepInfo();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					errorType = sleepInfo.unpackTLV(ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 18u:
				if (!has_showFashion())
				{
					set_has_showFashion();
				}
				errorType = srcBuf.readUInt8(ref showFashion);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 19u:
			{
				if (!has_vehicleInfo())
				{
					set_has_vehicleInfo();
				}
				int dest13 = 0;
				errorType = srcBuf.readInt32(ref dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest13 > 0)
				{
					errorType = vehicleInfo.unpackTLV(ref srcBuf, dest13, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 20u:
				if (!has_talentLevel())
				{
					set_has_talentLevel();
				}
				errorType = srcBuf.readUInt8(ref talentLevel);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 21u:
				if (!has_curTitleID())
				{
					set_has_curTitleID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref curTitleID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref curTitleID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 22u:
			{
				if (!has_rebirthPos())
				{
					set_has_rebirthPos();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 > 0)
				{
					errorType = rebirthPos.unpackTLV(ref srcBuf, dest3, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
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

using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSReqBeginPublishWork : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong workID;

	public byte workType;

	public byte[] name;

	public uint size;

	public byte[] description;

	public byte tag;

	public byte isFirstPublish;

	public CSReqAntiData antiData;

	public byte chargeMode;

	public CSChargeModeDetail chargeDetail;

	public int maxPlayerCount;

	public int teamCount;

	public byte isMidJoin;

	public byte instructionCount;

	public CSWorkDescStruct[] instructionDesc;

	public CSModTag modTag;

	public byte isModPatch;

	public uint triggerCount;

	public uint chunkCount;

	public uint editTime;

	public CSWorkAuditMisc auditMisc;

	public ushort modUniqueType;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_name = 32u;

	public static readonly uint LENGTH_description = 423u;

	public CSReqBeginPublishWork()
	{
		name = new byte[32];
		description = new byte[423];
		antiData = new CSReqAntiData();
		chargeDetail = new CSChargeModeDetail();
		instructionDesc = new CSWorkDescStruct[5];
		for (int i = 0; i < 5; i++)
		{
			instructionDesc[i] = new CSWorkDescStruct();
		}
		modTag = new CSModTag();
		auditMisc = new CSWorkAuditMisc();
	}

	public void set_has_workID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_workID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_workID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_workType()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_workType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_workType()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_name()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_name()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_name()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_size()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_size()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_size()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_description()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_description()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_description()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_tag()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_tag()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_tag()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_isFirstPublish()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_isFirstPublish()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_isFirstPublish()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_antiData()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_antiData()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_antiData()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_chargeMode()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_chargeMode()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_chargeMode()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_chargeDetail()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_chargeDetail()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_chargeDetail()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_maxPlayerCount()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_maxPlayerCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_maxPlayerCount()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_teamCount()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_teamCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_teamCount()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_isMidJoin()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_isMidJoin()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_isMidJoin()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_instructionCount()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_instructionCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_instructionCount()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_instructionDesc()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_instructionDesc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_instructionDesc()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_modTag()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_modTag()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_modTag()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_isModPatch()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_isModPatch()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_isModPatch()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_triggerCount()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_triggerCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_triggerCount()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_chunkCount()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_chunkCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_chunkCount()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_editTime()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_editTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_editTime()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_auditMisc()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_auditMisc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_auditMisc()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_modUniqueType()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_modUniqueType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_modUniqueType()
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
			errorType = destBuf.writeVarUInt64(workID);
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
			errorType = destBuf.writeUInt64(workID);
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
		errorType = destBuf.writeUInt8(workType);
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
		int src5 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src5, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(size);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(size);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
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
		int num2 = TdrTypeUtil.cstrlen(description);
		if (num2 >= 423)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(description, num2);
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
		uint src10 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(tag);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src11 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isFirstPublish);
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
		int usedSize3 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = antiData.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src13 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src13, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src14 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src14);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(chargeMode);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src15 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
		errorType = chargeDetail.packTLV((int)chargeMode, ref destBuf, useVarInt);
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
		if (useVarInt)
		{
			uint src17 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src17);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(maxPlayerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src18 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src18);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(maxPlayerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src19 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src19);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(teamCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src20 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src20);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(teamCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src21 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src21);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isMidJoin);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src22 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src22);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(instructionCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (instructionCount > 5)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (instructionCount > 0)
		{
			uint src23 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src23);
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
			for (int i = 0; i < instructionCount; i++)
			{
				int usedSize6 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = instructionDesc[i].packTLV(ref destBuf, useVarInt);
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
			}
			int src25 = destBuf.getUsedSize() - usedSize5 - 4;
			errorType = destBuf.writeInt32(src25, usedSize5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src26 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src26);
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
		errorType = modTag.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src27 = destBuf.getUsedSize() - usedSize7 - 4;
		errorType = destBuf.writeInt32(src27, usedSize7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src28 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src28);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isModPatch);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src29 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src29);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(triggerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src30 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src30);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(triggerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src31 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src31);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(chunkCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src32 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src32);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(chunkCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src33 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src33);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(editTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src34 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(editTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src35 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src35);
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
		errorType = auditMisc.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src36 = destBuf.getUsedSize() - usedSize8 - 4;
		errorType = destBuf.writeInt32(src36, usedSize8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src37 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src37);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(modUniqueType);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src38 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src38);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(modUniqueType);
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
				if (!has_workID())
				{
					set_has_workID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref workID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref workID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
				if (!has_workType())
				{
					set_has_workType();
				}
				errorType = srcBuf.readUInt8(ref workType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
			{
				if (!has_name())
				{
					set_has_name();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref name, dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				name[dest3] = 0;
				break;
			}
			case 4u:
				if (!has_size())
				{
					set_has_size();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref size);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref size);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 5u:
			{
				if (!has_description())
				{
					set_has_description();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 >= 423)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref description, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				description[dest2] = 0;
				break;
			}
			case 6u:
				if (!has_tag())
				{
					set_has_tag();
				}
				errorType = srcBuf.readUInt8(ref tag);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 8u:
				if (!has_isFirstPublish())
				{
					set_has_isFirstPublish();
				}
				errorType = srcBuf.readUInt8(ref isFirstPublish);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
			{
				if (!has_antiData())
				{
					set_has_antiData();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 > 0)
				{
					errorType = antiData.unpackTLV(ref srcBuf, dest8, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 9u:
				if (!has_chargeMode())
				{
					set_has_chargeMode();
				}
				errorType = srcBuf.readUInt8(ref chargeMode);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
			{
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					long selector = 0L;
					errorType = chargeDetail.unpackTLV(ref selector, ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					chargeMode = (byte)selector;
				}
				break;
			}
			case 11u:
				if (!has_maxPlayerCount())
				{
					set_has_maxPlayerCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref maxPlayerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref maxPlayerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 12u:
				if (!has_teamCount())
				{
					set_has_teamCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref teamCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref teamCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 13u:
				if (!has_isMidJoin())
				{
					set_has_isMidJoin();
				}
				errorType = srcBuf.readUInt8(ref isMidJoin);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 14u:
				if (!has_instructionCount())
				{
					set_has_instructionCount();
				}
				errorType = srcBuf.readUInt8(ref instructionCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 15u:
			{
				if (!has_instructionDesc())
				{
					set_has_instructionDesc();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize2 = srcBuf.getUsedSize();
				for (int i = 0; i < 5; i++)
				{
					int dest6 = 0;
					errorType = srcBuf.readInt32(ref dest6);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest6 > 0)
					{
						errorType = instructionDesc[i].unpackTLV(ref srcBuf, dest6, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize2 + dest5)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize2 + dest5)
					{
						instructionCount = (byte)(i + 1);
						break;
					}
				}
				break;
			}
			case 16u:
			{
				if (!has_modTag())
				{
					set_has_modTag();
				}
				int dest9 = 0;
				errorType = srcBuf.readInt32(ref dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest9 > 0)
				{
					errorType = modTag.unpackTLV(ref srcBuf, dest9, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 17u:
				if (!has_isModPatch())
				{
					set_has_isModPatch();
				}
				errorType = srcBuf.readUInt8(ref isModPatch);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 18u:
				if (!has_triggerCount())
				{
					set_has_triggerCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref triggerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref triggerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 19u:
				if (!has_chunkCount())
				{
					set_has_chunkCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref chunkCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref chunkCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 20u:
				if (!has_editTime())
				{
					set_has_editTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref editTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref editTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 21u:
			{
				if (!has_auditMisc())
				{
					set_has_auditMisc();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					errorType = auditMisc.unpackTLV(ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 22u:
				if (!has_modUniqueType())
				{
					set_has_modUniqueType();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref modUniqueType);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref modUniqueType);
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

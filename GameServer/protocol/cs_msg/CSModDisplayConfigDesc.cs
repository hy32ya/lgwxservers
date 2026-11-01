using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSModDisplayConfigDesc : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong modID;

	public byte[] name;

	public byte[] desc;

	public CSModWorldFeatureInfo worldFeatureInfo;

	public uint startTime;

	public uint endTime;

	public byte isActivityLink;

	public uint activityStartLink;

	public uint activityEndLink;

	public byte[] activityLink;

	public byte[] activityLinkDesc;

	public byte[] paint;

	public byte isLimitLevel;

	public uint limitLevel;

	public byte isDisplayInRankList;

	public byte activityType;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_name = 32u;

	public static readonly uint LENGTH_desc = 423u;

	public static readonly uint LENGTH_activityLink = 200u;

	public static readonly uint LENGTH_activityLinkDesc = 200u;

	public static readonly uint LENGTH_paint = 200u;

	public CSModDisplayConfigDesc()
	{
		name = new byte[32];
		desc = new byte[423];
		worldFeatureInfo = new CSModWorldFeatureInfo();
		activityLink = new byte[200];
		activityLinkDesc = new byte[200];
		paint = new byte[200];
	}

	public void set_has_modID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_modID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_modID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_name()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_name()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_name()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_desc()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_desc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_desc()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_worldFeatureInfo()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_worldFeatureInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_worldFeatureInfo()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_startTime()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_startTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_startTime()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_endTime()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_endTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_endTime()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_isActivityLink()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_isActivityLink()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_isActivityLink()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_activityStartLink()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_activityStartLink()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_activityStartLink()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_activityEndLink()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_activityEndLink()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_activityEndLink()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_activityLink()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_activityLink()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_activityLink()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_activityLinkDesc()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_activityLinkDesc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_activityLinkDesc()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_paint()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_paint()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_paint()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_isLimitLevel()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_isLimitLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_isLimitLevel()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_limitLevel()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_limitLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_limitLevel()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_isDisplayInRankList()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_isDisplayInRankList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_isDisplayInRankList()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_activityType()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_activityType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_activityType()
	{
		return (has_bits_[0] & 0x8000) != 0;
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
			errorType = destBuf.writeVarUInt64(modID);
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
			errorType = destBuf.writeUInt64(modID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src3);
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
		int src4 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src4, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src5);
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
		int num2 = TdrTypeUtil.cstrlen(desc);
		if (num2 >= 423)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(desc, num2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src6 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src6, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src7);
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
		errorType = worldFeatureInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src8 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src8, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(startTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src10 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src10);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(startTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src11 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src11);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(endTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src12 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(endTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src13 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src13);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isActivityLink);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src14 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(activityStartLink);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src15 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src15);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(activityStartLink);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src16 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src16);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(activityEndLink);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src17 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src17);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(activityEndLink);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src18 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src18);
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
		int num3 = TdrTypeUtil.cstrlen(activityLink);
		if (num3 >= 200)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(activityLink, num3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src19 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src19, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src20 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src20);
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
		int num4 = TdrTypeUtil.cstrlen(activityLinkDesc);
		if (num4 >= 200)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(activityLinkDesc, num4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src21 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src21, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src22 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src22);
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
		int num5 = TdrTypeUtil.cstrlen(paint);
		if (num5 >= 200)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(paint, num5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src23 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src23, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src24 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src24);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isLimitLevel);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src25 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src25);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(limitLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src26 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src26);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(limitLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src27 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src27);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isDisplayInRankList);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src28 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src28);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(activityType);
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
				if (!has_modID())
				{
					set_has_modID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref modID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref modID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
			{
				if (!has_name())
				{
					set_has_name();
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
				errorType = srcBuf.readCString(ref name, dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				name[dest5] = 0;
				break;
			}
			case 3u:
			{
				if (!has_desc())
				{
					set_has_desc();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 >= 423)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref desc, dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				desc[dest4] = 0;
				break;
			}
			case 4u:
			{
				if (!has_worldFeatureInfo())
				{
					set_has_worldFeatureInfo();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					errorType = worldFeatureInfo.unpackTLV(ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 5u:
				if (!has_startTime())
				{
					set_has_startTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref startTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref startTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6u:
				if (!has_endTime())
				{
					set_has_endTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref endTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref endTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 7u:
				if (!has_isActivityLink())
				{
					set_has_isActivityLink();
				}
				errorType = srcBuf.readUInt8(ref isActivityLink);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 8u:
				if (!has_activityStartLink())
				{
					set_has_activityStartLink();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref activityStartLink);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref activityStartLink);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 9u:
				if (!has_activityEndLink())
				{
					set_has_activityEndLink();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref activityEndLink);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref activityEndLink);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 10u:
			{
				if (!has_activityLink())
				{
					set_has_activityLink();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 >= 200)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref activityLink, dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				activityLink[dest6] = 0;
				break;
			}
			case 11u:
			{
				if (!has_activityLinkDesc())
				{
					set_has_activityLinkDesc();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 >= 200)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref activityLinkDesc, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				activityLinkDesc[dest2] = 0;
				break;
			}
			case 12u:
			{
				if (!has_paint())
				{
					set_has_paint();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 >= 200)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref paint, dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				paint[dest3] = 0;
				break;
			}
			case 13u:
				if (!has_isLimitLevel())
				{
					set_has_isLimitLevel();
				}
				errorType = srcBuf.readUInt8(ref isLimitLevel);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 14u:
				if (!has_limitLevel())
				{
					set_has_limitLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref limitLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref limitLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 15u:
				if (!has_isDisplayInRankList())
				{
					set_has_isDisplayInRankList();
				}
				errorType = srcBuf.readUInt8(ref isDisplayInRankList);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 16u:
				if (!has_activityType())
				{
					set_has_activityType();
				}
				errorType = srcBuf.readUInt8(ref activityType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
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

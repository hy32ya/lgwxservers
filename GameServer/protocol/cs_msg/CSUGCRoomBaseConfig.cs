using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSUGCRoomBaseConfig : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public byte[] roomName;

	public byte midwayJoin;

	public byte maxPlayerNum;

	public CSUGCTeamInfo teamInfo;

	public byte[] password;

	public byte settlementType;

	public CSWorkBaseInfo workBaseInfo;

	public byte[] roomDesc;

	public byte[] authorName;

	public CSAccountKey author;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roomName = 32u;

	public static readonly uint LENGTH_password = 8u;

	public static readonly uint LENGTH_roomDesc = 423u;

	public static readonly uint LENGTH_authorName = 32u;

	public CSUGCRoomBaseConfig()
	{
		roomName = new byte[32];
		teamInfo = new CSUGCTeamInfo();
		password = new byte[8];
		workBaseInfo = new CSWorkBaseInfo();
		roomDesc = new byte[423];
		authorName = new byte[32];
		author = new CSAccountKey();
	}

	public void set_has_roomName()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_roomName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_roomName()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_midwayJoin()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_midwayJoin()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_midwayJoin()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_maxPlayerNum()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_maxPlayerNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_maxPlayerNum()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_teamInfo()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_teamInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_teamInfo()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_password()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_password()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_password()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_settlementType()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_settlementType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_settlementType()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_workBaseInfo()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_workBaseInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_workBaseInfo()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_roomDesc()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_roomDesc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_roomDesc()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_authorName()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_authorName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_authorName()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_author()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_author()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_author()
	{
		return (has_bits_[0] & 0x200) != 0;
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
		uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src);
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
		int num = TdrTypeUtil.cstrlen(roomName);
		if (num >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(roomName, num);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src2 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src2, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(midwayJoin);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src4 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(maxPlayerNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src5 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
		errorType = teamInfo.packTLV(ref destBuf, useVarInt);
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
		uint src7 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
		int num2 = TdrTypeUtil.cstrlen(password);
		if (num2 >= 8)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(password, num2);
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
		uint src9 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(settlementType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src10 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src10);
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
		errorType = workBaseInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src11 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src11, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src12 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src12);
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
		int num3 = TdrTypeUtil.cstrlen(roomDesc);
		if (num3 >= 423)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(roomDesc, num3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src13 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src13, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src14 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src14);
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
		int num4 = TdrTypeUtil.cstrlen(authorName);
		if (num4 >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(authorName, num4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src15 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src15, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src16 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src16);
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
		errorType = author.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src17 = destBuf.getUsedSize() - usedSize7 - 4;
		errorType = destBuf.writeInt32(src17, usedSize7);
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
			{
				if (!has_roomName())
				{
					set_has_roomName();
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
				errorType = srcBuf.readCString(ref roomName, dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roomName[dest5] = 0;
				break;
			}
			case 2u:
				if (!has_midwayJoin())
				{
					set_has_midwayJoin();
				}
				errorType = srcBuf.readUInt8(ref midwayJoin);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
				if (!has_maxPlayerNum())
				{
					set_has_maxPlayerNum();
				}
				errorType = srcBuf.readUInt8(ref maxPlayerNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 4u:
			{
				if (!has_teamInfo())
				{
					set_has_teamInfo();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					errorType = teamInfo.unpackTLV(ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 5u:
			{
				if (!has_password())
				{
					set_has_password();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 >= 8)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref password, dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				password[dest6] = 0;
				break;
			}
			case 8u:
				if (!has_settlementType())
				{
					set_has_settlementType();
				}
				errorType = srcBuf.readUInt8(ref settlementType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 9u:
			{
				if (!has_workBaseInfo())
				{
					set_has_workBaseInfo();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 > 0)
				{
					errorType = workBaseInfo.unpackTLV(ref srcBuf, dest8, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 10u:
			{
				if (!has_roomDesc())
				{
					set_has_roomDesc();
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
				errorType = srcBuf.readCString(ref roomDesc, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roomDesc[dest2] = 0;
				break;
			}
			case 11u:
			{
				if (!has_authorName())
				{
					set_has_authorName();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref authorName, dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				authorName[dest7] = 0;
				break;
			}
			case 12u:
			{
				if (!has_author())
				{
					set_has_author();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 > 0)
				{
					errorType = author.unpackTLV(ref srcBuf, dest3, useVarInt);
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

using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSServerRoomConfig : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public uint shortID;

	public ulong workID;

	public byte[] roomName;

	public byte[] password;

	public byte opennessType;

	public byte[] desc;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roomName = 32u;

	public static readonly uint LENGTH_password = 8u;

	public static readonly uint LENGTH_desc = 423u;

	public CSServerRoomConfig()
	{
		roomName = new byte[32];
		password = new byte[8];
		desc = new byte[423];
	}

	public void set_has_shortID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_shortID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_shortID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_workID()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_workID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_workID()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_roomName()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_roomName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_roomName()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_password()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_password()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_password()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_opennessType()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_opennessType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_opennessType()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_desc()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_desc()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_desc()
	{
		return (has_bits_[0] & 0x20) != 0;
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
			errorType = destBuf.writeVarUInt32(shortID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src2 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(shortID);
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
			errorType = destBuf.writeVarUInt64(workID);
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
			errorType = destBuf.writeUInt64(workID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src5);
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
		int src6 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src6, usedSize);
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
		int usedSize2 = destBuf.getUsedSize();
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
		int src8 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src8, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(opennessType);
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
		int num3 = TdrTypeUtil.cstrlen(desc);
		if (num3 >= 423)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(desc, num3);
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
				if (!has_shortID())
				{
					set_has_shortID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref shortID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref shortID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
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
			case 3u:
			{
				if (!has_roomName())
				{
					set_has_roomName();
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
				errorType = srcBuf.readCString(ref roomName, dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roomName[dest3] = 0;
				break;
			}
			case 4u:
			{
				if (!has_password())
				{
					set_has_password();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 >= 8)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref password, dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				password[dest4] = 0;
				break;
			}
			case 5u:
				if (!has_opennessType())
				{
					set_has_opennessType();
				}
				errorType = srcBuf.readUInt8(ref opennessType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 6u:
			{
				if (!has_desc())
				{
					set_has_desc();
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
				errorType = srcBuf.readCString(ref desc, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				desc[dest2] = 0;
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

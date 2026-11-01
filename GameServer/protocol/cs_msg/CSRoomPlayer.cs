using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSRoomPlayer : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong accGID;

	public byte devType;

	public byte[] roleName;

	public byte teamIdx;

	public byte memberIdx;

	public byte ugcRoomIndex;

	public ushort headPicID;

	public byte downloadStatus;

	public byte gender;

	public ushort authContent;

	public ulong objID;

	public byte level;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roleName = 32u;

	public CSRoomPlayer()
	{
		roleName = new byte[32];
	}

	public void set_has_accGID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_accGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_accGID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_devType()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_devType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_devType()
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

	public void set_has_teamIdx()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_teamIdx()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_teamIdx()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_memberIdx()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_memberIdx()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_memberIdx()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_ugcRoomIndex()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_ugcRoomIndex()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_ugcRoomIndex()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_headPicID()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_headPicID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_headPicID()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_downloadStatus()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_downloadStatus()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_downloadStatus()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_gender()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_gender()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_gender()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_authContent()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_authContent()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_authContent()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_objID()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_objID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_objID()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_level()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_level()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_level()
	{
		return (has_bits_[0] & 0x800) != 0;
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
			errorType = destBuf.writeVarUInt64(accGID);
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
			errorType = destBuf.writeUInt64(accGID);
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
		errorType = destBuf.writeUInt8(devType);
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
		errorType = destBuf.writeUInt8(teamIdx);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src7 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(memberIdx);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src8 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(ugcRoomIndex);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src9 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(headPicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src10 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src10);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(headPicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src11 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(downloadStatus);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src12 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src12);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(gender);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src13 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(authContent);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(authContent);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
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
			uint src16 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
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
		uint src17 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(level);
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
				if (!has_accGID())
				{
					set_has_accGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref accGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref accGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
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
			case 3u:
			{
				if (!has_roleName())
				{
					set_has_roleName();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref roleName, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roleName[dest2] = 0;
				break;
			}
			case 4u:
				if (!has_teamIdx())
				{
					set_has_teamIdx();
				}
				errorType = srcBuf.readUInt8(ref teamIdx);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 5u:
				if (!has_memberIdx())
				{
					set_has_memberIdx();
				}
				errorType = srcBuf.readUInt8(ref memberIdx);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 6u:
				if (!has_ugcRoomIndex())
				{
					set_has_ugcRoomIndex();
				}
				errorType = srcBuf.readUInt8(ref ugcRoomIndex);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
				if (!has_headPicID())
				{
					set_has_headPicID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref headPicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref headPicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
				if (!has_downloadStatus())
				{
					set_has_downloadStatus();
				}
				errorType = srcBuf.readUInt8(ref downloadStatus);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 9u:
				if (!has_gender())
				{
					set_has_gender();
				}
				errorType = srcBuf.readUInt8(ref gender);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
				if (!has_authContent())
				{
					set_has_authContent();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref authContent);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref authContent);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 11u:
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
			case 12u:
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

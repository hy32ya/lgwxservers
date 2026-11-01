using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSStorageBox : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong objID;

	public byte subType;

	public CSPosition pos;

	public byte[] name;

	public ushort count;

	public CSItemData[] data;

	public int validTime;

	public int progress;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_name = 32u;

	public CSStorageBox()
	{
		pos = new CSPosition();
		name = new byte[32];
		data = new CSItemData[30];
		for (int i = 0; i < 30; i++)
		{
			data[i] = new CSItemData();
		}
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

	public void set_has_subType()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_subType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_subType()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_pos()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_pos()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_pos()
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

	public void set_has_count()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_count()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_count()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_data()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_data()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_data()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_validTime()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_validTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_validTime()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_progress()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_progress()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_progress()
	{
		return (has_bits_[0] & 0x80) != 0;
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
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(subType);
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
		errorType = pos.packTLV(ref destBuf, useVarInt);
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
		uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src6);
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
		int src7 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src7, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src8 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(count);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(count);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (count > 30)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (count > 0)
		{
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
			for (int i = 0; i < count; i++)
			{
				int usedSize4 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = data[i].packTLV(ref destBuf, useVarInt);
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
			}
			int src12 = destBuf.getUsedSize() - usedSize3 - 4;
			errorType = destBuf.writeInt32(src12, usedSize3);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src13 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(validTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(validTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(progress);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src16 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(progress);
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
				if (!has_subType())
				{
					set_has_subType();
				}
				errorType = srcBuf.readUInt8(ref subType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
			{
				if (!has_pos())
				{
					set_has_pos();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 > 0)
				{
					errorType = pos.unpackTLV(ref srcBuf, dest5, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 4u:
			{
				if (!has_name())
				{
					set_has_name();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref name, dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				name[dest4] = 0;
				break;
			}
			case 5u:
				if (!has_count())
				{
					set_has_count();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref count);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref count);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6u:
			{
				if (!has_data())
				{
					set_has_data();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize2 = srcBuf.getUsedSize();
				for (int i = 0; i < 30; i++)
				{
					int dest3 = 0;
					errorType = srcBuf.readInt32(ref dest3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest3 > 0)
					{
						errorType = data[i].unpackTLV(ref srcBuf, dest3, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize2 + dest2)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize2 + dest2)
					{
						count = (ushort)(i + 1);
						break;
					}
				}
				break;
			}
			case 7u:
				if (!has_validTime())
				{
					set_has_validTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref validTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref validTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
				if (!has_progress())
				{
					set_has_progress();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref progress);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref progress);
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

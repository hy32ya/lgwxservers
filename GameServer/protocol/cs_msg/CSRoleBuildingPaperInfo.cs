using System;
using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSRoleBuildingPaperInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public sbyte equipCount;

	public sbyte ownCount;

	public int[] paperEquip;

	public int[] paperOwn;

	private uint[] has_bits_ = new uint[1];

	public CSRoleBuildingPaperInfo()
	{
		paperEquip = new int[3];
		paperOwn = new int[32];
	}

	public void set_has_equipCount()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_equipCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_equipCount()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_ownCount()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_ownCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_ownCount()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_paperEquip()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_paperEquip()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_paperEquip()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_paperOwn()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_paperOwn()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_paperOwn()
	{
		return (has_bits_[0] & 8) != 0;
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
		uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeInt8(equipCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src2 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeInt8(ownCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (equipCount < 0)
		{
			return TdrError.ErrorType.TDR_ERR_MINUS_REFER_VALUE;
		}
		if (equipCount > 3)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (equipCount > 0)
			{
				uint src3 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				for (int i = 0; i < equipCount; i++)
				{
					errorType = destBuf.writeVarInt32(paperEquip[i]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src4 = destBuf.getUsedSize() - usedSize - 4;
				errorType = destBuf.writeInt32(src4, usedSize);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (equipCount > 0)
		{
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
			if (equipCount > 0)
			{
				int num = equipCount * 4;
				byte[] src6 = new byte[num];
				Buffer.BlockCopy(paperEquip, 0, src6, 0, num);
				TdrBufUtil.covertBytesOrder(src6, 4);
				errorType = destBuf.writeBytes(ref src6, num);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src7 = destBuf.getUsedSize() - usedSize2 - 4;
			errorType = destBuf.writeInt32(src7, usedSize2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (ownCount < 0)
		{
			return TdrError.ErrorType.TDR_ERR_MINUS_REFER_VALUE;
		}
		if (ownCount > 32)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (ownCount > 0)
			{
				uint src8 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src8);
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
				for (int j = 0; j < ownCount; j++)
				{
					errorType = destBuf.writeVarInt32(paperOwn[j]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src9 = destBuf.getUsedSize() - usedSize3 - 4;
				errorType = destBuf.writeInt32(src9, usedSize3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (ownCount > 0)
		{
			uint src10 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
			if (ownCount > 0)
			{
				int num2 = ownCount * 4;
				byte[] src11 = new byte[num2];
				Buffer.BlockCopy(paperOwn, 0, src11, 0, num2);
				TdrBufUtil.covertBytesOrder(src11, 4);
				errorType = destBuf.writeBytes(ref src11, num2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src12 = destBuf.getUsedSize() - usedSize4 - 4;
			errorType = destBuf.writeInt32(src12, usedSize4);
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
				if (!has_equipCount())
				{
					set_has_equipCount();
				}
				errorType = srcBuf.readInt8(ref equipCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 2u:
				if (!has_ownCount())
				{
					set_has_ownCount();
				}
				errorType = srcBuf.readInt8(ref ownCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
			{
				if (!has_paperEquip())
				{
					set_has_paperEquip();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize3 = srcBuf.getUsedSize();
				if (useVarInt)
				{
					for (int j = 0; j < 3; j++)
					{
						errorType = srcBuf.readVarInt32(ref paperEquip[j]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize3 + dest4)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize3 + dest4)
						{
							equipCount = (sbyte)(j + 1);
							break;
						}
					}
				}
				else
				{
					int num4 = dest4;
					byte[] dest5 = new byte[num4];
					errorType = srcBuf.readBytes(ref dest5, num4);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest5, 4);
					Buffer.BlockCopy(dest5, 0, paperEquip, 0, num4);
				}
				break;
			}
			case 4u:
			{
				if (!has_paperOwn())
				{
					set_has_paperOwn();
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
				if (useVarInt)
				{
					for (int i = 0; i < 32; i++)
					{
						errorType = srcBuf.readVarInt32(ref paperOwn[i]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize2 + dest2)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize2 + dest2)
						{
							ownCount = (sbyte)(i + 1);
							break;
						}
					}
				}
				else
				{
					int num3 = dest2;
					byte[] dest3 = new byte[num3];
					errorType = srcBuf.readBytes(ref dest3, num3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest3, 4);
					Buffer.BlockCopy(dest3, 0, paperOwn, 0, num3);
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

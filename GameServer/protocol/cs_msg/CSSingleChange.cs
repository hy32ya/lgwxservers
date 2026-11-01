using System;
using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSSingleChange : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public CSPosition basePosition;

	public byte areaX;

	public byte areaY;

	public byte areaZ;

	public byte changeType;

	public sbyte offset;

	public byte blockCount;

	public BlockChange[] blockInfo;

	public byte colorCount;

	public ushort[] colorBlockID;

	public byte dropCount;

	public CircuitDropBlock[] dropInfo;

	private uint[] has_bits_ = new uint[1];

	public CSSingleChange()
	{
		basePosition = new CSPosition();
		blockInfo = new BlockChange[255];
		for (int i = 0; i < 255; i++)
		{
			blockInfo[i] = new BlockChange();
		}
		colorBlockID = new ushort[255];
		dropInfo = new CircuitDropBlock[3];
		for (int j = 0; j < 3; j++)
		{
			dropInfo[j] = new CircuitDropBlock();
		}
	}

	public void set_has_basePosition()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_basePosition()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_basePosition()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_areaX()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_areaX()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_areaX()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_areaY()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_areaY()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_areaY()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_areaZ()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_areaZ()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_areaZ()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_changeType()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_changeType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_changeType()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_offset()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_offset()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_offset()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_blockCount()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_blockCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_blockCount()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_blockInfo()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_blockInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_blockInfo()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_colorCount()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_colorCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_colorCount()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_colorBlockID()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_colorBlockID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_colorBlockID()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_dropCount()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_dropCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_dropCount()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_dropInfo()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_dropInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_dropInfo()
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
		errorType = basePosition.packTLV(ref destBuf, useVarInt);
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
		errorType = destBuf.writeUInt8(areaX);
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
		errorType = destBuf.writeUInt8(areaY);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src5 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(areaZ);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src6 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(changeType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src7 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeInt8(offset);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src8 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(blockCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (blockCount > byte.MaxValue)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (blockCount > 0)
		{
			uint src9 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
			for (int i = 0; i < blockCount; i++)
			{
				int usedSize3 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = blockInfo[i].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src10 = destBuf.getUsedSize() - usedSize3 - 4;
				errorType = destBuf.writeInt32(src10, usedSize3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src11 = destBuf.getUsedSize() - usedSize2 - 4;
			errorType = destBuf.writeInt32(src11, usedSize2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src12 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src12);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(colorCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (colorCount > byte.MaxValue)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (colorCount > 0)
			{
				uint src13 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src13);
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
				for (int j = 0; j < colorCount; j++)
				{
					errorType = destBuf.writeVarUInt16(colorBlockID[j]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src14 = destBuf.getUsedSize() - usedSize4 - 4;
				errorType = destBuf.writeInt32(src14, usedSize4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (colorCount > 0)
		{
			uint src15 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src15);
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
			if (colorCount > 0)
			{
				int num = colorCount * 2;
				byte[] src16 = new byte[num];
				Buffer.BlockCopy(colorBlockID, 0, src16, 0, num);
				TdrBufUtil.covertBytesOrder(src16, 2);
				errorType = destBuf.writeBytes(ref src16, num);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src17 = destBuf.getUsedSize() - usedSize5 - 4;
			errorType = destBuf.writeInt32(src17, usedSize5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src18 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src18);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(dropCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (dropCount > 3)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (dropCount > 0)
		{
			uint src19 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src19);
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
			for (int k = 0; k < dropCount; k++)
			{
				int usedSize7 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = dropInfo[k].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src20 = destBuf.getUsedSize() - usedSize7 - 4;
				errorType = destBuf.writeInt32(src20, usedSize7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src21 = destBuf.getUsedSize() - usedSize6 - 4;
			errorType = destBuf.writeInt32(src21, usedSize6);
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
			{
				if (!has_basePosition())
				{
					set_has_basePosition();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 > 0)
				{
					errorType = basePosition.unpackTLV(ref srcBuf, dest6, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 2u:
				if (!has_areaX())
				{
					set_has_areaX();
				}
				errorType = srcBuf.readUInt8(ref areaX);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
				if (!has_areaY())
				{
					set_has_areaY();
				}
				errorType = srcBuf.readUInt8(ref areaY);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 4u:
				if (!has_areaZ())
				{
					set_has_areaZ();
				}
				errorType = srcBuf.readUInt8(ref areaZ);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 5u:
				if (!has_changeType())
				{
					set_has_changeType();
				}
				errorType = srcBuf.readUInt8(ref changeType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 6u:
				if (!has_offset())
				{
					set_has_offset();
				}
				errorType = srcBuf.readInt8(ref offset);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
				if (!has_blockCount())
				{
					set_has_blockCount();
				}
				errorType = srcBuf.readUInt8(ref blockCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 8u:
			{
				if (!has_blockInfo())
				{
					set_has_blockInfo();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize4 = srcBuf.getUsedSize();
				for (int k = 0; k < 255; k++)
				{
					int dest8 = 0;
					errorType = srcBuf.readInt32(ref dest8);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest8 > 0)
					{
						errorType = blockInfo[k].unpackTLV(ref srcBuf, dest8, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize4 + dest7)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize4 + dest7)
					{
						blockCount = (byte)(k + 1);
						break;
					}
				}
				break;
			}
			case 9u:
				if (!has_colorCount())
				{
					set_has_colorCount();
				}
				errorType = srcBuf.readUInt8(ref colorCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
			{
				if (!has_colorBlockID())
				{
					set_has_colorBlockID();
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
					for (int j = 0; j < 255; j++)
					{
						errorType = srcBuf.readVarUInt16(ref colorBlockID[j]);
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
							colorCount = (byte)(j + 1);
							break;
						}
					}
				}
				else
				{
					int num3 = dest4;
					byte[] dest5 = new byte[num3];
					errorType = srcBuf.readBytes(ref dest5, num3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest5, 2);
					Buffer.BlockCopy(dest5, 0, colorBlockID, 0, num3);
				}
				break;
			}
			case 11u:
				if (!has_dropCount())
				{
					set_has_dropCount();
				}
				errorType = srcBuf.readUInt8(ref dropCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 12u:
			{
				if (!has_dropInfo())
				{
					set_has_dropInfo();
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
				for (int i = 0; i < 3; i++)
				{
					int dest3 = 0;
					errorType = srcBuf.readInt32(ref dest3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest3 > 0)
					{
						errorType = dropInfo[i].unpackTLV(ref srcBuf, dest3, useVarInt);
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
						dropCount = (byte)(i + 1);
						break;
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

using System;
using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSRspPullActiveTaskInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public byte type;

	public byte lastDayNum;

	public byte finishTaskNum;

	public byte progressCount;

	public int[] progressID;

	public byte taskCount;

	public CSPullActiveTask[] taskInfo;

	public byte endDayNum;

	private uint[] has_bits_ = new uint[1];

	public CSRspPullActiveTaskInfo()
	{
		progressID = new int[5];
		taskInfo = new CSPullActiveTask[80];
		for (int i = 0; i < 80; i++)
		{
			taskInfo[i] = new CSPullActiveTask();
		}
	}

	public void set_has_type()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_type()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_type()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_lastDayNum()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_lastDayNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_lastDayNum()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_finishTaskNum()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_finishTaskNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_finishTaskNum()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_progressCount()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_progressCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_progressCount()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_progressID()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_progressID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_progressID()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_taskCount()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_taskCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_taskCount()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_taskInfo()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_taskInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_taskInfo()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_endDayNum()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_endDayNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_endDayNum()
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
		uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(type);
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
		errorType = destBuf.writeUInt8(lastDayNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src3 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(finishTaskNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src4 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(progressCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (progressCount > 5)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (progressCount > 0)
			{
				uint src5 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				for (int i = 0; i < progressCount; i++)
				{
					errorType = destBuf.writeVarInt32(progressID[i]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src6 = destBuf.getUsedSize() - usedSize - 4;
				errorType = destBuf.writeInt32(src6, usedSize);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (progressCount > 0)
		{
			uint src7 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
			if (progressCount > 0)
			{
				int num = progressCount * 4;
				byte[] src8 = new byte[num];
				Buffer.BlockCopy(progressID, 0, src8, 0, num);
				TdrBufUtil.covertBytesOrder(src8, 4);
				errorType = destBuf.writeBytes(ref src8, num);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src9 = destBuf.getUsedSize() - usedSize2 - 4;
			errorType = destBuf.writeInt32(src9, usedSize2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src10 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(taskCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (taskCount > 80)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (taskCount > 0)
		{
			uint src11 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src11);
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
			for (int j = 0; j < taskCount; j++)
			{
				int usedSize4 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = taskInfo[j].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src12 = destBuf.getUsedSize() - usedSize4 - 4;
				errorType = destBuf.writeInt32(src12, usedSize4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src13 = destBuf.getUsedSize() - usedSize3 - 4;
			errorType = destBuf.writeInt32(src13, usedSize3);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src14 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src14);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(endDayNum);
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
				if (!has_type())
				{
					set_has_type();
				}
				errorType = srcBuf.readUInt8(ref type);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 2u:
				if (!has_lastDayNum())
				{
					set_has_lastDayNum();
				}
				errorType = srcBuf.readUInt8(ref lastDayNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
				if (!has_finishTaskNum())
				{
					set_has_finishTaskNum();
				}
				errorType = srcBuf.readUInt8(ref finishTaskNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 4u:
				if (!has_progressCount())
				{
					set_has_progressCount();
				}
				errorType = srcBuf.readUInt8(ref progressCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 5u:
			{
				if (!has_progressID())
				{
					set_has_progressID();
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
					for (int i = 0; i < 5; i++)
					{
						errorType = srcBuf.readVarInt32(ref progressID[i]);
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
							progressCount = (byte)(i + 1);
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
					Buffer.BlockCopy(dest3, 0, progressID, 0, num3);
				}
				break;
			}
			case 6u:
				if (!has_taskCount())
				{
					set_has_taskCount();
				}
				errorType = srcBuf.readUInt8(ref taskCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
			{
				if (!has_taskInfo())
				{
					set_has_taskInfo();
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
				for (int j = 0; j < 80; j++)
				{
					int dest5 = 0;
					errorType = srcBuf.readInt32(ref dest5);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest5 > 0)
					{
						errorType = taskInfo[j].unpackTLV(ref srcBuf, dest5, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize3 + dest4)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize3 + dest4)
					{
						taskCount = (byte)(j + 1);
						break;
					}
				}
				break;
			}
			case 8u:
				if (!has_endDayNum())
				{
					set_has_endDayNum();
				}
				errorType = srcBuf.readUInt8(ref endDayNum);
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

using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class CSUnionNode
{
	[FieldOffset(0)]
	public byte[] strContent;

	[FieldOffset(8)]
	public int itemID;

	[FieldOffset(8)]
	public int monsterID;

	[FieldOffset(8)]
	public ulong playerObjID;

	[FieldOffset(8)]
	public ulong attackPlayer;

	[FieldOffset(8)]
	public ulong targetPlayer;

	[FieldOffset(8)]
	public int itemCount;

	[FieldOffset(8)]
	public ulong workID;

	[FieldOffset(8)]
	public ulong accountGID;

	public static readonly uint LENGTH_strContent = 120u;

	public tsf4g_csharp_interface select(long selector)
	{
		return null;
	}

	public TdrError.ErrorType construct(long selector)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		tsf4g_csharp_interface tsf4g_csharp_interface = select(selector);
		if (tsf4g_csharp_interface != null)
		{
			return tsf4g_csharp_interface.construct();
		}
		switch (selector)
		{
		case 1L:
			strContent = new byte[120];
			break;
		case 2L:
			itemID = 0;
			break;
		case 3L:
			monsterID = 0;
			break;
		case 4L:
			playerObjID = 0uL;
			break;
		case 5L:
			attackPlayer = 0uL;
			break;
		case 6L:
			targetPlayer = 0uL;
			break;
		case 7L:
			itemCount = 0;
			break;
		case 8L:
			workID = 0uL;
			break;
		case 9L:
			accountGID = 0uL;
			break;
		}
		return result;
	}

	public TdrError.ErrorType packTLV(long selector, ref byte[] buffer, int size, ref int used, bool useVarInt)
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
		errorType = packTLV(selector, ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = destBuf.getUsedSize();
		destBuf.writeInt32(used, usedSize);
		return errorType;
	}

	public TdrError.ErrorType packTLV(long selector, ref TdrWriteBuf destBuf, bool useVarInt)
	{
		if (destBuf == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		if (selector >= 1 && selector <= 9)
		{
			switch (selector - 1)
			{
			case 0L:
			{
				if (strContent == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src17 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src17);
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
				int num = TdrTypeUtil.cstrlen(strContent);
				if (num >= 120)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(strContent, num);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src18 = destBuf.getUsedSize() - usedSize - 4;
				errorType = destBuf.writeInt32(src18, usedSize);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 1L:
				if (useVarInt)
				{
					uint src5 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src5);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(itemID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src6 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src6);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeInt32(itemID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2L:
				if (useVarInt)
				{
					uint src9 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src9);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(monsterID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src10 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src10);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeInt32(monsterID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 3L:
				if (useVarInt)
				{
					uint src15 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src15);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt64(playerObjID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src16 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src16);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt64(playerObjID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 4L:
				if (useVarInt)
				{
					uint src11 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src11);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt64(attackPlayer);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src12 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src12);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt64(attackPlayer);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 5L:
				if (useVarInt)
				{
					uint src7 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src7);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt64(targetPlayer);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src8 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src8);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt64(targetPlayer);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6L:
				if (useVarInt)
				{
					uint src13 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src13);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(itemCount);
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
					errorType = destBuf.writeInt32(itemCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 7L:
				if (useVarInt)
				{
					uint src3 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
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
					uint src4 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
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
				break;
			case 8L:
				if (useVarInt)
				{
					uint src = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src);
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
					uint src2 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src2);
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
				break;
			}
		}
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref long selector, ref byte[] buffer, int size, ref int used)
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
		int num = dest2 - TdrTLV.TLV_MSG_MIN_SIZE;
		if (num > 0)
		{
			errorType = unpackTLV(ref selector, ref srcBuf, num, flag);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		used = srcBuf.getUsedSize();
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref long selector, ref TdrReadBuf srcBuf, int length, bool useVarInt)
	{
		if (srcBuf == null)
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		if (length == 0)
		{
			return result;
		}
		int usedSize = srcBuf.getUsedSize();
		uint dest = 0u;
		result = srcBuf.readVarUInt32(ref dest);
		if (result != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return result;
		}
		uint fieldId = TdrTLV.getFieldId(dest);
		switch (fieldId)
		{
		case 1u:
		{
			strContent = new byte[120];
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 >= 120)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref strContent, dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			strContent[dest2] = 0;
			break;
		}
		case 2u:
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref itemID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref itemID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 3u:
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref monsterID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref monsterID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 4u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref playerObjID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref playerObjID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 5u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref attackPlayer);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref attackPlayer);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 6u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref targetPlayer);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref targetPlayer);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 7u:
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref itemCount);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref itemCount);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 8u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref workID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref workID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 9u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref accountGID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref accountGID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		default:
		{
			uint typeId = TdrTLV.getTypeId(dest);
			result = TdrTLV.skipUnknownFields(ref srcBuf, (TdrTLV.TdrTLVTypeId)typeId);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			break;
		}
		}
		if (srcBuf.getUsedSize() > usedSize + length)
		{
			return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
		}
		selector = fieldId;
		return result;
	}
}

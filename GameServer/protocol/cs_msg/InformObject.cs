using System;
using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class InformObject
{
	[FieldOffset(8)]
	public ulong workGID;

	[FieldOffset(0)]
	public byte[] commentID;

	[FieldOffset(0)]
	public CSAccountKey playerGID;

	[FieldOffset(0)]
	public byte[] replyID;

	public static readonly uint LENGTH_commentID = 60u;

	public static readonly uint LENGTH_replyID = 60u;

	public tsf4g_csharp_interface select(long selector)
	{
		if (selector == 3)
		{
			Type typeFromHandle = typeof(CSAccountKey);
			if (playerGID == null || !typeFromHandle.IsInstanceOfType(playerGID))
			{
				playerGID = new CSAccountKey();
			}
			return playerGID;
		}
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
			workGID = 0uL;
			break;
		case 2L:
			commentID = new byte[60];
			break;
		case 4L:
			replyID = new byte[60];
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
		if (selector >= 1 && selector <= 4)
		{
			switch (selector - 1)
			{
			case 0L:
				if (useVarInt)
				{
					uint src3 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt64(workGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src4 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src4);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt64(workGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 1L:
			{
				if (commentID == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src5 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				int num2 = TdrTypeUtil.cstrlen(commentID);
				if (num2 >= 60)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(commentID, num2);
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
				break;
			}
			case 2L:
			{
				if (playerGID == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src7 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				errorType = playerGID.packTLV(ref destBuf, useVarInt);
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
				break;
			}
			case 3L:
			{
				if (replyID == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				int num = TdrTypeUtil.cstrlen(replyID);
				if (num >= 60)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(replyID, num);
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
				break;
			}
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
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref workGID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref workGID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 2u:
		{
			commentID = new byte[60];
			int dest4 = 0;
			result = srcBuf.readInt32(ref dest4);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest4 >= 60)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref commentID, dest4);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			commentID[dest4] = 0;
			break;
		}
		case 3u:
		{
			playerGID = new CSAccountKey();
			int dest3 = 0;
			result = srcBuf.readInt32(ref dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest3 > 0)
			{
				result = playerGID.unpackTLV(ref srcBuf, dest3, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 4u:
		{
			replyID = new byte[60];
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 >= 60)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref replyID, dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			replyID[dest2] = 0;
			break;
		}
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

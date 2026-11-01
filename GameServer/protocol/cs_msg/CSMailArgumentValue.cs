using System;
using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class CSMailArgumentValue
{
	[FieldOffset(8)]
	public int valueInt;

	[FieldOffset(0)]
	public byte[] valueString;

	[FieldOffset(0)]
	public CSMailLink valueLink;

	[FieldOffset(8)]
	public int valueFashionId;

	public static readonly uint LENGTH_valueString = 40u;

	public tsf4g_csharp_interface select(long selector)
	{
		if (selector == 3)
		{
			Type typeFromHandle = typeof(CSMailLink);
			if (valueLink == null || !typeFromHandle.IsInstanceOfType(valueLink))
			{
				valueLink = new CSMailLink();
			}
			return valueLink;
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
			valueInt = 0;
			break;
		case 2L:
			valueString = new byte[40];
			break;
		case 4L:
			valueFashionId = 0;
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
					uint src7 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src7);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(valueInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src8 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src8);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeInt32(valueInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 1L:
			{
				if (valueString == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
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
				int num = TdrTypeUtil.cstrlen(valueString);
				if (num >= 40)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(valueString, num);
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
				break;
			}
			case 2L:
			{
				if (valueLink == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
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
				errorType = valueLink.packTLV(ref destBuf, useVarInt);
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
			case 3L:
				if (useVarInt)
				{
					uint src = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(valueFashionId);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src2 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src2);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeInt32(valueFashionId);
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
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref valueInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref valueInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 2u:
		{
			valueString = new byte[40];
			int dest3 = 0;
			result = srcBuf.readInt32(ref dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest3 >= 40)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref valueString, dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			valueString[dest3] = 0;
			break;
		}
		case 3u:
		{
			valueLink = new CSMailLink();
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 > 0)
			{
				result = valueLink.unpackTLV(ref srcBuf, dest2, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 4u:
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref valueFashionId);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref valueFashionId);
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

using System;
using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class CSChatContent
{
	[FieldOffset(8)]
	public int predefineID;

	[FieldOffset(0)]
	public byte[] text;

	[FieldOffset(0)]
	public CSChatInviteJoinInfo inviteJoin;

	[FieldOffset(0)]
	public byte[] loudSpeakers;

	[FieldOffset(0)]
	public CSChatShare share;

	[FieldOffset(0)]
	public CSChatPrivateInviteInfo privateInvite;

	[FieldOffset(0)]
	public CSChatLegoZoneCase legoZoneCase;

	public static readonly uint LENGTH_text = 128u;

	public static readonly uint LENGTH_loudSpeakers = 128u;

	public tsf4g_csharp_interface select(long selector)
	{
		if (selector >= 2 && selector <= 6)
		{
			switch (selector - 2)
			{
			case 0L:
			{
				Type typeFromHandle3 = typeof(CSChatInviteJoinInfo);
				if (inviteJoin == null || !typeFromHandle3.IsInstanceOfType(inviteJoin))
				{
					inviteJoin = new CSChatInviteJoinInfo();
				}
				return inviteJoin;
			}
			case 2L:
			{
				Type typeFromHandle2 = typeof(CSChatShare);
				if (share == null || !typeFromHandle2.IsInstanceOfType(share))
				{
					share = new CSChatShare();
				}
				return share;
			}
			case 3L:
			{
				Type typeFromHandle4 = typeof(CSChatPrivateInviteInfo);
				if (privateInvite == null || !typeFromHandle4.IsInstanceOfType(privateInvite))
				{
					privateInvite = new CSChatPrivateInviteInfo();
				}
				return privateInvite;
			}
			case 4L:
			{
				Type typeFromHandle = typeof(CSChatLegoZoneCase);
				if (legoZoneCase == null || !typeFromHandle.IsInstanceOfType(legoZoneCase))
				{
					legoZoneCase = new CSChatLegoZoneCase();
				}
				return legoZoneCase;
			}
			}
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
		case 0L:
			predefineID = 0;
			break;
		case 1L:
			text = new byte[128];
			break;
		case 3L:
			loudSpeakers = new byte[128];
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
		if (selector >= 0 && selector <= 6)
		{
			switch (selector)
			{
			case 0L:
				if (useVarInt)
				{
					uint src3 = TdrTLV.makeTag(0, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarInt32(predefineID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src4 = TdrTLV.makeTag(0, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src4);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeInt32(predefineID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 1L:
			{
				if (text == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src5 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				int num = TdrTypeUtil.cstrlen(text);
				if (num >= 128)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(text, num);
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
				if (inviteJoin == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src11 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src11);
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
				errorType = inviteJoin.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src12 = destBuf.getUsedSize() - usedSize5 - 4;
				errorType = destBuf.writeInt32(src12, usedSize5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 3L:
			{
				if (loudSpeakers == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src13 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src13);
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
				int num2 = TdrTypeUtil.cstrlen(loudSpeakers);
				if (num2 >= 128)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = destBuf.writeCString(loudSpeakers, num2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src14 = destBuf.getUsedSize() - usedSize6 - 4;
				errorType = destBuf.writeInt32(src14, usedSize6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 4L:
			{
				if (share == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				errorType = share.packTLV(ref destBuf, useVarInt);
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
			case 5L:
			{
				if (privateInvite == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src9);
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
				errorType = privateInvite.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src10 = destBuf.getUsedSize() - usedSize4 - 4;
				errorType = destBuf.writeInt32(src10, usedSize4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 6L:
			{
				if (legoZoneCase == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				errorType = legoZoneCase.packTLV(ref destBuf, useVarInt);
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
		case 0u:
			if (useVarInt)
			{
				result = srcBuf.readVarInt32(ref predefineID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readInt32(ref predefineID);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 1u:
		{
			text = new byte[128];
			int dest5 = 0;
			result = srcBuf.readInt32(ref dest5);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest5 >= 128)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref text, dest5);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			text[dest5] = 0;
			break;
		}
		case 2u:
		{
			inviteJoin = new CSChatInviteJoinInfo();
			int dest4 = 0;
			result = srcBuf.readInt32(ref dest4);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest4 > 0)
			{
				result = inviteJoin.unpackTLV(ref srcBuf, dest4, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 3u:
		{
			loudSpeakers = new byte[128];
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 >= 128)
			{
				return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
			}
			result = srcBuf.readCString(ref loudSpeakers, dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			loudSpeakers[dest2] = 0;
			break;
		}
		case 4u:
		{
			share = new CSChatShare();
			int dest6 = 0;
			result = srcBuf.readInt32(ref dest6);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest6 > 0)
			{
				result = share.unpackTLV(ref srcBuf, dest6, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 5u:
		{
			privateInvite = new CSChatPrivateInviteInfo();
			int dest7 = 0;
			result = srcBuf.readInt32(ref dest7);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest7 > 0)
			{
				result = privateInvite.unpackTLV(ref srcBuf, dest7, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 6u:
		{
			legoZoneCase = new CSChatLegoZoneCase();
			int dest3 = 0;
			result = srcBuf.readInt32(ref dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest3 > 0)
			{
				result = legoZoneCase.unpackTLV(ref srcBuf, dest3, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
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

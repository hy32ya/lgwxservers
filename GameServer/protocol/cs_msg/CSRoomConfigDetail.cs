using System;
using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class CSRoomConfigDetail
{
	[FieldOffset(0)]
	public CSUgcRoomConfigDetail ugcEditRoomConfigDetail;

	[FieldOffset(0)]
	public CSUgcRoomConfigDetail ugcGamingRoomConfigDetail;

	[FieldOffset(0)]
	public CSUgcRoomConfigDetail ugcBuildRoomConfigDetail;

	[FieldOffset(0)]
	public CSSurvivalRoomConfigDetail survivalNormalConfigDetail;

	[FieldOffset(0)]
	public CSSurvivalRoomConfigDetail survivalCreativeConfigDetail;

	public tsf4g_csharp_interface select(long selector)
	{
		if (selector >= 201 && selector <= 203)
		{
			switch (selector - 201)
			{
			case 0L:
			{
				Type typeFromHandle2 = typeof(CSUgcRoomConfigDetail);
				if (ugcEditRoomConfigDetail == null || !typeFromHandle2.IsInstanceOfType(ugcEditRoomConfigDetail))
				{
					ugcEditRoomConfigDetail = new CSUgcRoomConfigDetail();
				}
				return ugcEditRoomConfigDetail;
			}
			case 1L:
			{
				Type typeFromHandle3 = typeof(CSUgcRoomConfigDetail);
				if (ugcGamingRoomConfigDetail == null || !typeFromHandle3.IsInstanceOfType(ugcGamingRoomConfigDetail))
				{
					ugcGamingRoomConfigDetail = new CSUgcRoomConfigDetail();
				}
				return ugcGamingRoomConfigDetail;
			}
			case 2L:
			{
				Type typeFromHandle = typeof(CSUgcRoomConfigDetail);
				if (ugcBuildRoomConfigDetail == null || !typeFromHandle.IsInstanceOfType(ugcBuildRoomConfigDetail))
				{
					ugcBuildRoomConfigDetail = new CSUgcRoomConfigDetail();
				}
				return ugcBuildRoomConfigDetail;
			}
			}
		}
		switch (selector)
		{
		case 302L:
		{
			Type typeFromHandle5 = typeof(CSSurvivalRoomConfigDetail);
			if (survivalNormalConfigDetail == null || !typeFromHandle5.IsInstanceOfType(survivalNormalConfigDetail))
			{
				survivalNormalConfigDetail = new CSSurvivalRoomConfigDetail();
			}
			return survivalNormalConfigDetail;
		}
		case 303L:
		{
			Type typeFromHandle4 = typeof(CSSurvivalRoomConfigDetail);
			if (survivalCreativeConfigDetail == null || !typeFromHandle4.IsInstanceOfType(survivalCreativeConfigDetail))
			{
				survivalCreativeConfigDetail = new CSSurvivalRoomConfigDetail();
			}
			return survivalCreativeConfigDetail;
		}
		default:
			return null;
		}
	}

	public TdrError.ErrorType construct(long selector)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		return select(selector)?.construct() ?? errorType;
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
		if (selector >= 201 && selector <= 203)
		{
			switch (selector - 201)
			{
			case 0L:
				goto IL_005b;
			case 1L:
				goto IL_00d8;
			case 2L:
				goto IL_015c;
			}
		}
		switch (selector)
		{
		case 302L:
		{
			if (survivalNormalConfigDetail == null)
			{
				return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
			}
			uint src3 = TdrTLV.makeTag(302, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src3);
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
			errorType = survivalNormalConfigDetail.packTLV(ref destBuf, useVarInt);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			int src4 = destBuf.getUsedSize() - usedSize2 - 4;
			errorType = destBuf.writeInt32(src4, usedSize2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			break;
		}
		case 303L:
		{
			if (survivalCreativeConfigDetail == null)
			{
				return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
			}
			uint src = TdrTLV.makeTag(303, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
			errorType = survivalCreativeConfigDetail.packTLV(ref destBuf, useVarInt);
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
		goto IL_02ed;
		IL_00d8:
		if (ugcGamingRoomConfigDetail == null)
		{
			return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
		}
		uint src5 = TdrTLV.makeTag(202, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src5);
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
		errorType = ugcGamingRoomConfigDetail.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src6 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src6, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		goto IL_02ed;
		IL_02ed:
		return errorType;
		IL_015c:
		if (ugcBuildRoomConfigDetail == null)
		{
			return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
		}
		uint src7 = TdrTLV.makeTag(203, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src7);
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
		errorType = ugcBuildRoomConfigDetail.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src8 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src8, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		goto IL_02ed;
		IL_005b:
		if (ugcEditRoomConfigDetail == null)
		{
			return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
		}
		uint src9 = TdrTLV.makeTag(201, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src9);
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
		errorType = ugcEditRoomConfigDetail.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src10 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src10, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		goto IL_02ed;
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
		case 201u:
		{
			ugcEditRoomConfigDetail = new CSUgcRoomConfigDetail();
			int dest5 = 0;
			result = srcBuf.readInt32(ref dest5);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest5 > 0)
			{
				result = ugcEditRoomConfigDetail.unpackTLV(ref srcBuf, dest5, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 202u:
		{
			ugcGamingRoomConfigDetail = new CSUgcRoomConfigDetail();
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 > 0)
			{
				result = ugcGamingRoomConfigDetail.unpackTLV(ref srcBuf, dest2, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 203u:
		{
			ugcBuildRoomConfigDetail = new CSUgcRoomConfigDetail();
			int dest6 = 0;
			result = srcBuf.readInt32(ref dest6);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest6 > 0)
			{
				result = ugcBuildRoomConfigDetail.unpackTLV(ref srcBuf, dest6, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 302u:
		{
			survivalNormalConfigDetail = new CSSurvivalRoomConfigDetail();
			int dest4 = 0;
			result = srcBuf.readInt32(ref dest4);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest4 > 0)
			{
				result = survivalNormalConfigDetail.unpackTLV(ref srcBuf, dest4, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 303u:
		{
			survivalCreativeConfigDetail = new CSSurvivalRoomConfigDetail();
			int dest3 = 0;
			result = srcBuf.readInt32(ref dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest3 > 0)
			{
				result = survivalCreativeConfigDetail.unpackTLV(ref srcBuf, dest3, useVarInt);
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

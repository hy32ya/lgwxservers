namespace tsf4g_tdr_csharp;

public class TdrTLV
{
	public enum TLV_MAGIC
	{
		TLV_MAGIC_VARINT = 170,
		TLV_MAGIC_NOVARINT = 153
	}

	public enum TdrTLVTypeId
	{
		TDR_TYPE_ID_VARINT,
		TDR_TYPE_ID_1_BYTE,
		TDR_TYPE_ID_2_BYTE,
		TDR_TYPE_ID_4_BYTE,
		TDR_TYPE_ID_8_BYTE,
		TDR_TYPE_ID_LENGTH_DELIMITED
	}

	public static readonly int TLV_MSG_MAGIC_SIZE = 1;

	public static readonly int TLV_MSG_MIN_SIZE = 5;

	public static uint makeTag(int id, TdrTLVTypeId type)
	{
		return (uint)(id << 4) | (uint)type;
	}

	public static uint getFieldId(uint tagid)
	{
		return tagid >> 4;
	}

	public static uint getTypeId(uint tagid)
	{
		return tagid & 0xF;
	}

	public static int getMsgSize(ref byte[] buffer, int size)
	{
		if (buffer == null || size < TLV_MSG_MIN_SIZE)
		{
			return -1;
		}
		int dest = 0;
		TdrReadBuf tdrReadBuf = new TdrReadBuf(ref buffer, size);
		tdrReadBuf.readInt32(ref dest, TLV_MSG_MAGIC_SIZE);
		return dest;
	}

	public static TdrError.ErrorType skipUnknownFields(ref TdrReadBuf srcBuf, TdrTLVTypeId type_id)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		switch (type_id)
		{
		case TdrTLVTypeId.TDR_TYPE_ID_VARINT:
		{
			long dest2 = 0L;
			return srcBuf.readVarInt64(ref dest2);
		}
		case TdrTLVTypeId.TDR_TYPE_ID_1_BYTE:
			return srcBuf.skipForward(1);
		case TdrTLVTypeId.TDR_TYPE_ID_2_BYTE:
			return srcBuf.skipForward(2);
		case TdrTLVTypeId.TDR_TYPE_ID_4_BYTE:
			return srcBuf.skipForward(4);
		case TdrTLVTypeId.TDR_TYPE_ID_8_BYTE:
			return srcBuf.skipForward(8);
		case TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED:
		{
			int dest = 0;
			errorType = srcBuf.readInt32(ref dest);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			return srcBuf.skipForward(dest);
		}
		default:
			return TdrError.ErrorType.TDR_ERR_UNKNOWN_TYPE_ID;
		}
	}
}

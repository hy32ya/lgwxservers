using System;
using System.Net;
using System.Text;

namespace tsf4g_tdr_csharp;

public class TdrWriteBuf
{
	private byte[] beginPtr;

	private int position;

	private int length;

	public TdrWriteBuf()
	{
		beginPtr = null;
		position = 0;
		length = 0;
	}

	public TdrWriteBuf(ref byte[] ptr, int len)
	{
		_set(ref ptr, len);
	}

	public TdrWriteBuf(int len)
	{
		beginPtr = new byte[len];
		position = 0;
		length = 0;
		if (beginPtr != null)
		{
			length = len;
		}
	}

	private void _set(ref byte[] ptr, int len)
	{
		beginPtr = ptr;
		position = 0;
		length = 0;
		if (beginPtr != null)
		{
			length = len;
		}
	}

	private void _reset()
	{
		position = 0;
		length = 0;
		beginPtr = null;
	}

	public void reset()
	{
		_reset();
	}

	public void set(ref byte[] ptr, int len)
	{
		_set(ref ptr, len);
	}

	public int getUsedSize()
	{
		return position;
	}

	public int getTotalSize()
	{
		return length;
	}

	public int getLeftSize()
	{
		return length - position;
	}

	public byte[] getBeginPtr()
	{
		return beginPtr;
	}

	public TdrError.ErrorType reserve(int gap)
	{
		if (position > length)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (gap > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		position += gap;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeInt8(sbyte src)
	{
		return writeUInt8((byte)src);
	}

	public TdrError.ErrorType writeUInt8(byte src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (1 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		beginPtr[position++] = src;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt16(ushort src)
	{
		return writeInt16((short)src);
	}

	public TdrError.ErrorType writeInt16(short src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[position] = (byte)(src >> 8);
			beginPtr[position + 1] = (byte)src;
		}
		else
		{
			beginPtr[position] = (byte)src;
			beginPtr[position + 1] = (byte)(src >> 8);
		}
		position += 2;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt32(uint src)
	{
		return writeInt32((int)src);
	}

	public TdrError.ErrorType writeInt32(int src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (4 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[position] = (byte)(src >> 24);
			beginPtr[position + 1] = (byte)(src >> 16);
			beginPtr[position + 2] = (byte)(src >> 8);
			beginPtr[position + 3] = (byte)src;
		}
		else
		{
			beginPtr[position] = (byte)src;
			beginPtr[position + 1] = (byte)(src >> 8);
			beginPtr[position + 2] = (byte)(src >> 16);
			beginPtr[position + 3] = (byte)(src >> 24);
		}
		position += 4;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt64(ulong src)
	{
		return writeInt64((long)src);
	}

	public TdrError.ErrorType writeInt64(long src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (8 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[position] = (byte)(src >> 56);
			beginPtr[position + 1] = (byte)(src >> 48);
			beginPtr[position + 2] = (byte)(src >> 40);
			beginPtr[position + 3] = (byte)(src >> 32);
			beginPtr[position + 4] = (byte)(src >> 24);
			beginPtr[position + 5] = (byte)(src >> 16);
			beginPtr[position + 6] = (byte)(src >> 8);
			beginPtr[position + 7] = (byte)src;
		}
		else
		{
			beginPtr[position] = (byte)src;
			beginPtr[position + 1] = (byte)(src >> 8);
			beginPtr[position + 2] = (byte)(src >> 16);
			beginPtr[position + 3] = (byte)(src >> 24);
			beginPtr[position + 4] = (byte)(src >> 32);
			beginPtr[position + 5] = (byte)(src >> 40);
			beginPtr[position + 6] = (byte)(src >> 48);
			beginPtr[position + 7] = (byte)(src >> 56);
		}
		position += 8;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeFloat(float src)
	{
		int src2 = BitConverter.ToInt32(BitConverter.GetBytes(src), 0);
		return writeInt32(src2);
	}

	public TdrError.ErrorType writeDouble(double src)
	{
		long src2 = BitConverter.DoubleToInt64Bits(src);
		return writeInt64(src2);
	}

	public TdrError.ErrorType writeVarUInt16(ushort src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = (ushort)IPAddress.HostToNetworkOrder((short)src);
		}
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(src);
			b = (byte)(array[0] & 0x7F);
			src >>= 7;
			if (src != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (src != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeVarInt16(short src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = IPAddress.HostToNetworkOrder(src);
		}
		src = (short)((src << 1) ^ (src >> 15));
		ushort num = (ushort)src;
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(num);
			b = (byte)(array[0] & 0x7F);
			num >>= 7;
			if (num != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (num != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeVarUInt32(uint src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = (uint)IPAddress.HostToNetworkOrder((int)src);
		}
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(src);
			b = (byte)(array[0] & 0x7F);
			src >>= 7;
			if (src != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (src != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeVarInt32(int src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = IPAddress.HostToNetworkOrder(src);
		}
		src = (src << 1) ^ (src >> 31);
		uint num = (uint)src;
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(num);
			b = (byte)(array[0] & 0x7F);
			num >>= 7;
			if (num != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (num != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeVarUInt64(ulong src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = (ulong)IPAddress.HostToNetworkOrder((long)src);
		}
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(src);
			b = (byte)(array[0] & 0x7F);
			src >>= 7;
			if (src != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (src != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeVarInt64(long src)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (!BitConverter.IsLittleEndian)
		{
			src = IPAddress.HostToNetworkOrder(src);
		}
		src = (src << 1) ^ (src >> 63);
		ulong num = (ulong)src;
		byte[] array = null;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
			}
			array = BitConverter.GetBytes(num);
			b = (byte)(array[0] & 0x7F);
			num >>= 7;
			if (num != 0)
			{
				b |= 0x80;
			}
			beginPtr[position++] = b;
		}
		while (num != 0);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeCString(ref string src, int max_count)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		TdrTypeUtil.StringNoNULL(ref src);
		int num = 0;
		try
		{
			num = Encoding.Default.GetBytes(src, 0, src.Length, beginPtr, position);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (num > max_count)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_CONFLICT;
		}
		position += num;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeCString(byte[] src, int count)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		Buffer.BlockCopy(src, 0, beginPtr, position, count);
		position += count;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeWString(short[] src, int count)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 * count > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		Buffer.BlockCopy(src, 0, beginPtr, position, count * 2);
		position += count * 2;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeInt8(sbyte src, int pos)
	{
		return writeUInt8((byte)src, pos);
	}

	public TdrError.ErrorType writeUInt8(byte src, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (1 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		beginPtr[pos] = src;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt16(ushort src, int pos)
	{
		return writeInt16((short)src, pos);
	}

	public TdrError.ErrorType writeInt16(short src, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[pos] = (byte)(src >> 8);
			beginPtr[pos + 1] = (byte)src;
		}
		else
		{
			beginPtr[pos] = (byte)src;
			beginPtr[pos + 1] = (byte)(src >> 8);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt32(uint src, int pos)
	{
		return writeInt32((int)src, pos);
	}

	public TdrError.ErrorType writeInt32(int src, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (4 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[pos] = (byte)(src >> 24);
			beginPtr[pos + 1] = (byte)(src >> 16);
			beginPtr[pos + 2] = (byte)(src >> 8);
			beginPtr[pos + 3] = (byte)src;
		}
		else
		{
			beginPtr[pos] = (byte)src;
			beginPtr[pos + 1] = (byte)(src >> 8);
			beginPtr[pos + 2] = (byte)(src >> 16);
			beginPtr[pos + 3] = (byte)(src >> 24);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeUInt64(ulong src, int pos)
	{
		return writeInt64((long)src, pos);
	}

	public TdrError.ErrorType writeInt64(long src, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (8 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (BitConverter.IsLittleEndian)
		{
			beginPtr[pos] = (byte)(src >> 56);
			beginPtr[pos + 1] = (byte)(src >> 48);
			beginPtr[pos + 2] = (byte)(src >> 40);
			beginPtr[pos + 3] = (byte)(src >> 32);
			beginPtr[pos + 4] = (byte)(src >> 24);
			beginPtr[pos + 5] = (byte)(src >> 16);
			beginPtr[pos + 6] = (byte)(src >> 8);
			beginPtr[pos + 7] = (byte)src;
		}
		else
		{
			beginPtr[pos] = (byte)src;
			beginPtr[pos + 1] = (byte)(src >> 8);
			beginPtr[pos + 2] = (byte)(src >> 16);
			beginPtr[pos + 3] = (byte)(src >> 24);
			beginPtr[pos + 4] = (byte)(src >> 32);
			beginPtr[pos + 5] = (byte)(src >> 40);
			beginPtr[pos + 6] = (byte)(src >> 48);
			beginPtr[pos + 7] = (byte)(src >> 56);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeFloat(float src, int pos)
	{
		int src2 = BitConverter.ToInt32(BitConverter.GetBytes(src), 0);
		return writeInt32(src2, pos);
	}

	public TdrError.ErrorType writeDouble(double src, int pos)
	{
		long src2 = BitConverter.DoubleToInt64Bits(src);
		return writeInt64(src2, pos);
	}

	public TdrError.ErrorType writeCString(ref string src, int max_count, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		int num = 0;
		try
		{
			num = Encoding.Default.GetBytes(src, 0, src.Length, beginPtr, pos);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		if (num > max_count)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_CONFLICT;
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeCString(byte[] src, int count, int pos)
	{
		if (beginPtr == null || count > src.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		Buffer.BlockCopy(src, 0, beginPtr, pos, count);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeWString(short[] src, int count, int pos)
	{
		if (beginPtr == null || count > src.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 * count > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		Buffer.BlockCopy(src, 0, beginPtr, pos, count * 2);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType writeBytes(ref byte[] src, int len)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (len > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		Buffer.BlockCopy(src, 0, beginPtr, position, len);
		position += len;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}
}

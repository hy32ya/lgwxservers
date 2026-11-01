using System;
using System.Net;
using System.Text;

namespace tsf4g_tdr_csharp;

public class TdrReadBuf
{
	private byte[] beginPtr;

	private int position;

	private int length;

	private bool IsNetEndian;

	public TdrReadBuf()
	{
		length = 0;
		position = 0;
		beginPtr = null;
		IsNetEndian = true;
	}

	public TdrReadBuf(ref TdrWriteBuf writeBuf)
	{
		byte[] ptr = writeBuf.getBeginPtr();
		set(ref ptr, writeBuf.getUsedSize());
	}

	public TdrReadBuf(ref byte[] ptr, int len)
	{
		set(ref ptr, len);
	}

	public void reset()
	{
		length = 0;
		position = 0;
		beginPtr = null;
		IsNetEndian = true;
	}

	public void set(ref byte[] ptr, int len)
	{
		beginPtr = ptr;
		position = 0;
		length = 0;
		IsNetEndian = true;
		if (beginPtr != null)
		{
			length = len;
		}
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

	public void disableEndian()
	{
		IsNetEndian = false;
	}

	public TdrError.ErrorType readInt8(ref sbyte dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		byte dest2 = 0;
		errorType = readUInt8(ref dest2);
		dest = (sbyte)dest2;
		return errorType;
	}

	public TdrError.ErrorType readUInt8(ref byte dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (1 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		dest = beginPtr[position++];
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readInt16(ref short dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = (short)((short)(beginPtr[position] << 8) | beginPtr[position + 1]);
		}
		else
		{
			dest = (short)(beginPtr[position] | (short)(beginPtr[position + 1] << 8));
		}
		position += 2;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt16(ref ushort dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		short dest2 = 0;
		errorType = readInt16(ref dest2);
		dest = (ushort)dest2;
		return errorType;
	}

	public TdrError.ErrorType readInt32(ref int dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (4 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = (beginPtr[position] << 24) | (beginPtr[position + 1] << 16) | (beginPtr[position + 2] << 8) | beginPtr[position + 3];
		}
		else
		{
			dest = beginPtr[position] | (beginPtr[position + 1] << 8) | (beginPtr[position + 1] << 16) | (beginPtr[position + 3] << 24);
		}
		position += 4;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt32(ref uint dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int dest2 = 0;
		errorType = readInt32(ref dest2);
		dest = (uint)dest2;
		return errorType;
	}

	public TdrError.ErrorType readInt64(ref long dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (8 > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = ((long)(int)beginPtr[position] << 56) | ((long)(int)beginPtr[position + 1] << 48) | ((long)(int)beginPtr[position + 2] << 40) | ((long)(int)beginPtr[position + 3] << 32) | ((long)(int)beginPtr[position + 4] << 24) | ((long)(int)beginPtr[position + 5] << 16) | ((long)(int)beginPtr[position + 6] << 8) | (int)beginPtr[position + 7];
		}
		else
		{
			dest = (int)beginPtr[position] | ((long)(int)beginPtr[position + 1] << 8) | ((long)(int)beginPtr[position + 2] << 16) | ((long)(int)beginPtr[position + 3] << 24) | ((long)(int)beginPtr[position + 4] << 32) | ((long)(int)beginPtr[position + 5] << 40) | ((long)(int)beginPtr[position + 6] << 48) | ((long)(int)beginPtr[position + 7] << 56);
		}
		position += 8;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt64(ref ulong dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		long dest2 = 0L;
		errorType = readInt64(ref dest2);
		dest = (ulong)dest2;
		return errorType;
	}

	public TdrError.ErrorType readFloat(ref float dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int dest2 = 0;
		errorType = readInt32(ref dest2);
		dest = BitConverter.ToSingle(BitConverter.GetBytes(dest2), 0);
		return errorType;
	}

	public TdrError.ErrorType readDouble(ref double dest)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		long dest2 = 0L;
		errorType = readInt64(ref dest2);
		dest = BitConverter.Int64BitsToDouble(dest2);
		return errorType;
	}

	public TdrError.ErrorType readVarUInt16(ref ushort dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= (ushort)(((ulong)(int)b & 0x7FuL) << 7 * num);
			num++;
		}
		while ((b & 0x80) != 0);
		if (!BitConverter.IsLittleEndian)
		{
			dest = (ushort)IPAddress.NetworkToHostOrder((short)dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readVarInt16(ref short dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= (short)(((ulong)(int)b & 0x7FuL) << 7 * num);
			num++;
		}
		while ((b & 0x80) != 0);
		if ((dest & 1) != 0)
		{
			dest = (short)((((dest ^ 0xFFFF) >> 1) & -32769) | ((dest & 1) << 15));
		}
		else
		{
			dest = (short)(((dest >> 1) & -32769) | ((dest & 1) << 15));
		}
		if (!BitConverter.IsLittleEndian)
		{
			dest = IPAddress.NetworkToHostOrder(dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readVarUInt32(ref uint dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0u;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= (uint)(int)(((ulong)(int)b & 0x7FuL) << 7 * num);
			num++;
		}
		while ((b & 0x80) != 0);
		if (!BitConverter.IsLittleEndian)
		{
			dest = (uint)IPAddress.NetworkToHostOrder((int)dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readVarInt32(ref int dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= (int)(((ulong)(int)b & 0x7FuL) << 7 * num);
			num++;
		}
		while ((b & 0x80) != 0);
		if ((dest & 1) != 0)
		{
			uint num3 = (uint)(dest ^ -1) >> 1;
			num3 &= 0x7FFFFFFF;
			dest = (int)num3 | ((dest & 1) << 31);
		}
		else
		{
			uint num4 = (uint)((dest >> 1) & 0x7FFFFFFF);
			dest = (int)num4 | ((dest & 1) << 31);
		}
		if (!BitConverter.IsLittleEndian)
		{
			dest = IPAddress.NetworkToHostOrder(dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readVarUInt64(ref ulong dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0uL;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= ((ulong)(int)b & 0x7FuL) << 7 * num;
			num++;
		}
		while ((b & 0x80) != 0);
		if (!BitConverter.IsLittleEndian)
		{
			dest = (ulong)IPAddress.NetworkToHostOrder((long)dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readVarInt64(ref long dest)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		dest = 0L;
		int num = 0;
		int num2 = 0;
		byte b = 0;
		do
		{
			if (length - position <= 0)
			{
				return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
			}
			b = beginPtr[position++];
			dest |= (long)(((ulong)(int)b & 0x7FuL) << 7 * num);
			num++;
		}
		while ((b & 0x80) != 0);
		if ((dest & 1) != 0)
		{
			ulong num3 = (ulong)(dest ^ -1) >> 1;
			num3 &= 0x7FFFFFFFFFFFFFFFL;
			dest = (long)num3 | ((dest & 1) << 63);
		}
		else
		{
			ulong num4 = (ulong)((dest >> 1) & 0x7FFFFFFFFFFFFFFFL);
			dest = (long)num4 | ((dest & 1) << 63);
		}
		if (!BitConverter.IsLittleEndian)
		{
			dest = IPAddress.NetworkToHostOrder(dest);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType skipForward(int step)
	{
		if (length - position < step)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		position += step;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readCString(ref string dest, int count)
	{
		if (beginPtr == null || dest == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		dest = Encoding.Default.GetString(beginPtr, position, count);
		position += count;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readCString(ref byte[] dest, int count)
	{
		if (beginPtr == null || count > dest.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (dest == null || dest.GetLength(0) == 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		Buffer.BlockCopy(beginPtr, position, dest, 0, count);
		position += count;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readWString(ref short[] dest, int count)
	{
		if (beginPtr == null || count > dest.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (dest == null || dest.GetLength(0) == 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 * count > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		Buffer.BlockCopy(beginPtr, position, dest, 0, count * 2);
		position += count * 2;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readInt8(ref sbyte dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		byte dest2 = 0;
		errorType = readUInt8(ref dest2, pos);
		dest = (sbyte)dest2;
		return errorType;
	}

	public TdrError.ErrorType readUInt8(ref byte dest, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (1 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		dest = beginPtr[pos];
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readInt16(ref short dest, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = (short)((short)(beginPtr[pos] << 8) | beginPtr[pos + 1]);
		}
		else
		{
			dest = (short)(beginPtr[pos] | (short)(beginPtr[pos + 1] << 8));
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt16(ref ushort dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		short dest2 = 0;
		errorType = readInt16(ref dest2, pos);
		dest = (ushort)dest2;
		return errorType;
	}

	public TdrError.ErrorType readInt32(ref int dest, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (4 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = (beginPtr[pos] << 24) | (beginPtr[pos + 1] << 16) | (beginPtr[pos + 2] << 8) | beginPtr[pos + 3];
		}
		else
		{
			dest = beginPtr[pos] | (beginPtr[pos + 1] << 8) | (beginPtr[pos + 1] << 16) | (beginPtr[pos + 3] << 24);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt32(ref uint dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int dest2 = 0;
		errorType = readInt32(ref dest2, pos);
		dest = (uint)dest2;
		return errorType;
	}

	public TdrError.ErrorType readInt64(ref long dest, int pos)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (8 > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		if (IsNetEndian && BitConverter.IsLittleEndian)
		{
			dest = ((long)(int)beginPtr[pos] << 56) | ((long)(int)beginPtr[pos + 1] << 48) | ((long)(int)beginPtr[pos + 2] << 40) | ((long)(int)beginPtr[pos + 3] << 32) | ((long)(int)beginPtr[pos + 4] << 24) | ((long)(int)beginPtr[pos + 5] << 16) | ((long)(int)beginPtr[pos + 6] << 8) | (int)beginPtr[pos + 7];
		}
		else
		{
			dest = (int)beginPtr[pos] | ((long)(int)beginPtr[pos + 1] << 8) | ((long)(int)beginPtr[pos + 2] << 16) | ((long)(int)beginPtr[pos + 3] << 24) | ((long)(int)beginPtr[pos + 4] << 32) | ((long)(int)beginPtr[pos + 5] << 40) | ((long)(int)beginPtr[pos + 6] << 48) | ((long)(int)beginPtr[pos + 7] << 56);
		}
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readUInt64(ref ulong dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		long dest2 = 0L;
		errorType = readInt64(ref dest2, pos);
		dest = (ulong)dest2;
		return errorType;
	}

	public TdrError.ErrorType readFloat(ref float dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int dest2 = 0;
		errorType = readInt32(ref dest2, pos);
		dest = BitConverter.ToSingle(BitConverter.GetBytes(dest2), 0);
		return errorType;
	}

	public TdrError.ErrorType readDouble(ref double dest, int pos)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		long dest2 = 0L;
		errorType = readInt64(ref dest2, pos);
		dest = BitConverter.Int64BitsToDouble(dest2);
		return errorType;
	}

	public TdrError.ErrorType readCString(ref string dest, int count, int pos)
	{
		if (beginPtr == null || dest == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		dest = Encoding.Default.GetString(beginPtr, pos, count);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readCString(ref byte[] dest, int count, int pos)
	{
		if (beginPtr == null || count > dest.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (dest == null || dest.GetLength(0) == 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (count > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		Buffer.BlockCopy(beginPtr, pos, dest, 0, count);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readWString(ref short[] dest, int count, int pos)
	{
		if (beginPtr == null || count > dest.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (dest == null || dest.GetLength(0) == 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (2 * count > length - pos)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		Buffer.BlockCopy(beginPtr, pos, dest, 0, count * 2);
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType readBytes(ref byte[] dest, int len)
	{
		if (beginPtr == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		if (len > length - position)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		Buffer.BlockCopy(beginPtr, position, dest, 0, len);
		position += len;
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType toHexStr(ref char[] buffer, out int usedsize)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int num = length - position;
		int num2 = num * 2 + 1;
		if (buffer.GetLength(0) < num2)
		{
			usedsize = 0;
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_WRITE;
		}
		string text = string.Empty;
		byte[] array = new byte[length - position];
		for (int i = 0; i < length - position; i++)
		{
			errorType = readUInt8(ref array[i], position + i);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				usedsize = 0;
				return errorType;
			}
			text += $"{array[i]:x2}";
		}
		text += $"{0:x}";
		buffer = text.ToCharArray();
		usedsize = num2;
		return errorType;
	}

	public TdrError.ErrorType toHexStr(ref string buffer)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		byte[] array = new byte[length - position];
		for (int i = 0; i < length - position; i++)
		{
			errorType = readUInt8(ref array[i], position + i);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			buffer += $"{array[i]:x2}";
		}
		buffer += $"{0:x}";
		return errorType;
	}
}

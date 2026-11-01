using System;

namespace tsf4g_tdr_csharp;

public class TdrDate
{
	public short nYear;

	public byte bMon;

	public byte bDay;

	public TdrDate()
	{
	}

	public TdrDate(uint date)
	{
		nYear = (short)(date & 0xFFFF);
		bMon = (byte)((date >> 16) & 0xFF);
		bDay = (byte)((date >> 24) & 0xFF);
	}

	public TdrError.ErrorType parse(uint date)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		nYear = (short)(date & 0xFFFF);
		bMon = (byte)((date >> 16) & 0xFF);
		bDay = (byte)((date >> 24) & 0xFF);
		if (!isValid())
		{
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
		}
		return result;
	}

	public bool isValid()
	{
		string s = $"{nYear:d4}-{bMon:d2}-{bDay:d2}";
		if (!DateTime.TryParse(s, out var _))
		{
			return false;
		}
		return true;
	}

	public void toDate(out uint date)
	{
		date = (uint)((ushort)nYear | (bMon << 16) | (bDay << 24));
	}
}

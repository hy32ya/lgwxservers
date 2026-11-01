using System;

namespace tsf4g_tdr_csharp;

public class TdrTime
{
	public short nHour;

	public byte bMin;

	public byte bSec;

	public TdrTime()
	{
	}

	public TdrTime(uint time)
	{
		nHour = (short)(time & 0xFFFF);
		bMin = (byte)((time >> 16) & 0xFF);
		bSec = (byte)((time >> 24) & 0xFF);
	}

	public TdrError.ErrorType parse(uint time)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		nHour = (short)(time & 0xFFFF);
		bMin = (byte)((time >> 16) & 0xFF);
		bSec = (byte)((time >> 24) & 0xFF);
		if (!isValid())
		{
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
		}
		return result;
	}

	public bool isValid()
	{
		string s = $"{nHour:d2}:{bMin:d2}:{bSec:d2}";
		if (!DateTime.TryParse(s, out var _))
		{
			return false;
		}
		return true;
	}

	public void toTime(out uint time)
	{
		time = (uint)((ushort)nHour | (bMin << 16) | (bSec << 24));
	}
}

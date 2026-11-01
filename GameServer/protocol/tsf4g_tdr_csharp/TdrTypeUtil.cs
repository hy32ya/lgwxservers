using System;
using System.Net;

namespace tsf4g_tdr_csharp;

public class TdrTypeUtil
{
	public static int cstrlen(byte[] str)
	{
		byte b = 0;
		int num = 0;
		for (int i = 0; i < str.GetLength(0) && b != str[i]; i++)
		{
			num++;
		}
		return num;
	}

	public static int wstrlen(short[] str)
	{
		short num = 0;
		int num2 = 0;
		for (int i = 0; i < str.GetLength(0) && num != str[i]; i++)
		{
			num2++;
		}
		return num2;
	}

	public static TdrError.ErrorType str2TdrIP(out uint ip, string strip)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		if (IPAddress.TryParse(strip, out var address))
		{
			byte[] addressBytes = address.GetAddressBytes();
			ip = (uint)((addressBytes[3] << 24) | (addressBytes[2] << 16) | (addressBytes[1] << 8) | addressBytes[0]);
		}
		else
		{
			ip = 0u;
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRIP_VALUE;
		}
		return result;
	}

	public static TdrError.ErrorType tdrIP2Str(ref TdrVisualBuf buf, uint ip)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		IPAddress iPAddress = new IPAddress(ip);
		string text = iPAddress.ToString();
		return buf.sprintf("{0}", text);
	}

	public static TdrError.ErrorType str2TdrTime(out uint time, string strTime)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		TdrTime tdrTime = new TdrTime();
		if (DateTime.TryParse(strTime, out var result2))
		{
			tdrTime.nHour = (short)result2.TimeOfDay.Hours;
			tdrTime.bMin = (byte)result2.TimeOfDay.Minutes;
			tdrTime.bSec = (byte)result2.TimeOfDay.Seconds;
			tdrTime.toTime(out time);
		}
		else
		{
			time = 0u;
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
		}
		return result;
	}

	public static TdrError.ErrorType tdrTime2Str(ref TdrVisualBuf buf, uint time)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		TdrTime tdrTime = new TdrTime();
		if (tdrTime.parse(time) == TdrError.ErrorType.TDR_NO_ERROR)
		{
			return buf.sprintf("{0:d2}:{1:d2}:{2:d2}", tdrTime.nHour, tdrTime.bMin, tdrTime.bSec);
		}
		return TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
	}

	public static TdrError.ErrorType str2TdrDate(out uint date, string strDate)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		TdrDate tdrDate = new TdrDate();
		if (DateTime.TryParse(strDate, out var result2))
		{
			tdrDate.nYear = (short)result2.Year;
			tdrDate.bMon = (byte)result2.Month;
			tdrDate.bDay = (byte)result2.Day;
			tdrDate.toDate(out date);
		}
		else
		{
			date = 0u;
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATE_VALUE;
		}
		return result;
	}

	public static TdrError.ErrorType tdrDate2Str(ref TdrVisualBuf buf, uint date)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		TdrDate tdrDate = new TdrDate();
		if (tdrDate.parse(date) == TdrError.ErrorType.TDR_NO_ERROR)
		{
			return buf.sprintf("{0:d4}-{1:d2}-{2:d2}", tdrDate.nYear, tdrDate.bMon, tdrDate.bDay);
		}
		return TdrError.ErrorType.TDR_ERR_INVALID_TDRDATE_VALUE;
	}

	public static TdrError.ErrorType str2TdrDateTime(out ulong datetime, string strDateTime)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		TdrDateTime tdrDateTime = new TdrDateTime();
		if (DateTime.TryParse(strDateTime, out var result2))
		{
			tdrDateTime.tdrDate.nYear = (short)result2.Year;
			tdrDateTime.tdrDate.bMon = (byte)result2.Month;
			tdrDateTime.tdrDate.bDay = (byte)result2.Day;
			tdrDateTime.tdrTime.nHour = (short)result2.TimeOfDay.Hours;
			tdrDateTime.tdrTime.bMin = (byte)result2.TimeOfDay.Minutes;
			tdrDateTime.tdrTime.bSec = (byte)result2.TimeOfDay.Seconds;
			tdrDateTime.toDateTime(out datetime);
		}
		else
		{
			datetime = 0uL;
			result = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATETIME_VALUE;
		}
		return result;
	}

	public static TdrError.ErrorType tdrDateTime2Str(ref TdrVisualBuf buf, ulong datetime)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		TdrDateTime tdrDateTime = new TdrDateTime();
		if (tdrDateTime.parse(datetime) == TdrError.ErrorType.TDR_NO_ERROR)
		{
			return buf.sprintf("{0:d4}-{1:d2}-{2:d2} {3:d2}:{4:d2}:{5:d2}", tdrDateTime.tdrDate.nYear, tdrDateTime.tdrDate.bMon, tdrDateTime.tdrDate.bDay, tdrDateTime.tdrTime.nHour, tdrDateTime.tdrTime.bMin, tdrDateTime.tdrTime.bSec);
		}
		return TdrError.ErrorType.TDR_ERR_INVALID_TDRDATETIME_VALUE;
	}

	public static void StringNoNULL(ref string str)
	{
		int num = str.IndexOf('\0');
		if (num >= 0 && num < str.Length)
		{
			str = str.Substring(0, num);
		}
	}
}

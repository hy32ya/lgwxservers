using System;
using System.Text;

namespace tsf4g_tdr_csharp;

public class TdrBufUtil
{
	public static TdrError.ErrorType printMultiStr(ref TdrVisualBuf buf, string str, int times)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		for (int i = 0; i < times; i++)
		{
			errorType = buf.sprintf("{0}", str);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				break;
			}
		}
		return errorType;
	}

	public static TdrError.ErrorType printVariable(ref TdrVisualBuf buf, int indent, char sep, string variable, bool withSep)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = ((!withSep) ? buf.sprintf("{0}: ", variable) : buf.sprintf("{0}{1}", variable, sep));
		}
		return errorType;
	}

	public static TdrError.ErrorType printVariable(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, bool withSep)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = ((!withSep) ? buf.sprintf("{0}[{1:d}]: ", variable, arrIdx) : buf.sprintf("{0}[{1:d}]{2}", variable, arrIdx, sep));
		}
		return errorType;
	}

	public static TdrError.ErrorType printVariable(ref TdrVisualBuf buf, int indent, char sep, string variable, string format, params object[] args)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: ", variable);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf(format, args);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printVariable(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, string format, params object[] args)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: ", variable, arrIdx);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf(format, args);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printArray(ref TdrVisualBuf buf, int indent, char sep, string variable, long count)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[0:{1:d}]: ", variable, count);
		}
		return errorType;
	}

	public static TdrError.ErrorType printString(ref TdrVisualBuf buf, int indent, char sep, string variable, ref string str)
	{
		TdrTypeUtil.StringNoNULL(ref str);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		return buf.sprintf("{0}: {1}{2}", variable, str, sep);
	}

	public static TdrError.ErrorType printString(ref TdrVisualBuf buf, int indent, char sep, string variable, byte[] bStr)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		string text = string.Empty;
		int count = TdrTypeUtil.cstrlen(bStr);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = printMultiStr(ref buf, "    ", indent);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			text = Encoding.Default.GetString(bStr, 0, count);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: {1}{2}", variable, text, sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printWString(ref TdrVisualBuf buf, int indent, char sep, string variable, short[] str)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int num = TdrTypeUtil.wstrlen(str) + 1;
		errorType = buf.sprintf("{0}:  ", variable);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			int num2 = TdrTypeUtil.wstrlen(str);
			for (int i = 0; i < num2; i++)
			{
				errorType = buf.sprintf("0x{0:X4}", str[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					break;
				}
			}
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printString(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, ref string str)
	{
		TdrTypeUtil.StringNoNULL(ref str);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		return buf.sprintf("{0}[{1:d}]: {2}{3}", variable, arrIdx, str, sep);
	}

	public static TdrError.ErrorType printString(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, byte[] bStr)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		string text = string.Empty;
		int count = TdrTypeUtil.cstrlen(bStr);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = printMultiStr(ref buf, "    ", indent);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			text = Encoding.Default.GetString(bStr, 0, count);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: {2}{3}", variable, arrIdx, text, sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printWString(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, short[] str)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		int num = TdrTypeUtil.wstrlen(str) + 1;
		errorType = buf.sprintf("{0}[{1:d}]", variable, arrIdx);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			int num2 = TdrTypeUtil.wstrlen(str);
			for (int i = 0; i < num2; i++)
			{
				errorType = buf.sprintf("0x{0:X4}", str[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					break;
				}
			}
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrIP(ref TdrVisualBuf buf, int indent, char sep, string variable, uint ip)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: ", variable);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrIP2Str(ref buf, ip);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrIP(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, uint ip)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: ", variable, arrIdx);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrIP2Str(ref buf, ip);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrTime(ref TdrVisualBuf buf, int indent, char sep, string variable, uint time)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: ", variable);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrTime2Str(ref buf, time);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrTime(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, uint time)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: ", variable, arrIdx);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrTime2Str(ref buf, time);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrDate(ref TdrVisualBuf buf, int indent, char sep, string variable, uint date)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: ", variable);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrDate2Str(ref buf, date);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrDate(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, uint date)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: ", variable, arrIdx);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrDate2Str(ref buf, date);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrDateTime(ref TdrVisualBuf buf, int indent, char sep, string variable, ulong datetime)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}: ", variable);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrDateTime2Str(ref buf, datetime);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType printTdrDateTime(ref TdrVisualBuf buf, int indent, char sep, string variable, int arrIdx, ulong datetime)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = printMultiStr(ref buf, "    ", indent);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}[{1:d}]: ", variable, arrIdx);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = TdrTypeUtil.tdrDateTime2Str(ref buf, datetime);
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = buf.sprintf("{0}", sep);
		}
		return errorType;
	}

	public static TdrError.ErrorType covertBytesOrder(byte[] data, int step)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		if (!BitConverter.IsLittleEndian || step < 2)
		{
			return result;
		}
		int num = data.Length;
		int num2 = num / step;
		for (int i = 0; i < num2; i++)
		{
			int num3 = i * step;
			int num4 = step / 2;
			for (int j = 0; j < num4; j++)
			{
				int num5 = num3 + j;
				int num6 = num3 + step - j - 1;
				byte b = data[num6];
				data[num6] = data[num5];
				data[num5] = b;
			}
		}
		return result;
	}
}

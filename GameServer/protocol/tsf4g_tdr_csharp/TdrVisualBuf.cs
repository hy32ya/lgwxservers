using System;
using System.Text;

namespace tsf4g_tdr_csharp;

public class TdrVisualBuf
{
	private StringBuilder visualBuf;

	public TdrVisualBuf()
	{
		visualBuf = new StringBuilder();
	}

	public TdrError.ErrorType sprintf(string format, params object[] args)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		string value = string.Empty;
		try
		{
			value = string.Format(format, args);
		}
		catch (ArgumentNullException ex)
		{
			Console.WriteLine("Error: " + ex.Message);
			errorType = TdrError.ErrorType.TDR_ERR_ARGUMENT_NULL_EXCEPTION;
		}
		catch (FormatException ex2)
		{
			Console.WriteLine("Error: " + ex2.Message);
			errorType = TdrError.ErrorType.TDR_ERR_INVALID_FORMAT;
		}
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			visualBuf.Append(value);
		}
		return errorType;
	}

	public string getVisualBuf()
	{
		return visualBuf.ToString();
	}
}

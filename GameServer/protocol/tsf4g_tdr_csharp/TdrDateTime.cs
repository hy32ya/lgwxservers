namespace tsf4g_tdr_csharp;

public class TdrDateTime
{
	public TdrDate tdrDate;

	public TdrTime tdrTime;

	public TdrDateTime()
	{
		tdrDate = new TdrDate();
		tdrTime = new TdrTime();
	}

	public TdrDateTime(ulong datetime)
	{
		tdrDate = new TdrDate((uint)(datetime & 0xFFFFFFFFu));
		tdrTime = new TdrTime((uint)((datetime >> 32) & 0xFFFFFFFFu));
	}

	public TdrError.ErrorType parse(ulong datetime)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		uint date = (uint)(datetime & 0xFFFFFFFFu);
		uint time = (uint)((datetime >> 32) & 0xFFFFFFFFu);
		errorType = tdrDate.parse(date);
		if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
		{
			errorType = tdrTime.parse(time);
		}
		return errorType;
	}

	public void toDateTime(out ulong datetime)
	{
		uint date = 0u;
		uint time = 0u;
		tdrDate.toDate(out date);
		tdrTime.toTime(out time);
		datetime = date | ((ulong)time << 32);
	}

	public bool isValid()
	{
		return tdrDate.isValid() && tdrTime.isValid();
	}
}

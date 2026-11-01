namespace tsf4g_tdr_csharp;

public interface IUnpackable
{
	TdrError.ErrorType unpackTLV(ref byte[] buffer, int size, ref int used);
}

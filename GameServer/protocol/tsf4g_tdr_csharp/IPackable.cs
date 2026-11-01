namespace tsf4g_tdr_csharp;

public interface IPackable
{
	TdrError.ErrorType packTLV(ref byte[] buffer, int size, ref int used, bool useVarInt);
}

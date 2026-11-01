using tsf4g_tdr_csharp;

namespace cs_msg;

public class ClientDevInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public int platID;

	public byte[] clientVersion;

	public byte[] systemSoftware;

	public byte[] systemHardware;

	public byte[] telecomOper;

	public byte[] network;

	public int screenWidth;

	public int screenHight;

	public float density;

	public byte[] loginChannel;

	public byte[] cpuHardware;

	public int memory;

	public byte[] GLRender;

	public byte[] GLVersion;

	public uint softVersionID;

	public uint deviceID;

	public uint triggerVersionID;

	public uint landformVersionID;

	public byte[] resourceVersion;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_clientVersion = 64u;

	public static readonly uint LENGTH_systemSoftware = 64u;

	public static readonly uint LENGTH_systemHardware = 64u;

	public static readonly uint LENGTH_telecomOper = 64u;

	public static readonly uint LENGTH_network = 64u;

	public static readonly uint LENGTH_loginChannel = 16u;

	public static readonly uint LENGTH_cpuHardware = 64u;

	public static readonly uint LENGTH_GLRender = 64u;

	public static readonly uint LENGTH_GLVersion = 64u;

	public static readonly uint LENGTH_resourceVersion = 64u;

	public ClientDevInfo()
	{
		clientVersion = new byte[64];
		systemSoftware = new byte[64];
		systemHardware = new byte[64];
		telecomOper = new byte[64];
		network = new byte[64];
		loginChannel = new byte[16];
		cpuHardware = new byte[64];
		GLRender = new byte[64];
		GLVersion = new byte[64];
		resourceVersion = new byte[64];
	}

	public void set_has_platID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_platID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_platID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_clientVersion()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_clientVersion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_clientVersion()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_systemSoftware()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_systemSoftware()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_systemSoftware()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_systemHardware()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_systemHardware()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_systemHardware()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_telecomOper()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_telecomOper()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_telecomOper()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_network()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_network()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_network()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_screenWidth()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_screenWidth()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_screenWidth()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_screenHight()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_screenHight()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_screenHight()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_density()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_density()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_density()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_loginChannel()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_loginChannel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_loginChannel()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_cpuHardware()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_cpuHardware()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_cpuHardware()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_memory()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_memory()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_memory()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_GLRender()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_GLRender()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_GLRender()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_GLVersion()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_GLVersion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_GLVersion()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_softVersionID()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_softVersionID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_softVersionID()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_deviceID()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_deviceID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_deviceID()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_triggerVersionID()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_triggerVersionID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_triggerVersionID()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_landformVersionID()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_landformVersionID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_landformVersionID()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_resourceVersion()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_resourceVersion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_resourceVersion()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	private int requiredFieldNum()
	{
		return 0;
	}

	public string getLastLostRequiredFields()
	{
		return string.Empty;
	}

	public TdrError.ErrorType construct()
	{
		return TdrError.ErrorType.TDR_NO_ERROR;
	}

	public TdrError.ErrorType packTLV(ref byte[] buffer, int size, ref int used, bool useVarInt)
	{
		if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		TdrWriteBuf destBuf = new TdrWriteBuf(ref buffer, size);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		errorType = ((!useVarInt) ? destBuf.writeUInt8(153) : destBuf.writeUInt8(170));
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = destBuf.getUsedSize();
		destBuf.writeInt32(used, usedSize);
		return errorType;
	}

	public TdrError.ErrorType packTLV(ref TdrWriteBuf destBuf, bool useVarInt)
	{
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		if (useVarInt)
		{
			uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(platID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src2 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(platID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num = TdrTypeUtil.cstrlen(clientVersion);
		if (num >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(clientVersion, num);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src4 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src4, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize2 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num2 = TdrTypeUtil.cstrlen(systemSoftware);
		if (num2 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(systemSoftware, num2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src6 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src6, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize3 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num3 = TdrTypeUtil.cstrlen(systemHardware);
		if (num3 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(systemHardware, num3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src8 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src8, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize4 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num4 = TdrTypeUtil.cstrlen(telecomOper);
		if (num4 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(telecomOper, num4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src10 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src10, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src11 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize5 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num5 = TdrTypeUtil.cstrlen(network);
		if (num5 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(network, num5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src12 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src12, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src13 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(screenWidth);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(screenWidth);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(screenHight);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src16 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(screenHight);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src17 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeFloat(density);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src18 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src18);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize6 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num6 = TdrTypeUtil.cstrlen(loginChannel);
		if (num6 >= 16)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(loginChannel, num6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src19 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src19, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src20 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src20);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize7 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num7 = TdrTypeUtil.cstrlen(cpuHardware);
		if (num7 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(cpuHardware, num7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src21 = destBuf.getUsedSize() - usedSize7 - 4;
		errorType = destBuf.writeInt32(src21, usedSize7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src22 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src22);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(memory);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src23 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src23);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(memory);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src24 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src24);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize8 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num8 = TdrTypeUtil.cstrlen(GLRender);
		if (num8 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(GLRender, num8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src25 = destBuf.getUsedSize() - usedSize8 - 4;
		errorType = destBuf.writeInt32(src25, usedSize8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src26 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src26);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize9 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num9 = TdrTypeUtil.cstrlen(GLVersion);
		if (num9 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(GLVersion, num9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src27 = destBuf.getUsedSize() - usedSize9 - 4;
		errorType = destBuf.writeInt32(src27, usedSize9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src28 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src28);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(softVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src29 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src29);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(softVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src30 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src30);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(deviceID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src31 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src31);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(deviceID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src32 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src32);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(triggerVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src33 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src33);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(triggerVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src34 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(landformVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src35 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src35);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(landformVersionID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src36 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src36);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize10 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int num10 = TdrTypeUtil.cstrlen(resourceVersion);
		if (num10 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(resourceVersion, num10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src37 = destBuf.getUsedSize() - usedSize10 - 4;
		errorType = destBuf.writeInt32(src37, usedSize10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref byte[] buffer, int size, ref int used)
	{
		if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		if (size < TdrTLV.TLV_MSG_MIN_SIZE)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		TdrReadBuf srcBuf = new TdrReadBuf(ref buffer, size);
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		byte dest = 0;
		bool flag = true;
		errorType = srcBuf.readUInt8(ref dest);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		switch (dest)
		{
		case 170:
			flag = true;
			break;
		case 153:
			flag = false;
			break;
		default:
			return TdrError.ErrorType.TDR_ERR_BAD_TLV_MAGIC;
		}
		int dest2 = 0;
		srcBuf.readInt32(ref dest2);
		if (size < dest2)
		{
			return TdrError.ErrorType.TDR_ERR_SHORT_BUF_FOR_READ;
		}
		errorType = unpackTLV(ref srcBuf, dest2 - TdrTLV.TLV_MSG_MIN_SIZE, flag);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = srcBuf.getUsedSize();
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref TdrReadBuf srcBuf, int length, bool useVarInt)
	{
		if (srcBuf == null || length <= 0)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		uint dest = 0u;
		uint num = 0u;
		int num2 = 0;
		int usedSize = srcBuf.getUsedSize();
		while (srcBuf.getUsedSize() < usedSize + length)
		{
			errorType = srcBuf.readVarUInt32(ref dest);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			switch (TdrTLV.getFieldId(dest))
			{
			case 1u:
				if (!has_platID())
				{
					set_has_platID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref platID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref platID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
			{
				if (!has_clientVersion())
				{
					set_has_clientVersion();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref clientVersion, dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				clientVersion[dest6] = 0;
				break;
			}
			case 3u:
			{
				if (!has_systemSoftware())
				{
					set_has_systemSoftware();
				}
				int dest10 = 0;
				errorType = srcBuf.readInt32(ref dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest10 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref systemSoftware, dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				systemSoftware[dest10] = 0;
				break;
			}
			case 4u:
			{
				if (!has_systemHardware())
				{
					set_has_systemHardware();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref systemHardware, dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				systemHardware[dest8] = 0;
				break;
			}
			case 5u:
			{
				if (!has_telecomOper())
				{
					set_has_telecomOper();
				}
				int dest11 = 0;
				errorType = srcBuf.readInt32(ref dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest11 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref telecomOper, dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				telecomOper[dest11] = 0;
				break;
			}
			case 6u:
			{
				if (!has_network())
				{
					set_has_network();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref network, dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				network[dest7] = 0;
				break;
			}
			case 7u:
				if (!has_screenWidth())
				{
					set_has_screenWidth();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref screenWidth);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref screenWidth);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
				if (!has_screenHight())
				{
					set_has_screenHight();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref screenHight);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref screenHight);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 9u:
				if (!has_density())
				{
					set_has_density();
				}
				errorType = srcBuf.readFloat(ref density);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
			{
				if (!has_loginChannel())
				{
					set_has_loginChannel();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 >= 16)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref loginChannel, dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				loginChannel[dest4] = 0;
				break;
			}
			case 11u:
			{
				if (!has_cpuHardware())
				{
					set_has_cpuHardware();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref cpuHardware, dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				cpuHardware[dest5] = 0;
				break;
			}
			case 12u:
				if (!has_memory())
				{
					set_has_memory();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref memory);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref memory);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 13u:
			{
				if (!has_GLRender())
				{
					set_has_GLRender();
				}
				int dest9 = 0;
				errorType = srcBuf.readInt32(ref dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest9 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref GLRender, dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				GLRender[dest9] = 0;
				break;
			}
			case 14u:
			{
				if (!has_GLVersion())
				{
					set_has_GLVersion();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref GLVersion, dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				GLVersion[dest3] = 0;
				break;
			}
			case 15u:
				if (!has_softVersionID())
				{
					set_has_softVersionID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref softVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref softVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 16u:
				if (!has_deviceID())
				{
					set_has_deviceID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref deviceID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref deviceID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 17u:
				if (!has_triggerVersionID())
				{
					set_has_triggerVersionID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref triggerVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref triggerVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 18u:
				if (!has_landformVersionID())
				{
					set_has_landformVersionID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref landformVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref landformVersionID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 19u:
			{
				if (!has_resourceVersion())
				{
					set_has_resourceVersion();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref resourceVersion, dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				resourceVersion[dest2] = 0;
				break;
			}
			default:
			{
				uint typeId = TdrTLV.getTypeId(dest);
				errorType = TdrTLV.skipUnknownFields(ref srcBuf, (TdrTLV.TdrTLVTypeId)typeId);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			}
		}
		if (srcBuf.getUsedSize() > usedSize + length)
		{
			return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
		}
		if (num2 < requiredFieldNum())
		{
			return TdrError.ErrorType.TDR_ERR_LOST_REQUIRED_FIELD;
		}
		return errorType;
	}

	public TdrError.ErrorType visualize(ref string buffer, int indent, char separator)
	{
		return TdrError.ErrorType.TDR_ERR_METHOD_NOT_IMPLEMENTED;
	}

	public TdrError.ErrorType visualize(ref TdrVisualBuf destBuf, int indent, char separator)
	{
		return TdrError.ErrorType.TDR_ERR_METHOD_NOT_IMPLEMENTED;
	}
}

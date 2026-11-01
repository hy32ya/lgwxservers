using System;
using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSPublicProfile : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong accountGID;

	public byte deviceType;

	public ushort profilePicID;

	public byte[] roleName;

	public byte[] signature;

	public sbyte gender;

	public CSWearFashion fashion;

	public uint friendCount;

	public CSWorkSum map;

	public CSWorkSum prefab;

	public uint followerCount;

	public ulong totalVisitorCount;

	public ulong todayVisitorCount;

	public uint recentOnlineTime;

	public ushort[] tagOnlineTime;

	public CSAlbum album;

	public uint subscribeCount;

	public CSAccountKey[] subscibe;

	public byte workPlayCount;

	public ulong[] workPlay;

	public byte readMode;

	public CSPlayerProfileState profileState;

	public CSRoleStyle roleStyle;

	public byte accountAuthType;

	public int curTitleID;

	public byte level;

	public CSMedalInfo medalInfo;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roleName = 32u;

	public static readonly uint LENGTH_signature = 128u;

	public CSPublicProfile()
	{
		roleName = new byte[32];
		signature = new byte[128];
		fashion = new CSWearFashion();
		map = new CSWorkSum();
		prefab = new CSWorkSum();
		tagOnlineTime = new ushort[2];
		album = new CSAlbum();
		subscibe = new CSAccountKey[200];
		for (int i = 0; i < 200; i++)
		{
			subscibe[i] = new CSAccountKey();
		}
		workPlay = new ulong[20];
		profileState = new CSPlayerProfileState();
		roleStyle = new CSRoleStyle();
		medalInfo = new CSMedalInfo();
	}

	public void set_has_accountGID()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_accountGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_accountGID()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_deviceType()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_deviceType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_deviceType()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_profilePicID()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_profilePicID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_profilePicID()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_roleName()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_roleName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_roleName()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_signature()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_signature()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_signature()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_gender()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_gender()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_gender()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_fashion()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_fashion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_fashion()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_friendCount()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_friendCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_friendCount()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_map()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_map()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_map()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_prefab()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_prefab()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_prefab()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_followerCount()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_followerCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_followerCount()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_totalVisitorCount()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_totalVisitorCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_totalVisitorCount()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_todayVisitorCount()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_todayVisitorCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_todayVisitorCount()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_recentOnlineTime()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_recentOnlineTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_recentOnlineTime()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_tagOnlineTime()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_tagOnlineTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_tagOnlineTime()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_album()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_album()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_album()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_subscribeCount()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_subscribeCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_subscribeCount()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_subscibe()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_subscibe()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_subscibe()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_workPlayCount()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_workPlayCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_workPlayCount()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_workPlay()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_workPlay()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_workPlay()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_readMode()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_readMode()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_readMode()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_profileState()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_profileState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_profileState()
	{
		return (has_bits_[0] & 0x200000) != 0;
	}

	public void set_has_roleStyle()
	{
		has_bits_[0] |= 4194304u;
	}

	private void clear_has_roleStyle()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4194305);
	}

	public bool has_roleStyle()
	{
		return (has_bits_[0] & 0x400000) != 0;
	}

	public void set_has_accountAuthType()
	{
		has_bits_[0] |= 8388608u;
	}

	private void clear_has_accountAuthType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8388609);
	}

	public bool has_accountAuthType()
	{
		return (has_bits_[0] & 0x800000) != 0;
	}

	public void set_has_curTitleID()
	{
		has_bits_[0] |= 16777216u;
	}

	private void clear_has_curTitleID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16777217);
	}

	public bool has_curTitleID()
	{
		return (has_bits_[0] & 0x1000000) != 0;
	}

	public void set_has_level()
	{
		has_bits_[0] |= 33554432u;
	}

	private void clear_has_level()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33554433);
	}

	public bool has_level()
	{
		return (has_bits_[0] & 0x2000000) != 0;
	}

	public void set_has_medalInfo()
	{
		has_bits_[0] |= 67108864u;
	}

	private void clear_has_medalInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -67108865);
	}

	public bool has_medalInfo()
	{
		return (has_bits_[0] & 0x4000000) != 0;
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
			errorType = destBuf.writeVarUInt64(accountGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src2 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src2);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(accountGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(deviceType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src4 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src4);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(profilePicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(profilePicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src6);
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
		int num = TdrTypeUtil.cstrlen(roleName);
		if (num >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(roleName, num);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src7 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src7, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src8 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src8);
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
		int num2 = TdrTypeUtil.cstrlen(signature);
		if (num2 >= 128)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(signature, num2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src9 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src9, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src10 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeInt8(gender);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src11 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src11);
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
		errorType = fashion.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src12 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src12, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src13 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(friendCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(friendCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src15 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src15);
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
		errorType = map.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src16 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src16, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src17 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src17);
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
		errorType = prefab.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src18 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src18, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src19 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src19);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(followerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src20 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src20);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(followerCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src21 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src21);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(totalVisitorCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src22 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src22);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(totalVisitorCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src23 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src23);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(todayVisitorCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src24 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src24);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(todayVisitorCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src25 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src25);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(recentOnlineTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src26 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src26);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(recentOnlineTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src27 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src27);
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
			for (int i = 0; i < 2; i++)
			{
				errorType = destBuf.writeVarUInt16(tagOnlineTime[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src28 = destBuf.getUsedSize() - usedSize6 - 4;
			errorType = destBuf.writeInt32(src28, usedSize6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src29 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src29);
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
			int num3 = 4;
			byte[] src30 = new byte[num3];
			Buffer.BlockCopy(tagOnlineTime, 0, src30, 0, num3);
			TdrBufUtil.covertBytesOrder(src30, 2);
			errorType = destBuf.writeBytes(ref src30, num3);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			int src31 = destBuf.getUsedSize() - usedSize7 - 4;
			errorType = destBuf.writeInt32(src31, usedSize7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src32 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src32);
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
		errorType = album.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src33 = destBuf.getUsedSize() - usedSize8 - 4;
		errorType = destBuf.writeInt32(src33, usedSize8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src34 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(subscribeCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src35 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src35);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(subscribeCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (subscribeCount > 200)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (subscribeCount != 0)
		{
			uint src36 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src36);
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
			for (int j = 0; j < subscribeCount; j++)
			{
				int usedSize10 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = subscibe[j].packTLV(ref destBuf, useVarInt);
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
			}
			int src38 = destBuf.getUsedSize() - usedSize9 - 4;
			errorType = destBuf.writeInt32(src38, usedSize9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src39 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src39);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(workPlayCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (workPlayCount > 20)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (workPlayCount > 0)
			{
				uint src40 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src40);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize11 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				for (int k = 0; k < workPlayCount; k++)
				{
					errorType = destBuf.writeVarUInt64(workPlay[k]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src41 = destBuf.getUsedSize() - usedSize11 - 4;
				errorType = destBuf.writeInt32(src41, usedSize11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (workPlayCount > 0)
		{
			uint src42 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src42);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			int usedSize12 = destBuf.getUsedSize();
			errorType = destBuf.reserve(4);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			if (workPlayCount > 0)
			{
				int num4 = workPlayCount * 8;
				byte[] src43 = new byte[num4];
				Buffer.BlockCopy(workPlay, 0, src43, 0, num4);
				TdrBufUtil.covertBytesOrder(src43, 8);
				errorType = destBuf.writeBytes(ref src43, num4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src44 = destBuf.getUsedSize() - usedSize12 - 4;
			errorType = destBuf.writeInt32(src44, usedSize12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src45 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src45);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(readMode);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src46 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src46);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize13 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = profileState.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src47 = destBuf.getUsedSize() - usedSize13 - 4;
		errorType = destBuf.writeInt32(src47, usedSize13);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src48 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src48);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize14 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = roleStyle.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src49 = destBuf.getUsedSize() - usedSize14 - 4;
		errorType = destBuf.writeInt32(src49, usedSize14);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src50 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src50);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(accountAuthType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src51 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src51);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(curTitleID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src52 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src52);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(curTitleID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src53 = TdrTLV.makeTag(26, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src53);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(level);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src54 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src54);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int usedSize15 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = medalInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src55 = destBuf.getUsedSize() - usedSize15 - 4;
		errorType = destBuf.writeInt32(src55, usedSize15);
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
				if (!has_accountGID())
				{
					set_has_accountGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref accountGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref accountGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
				if (!has_deviceType())
				{
					set_has_deviceType();
				}
				errorType = srcBuf.readUInt8(ref deviceType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
				if (!has_profilePicID())
				{
					set_has_profilePicID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref profilePicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref profilePicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 4u:
			{
				if (!has_roleName())
				{
					set_has_roleName();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref roleName, dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roleName[dest8] = 0;
				break;
			}
			case 5u:
			{
				if (!has_signature())
				{
					set_has_signature();
				}
				int dest13 = 0;
				errorType = srcBuf.readInt32(ref dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest13 >= 128)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref signature, dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				signature[dest13] = 0;
				break;
			}
			case 6u:
				if (!has_gender())
				{
					set_has_gender();
				}
				errorType = srcBuf.readInt8(ref gender);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
			{
				if (!has_fashion())
				{
					set_has_fashion();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					errorType = fashion.unpackTLV(ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 8u:
				if (!has_friendCount())
				{
					set_has_friendCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref friendCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref friendCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 9u:
			{
				if (!has_map())
				{
					set_has_map();
				}
				int dest14 = 0;
				errorType = srcBuf.readInt32(ref dest14);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest14 > 0)
				{
					errorType = map.unpackTLV(ref srcBuf, dest14, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 10u:
			{
				if (!has_prefab())
				{
					set_has_prefab();
				}
				int dest16 = 0;
				errorType = srcBuf.readInt32(ref dest16);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest16 > 0)
				{
					errorType = prefab.unpackTLV(ref srcBuf, dest16, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 11u:
				if (!has_followerCount())
				{
					set_has_followerCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref followerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref followerCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 12u:
				if (!has_totalVisitorCount())
				{
					set_has_totalVisitorCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref totalVisitorCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref totalVisitorCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 13u:
				if (!has_todayVisitorCount())
				{
					set_has_todayVisitorCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref todayVisitorCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref todayVisitorCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 14u:
				if (!has_recentOnlineTime())
				{
					set_has_recentOnlineTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref recentOnlineTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref recentOnlineTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 15u:
			{
				if (!has_tagOnlineTime())
				{
					set_has_tagOnlineTime();
				}
				int dest11 = 0;
				errorType = srcBuf.readInt32(ref dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest11 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize4 = srcBuf.getUsedSize();
				if (useVarInt)
				{
					for (int k = 0; k < 2; k++)
					{
						errorType = srcBuf.readVarUInt16(ref tagOnlineTime[k]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize4 + dest11)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize4 + dest11)
						{
							break;
						}
					}
				}
				else
				{
					int num4 = dest11;
					byte[] dest12 = new byte[num4];
					errorType = srcBuf.readBytes(ref dest12, num4);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest12, 2);
					Buffer.BlockCopy(dest12, 0, tagOnlineTime, 0, num4);
				}
				break;
			}
			case 16u:
			{
				if (!has_album())
				{
					set_has_album();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 > 0)
				{
					errorType = album.unpackTLV(ref srcBuf, dest5, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 17u:
				if (!has_subscribeCount())
				{
					set_has_subscribeCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref subscribeCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref subscribeCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 18u:
			{
				if (!has_subscibe())
				{
					set_has_subscibe();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize2 = srcBuf.getUsedSize();
				for (int i = 0; i < 200; i++)
				{
					int dest7 = 0;
					errorType = srcBuf.readInt32(ref dest7);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest7 > 0)
					{
						errorType = subscibe[i].unpackTLV(ref srcBuf, dest7, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize2 + dest6)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize2 + dest6)
					{
						subscribeCount = (uint)(i + 1);
						break;
					}
				}
				break;
			}
			case 19u:
				if (!has_workPlayCount())
				{
					set_has_workPlayCount();
				}
				errorType = srcBuf.readUInt8(ref workPlayCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 20u:
			{
				if (!has_workPlay())
				{
					set_has_workPlay();
				}
				int dest9 = 0;
				errorType = srcBuf.readInt32(ref dest9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest9 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize3 = srcBuf.getUsedSize();
				if (useVarInt)
				{
					for (int j = 0; j < 20; j++)
					{
						errorType = srcBuf.readVarUInt64(ref workPlay[j]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize3 + dest9)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize3 + dest9)
						{
							workPlayCount = (byte)(j + 1);
							break;
						}
					}
				}
				else
				{
					int num3 = dest9;
					byte[] dest10 = new byte[num3];
					errorType = srcBuf.readBytes(ref dest10, num3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest10, 8);
					Buffer.BlockCopy(dest10, 0, workPlay, 0, num3);
				}
				break;
			}
			case 21u:
				if (!has_readMode())
				{
					set_has_readMode();
				}
				errorType = srcBuf.readUInt8(ref readMode);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 22u:
			{
				if (!has_profileState())
				{
					set_has_profileState();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 > 0)
				{
					errorType = profileState.unpackTLV(ref srcBuf, dest3, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 23u:
			{
				if (!has_roleStyle())
				{
					set_has_roleStyle();
				}
				int dest15 = 0;
				errorType = srcBuf.readInt32(ref dest15);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest15 > 0)
				{
					errorType = roleStyle.unpackTLV(ref srcBuf, dest15, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 24u:
				if (!has_accountAuthType())
				{
					set_has_accountAuthType();
				}
				errorType = srcBuf.readUInt8(ref accountAuthType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 25u:
				if (!has_curTitleID())
				{
					set_has_curTitleID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref curTitleID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref curTitleID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 26u:
				if (!has_level())
				{
					set_has_level();
				}
				errorType = srcBuf.readUInt8(ref level);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 27u:
			{
				if (!has_medalInfo())
				{
					set_has_medalInfo();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 > 0)
				{
					errorType = medalInfo.unpackTLV(ref srcBuf, dest2, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
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

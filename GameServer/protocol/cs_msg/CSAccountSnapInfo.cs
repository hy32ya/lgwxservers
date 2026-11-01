using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSAccountSnapInfo : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public CSAccountRoleID account;

	public sbyte gender;

	public byte[] roleName;

	public uint lastOnlineTm;

	public ushort curProfilePicID;

	public ushort legoLandLevel;

	public int legoLandExp;

	public byte accountAuthType;

	public int curTitleID;

	public byte level;

	public CSPlatPrivilege qqVipPrivilege;

	public CSPlatPrivilege startPrivilege;

	public byte accountType;

	public byte[] openID;

	public uint headImgValidTime;

	public CSImgFrame curHeadImgFrame;

	public byte accountState;

	public int mayDayGrowthExp;

	private uint[] has_bits_ = new uint[1];

	public static readonly uint LENGTH_roleName = 32u;

	public static readonly uint LENGTH_openID = 64u;

	public CSAccountSnapInfo()
	{
		account = new CSAccountRoleID();
		roleName = new byte[32];
		qqVipPrivilege = new CSPlatPrivilege();
		startPrivilege = new CSPlatPrivilege();
		openID = new byte[64];
		curHeadImgFrame = new CSImgFrame();
	}

	public void set_has_account()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_account()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_account()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_gender()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_gender()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_gender()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_roleName()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_roleName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_roleName()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_lastOnlineTm()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_lastOnlineTm()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_lastOnlineTm()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_curProfilePicID()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_curProfilePicID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_curProfilePicID()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_legoLandLevel()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_legoLandLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_legoLandLevel()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_legoLandExp()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_legoLandExp()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_legoLandExp()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_accountAuthType()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_accountAuthType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_accountAuthType()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_curTitleID()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_curTitleID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_curTitleID()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_level()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_level()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_level()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_qqVipPrivilege()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_qqVipPrivilege()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_qqVipPrivilege()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_startPrivilege()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_startPrivilege()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_startPrivilege()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_accountType()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_accountType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_accountType()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_openID()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_openID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_openID()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_headImgValidTime()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_headImgValidTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_headImgValidTime()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_curHeadImgFrame()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_curHeadImgFrame()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_curHeadImgFrame()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_accountState()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_accountState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_accountState()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_mayDayGrowthExp()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_mayDayGrowthExp()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_mayDayGrowthExp()
	{
		return (has_bits_[0] & 0x20000) != 0;
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
		uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src);
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
		errorType = account.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src2 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src2, usedSize);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeInt8(gender);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src4 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src4);
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
		int src5 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src5, usedSize2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src6 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(lastOnlineTm);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(lastOnlineTm);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src8 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(curProfilePicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src9 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(curProfilePicID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src10 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src10);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(legoLandLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src11 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src11);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(legoLandLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src12 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(legoLandExp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src13 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(legoLandExp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src14 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src14);
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
			uint src15 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
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
			uint src16 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
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
		uint src17 = TdrTLV.makeTag(28, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(level);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src18 = TdrTLV.makeTag(29, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src18);
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
		errorType = qqVipPrivilege.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src19 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src19, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src20 = TdrTLV.makeTag(30, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src20);
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
		errorType = startPrivilege.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src21 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src21, usedSize4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src22 = TdrTLV.makeTag(31, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src22);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(accountType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src23 = TdrTLV.makeTag(32, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src23);
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
		int num2 = TdrTypeUtil.cstrlen(openID);
		if (num2 >= 64)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(openID, num2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src24 = destBuf.getUsedSize() - usedSize5 - 4;
		errorType = destBuf.writeInt32(src24, usedSize5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src25 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src25);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(headImgValidTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src26 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src26);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(headImgValidTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src27 = TdrTLV.makeTag(34, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
		errorType = curHeadImgFrame.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src28 = destBuf.getUsedSize() - usedSize6 - 4;
		errorType = destBuf.writeInt32(src28, usedSize6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src29 = TdrTLV.makeTag(35, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src29);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(accountState);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src30 = TdrTLV.makeTag(36, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src30);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(mayDayGrowthExp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src31 = TdrTLV.makeTag(36, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src31);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(mayDayGrowthExp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
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
			{
				if (!has_account())
				{
					set_has_account();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					errorType = account.unpackTLV(ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 2u:
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
			case 3u:
			{
				if (!has_roleName())
				{
					set_has_roleName();
				}
				int dest3 = 0;
				errorType = srcBuf.readInt32(ref dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest3 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref roleName, dest3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roleName[dest3] = 0;
				break;
			}
			case 4u:
				if (!has_lastOnlineTm())
				{
					set_has_lastOnlineTm();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref lastOnlineTm);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref lastOnlineTm);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 5u:
				if (!has_curProfilePicID())
				{
					set_has_curProfilePicID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref curProfilePicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref curProfilePicID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6u:
				if (!has_legoLandLevel())
				{
					set_has_legoLandLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref legoLandLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref legoLandLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 7u:
				if (!has_legoLandExp())
				{
					set_has_legoLandExp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref legoLandExp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref legoLandExp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
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
			case 27u:
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
			case 28u:
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
			case 29u:
			{
				if (!has_qqVipPrivilege())
				{
					set_has_qqVipPrivilege();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 > 0)
				{
					errorType = qqVipPrivilege.unpackTLV(ref srcBuf, dest2, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 30u:
			{
				if (!has_startPrivilege())
				{
					set_has_startPrivilege();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 > 0)
				{
					errorType = startPrivilege.unpackTLV(ref srcBuf, dest5, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 31u:
				if (!has_accountType())
				{
					set_has_accountType();
				}
				errorType = srcBuf.readUInt8(ref accountType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 32u:
			{
				if (!has_openID())
				{
					set_has_openID();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 >= 64)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref openID, dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				openID[dest4] = 0;
				break;
			}
			case 33u:
				if (!has_headImgValidTime())
				{
					set_has_headImgValidTime();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref headImgValidTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref headImgValidTime);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 34u:
			{
				if (!has_curHeadImgFrame())
				{
					set_has_curHeadImgFrame();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 > 0)
				{
					errorType = curHeadImgFrame.unpackTLV(ref srcBuf, dest6, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 35u:
				if (!has_accountState())
				{
					set_has_accountState();
				}
				errorType = srcBuf.readUInt8(ref accountState);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 36u:
				if (!has_mayDayGrowthExp())
				{
					set_has_mayDayGrowthExp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref mayDayGrowthExp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref mayDayGrowthExp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
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

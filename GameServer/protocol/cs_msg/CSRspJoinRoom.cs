using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSRspJoinRoom : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public int result;

	public ulong roomGID;

	public uint roomShortID;

	public ulong ownerGID;

	public ulong ownerActorID;

	public byte playerNum;

	public CSRoomPlayer[] playerList;

	public ushort gameMode;

	public byte gameStarted;

	public byte isPublic;

	public ulong publishWorkID;

	public byte maxPlayerNum;

	public CSUGCTeamInfo teamInfo;

	public byte slotNum;

	public CSTeamSlotStat[] slotStats;

	public byte scoreNum;

	public CSTeamScore[] scoreList;

	public byte[] password;

	public uint version;

	public ushort joinAuthID;

	public byte isMulti;

	public byte isAllowOtherJoin;

	public ulong authorAccGID;

	public byte authorDeviceType;

	public uint progressLevel;

	public byte workTag;

	public byte difficultyLevel;

	public CSRoomStatusDetail roomStatus;

	public byte[] roomName;

	public CSModDetail mod;

	public byte isSvrRoom;

	public byte isOldWorldRole;

	public CSPosition lastPos;

	public byte isOwnerBakestage;

	public byte isPubAudit;

	private uint[] has_bits_ = new uint[2];

	public static readonly uint LENGTH_password = 8u;

	public static readonly uint LENGTH_roomName = 32u;

	public CSRspJoinRoom()
	{
		playerList = new CSRoomPlayer[20];
		for (int i = 0; i < 20; i++)
		{
			playerList[i] = new CSRoomPlayer();
		}
		teamInfo = new CSUGCTeamInfo();
		slotStats = new CSTeamSlotStat[20];
		for (int j = 0; j < 20; j++)
		{
			slotStats[j] = new CSTeamSlotStat();
		}
		scoreList = new CSTeamScore[11];
		for (int k = 0; k < 11; k++)
		{
			scoreList[k] = new CSTeamScore();
		}
		password = new byte[8];
		roomStatus = new CSRoomStatusDetail();
		roomName = new byte[32];
		mod = new CSModDetail();
		lastPos = new CSPosition();
	}

	public void set_has_result()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_result()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_result()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_roomGID()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_roomGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_roomGID()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_roomShortID()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_roomShortID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_roomShortID()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_ownerGID()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_ownerGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_ownerGID()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_ownerActorID()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_ownerActorID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_ownerActorID()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_playerNum()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_playerNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_playerNum()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_playerList()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_playerList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_playerList()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_gameMode()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_gameMode()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_gameMode()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_gameStarted()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_gameStarted()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_gameStarted()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_isPublic()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_isPublic()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_isPublic()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_publishWorkID()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_publishWorkID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_publishWorkID()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_maxPlayerNum()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_maxPlayerNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_maxPlayerNum()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_teamInfo()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_teamInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_teamInfo()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_slotNum()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_slotNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_slotNum()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_slotStats()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_slotStats()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_slotStats()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_scoreNum()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_scoreNum()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_scoreNum()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_scoreList()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_scoreList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_scoreList()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_password()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_password()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_password()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_version()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_version()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_version()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_joinAuthID()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_joinAuthID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_joinAuthID()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_isMulti()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_isMulti()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_isMulti()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_isAllowOtherJoin()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_isAllowOtherJoin()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_isAllowOtherJoin()
	{
		return (has_bits_[0] & 0x200000) != 0;
	}

	public void set_has_authorAccGID()
	{
		has_bits_[0] |= 4194304u;
	}

	private void clear_has_authorAccGID()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4194305);
	}

	public bool has_authorAccGID()
	{
		return (has_bits_[0] & 0x400000) != 0;
	}

	public void set_has_authorDeviceType()
	{
		has_bits_[0] |= 8388608u;
	}

	private void clear_has_authorDeviceType()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8388609);
	}

	public bool has_authorDeviceType()
	{
		return (has_bits_[0] & 0x800000) != 0;
	}

	public void set_has_progressLevel()
	{
		has_bits_[0] |= 16777216u;
	}

	private void clear_has_progressLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16777217);
	}

	public bool has_progressLevel()
	{
		return (has_bits_[0] & 0x1000000) != 0;
	}

	public void set_has_workTag()
	{
		has_bits_[0] |= 33554432u;
	}

	private void clear_has_workTag()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33554433);
	}

	public bool has_workTag()
	{
		return (has_bits_[0] & 0x2000000) != 0;
	}

	public void set_has_difficultyLevel()
	{
		has_bits_[0] |= 67108864u;
	}

	private void clear_has_difficultyLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -67108865);
	}

	public bool has_difficultyLevel()
	{
		return (has_bits_[0] & 0x4000000) != 0;
	}

	public void set_has_roomStatus()
	{
		has_bits_[0] |= 134217728u;
	}

	private void clear_has_roomStatus()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -134217729);
	}

	public bool has_roomStatus()
	{
		return (has_bits_[0] & 0x8000000) != 0;
	}

	public void set_has_roomName()
	{
		has_bits_[0] |= 268435456u;
	}

	private void clear_has_roomName()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -268435457);
	}

	public bool has_roomName()
	{
		return (has_bits_[0] & 0x10000000) != 0;
	}

	public void set_has_mod()
	{
		has_bits_[0] |= 536870912u;
	}

	private void clear_has_mod()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -536870913);
	}

	public bool has_mod()
	{
		return (has_bits_[0] & 0x20000000) != 0;
	}

	public void set_has_isSvrRoom()
	{
		has_bits_[0] |= 1073741824u;
	}

	private void clear_has_isSvrRoom()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1073741825);
	}

	public bool has_isSvrRoom()
	{
		return (has_bits_[0] & 0x40000000) != 0;
	}

	public void set_has_isOldWorldRole()
	{
		has_bits_[0] |= 2147483648u;
	}

	private void clear_has_isOldWorldRole()
	{
		has_bits_[0] = has_bits_[0] & 0x7FFFFFFF;
	}

	public bool has_isOldWorldRole()
	{
		return (has_bits_[0] & 0x80000000u) != 0;
	}

	public void set_has_lastPos()
	{
		has_bits_[1] |= 1u;
	}

	private void clear_has_lastPos()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -2);
	}

	public bool has_lastPos()
	{
		return (has_bits_[1] & 1) != 0;
	}

	public void set_has_isOwnerBakestage()
	{
		has_bits_[1] |= 2u;
	}

	private void clear_has_isOwnerBakestage()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -3);
	}

	public bool has_isOwnerBakestage()
	{
		return (has_bits_[1] & 2) != 0;
	}

	public void set_has_isPubAudit()
	{
		has_bits_[1] |= 4u;
	}

	private void clear_has_isPubAudit()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -5);
	}

	public bool has_isPubAudit()
	{
		return (has_bits_[1] & 4) != 0;
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
			errorType = destBuf.writeVarInt32(result);
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
			errorType = destBuf.writeInt32(result);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src3 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src3);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(roomGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src4 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src4);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(roomGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(roomShortID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src6 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(roomShortID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(ownerGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src8 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(ownerGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src9 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(ownerActorID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src10 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src10);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(ownerActorID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src11 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(playerNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (playerNum > 20)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (playerNum > 0)
		{
			uint src12 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src12);
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
			for (int i = 0; i < playerNum; i++)
			{
				int usedSize2 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = playerList[i].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src13 = destBuf.getUsedSize() - usedSize2 - 4;
				errorType = destBuf.writeInt32(src13, usedSize2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src14 = destBuf.getUsedSize() - usedSize - 4;
			errorType = destBuf.writeInt32(src14, usedSize);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(gameMode);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src16 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(gameMode);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src17 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(gameStarted);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src18 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src18);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isPublic);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src19 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src19);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(publishWorkID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src20 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src20);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(publishWorkID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src21 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src21);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(maxPlayerNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src22 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src22);
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
		errorType = teamInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src23 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src23, usedSize3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src24 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src24);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(slotNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (slotNum > 20)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (slotNum > 0)
		{
			uint src25 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src25);
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
			for (int j = 0; j < slotNum; j++)
			{
				int usedSize5 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = slotStats[j].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src26 = destBuf.getUsedSize() - usedSize5 - 4;
				errorType = destBuf.writeInt32(src26, usedSize5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src27 = destBuf.getUsedSize() - usedSize4 - 4;
			errorType = destBuf.writeInt32(src27, usedSize4);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src28 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src28);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(scoreNum);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (scoreNum > 11)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (scoreNum > 0)
		{
			uint src29 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src29);
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
			for (int k = 0; k < scoreNum; k++)
			{
				int usedSize7 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = scoreList[k].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src30 = destBuf.getUsedSize() - usedSize7 - 4;
				errorType = destBuf.writeInt32(src30, usedSize7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src31 = destBuf.getUsedSize() - usedSize6 - 4;
			errorType = destBuf.writeInt32(src31, usedSize6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src32 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
		int num = TdrTypeUtil.cstrlen(password);
		if (num >= 8)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(password, num);
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
			uint src34 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(version);
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
			errorType = destBuf.writeUInt32(version);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src36 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src36);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(joinAuthID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src37 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src37);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(joinAuthID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src38 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src38);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isMulti);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src39 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src39);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isAllowOtherJoin);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src40 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src40);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(authorAccGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src41 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src41);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(authorAccGID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src42 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src42);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(authorDeviceType);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src43 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src43);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt32(progressLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src44 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src44);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(progressLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src45 = TdrTLV.makeTag(26, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src45);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(workTag);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src46 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src46);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(difficultyLevel);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src47 = TdrTLV.makeTag(28, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src47);
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
		errorType = roomStatus.packTLV((int)gameMode, ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src48 = destBuf.getUsedSize() - usedSize9 - 4;
		errorType = destBuf.writeInt32(src48, usedSize9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src49 = TdrTLV.makeTag(29, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src49);
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
		int num2 = TdrTypeUtil.cstrlen(roomName);
		if (num2 >= 32)
		{
			return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
		}
		errorType = destBuf.writeCString(roomName, num2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src50 = destBuf.getUsedSize() - usedSize10 - 4;
		errorType = destBuf.writeInt32(src50, usedSize10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src51 = TdrTLV.makeTag(30, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src51);
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
		errorType = mod.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src52 = destBuf.getUsedSize() - usedSize11 - 4;
		errorType = destBuf.writeInt32(src52, usedSize11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src53 = TdrTLV.makeTag(31, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src53);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isSvrRoom);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src54 = TdrTLV.makeTag(32, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src54);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isOldWorldRole);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (1 < isOldWorldRole)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (isOldWorldRole == 1)
		{
			uint src55 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src55);
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
			errorType = lastPos.packTLV(ref destBuf, useVarInt);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			int src56 = destBuf.getUsedSize() - usedSize12 - 4;
			errorType = destBuf.writeInt32(src56, usedSize12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src57 = TdrTLV.makeTag(34, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src57);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isOwnerBakestage);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src58 = TdrTLV.makeTag(35, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src58);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(isPubAudit);
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
				if (!has_result())
				{
					set_has_result();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref result);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref result);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 2u:
				if (!has_roomGID())
				{
					set_has_roomGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref roomGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref roomGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 3u:
				if (!has_roomShortID())
				{
					set_has_roomShortID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref roomShortID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref roomShortID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 4u:
				if (!has_ownerGID())
				{
					set_has_ownerGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref ownerGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref ownerGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 19u:
				if (!has_ownerActorID())
				{
					set_has_ownerActorID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref ownerActorID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref ownerActorID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 5u:
				if (!has_playerNum())
				{
					set_has_playerNum();
				}
				errorType = srcBuf.readUInt8(ref playerNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 6u:
			{
				if (!has_playerList())
				{
					set_has_playerList();
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
				for (int k = 0; k < 20; k++)
				{
					int dest12 = 0;
					errorType = srcBuf.readInt32(ref dest12);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest12 > 0)
					{
						errorType = playerList[k].unpackTLV(ref srcBuf, dest12, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize4 + dest11)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize4 + dest11)
					{
						playerNum = (byte)(k + 1);
						break;
					}
				}
				break;
			}
			case 7u:
				if (!has_gameMode())
				{
					set_has_gameMode();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref gameMode);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref gameMode);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
				if (!has_gameStarted())
				{
					set_has_gameStarted();
				}
				errorType = srcBuf.readUInt8(ref gameStarted);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 9u:
				if (!has_isPublic())
				{
					set_has_isPublic();
				}
				errorType = srcBuf.readUInt8(ref isPublic);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
				if (!has_publishWorkID())
				{
					set_has_publishWorkID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref publishWorkID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref publishWorkID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 11u:
				if (!has_maxPlayerNum())
				{
					set_has_maxPlayerNum();
				}
				errorType = srcBuf.readUInt8(ref maxPlayerNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 12u:
			{
				if (!has_teamInfo())
				{
					set_has_teamInfo();
				}
				int dest7 = 0;
				errorType = srcBuf.readInt32(ref dest7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest7 > 0)
				{
					errorType = teamInfo.unpackTLV(ref srcBuf, dest7, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 13u:
				if (!has_slotNum())
				{
					set_has_slotNum();
				}
				errorType = srcBuf.readUInt8(ref slotNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 14u:
			{
				if (!has_slotStats())
				{
					set_has_slotStats();
				}
				int dest8 = 0;
				errorType = srcBuf.readInt32(ref dest8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest8 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize3 = srcBuf.getUsedSize();
				for (int j = 0; j < 20; j++)
				{
					int dest9 = 0;
					errorType = srcBuf.readInt32(ref dest9);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest9 > 0)
					{
						errorType = slotStats[j].unpackTLV(ref srcBuf, dest9, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize3 + dest8)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize3 + dest8)
					{
						slotNum = (byte)(j + 1);
						break;
					}
				}
				break;
			}
			case 15u:
				if (!has_scoreNum())
				{
					set_has_scoreNum();
				}
				errorType = srcBuf.readUInt8(ref scoreNum);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 16u:
			{
				if (!has_scoreList())
				{
					set_has_scoreList();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize2 = srcBuf.getUsedSize();
				for (int i = 0; i < 11; i++)
				{
					int dest3 = 0;
					errorType = srcBuf.readInt32(ref dest3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest3 > 0)
					{
						errorType = scoreList[i].unpackTLV(ref srcBuf, dest3, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize2 + dest2)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize2 + dest2)
					{
						scoreNum = (byte)(i + 1);
						break;
					}
				}
				break;
			}
			case 17u:
			{
				if (!has_password())
				{
					set_has_password();
				}
				int dest6 = 0;
				errorType = srcBuf.readInt32(ref dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest6 >= 8)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref password, dest6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				password[dest6] = 0;
				break;
			}
			case 18u:
				if (!has_version())
				{
					set_has_version();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref version);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref version);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 20u:
				if (!has_joinAuthID())
				{
					set_has_joinAuthID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref joinAuthID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref joinAuthID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 21u:
				if (!has_isMulti())
				{
					set_has_isMulti();
				}
				errorType = srcBuf.readUInt8(ref isMulti);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 22u:
				if (!has_isAllowOtherJoin())
				{
					set_has_isAllowOtherJoin();
				}
				errorType = srcBuf.readUInt8(ref isAllowOtherJoin);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 23u:
				if (!has_authorAccGID())
				{
					set_has_authorAccGID();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref authorAccGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref authorAccGID);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 24u:
				if (!has_authorDeviceType())
				{
					set_has_authorDeviceType();
				}
				errorType = srcBuf.readUInt8(ref authorDeviceType);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 25u:
				if (!has_progressLevel())
				{
					set_has_progressLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt32(ref progressLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt32(ref progressLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 26u:
				if (!has_workTag())
				{
					set_has_workTag();
				}
				errorType = srcBuf.readUInt8(ref workTag);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 27u:
				if (!has_difficultyLevel())
				{
					set_has_difficultyLevel();
				}
				errorType = srcBuf.readUInt8(ref difficultyLevel);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 28u:
			{
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 > 0)
				{
					long selector = 0L;
					errorType = roomStatus.unpackTLV(ref selector, ref srcBuf, dest4, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					gameMode = (ushort)selector;
				}
				break;
			}
			case 29u:
			{
				if (!has_roomName())
				{
					set_has_roomName();
				}
				int dest13 = 0;
				errorType = srcBuf.readInt32(ref dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest13 >= 32)
				{
					return TdrError.ErrorType.TDR_ERR_STR_LEN_TOO_BIG;
				}
				errorType = srcBuf.readCString(ref roomName, dest13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				roomName[dest13] = 0;
				break;
			}
			case 30u:
			{
				if (!has_mod())
				{
					set_has_mod();
				}
				int dest10 = 0;
				errorType = srcBuf.readInt32(ref dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest10 > 0)
				{
					errorType = mod.unpackTLV(ref srcBuf, dest10, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 31u:
				if (!has_isSvrRoom())
				{
					set_has_isSvrRoom();
				}
				errorType = srcBuf.readUInt8(ref isSvrRoom);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 32u:
				if (!has_isOldWorldRole())
				{
					set_has_isOldWorldRole();
				}
				errorType = srcBuf.readUInt8(ref isOldWorldRole);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 33u:
			{
				if (!has_lastPos())
				{
					set_has_lastPos();
				}
				int dest5 = 0;
				errorType = srcBuf.readInt32(ref dest5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest5 > 0)
				{
					errorType = lastPos.unpackTLV(ref srcBuf, dest5, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				isOldWorldRole = 1;
				break;
			}
			case 34u:
				if (!has_isOwnerBakestage())
				{
					set_has_isOwnerBakestage();
				}
				errorType = srcBuf.readUInt8(ref isOwnerBakestage);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 35u:
				if (!has_isPubAudit())
				{
					set_has_isPubAudit();
				}
				errorType = srcBuf.readUInt8(ref isPubAudit);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
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

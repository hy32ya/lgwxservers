using System;
using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSDetailProfile : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public ulong todayVisitorCount;

	public uint recentOnlineTime;

	public CSPlayerProfileState profileState;

	public CSWearFashion fashion;

	public CSRoleStyle roleStyle;

	public CSMedalShowInfo medalIDInfo;

	public ushort publishedWorkCount;

	public ulong[] publishedWorkList;

	public byte recentCommentWorkCount;

	public ulong[] recentCommentWorkList;

	public byte favoriteWorkReadMode;

	public byte commentWorkReadMode;

	public ulong totalVisitsRecent;

	public byte lastVisitorCount;

	public CSAccountKey[] lastVisitorList;

	public ushort creatorLevel;

	private uint[] has_bits_ = new uint[1];

	public CSDetailProfile()
	{
		profileState = new CSPlayerProfileState();
		fashion = new CSWearFashion();
		roleStyle = new CSRoleStyle();
		medalIDInfo = new CSMedalShowInfo();
		publishedWorkList = new ulong[200];
		recentCommentWorkList = new ulong[100];
		lastVisitorList = new CSAccountKey[3];
		for (int i = 0; i < 3; i++)
		{
			lastVisitorList[i] = new CSAccountKey();
		}
	}

	public void set_has_todayVisitorCount()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_todayVisitorCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_todayVisitorCount()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_recentOnlineTime()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_recentOnlineTime()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_recentOnlineTime()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_profileState()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_profileState()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_profileState()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_fashion()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_fashion()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_fashion()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_roleStyle()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_roleStyle()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_roleStyle()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_medalIDInfo()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_medalIDInfo()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_medalIDInfo()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_publishedWorkCount()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_publishedWorkCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_publishedWorkCount()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_publishedWorkList()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_publishedWorkList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_publishedWorkList()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_recentCommentWorkCount()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_recentCommentWorkCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_recentCommentWorkCount()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_recentCommentWorkList()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_recentCommentWorkList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_recentCommentWorkList()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_favoriteWorkReadMode()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_favoriteWorkReadMode()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_favoriteWorkReadMode()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_commentWorkReadMode()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_commentWorkReadMode()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_commentWorkReadMode()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_totalVisitsRecent()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_totalVisitsRecent()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_totalVisitsRecent()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_lastVisitorCount()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_lastVisitorCount()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_lastVisitorCount()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_lastVisitorList()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_lastVisitorList()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_lastVisitorList()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_creatorLevel()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_creatorLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_creatorLevel()
	{
		return (has_bits_[0] & 0x8000) != 0;
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
			errorType = destBuf.writeVarUInt64(todayVisitorCount);
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
			errorType = destBuf.writeUInt64(todayVisitorCount);
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
			errorType = destBuf.writeVarUInt32(recentOnlineTime);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src4 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src4);
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
		uint src5 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
		errorType = destBuf.writeVarUInt32(src5);
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
		errorType = profileState.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src6 = destBuf.getUsedSize() - usedSize - 4;
		errorType = destBuf.writeInt32(src6, usedSize);
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
		int usedSize2 = destBuf.getUsedSize();
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
		int src8 = destBuf.getUsedSize() - usedSize2 - 4;
		errorType = destBuf.writeInt32(src8, usedSize2);
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
		int usedSize3 = destBuf.getUsedSize();
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
		int src10 = destBuf.getUsedSize() - usedSize3 - 4;
		errorType = destBuf.writeInt32(src10, usedSize3);
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
		int usedSize4 = destBuf.getUsedSize();
		errorType = destBuf.reserve(4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = medalIDInfo.packTLV(ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		int src12 = destBuf.getUsedSize() - usedSize4 - 4;
		errorType = destBuf.writeInt32(src12, usedSize4);
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
			errorType = destBuf.writeVarUInt16(publishedWorkCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(publishedWorkCount);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src15);
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
			for (int i = 0; i < 200; i++)
			{
				errorType = destBuf.writeVarUInt64(publishedWorkList[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src16 = destBuf.getUsedSize() - usedSize5 - 4;
			errorType = destBuf.writeInt32(src16, usedSize5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src17 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src17);
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
			int num = 1600;
			byte[] src18 = new byte[num];
			Buffer.BlockCopy(publishedWorkList, 0, src18, 0, num);
			TdrBufUtil.covertBytesOrder(src18, 8);
			errorType = destBuf.writeBytes(ref src18, num);
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
		}
		uint src20 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src20);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(recentCommentWorkCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (recentCommentWorkCount > 100)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (useVarInt)
		{
			if (recentCommentWorkCount > 0)
			{
				uint src21 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src21);
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
				for (int j = 0; j < recentCommentWorkCount; j++)
				{
					errorType = destBuf.writeVarUInt64(recentCommentWorkList[j]);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				int src22 = destBuf.getUsedSize() - usedSize7 - 4;
				errorType = destBuf.writeInt32(src22, usedSize7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
		}
		else if (recentCommentWorkCount > 0)
		{
			uint src23 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src23);
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
			if (recentCommentWorkCount > 0)
			{
				int num2 = recentCommentWorkCount * 8;
				byte[] src24 = new byte[num2];
				Buffer.BlockCopy(recentCommentWorkList, 0, src24, 0, num2);
				TdrBufUtil.covertBytesOrder(src24, 8);
				errorType = destBuf.writeBytes(ref src24, num2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src25 = destBuf.getUsedSize() - usedSize8 - 4;
			errorType = destBuf.writeInt32(src25, usedSize8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src26 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src26);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(favoriteWorkReadMode);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src27 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src27);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(commentWorkReadMode);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (useVarInt)
		{
			uint src28 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src28);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt64(totalVisitsRecent);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src29 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
			errorType = destBuf.writeVarUInt32(src29);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt64(totalVisitsRecent);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		uint src30 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src30);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(lastVisitorCount);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		if (lastVisitorCount > 3)
		{
			return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
		}
		if (lastVisitorCount > 0)
		{
			uint src31 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
			errorType = destBuf.writeVarUInt32(src31);
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
			for (int k = 0; k < lastVisitorCount; k++)
			{
				int usedSize10 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = lastVisitorList[k].packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src32 = destBuf.getUsedSize() - usedSize10 - 4;
				errorType = destBuf.writeInt32(src32, usedSize10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			int src33 = destBuf.getUsedSize() - usedSize9 - 4;
			errorType = destBuf.writeInt32(src33, usedSize9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src34 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarUInt16(creatorLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src35 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_2_BYTE);
			errorType = destBuf.writeVarUInt32(src35);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt16(creatorLevel);
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
			case 2u:
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
			case 3u:
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
			case 4u:
			{
				if (!has_fashion())
				{
					set_has_fashion();
				}
				int dest10 = 0;
				errorType = srcBuf.readInt32(ref dest10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest10 > 0)
				{
					errorType = fashion.unpackTLV(ref srcBuf, dest10, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 5u:
			{
				if (!has_roleStyle())
				{
					set_has_roleStyle();
				}
				int dest11 = 0;
				errorType = srcBuf.readInt32(ref dest11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest11 > 0)
				{
					errorType = roleStyle.unpackTLV(ref srcBuf, dest11, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 6u:
			{
				if (!has_medalIDInfo())
				{
					set_has_medalIDInfo();
				}
				int dest2 = 0;
				errorType = srcBuf.readInt32(ref dest2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest2 > 0)
				{
					errorType = medalIDInfo.unpackTLV(ref srcBuf, dest2, useVarInt);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			}
			case 7u:
				if (!has_publishedWorkCount())
				{
					set_has_publishedWorkCount();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref publishedWorkCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref publishedWorkCount);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
			{
				if (!has_publishedWorkList())
				{
					set_has_publishedWorkList();
				}
				int dest4 = 0;
				errorType = srcBuf.readInt32(ref dest4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				if (dest4 == 0)
				{
					return TdrError.ErrorType.TDR_ERR_NULL_ARRAY;
				}
				int usedSize2 = srcBuf.getUsedSize();
				if (useVarInt)
				{
					for (int i = 0; i < 200; i++)
					{
						errorType = srcBuf.readVarUInt64(ref publishedWorkList[i]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize2 + dest4)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize2 + dest4)
						{
							break;
						}
					}
				}
				else
				{
					int num3 = dest4;
					byte[] dest5 = new byte[num3];
					errorType = srcBuf.readBytes(ref dest5, num3);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest5, 8);
					Buffer.BlockCopy(dest5, 0, publishedWorkList, 0, num3);
				}
				break;
			}
			case 9u:
				if (!has_recentCommentWorkCount())
				{
					set_has_recentCommentWorkCount();
				}
				errorType = srcBuf.readUInt8(ref recentCommentWorkCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
			{
				if (!has_recentCommentWorkList())
				{
					set_has_recentCommentWorkList();
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
				int usedSize4 = srcBuf.getUsedSize();
				if (useVarInt)
				{
					for (int k = 0; k < 100; k++)
					{
						errorType = srcBuf.readVarUInt64(ref recentCommentWorkList[k]);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
						if (srcBuf.getUsedSize() > usedSize4 + dest8)
						{
							return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
						}
						if (srcBuf.getUsedSize() == usedSize4 + dest8)
						{
							recentCommentWorkCount = (byte)(k + 1);
							break;
						}
					}
				}
				else
				{
					int num4 = dest8;
					byte[] dest9 = new byte[num4];
					errorType = srcBuf.readBytes(ref dest9, num4);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					TdrBufUtil.covertBytesOrder(dest9, 8);
					Buffer.BlockCopy(dest9, 0, recentCommentWorkList, 0, num4);
				}
				break;
			}
			case 11u:
				if (!has_favoriteWorkReadMode())
				{
					set_has_favoriteWorkReadMode();
				}
				errorType = srcBuf.readUInt8(ref favoriteWorkReadMode);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 12u:
				if (!has_commentWorkReadMode())
				{
					set_has_commentWorkReadMode();
				}
				errorType = srcBuf.readUInt8(ref commentWorkReadMode);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 13u:
				if (!has_totalVisitsRecent())
				{
					set_has_totalVisitsRecent();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt64(ref totalVisitsRecent);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt64(ref totalVisitsRecent);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 14u:
				if (!has_lastVisitorCount())
				{
					set_has_lastVisitorCount();
				}
				errorType = srcBuf.readUInt8(ref lastVisitorCount);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 15u:
			{
				if (!has_lastVisitorList())
				{
					set_has_lastVisitorList();
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
				int usedSize3 = srcBuf.getUsedSize();
				for (int j = 0; j < 3; j++)
				{
					int dest7 = 0;
					errorType = srcBuf.readInt32(ref dest7);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					if (dest7 > 0)
					{
						errorType = lastVisitorList[j].unpackTLV(ref srcBuf, dest7, useVarInt);
						if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
						{
							return errorType;
						}
					}
					if (srcBuf.getUsedSize() > usedSize3 + dest6)
					{
						return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
					}
					if (srcBuf.getUsedSize() == usedSize3 + dest6)
					{
						lastVisitorCount = (byte)(j + 1);
						break;
					}
				}
				break;
			}
			case 16u:
				if (!has_creatorLevel())
				{
					set_has_creatorLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarUInt16(ref creatorLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readUInt16(ref creatorLevel);
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

using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSWearCurrencyType : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public byte suit;

	public byte body;

	public byte leg;

	public byte deco;

	public byte torso;

	public byte head;

	public byte back;

	public byte lefthand;

	public byte righthand;

	public byte foot;

	public byte waist;

	public byte hair;

	public byte brow;

	public byte eye;

	public byte mouth;

	public byte face;

	public byte hairColor;

	public byte footprint;

	public byte fixedeffect;

	public byte sound;

	public byte facecombine;

	private uint[] has_bits_ = new uint[1];

	public void set_has_suit()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_suit()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_suit()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_body()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_body()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_body()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_leg()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_leg()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_leg()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_deco()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_deco()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_deco()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_torso()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_torso()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_torso()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_head()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_head()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_head()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_back()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_back()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_back()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_lefthand()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_lefthand()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_lefthand()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_righthand()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_righthand()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_righthand()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_foot()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_foot()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_foot()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_waist()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_waist()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_waist()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_hair()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_hair()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_hair()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_brow()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_brow()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_brow()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_eye()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_eye()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_eye()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_mouth()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_mouth()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_mouth()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_face()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_face()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_face()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_hairColor()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_hairColor()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_hairColor()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_footprint()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_footprint()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_footprint()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_fixedeffect()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_fixedeffect()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_fixedeffect()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_sound()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_sound()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_sound()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_facecombine()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_facecombine()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_facecombine()
	{
		return (has_bits_[0] & 0x100000) != 0;
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
		uint src = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(suit);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src2 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src2);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(body);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src3 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src3);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(leg);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src4 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src4);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(deco);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src5 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src5);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(torso);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src6 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src6);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(head);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src7 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src7);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(back);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src8 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src8);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(lefthand);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src9 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src9);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(righthand);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src10 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src10);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(foot);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src11 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src11);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(waist);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src12 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src12);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(hair);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src13 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src13);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(brow);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src14 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src14);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(eye);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src15 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src15);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(mouth);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src16 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src16);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(face);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src17 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src17);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(hairColor);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src18 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src18);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(footprint);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src19 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src19);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(fixedeffect);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src20 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src20);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(sound);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		uint src21 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_1_BYTE);
		errorType = destBuf.writeVarUInt32(src21);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		errorType = destBuf.writeUInt8(facecombine);
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
				if (!has_suit())
				{
					set_has_suit();
				}
				errorType = srcBuf.readUInt8(ref suit);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 2u:
				if (!has_body())
				{
					set_has_body();
				}
				errorType = srcBuf.readUInt8(ref body);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 3u:
				if (!has_leg())
				{
					set_has_leg();
				}
				errorType = srcBuf.readUInt8(ref leg);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 4u:
				if (!has_deco())
				{
					set_has_deco();
				}
				errorType = srcBuf.readUInt8(ref deco);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 5u:
				if (!has_torso())
				{
					set_has_torso();
				}
				errorType = srcBuf.readUInt8(ref torso);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 6u:
				if (!has_head())
				{
					set_has_head();
				}
				errorType = srcBuf.readUInt8(ref head);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 7u:
				if (!has_back())
				{
					set_has_back();
				}
				errorType = srcBuf.readUInt8(ref back);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 8u:
				if (!has_lefthand())
				{
					set_has_lefthand();
				}
				errorType = srcBuf.readUInt8(ref lefthand);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 9u:
				if (!has_righthand())
				{
					set_has_righthand();
				}
				errorType = srcBuf.readUInt8(ref righthand);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 10u:
				if (!has_foot())
				{
					set_has_foot();
				}
				errorType = srcBuf.readUInt8(ref foot);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 11u:
				if (!has_waist())
				{
					set_has_waist();
				}
				errorType = srcBuf.readUInt8(ref waist);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 12u:
				if (!has_hair())
				{
					set_has_hair();
				}
				errorType = srcBuf.readUInt8(ref hair);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 13u:
				if (!has_brow())
				{
					set_has_brow();
				}
				errorType = srcBuf.readUInt8(ref brow);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 14u:
				if (!has_eye())
				{
					set_has_eye();
				}
				errorType = srcBuf.readUInt8(ref eye);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 15u:
				if (!has_mouth())
				{
					set_has_mouth();
				}
				errorType = srcBuf.readUInt8(ref mouth);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 16u:
				if (!has_face())
				{
					set_has_face();
				}
				errorType = srcBuf.readUInt8(ref face);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 17u:
				if (!has_hairColor())
				{
					set_has_hairColor();
				}
				errorType = srcBuf.readUInt8(ref hairColor);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 18u:
				if (!has_footprint())
				{
					set_has_footprint();
				}
				errorType = srcBuf.readUInt8(ref footprint);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 19u:
				if (!has_fixedeffect())
				{
					set_has_fixedeffect();
				}
				errorType = srcBuf.readUInt8(ref fixedeffect);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 20u:
				if (!has_sound())
				{
					set_has_sound();
				}
				errorType = srcBuf.readUInt8(ref sound);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			case 21u:
				if (!has_facecombine())
				{
					set_has_facecombine();
				}
				errorType = srcBuf.readUInt8(ref facecombine);
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

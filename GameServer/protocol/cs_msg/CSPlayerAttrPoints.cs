using tsf4g_tdr_csharp;

namespace cs_msg;

public class CSPlayerAttrPoints : tsf4g_csharp_interface, IPackable, IUnpackable
{
	public int maxHp;

	public int speedStealth;

	public int speedRun;

	public int speedSprint;

	public int speedSwim;

	public int defenseLevel;

	public int physicalAttack;

	public int magicAttack;

	public int attackDistance;

	public int criticalHitProb;

	public int criticalHitDamage;

	public int toughness;

	public int efficiencyProper;

	public int strength;

	public int damageLevel;

	public int maxOxygen;

	public int harvestLevel;

	public int jumpPower;

	public int oxygenConsume;

	public int currentHp;

	public int currentHunger;

	public int currentOxygen;

	public int currentInGameCoin;

	public int currentEnergy;

	public int physicalDefense;

	public int magicDefense;

	public int maxHunger;

	public int attackSpeed;

	public int knockBack;

	public int tapDistance;

	public int upTapDistance;

	public int downTapDistance;

	public int currentScore;

	public int maxSp;

	public int currSp;

	public int currentExpValue;

	public int currentExpLevel;

	private uint[] has_bits_ = new uint[2];

	public void set_has_maxHp()
	{
		has_bits_[0] |= 1u;
	}

	private void clear_has_maxHp()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2);
	}

	public bool has_maxHp()
	{
		return (has_bits_[0] & 1) != 0;
	}

	public void set_has_speedStealth()
	{
		has_bits_[0] |= 2u;
	}

	private void clear_has_speedStealth()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -3);
	}

	public bool has_speedStealth()
	{
		return (has_bits_[0] & 2) != 0;
	}

	public void set_has_speedRun()
	{
		has_bits_[0] |= 4u;
	}

	private void clear_has_speedRun()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -5);
	}

	public bool has_speedRun()
	{
		return (has_bits_[0] & 4) != 0;
	}

	public void set_has_speedSprint()
	{
		has_bits_[0] |= 8u;
	}

	private void clear_has_speedSprint()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -9);
	}

	public bool has_speedSprint()
	{
		return (has_bits_[0] & 8) != 0;
	}

	public void set_has_speedSwim()
	{
		has_bits_[0] |= 16u;
	}

	private void clear_has_speedSwim()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -17);
	}

	public bool has_speedSwim()
	{
		return (has_bits_[0] & 0x10) != 0;
	}

	public void set_has_defenseLevel()
	{
		has_bits_[0] |= 32u;
	}

	private void clear_has_defenseLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33);
	}

	public bool has_defenseLevel()
	{
		return (has_bits_[0] & 0x20) != 0;
	}

	public void set_has_physicalAttack()
	{
		has_bits_[0] |= 64u;
	}

	private void clear_has_physicalAttack()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65);
	}

	public bool has_physicalAttack()
	{
		return (has_bits_[0] & 0x40) != 0;
	}

	public void set_has_magicAttack()
	{
		has_bits_[0] |= 128u;
	}

	private void clear_has_magicAttack()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -129);
	}

	public bool has_magicAttack()
	{
		return (has_bits_[0] & 0x80) != 0;
	}

	public void set_has_attackDistance()
	{
		has_bits_[0] |= 256u;
	}

	private void clear_has_attackDistance()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -257);
	}

	public bool has_attackDistance()
	{
		return (has_bits_[0] & 0x100) != 0;
	}

	public void set_has_criticalHitProb()
	{
		has_bits_[0] |= 512u;
	}

	private void clear_has_criticalHitProb()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -513);
	}

	public bool has_criticalHitProb()
	{
		return (has_bits_[0] & 0x200) != 0;
	}

	public void set_has_criticalHitDamage()
	{
		has_bits_[0] |= 1024u;
	}

	private void clear_has_criticalHitDamage()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1025);
	}

	public bool has_criticalHitDamage()
	{
		return (has_bits_[0] & 0x400) != 0;
	}

	public void set_has_toughness()
	{
		has_bits_[0] |= 2048u;
	}

	private void clear_has_toughness()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2049);
	}

	public bool has_toughness()
	{
		return (has_bits_[0] & 0x800) != 0;
	}

	public void set_has_efficiencyProper()
	{
		has_bits_[0] |= 4096u;
	}

	private void clear_has_efficiencyProper()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4097);
	}

	public bool has_efficiencyProper()
	{
		return (has_bits_[0] & 0x1000) != 0;
	}

	public void set_has_strength()
	{
		has_bits_[0] |= 8192u;
	}

	private void clear_has_strength()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8193);
	}

	public bool has_strength()
	{
		return (has_bits_[0] & 0x2000) != 0;
	}

	public void set_has_damageLevel()
	{
		has_bits_[0] |= 16384u;
	}

	private void clear_has_damageLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16385);
	}

	public bool has_damageLevel()
	{
		return (has_bits_[0] & 0x4000) != 0;
	}

	public void set_has_maxOxygen()
	{
		has_bits_[0] |= 32768u;
	}

	private void clear_has_maxOxygen()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -32769);
	}

	public bool has_maxOxygen()
	{
		return (has_bits_[0] & 0x8000) != 0;
	}

	public void set_has_harvestLevel()
	{
		has_bits_[0] |= 65536u;
	}

	private void clear_has_harvestLevel()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -65537);
	}

	public bool has_harvestLevel()
	{
		return (has_bits_[0] & 0x10000) != 0;
	}

	public void set_has_jumpPower()
	{
		has_bits_[0] |= 131072u;
	}

	private void clear_has_jumpPower()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -131073);
	}

	public bool has_jumpPower()
	{
		return (has_bits_[0] & 0x20000) != 0;
	}

	public void set_has_oxygenConsume()
	{
		has_bits_[0] |= 262144u;
	}

	private void clear_has_oxygenConsume()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -262145);
	}

	public bool has_oxygenConsume()
	{
		return (has_bits_[0] & 0x40000) != 0;
	}

	public void set_has_currentHp()
	{
		has_bits_[0] |= 524288u;
	}

	private void clear_has_currentHp()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -524289);
	}

	public bool has_currentHp()
	{
		return (has_bits_[0] & 0x80000) != 0;
	}

	public void set_has_currentHunger()
	{
		has_bits_[0] |= 1048576u;
	}

	private void clear_has_currentHunger()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1048577);
	}

	public bool has_currentHunger()
	{
		return (has_bits_[0] & 0x100000) != 0;
	}

	public void set_has_currentOxygen()
	{
		has_bits_[0] |= 2097152u;
	}

	private void clear_has_currentOxygen()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -2097153);
	}

	public bool has_currentOxygen()
	{
		return (has_bits_[0] & 0x200000) != 0;
	}

	public void set_has_currentInGameCoin()
	{
		has_bits_[0] |= 4194304u;
	}

	private void clear_has_currentInGameCoin()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -4194305);
	}

	public bool has_currentInGameCoin()
	{
		return (has_bits_[0] & 0x400000) != 0;
	}

	public void set_has_currentEnergy()
	{
		has_bits_[0] |= 8388608u;
	}

	private void clear_has_currentEnergy()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -8388609);
	}

	public bool has_currentEnergy()
	{
		return (has_bits_[0] & 0x800000) != 0;
	}

	public void set_has_physicalDefense()
	{
		has_bits_[0] |= 16777216u;
	}

	private void clear_has_physicalDefense()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -16777217);
	}

	public bool has_physicalDefense()
	{
		return (has_bits_[0] & 0x1000000) != 0;
	}

	public void set_has_magicDefense()
	{
		has_bits_[0] |= 33554432u;
	}

	private void clear_has_magicDefense()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -33554433);
	}

	public bool has_magicDefense()
	{
		return (has_bits_[0] & 0x2000000) != 0;
	}

	public void set_has_maxHunger()
	{
		has_bits_[0] |= 67108864u;
	}

	private void clear_has_maxHunger()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -67108865);
	}

	public bool has_maxHunger()
	{
		return (has_bits_[0] & 0x4000000) != 0;
	}

	public void set_has_attackSpeed()
	{
		has_bits_[0] |= 134217728u;
	}

	private void clear_has_attackSpeed()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -134217729);
	}

	public bool has_attackSpeed()
	{
		return (has_bits_[0] & 0x8000000) != 0;
	}

	public void set_has_knockBack()
	{
		has_bits_[0] |= 268435456u;
	}

	private void clear_has_knockBack()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -268435457);
	}

	public bool has_knockBack()
	{
		return (has_bits_[0] & 0x10000000) != 0;
	}

	public void set_has_tapDistance()
	{
		has_bits_[0] |= 536870912u;
	}

	private void clear_has_tapDistance()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -536870913);
	}

	public bool has_tapDistance()
	{
		return (has_bits_[0] & 0x20000000) != 0;
	}

	public void set_has_upTapDistance()
	{
		has_bits_[0] |= 1073741824u;
	}

	private void clear_has_upTapDistance()
	{
		has_bits_[0] = (uint)(has_bits_[0] & -1073741825);
	}

	public bool has_upTapDistance()
	{
		return (has_bits_[0] & 0x40000000) != 0;
	}

	public void set_has_downTapDistance()
	{
		has_bits_[0] |= 2147483648u;
	}

	private void clear_has_downTapDistance()
	{
		has_bits_[0] = has_bits_[0] & 0x7FFFFFFF;
	}

	public bool has_downTapDistance()
	{
		return (has_bits_[0] & 0x80000000u) != 0;
	}

	public void set_has_currentScore()
	{
		has_bits_[1] |= 1u;
	}

	private void clear_has_currentScore()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -2);
	}

	public bool has_currentScore()
	{
		return (has_bits_[1] & 1) != 0;
	}

	public void set_has_maxSp()
	{
		has_bits_[1] |= 2u;
	}

	private void clear_has_maxSp()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -3);
	}

	public bool has_maxSp()
	{
		return (has_bits_[1] & 2) != 0;
	}

	public void set_has_currSp()
	{
		has_bits_[1] |= 4u;
	}

	private void clear_has_currSp()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -5);
	}

	public bool has_currSp()
	{
		return (has_bits_[1] & 4) != 0;
	}

	public void set_has_currentExpValue()
	{
		has_bits_[1] |= 8u;
	}

	private void clear_has_currentExpValue()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -9);
	}

	public bool has_currentExpValue()
	{
		return (has_bits_[1] & 8) != 0;
	}

	public void set_has_currentExpLevel()
	{
		has_bits_[1] |= 16u;
	}

	private void clear_has_currentExpLevel()
	{
		has_bits_[1] = (uint)(has_bits_[1] & -17);
	}

	public bool has_currentExpLevel()
	{
		return (has_bits_[1] & 0x10) != 0;
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
			errorType = destBuf.writeVarInt32(maxHp);
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
			errorType = destBuf.writeInt32(maxHp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src3 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src3);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(speedStealth);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src4 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src4);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(speedStealth);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src5 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src5);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(speedRun);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src6 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src6);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(speedRun);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src7 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src7);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(speedSprint);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src8 = TdrTLV.makeTag(6, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src8);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(speedSprint);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src9 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src9);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(speedSwim);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src10 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src10);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(speedSwim);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src11 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src11);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(defenseLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src12 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src12);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(defenseLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src13 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src13);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(physicalAttack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src14 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src14);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(physicalAttack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src15 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src15);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(magicAttack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src16 = TdrTLV.makeTag(11, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src16);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(magicAttack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src17 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src17);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(attackDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src18 = TdrTLV.makeTag(13, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src18);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(attackDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src19 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src19);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(criticalHitProb);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src20 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src20);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(criticalHitProb);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src21 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src21);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(criticalHitDamage);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src22 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src22);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(criticalHitDamage);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src23 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src23);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(toughness);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src24 = TdrTLV.makeTag(16, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src24);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(toughness);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src25 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src25);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(efficiencyProper);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src26 = TdrTLV.makeTag(17, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src26);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(efficiencyProper);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src27 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src27);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(strength);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src28 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src28);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(strength);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src29 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src29);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(damageLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src30 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src30);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(damageLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src31 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src31);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(maxOxygen);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src32 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src32);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(maxOxygen);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src33 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src33);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(harvestLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src34 = TdrTLV.makeTag(21, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src34);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(harvestLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src35 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src35);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(jumpPower);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src36 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src36);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(jumpPower);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src37 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src37);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(oxygenConsume);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src38 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src38);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(oxygenConsume);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src39 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src39);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentHp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src40 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src40);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentHp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src41 = TdrTLV.makeTag(26, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src41);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentHunger);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src42 = TdrTLV.makeTag(26, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src42);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentHunger);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src43 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src43);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentOxygen);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src44 = TdrTLV.makeTag(27, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src44);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentOxygen);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src45 = TdrTLV.makeTag(28, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src45);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentInGameCoin);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src46 = TdrTLV.makeTag(28, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src46);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentInGameCoin);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src47 = TdrTLV.makeTag(29, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src47);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentEnergy);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src48 = TdrTLV.makeTag(29, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src48);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentEnergy);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src49 = TdrTLV.makeTag(30, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src49);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(physicalDefense);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src50 = TdrTLV.makeTag(30, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src50);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(physicalDefense);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src51 = TdrTLV.makeTag(31, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src51);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(magicDefense);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src52 = TdrTLV.makeTag(31, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src52);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(magicDefense);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src53 = TdrTLV.makeTag(32, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src53);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(maxHunger);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src54 = TdrTLV.makeTag(32, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src54);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(maxHunger);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src55 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src55);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(attackSpeed);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src56 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src56);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(attackSpeed);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src57 = TdrTLV.makeTag(35, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src57);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(knockBack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src58 = TdrTLV.makeTag(35, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src58);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(knockBack);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src59 = TdrTLV.makeTag(37, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src59);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(tapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src60 = TdrTLV.makeTag(37, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src60);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(tapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src61 = TdrTLV.makeTag(38, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src61);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(upTapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src62 = TdrTLV.makeTag(38, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src62);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(upTapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src63 = TdrTLV.makeTag(39, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src63);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(downTapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src64 = TdrTLV.makeTag(39, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src64);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(downTapDistance);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src65 = TdrTLV.makeTag(40, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src65);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentScore);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src66 = TdrTLV.makeTag(40, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src66);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentScore);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src67 = TdrTLV.makeTag(41, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src67);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(maxSp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src68 = TdrTLV.makeTag(41, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src68);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(maxSp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src69 = TdrTLV.makeTag(42, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src69);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currSp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src70 = TdrTLV.makeTag(42, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src70);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currSp);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src71 = TdrTLV.makeTag(43, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src71);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentExpValue);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src72 = TdrTLV.makeTag(43, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src72);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentExpValue);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		if (useVarInt)
		{
			uint src73 = TdrTLV.makeTag(44, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
			errorType = destBuf.writeVarUInt32(src73);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeVarInt32(currentExpLevel);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		else
		{
			uint src74 = TdrTLV.makeTag(44, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
			errorType = destBuf.writeVarUInt32(src74);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeInt32(currentExpLevel);
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
				if (!has_maxHp())
				{
					set_has_maxHp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref maxHp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref maxHp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 4u:
				if (!has_speedStealth())
				{
					set_has_speedStealth();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref speedStealth);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref speedStealth);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 5u:
				if (!has_speedRun())
				{
					set_has_speedRun();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref speedRun);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref speedRun);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 6u:
				if (!has_speedSprint())
				{
					set_has_speedSprint();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref speedSprint);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref speedSprint);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 7u:
				if (!has_speedSwim())
				{
					set_has_speedSwim();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref speedSwim);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref speedSwim);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 8u:
				if (!has_defenseLevel())
				{
					set_has_defenseLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref defenseLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref defenseLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 9u:
				if (!has_physicalAttack())
				{
					set_has_physicalAttack();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref physicalAttack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref physicalAttack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 11u:
				if (!has_magicAttack())
				{
					set_has_magicAttack();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref magicAttack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref magicAttack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 13u:
				if (!has_attackDistance())
				{
					set_has_attackDistance();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref attackDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref attackDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 14u:
				if (!has_criticalHitProb())
				{
					set_has_criticalHitProb();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref criticalHitProb);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref criticalHitProb);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 15u:
				if (!has_criticalHitDamage())
				{
					set_has_criticalHitDamage();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref criticalHitDamage);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref criticalHitDamage);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 16u:
				if (!has_toughness())
				{
					set_has_toughness();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref toughness);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref toughness);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 17u:
				if (!has_efficiencyProper())
				{
					set_has_efficiencyProper();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref efficiencyProper);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref efficiencyProper);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 18u:
				if (!has_strength())
				{
					set_has_strength();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref strength);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref strength);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 19u:
				if (!has_damageLevel())
				{
					set_has_damageLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref damageLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref damageLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 20u:
				if (!has_maxOxygen())
				{
					set_has_maxOxygen();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref maxOxygen);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref maxOxygen);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 21u:
				if (!has_harvestLevel())
				{
					set_has_harvestLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref harvestLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref harvestLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 22u:
				if (!has_jumpPower())
				{
					set_has_jumpPower();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref jumpPower);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref jumpPower);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 23u:
				if (!has_oxygenConsume())
				{
					set_has_oxygenConsume();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref oxygenConsume);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref oxygenConsume);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 24u:
				if (!has_currentHp())
				{
					set_has_currentHp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentHp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentHp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 26u:
				if (!has_currentHunger())
				{
					set_has_currentHunger();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentHunger);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentHunger);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 27u:
				if (!has_currentOxygen())
				{
					set_has_currentOxygen();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentOxygen);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentOxygen);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 28u:
				if (!has_currentInGameCoin())
				{
					set_has_currentInGameCoin();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentInGameCoin);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentInGameCoin);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 29u:
				if (!has_currentEnergy())
				{
					set_has_currentEnergy();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentEnergy);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentEnergy);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 30u:
				if (!has_physicalDefense())
				{
					set_has_physicalDefense();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref physicalDefense);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref physicalDefense);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 31u:
				if (!has_magicDefense())
				{
					set_has_magicDefense();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref magicDefense);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref magicDefense);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 32u:
				if (!has_maxHunger())
				{
					set_has_maxHunger();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref maxHunger);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref maxHunger);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 33u:
				if (!has_attackSpeed())
				{
					set_has_attackSpeed();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref attackSpeed);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref attackSpeed);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 35u:
				if (!has_knockBack())
				{
					set_has_knockBack();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref knockBack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref knockBack);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 37u:
				if (!has_tapDistance())
				{
					set_has_tapDistance();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref tapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref tapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 38u:
				if (!has_upTapDistance())
				{
					set_has_upTapDistance();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref upTapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref upTapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 39u:
				if (!has_downTapDistance())
				{
					set_has_downTapDistance();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref downTapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref downTapDistance);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 40u:
				if (!has_currentScore())
				{
					set_has_currentScore();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentScore);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentScore);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 41u:
				if (!has_maxSp())
				{
					set_has_maxSp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref maxSp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref maxSp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 42u:
				if (!has_currSp())
				{
					set_has_currSp();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currSp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currSp);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 43u:
				if (!has_currentExpValue())
				{
					set_has_currentExpValue();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentExpValue);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentExpValue);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 44u:
				if (!has_currentExpLevel())
				{
					set_has_currentExpLevel();
				}
				if (useVarInt)
				{
					errorType = srcBuf.readVarInt32(ref currentExpLevel);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					errorType = srcBuf.readInt32(ref currentExpLevel);
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

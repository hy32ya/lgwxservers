using System;
using System.Runtime.InteropServices;
using tsf4g_tdr_csharp;

namespace cs_msg;

[StructLayout(LayoutKind.Explicit)]
public class CSTlogEventUnion
{
	[FieldOffset(0)]
	public CSTlogBlockStat putBlock;

	[FieldOffset(0)]
	public CSTlogBlockStat delBlock;

	[FieldOffset(0)]
	public CSTlogBlockStat useToolCopyArea;

	[FieldOffset(0)]
	public CSTlogClictMapEvent beginDownload;

	[FieldOffset(0)]
	public CSTlogClictMapEvent mapDetail;

	[FieldOffset(0)]
	public CSAccountKey getPC;

	[FieldOffset(0)]
	public CSAccountKey getMyWork;

	[FieldOffset(0)]
	public CSAccountKey getMyPlay;

	[FieldOffset(0)]
	public CSAccountKey getMyFollower;

	[FieldOffset(0)]
	public CSTlogClictMapEvent endDownload;

	[FieldOffset(0)]
	public CSTlogClickEvent dailySign;

	[FieldOffset(0)]
	public CSTlogClickEvent todoTask;

	[FieldOffset(0)]
	public CSTlogSns subscribe;

	[FieldOffset(0)]
	public CSTlogSns addFriend;

	[FieldOffset(0)]
	public CSTlogClictMapEvent deleteLocalMap;

	[FieldOffset(0)]
	public CSTlogBlockStat useToolDelArea;

	[FieldOffset(0)]
	public CSTlogBlockStat useToolMoveArea;

	[FieldOffset(0)]
	public CSTlogBlockStat useToolCopyWidget;

	[FieldOffset(0)]
	public CSTlogBlockStat useToolReplaceWidget;

	[FieldOffset(0)]
	public CSTlogTrigger useTrigger;

	[FieldOffset(0)]
	public CSTlogClickEvent achievementDetail;

	[FieldOffset(0)]
	public CSTlogAchievement achievementActivate;

	[FieldOffset(0)]
	public CSTlogNewMap createNewMap;

	[FieldOffset(0)]
	public CSTlogMaterialLib materialLib;

	[FieldOffset(0)]
	public CSTlogMapCardClick mapCardClick;

	[FieldOffset(0)]
	public CSShare share;

	[FieldOffset(8)]
	public uint guideMap;

	[FieldOffset(0)]
	public CSTlogRecommentEvent recomment;

	[FieldOffset(0)]
	public CSTlogUIOperation uiOperation;

	[FieldOffset(8)]
	public ulong visitFriendLand;

	[FieldOffset(8)]
	public uint npcDialog;

	[FieldOffset(0)]
	public CSTlogMinifigure minifigure;

	[FieldOffset(0)]
	public CSClickVedio clickVedio;

	public tsf4g_csharp_interface select(long selector)
	{
		if (selector >= 1 && selector <= 40)
		{
			switch (selector - 1)
			{
			case 0L:
			{
				Type typeFromHandle16 = typeof(CSTlogBlockStat);
				if (putBlock == null || !typeFromHandle16.IsInstanceOfType(putBlock))
				{
					putBlock = new CSTlogBlockStat();
				}
				return putBlock;
			}
			case 1L:
			{
				Type typeFromHandle20 = typeof(CSTlogBlockStat);
				if (delBlock == null || !typeFromHandle20.IsInstanceOfType(delBlock))
				{
					delBlock = new CSTlogBlockStat();
				}
				return delBlock;
			}
			case 2L:
			{
				Type typeFromHandle3 = typeof(CSTlogBlockStat);
				if (useToolCopyArea == null || !typeFromHandle3.IsInstanceOfType(useToolCopyArea))
				{
					useToolCopyArea = new CSTlogBlockStat();
				}
				return useToolCopyArea;
			}
			case 3L:
			{
				Type typeFromHandle7 = typeof(CSTlogClictMapEvent);
				if (beginDownload == null || !typeFromHandle7.IsInstanceOfType(beginDownload))
				{
					beginDownload = new CSTlogClictMapEvent();
				}
				return beginDownload;
			}
			case 4L:
			{
				Type typeFromHandle10 = typeof(CSTlogClictMapEvent);
				if (mapDetail == null || !typeFromHandle10.IsInstanceOfType(mapDetail))
				{
					mapDetail = new CSTlogClictMapEvent();
				}
				return mapDetail;
			}
			case 6L:
			{
				Type typeFromHandle6 = typeof(CSAccountKey);
				if (getPC == null || !typeFromHandle6.IsInstanceOfType(getPC))
				{
					getPC = new CSAccountKey();
				}
				return getPC;
			}
			case 7L:
			{
				Type typeFromHandle30 = typeof(CSAccountKey);
				if (getMyWork == null || !typeFromHandle30.IsInstanceOfType(getMyWork))
				{
					getMyWork = new CSAccountKey();
				}
				return getMyWork;
			}
			case 8L:
			{
				Type typeFromHandle26 = typeof(CSAccountKey);
				if (getMyPlay == null || !typeFromHandle26.IsInstanceOfType(getMyPlay))
				{
					getMyPlay = new CSAccountKey();
				}
				return getMyPlay;
			}
			case 9L:
			{
				Type typeFromHandle22 = typeof(CSAccountKey);
				if (getMyFollower == null || !typeFromHandle22.IsInstanceOfType(getMyFollower))
				{
					getMyFollower = new CSAccountKey();
				}
				return getMyFollower;
			}
			case 11L:
			{
				Type typeFromHandle24 = typeof(CSTlogClictMapEvent);
				if (endDownload == null || !typeFromHandle24.IsInstanceOfType(endDownload))
				{
					endDownload = new CSTlogClictMapEvent();
				}
				return endDownload;
			}
			case 13L:
			{
				Type typeFromHandle14 = typeof(CSTlogClickEvent);
				if (dailySign == null || !typeFromHandle14.IsInstanceOfType(dailySign))
				{
					dailySign = new CSTlogClickEvent();
				}
				return dailySign;
			}
			case 14L:
			{
				Type typeFromHandle11 = typeof(CSTlogClickEvent);
				if (todoTask == null || !typeFromHandle11.IsInstanceOfType(todoTask))
				{
					todoTask = new CSTlogClickEvent();
				}
				return todoTask;
			}
			case 17L:
			{
				Type typeFromHandle27 = typeof(CSTlogSns);
				if (subscribe == null || !typeFromHandle27.IsInstanceOfType(subscribe))
				{
					subscribe = new CSTlogSns();
				}
				return subscribe;
			}
			case 18L:
			{
				Type typeFromHandle23 = typeof(CSTlogSns);
				if (addFriend == null || !typeFromHandle23.IsInstanceOfType(addFriend))
				{
					addFriend = new CSTlogSns();
				}
				return addFriend;
			}
			case 19L:
			{
				Type typeFromHandle19 = typeof(CSTlogClictMapEvent);
				if (deleteLocalMap == null || !typeFromHandle19.IsInstanceOfType(deleteLocalMap))
				{
					deleteLocalMap = new CSTlogClictMapEvent();
				}
				return deleteLocalMap;
			}
			case 21L:
			{
				Type typeFromHandle8 = typeof(CSTlogBlockStat);
				if (useToolDelArea == null || !typeFromHandle8.IsInstanceOfType(useToolDelArea))
				{
					useToolDelArea = new CSTlogBlockStat();
				}
				return useToolDelArea;
			}
			case 22L:
			{
				Type typeFromHandle4 = typeof(CSTlogBlockStat);
				if (useToolMoveArea == null || !typeFromHandle4.IsInstanceOfType(useToolMoveArea))
				{
					useToolMoveArea = new CSTlogBlockStat();
				}
				return useToolMoveArea;
			}
			case 23L:
			{
				Type typeFromHandle28 = typeof(CSTlogBlockStat);
				if (useToolCopyWidget == null || !typeFromHandle28.IsInstanceOfType(useToolCopyWidget))
				{
					useToolCopyWidget = new CSTlogBlockStat();
				}
				return useToolCopyWidget;
			}
			case 24L:
			{
				Type typeFromHandle18 = typeof(CSTlogBlockStat);
				if (useToolReplaceWidget == null || !typeFromHandle18.IsInstanceOfType(useToolReplaceWidget))
				{
					useToolReplaceWidget = new CSTlogBlockStat();
				}
				return useToolReplaceWidget;
			}
			case 25L:
			{
				Type typeFromHandle15 = typeof(CSTlogTrigger);
				if (useTrigger == null || !typeFromHandle15.IsInstanceOfType(useTrigger))
				{
					useTrigger = new CSTlogTrigger();
				}
				return useTrigger;
			}
			case 27L:
			{
				Type typeFromHandle12 = typeof(CSTlogClickEvent);
				if (achievementDetail == null || !typeFromHandle12.IsInstanceOfType(achievementDetail))
				{
					achievementDetail = new CSTlogClickEvent();
				}
				return achievementDetail;
			}
			case 28L:
			{
				Type typeFromHandle2 = typeof(CSTlogAchievement);
				if (achievementActivate == null || !typeFromHandle2.IsInstanceOfType(achievementActivate))
				{
					achievementActivate = new CSTlogAchievement();
				}
				return achievementActivate;
			}
			case 29L:
			{
				Type typeFromHandle29 = typeof(CSTlogNewMap);
				if (createNewMap == null || !typeFromHandle29.IsInstanceOfType(createNewMap))
				{
					createNewMap = new CSTlogNewMap();
				}
				return createNewMap;
			}
			case 30L:
			{
				Type typeFromHandle25 = typeof(CSTlogMaterialLib);
				if (materialLib == null || !typeFromHandle25.IsInstanceOfType(materialLib))
				{
					materialLib = new CSTlogMaterialLib();
				}
				return materialLib;
			}
			case 31L:
			{
				Type typeFromHandle21 = typeof(CSTlogMapCardClick);
				if (mapCardClick == null || !typeFromHandle21.IsInstanceOfType(mapCardClick))
				{
					mapCardClick = new CSTlogMapCardClick();
				}
				return mapCardClick;
			}
			case 32L:
			{
				Type typeFromHandle17 = typeof(CSShare);
				if (share == null || !typeFromHandle17.IsInstanceOfType(share))
				{
					share = new CSShare();
				}
				return share;
			}
			case 34L:
			{
				Type typeFromHandle13 = typeof(CSTlogRecommentEvent);
				if (recomment == null || !typeFromHandle13.IsInstanceOfType(recomment))
				{
					recomment = new CSTlogRecommentEvent();
				}
				return recomment;
			}
			case 35L:
			{
				Type typeFromHandle9 = typeof(CSTlogUIOperation);
				if (uiOperation == null || !typeFromHandle9.IsInstanceOfType(uiOperation))
				{
					uiOperation = new CSTlogUIOperation();
				}
				return uiOperation;
			}
			case 38L:
			{
				Type typeFromHandle5 = typeof(CSTlogMinifigure);
				if (minifigure == null || !typeFromHandle5.IsInstanceOfType(minifigure))
				{
					minifigure = new CSTlogMinifigure();
				}
				return minifigure;
			}
			case 39L:
			{
				Type typeFromHandle = typeof(CSClickVedio);
				if (clickVedio == null || !typeFromHandle.IsInstanceOfType(clickVedio))
				{
					clickVedio = new CSClickVedio();
				}
				return clickVedio;
			}
			}
		}
		return null;
	}

	public TdrError.ErrorType construct(long selector)
	{
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		tsf4g_csharp_interface tsf4g_csharp_interface = select(selector);
		if (tsf4g_csharp_interface != null)
		{
			return tsf4g_csharp_interface.construct();
		}
		switch (selector)
		{
		case 34L:
			guideMap = 0u;
			break;
		case 37L:
			visitFriendLand = 0uL;
			break;
		case 38L:
			npcDialog = 0u;
			break;
		}
		return result;
	}

	public TdrError.ErrorType packTLV(long selector, ref byte[] buffer, int size, ref int used, bool useVarInt)
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
		errorType = packTLV(selector, ref destBuf, useVarInt);
		if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return errorType;
		}
		used = destBuf.getUsedSize();
		destBuf.writeInt32(used, usedSize);
		return errorType;
	}

	public TdrError.ErrorType packTLV(long selector, ref TdrWriteBuf destBuf, bool useVarInt)
	{
		if (destBuf == null)
		{
			return TdrError.ErrorType.TDR_ERR_ARG_IS_NULL;
		}
		TdrError.ErrorType errorType = TdrError.ErrorType.TDR_NO_ERROR;
		if (selector >= 1 && selector <= 40)
		{
			switch (selector - 1)
			{
			case 0L:
			{
				if (putBlock == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src29 = TdrTLV.makeTag(1, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src29);
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
				errorType = putBlock.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src30 = destBuf.getUsedSize() - usedSize15 - 4;
				errorType = destBuf.writeInt32(src30, usedSize15);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 1L:
			{
				if (delBlock == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src65 = TdrTLV.makeTag(2, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src65);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize30 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = delBlock.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src66 = destBuf.getUsedSize() - usedSize30 - 4;
				errorType = destBuf.writeInt32(src66, usedSize30);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 2L:
			{
				if (useToolCopyArea == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src23 = TdrTLV.makeTag(3, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src23);
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
				errorType = useToolCopyArea.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src24 = destBuf.getUsedSize() - usedSize12 - 4;
				errorType = destBuf.writeInt32(src24, usedSize12);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 3L:
			{
				if (beginDownload == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src7 = TdrTLV.makeTag(4, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src7);
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
				errorType = beginDownload.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src8 = destBuf.getUsedSize() - usedSize4 - 4;
				errorType = destBuf.writeInt32(src8, usedSize4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 4L:
			{
				if (mapDetail == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src31 = TdrTLV.makeTag(5, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src31);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize16 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = mapDetail.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src32 = destBuf.getUsedSize() - usedSize16 - 4;
				errorType = destBuf.writeInt32(src32, usedSize16);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 6L:
			{
				if (getPC == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src55 = TdrTLV.makeTag(7, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src55);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize27 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = getPC.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src56 = destBuf.getUsedSize() - usedSize27 - 4;
				errorType = destBuf.writeInt32(src56, usedSize27);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 7L:
			{
				if (getMyWork == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src9 = TdrTLV.makeTag(8, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src9);
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
				errorType = getMyWork.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src10 = destBuf.getUsedSize() - usedSize5 - 4;
				errorType = destBuf.writeInt32(src10, usedSize5);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 8L:
			{
				if (getMyPlay == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src61 = TdrTLV.makeTag(9, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src61);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize28 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = getMyPlay.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src62 = destBuf.getUsedSize() - usedSize28 - 4;
				errorType = destBuf.writeInt32(src62, usedSize28);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 9L:
			{
				if (getMyFollower == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src51 = TdrTLV.makeTag(10, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src51);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize25 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = getMyFollower.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src52 = destBuf.getUsedSize() - usedSize25 - 4;
				errorType = destBuf.writeInt32(src52, usedSize25);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 11L:
			{
				if (endDownload == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src33 = TdrTLV.makeTag(12, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src33);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize17 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = endDownload.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src34 = destBuf.getUsedSize() - usedSize17 - 4;
				errorType = destBuf.writeInt32(src34, usedSize17);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 13L:
			{
				if (dailySign == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src43 = TdrTLV.makeTag(14, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src43);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize21 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = dailySign.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src44 = destBuf.getUsedSize() - usedSize21 - 4;
				errorType = destBuf.writeInt32(src44, usedSize21);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 14L:
			{
				if (todoTask == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src45 = TdrTLV.makeTag(15, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src45);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize22 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = todoTask.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src46 = destBuf.getUsedSize() - usedSize22 - 4;
				errorType = destBuf.writeInt32(src46, usedSize22);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 17L:
			{
				if (subscribe == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src63 = TdrTLV.makeTag(18, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src63);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize29 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = subscribe.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src64 = destBuf.getUsedSize() - usedSize29 - 4;
				errorType = destBuf.writeInt32(src64, usedSize29);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 18L:
			{
				if (addFriend == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src11 = TdrTLV.makeTag(19, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src11);
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
				errorType = addFriend.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src12 = destBuf.getUsedSize() - usedSize6 - 4;
				errorType = destBuf.writeInt32(src12, usedSize6);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 19L:
			{
				if (deleteLocalMap == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src37 = TdrTLV.makeTag(20, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src37);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize19 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = deleteLocalMap.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src38 = destBuf.getUsedSize() - usedSize19 - 4;
				errorType = destBuf.writeInt32(src38, usedSize19);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 21L:
			{
				if (useToolDelArea == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src3 = TdrTLV.makeTag(22, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src3);
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
				errorType = useToolDelArea.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src4 = destBuf.getUsedSize() - usedSize2 - 4;
				errorType = destBuf.writeInt32(src4, usedSize2);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 22L:
			{
				if (useToolMoveArea == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src25 = TdrTLV.makeTag(23, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src25);
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
				errorType = useToolMoveArea.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src26 = destBuf.getUsedSize() - usedSize13 - 4;
				errorType = destBuf.writeInt32(src26, usedSize13);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 23L:
			{
				if (useToolCopyWidget == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src49 = TdrTLV.makeTag(24, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src49);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize24 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = useToolCopyWidget.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src50 = destBuf.getUsedSize() - usedSize24 - 4;
				errorType = destBuf.writeInt32(src50, usedSize24);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 24L:
			{
				if (useToolReplaceWidget == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src17 = TdrTLV.makeTag(25, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src17);
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
				errorType = useToolReplaceWidget.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src18 = destBuf.getUsedSize() - usedSize9 - 4;
				errorType = destBuf.writeInt32(src18, usedSize9);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 25L:
			{
				if (useTrigger == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src47 = TdrTLV.makeTag(26, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src47);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize23 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = useTrigger.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src48 = destBuf.getUsedSize() - usedSize23 - 4;
				errorType = destBuf.writeInt32(src48, usedSize23);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 27L:
			{
				if (achievementDetail == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src19 = TdrTLV.makeTag(28, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src19);
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
				errorType = achievementDetail.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src20 = destBuf.getUsedSize() - usedSize10 - 4;
				errorType = destBuf.writeInt32(src20, usedSize10);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 28L:
			{
				if (achievementActivate == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src53 = TdrTLV.makeTag(29, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src53);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize26 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = achievementActivate.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src54 = destBuf.getUsedSize() - usedSize26 - 4;
				errorType = destBuf.writeInt32(src54, usedSize26);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 29L:
			{
				if (createNewMap == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src27 = TdrTLV.makeTag(30, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src27);
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
				errorType = createNewMap.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src28 = destBuf.getUsedSize() - usedSize14 - 4;
				errorType = destBuf.writeInt32(src28, usedSize14);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 30L:
			{
				if (materialLib == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src5 = TdrTLV.makeTag(31, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src5);
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
				errorType = materialLib.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src6 = destBuf.getUsedSize() - usedSize3 - 4;
				errorType = destBuf.writeInt32(src6, usedSize3);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 31L:
			{
				if (mapCardClick == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src39 = TdrTLV.makeTag(32, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src39);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize20 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = mapCardClick.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src40 = destBuf.getUsedSize() - usedSize20 - 4;
				errorType = destBuf.writeInt32(src40, usedSize20);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 32L:
			{
				if (share == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src15 = TdrTLV.makeTag(33, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src15);
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
				errorType = share.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src16 = destBuf.getUsedSize() - usedSize8 - 4;
				errorType = destBuf.writeInt32(src16, usedSize8);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 33L:
				if (useVarInt)
				{
					uint src57 = TdrTLV.makeTag(34, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src57);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt32(guideMap);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src58 = TdrTLV.makeTag(34, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src58);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt32(guideMap);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 34L:
			{
				if (recomment == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src35 = TdrTLV.makeTag(35, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src35);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int usedSize18 = destBuf.getUsedSize();
				errorType = destBuf.reserve(4);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				errorType = recomment.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src36 = destBuf.getUsedSize() - usedSize18 - 4;
				errorType = destBuf.writeInt32(src36, usedSize18);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 35L:
			{
				if (uiOperation == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src13 = TdrTLV.makeTag(36, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src13);
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
				errorType = uiOperation.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src14 = destBuf.getUsedSize() - usedSize7 - 4;
				errorType = destBuf.writeInt32(src14, usedSize7);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 36L:
				if (useVarInt)
				{
					uint src59 = TdrTLV.makeTag(37, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src59);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt64(visitFriendLand);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src60 = TdrTLV.makeTag(37, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_8_BYTE);
					errorType = destBuf.writeVarUInt32(src60);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt64(visitFriendLand);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 37L:
				if (useVarInt)
				{
					uint src41 = TdrTLV.makeTag(38, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_VARINT);
					errorType = destBuf.writeVarUInt32(src41);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeVarUInt32(npcDialog);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				else
				{
					uint src42 = TdrTLV.makeTag(38, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_4_BYTE);
					errorType = destBuf.writeVarUInt32(src42);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
					errorType = destBuf.writeUInt32(npcDialog);
					if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
					{
						return errorType;
					}
				}
				break;
			case 38L:
			{
				if (minifigure == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src21 = TdrTLV.makeTag(39, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
				errorType = destBuf.writeVarUInt32(src21);
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
				errorType = minifigure.packTLV(ref destBuf, useVarInt);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				int src22 = destBuf.getUsedSize() - usedSize11 - 4;
				errorType = destBuf.writeInt32(src22, usedSize11);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
				break;
			}
			case 39L:
			{
				if (clickVedio == null)
				{
					return TdrError.ErrorType.TDR_ERR_UNION_SELECTE_FIELD_IS_NULL;
				}
				uint src = TdrTLV.makeTag(40, TdrTLV.TdrTLVTypeId.TDR_TYPE_ID_LENGTH_DELIMITED);
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
				errorType = clickVedio.packTLV(ref destBuf, useVarInt);
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
				break;
			}
			}
		}
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref long selector, ref byte[] buffer, int size, ref int used)
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
		int num = dest2 - TdrTLV.TLV_MSG_MIN_SIZE;
		if (num > 0)
		{
			errorType = unpackTLV(ref selector, ref srcBuf, num, flag);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
		}
		used = srcBuf.getUsedSize();
		return errorType;
	}

	public TdrError.ErrorType unpackTLV(ref long selector, ref TdrReadBuf srcBuf, int length, bool useVarInt)
	{
		if (srcBuf == null)
		{
			return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
		}
		TdrError.ErrorType result = TdrError.ErrorType.TDR_NO_ERROR;
		if (length == 0)
		{
			return result;
		}
		int usedSize = srcBuf.getUsedSize();
		uint dest = 0u;
		result = srcBuf.readVarUInt32(ref dest);
		if (result != TdrError.ErrorType.TDR_NO_ERROR)
		{
			return result;
		}
		uint fieldId = TdrTLV.getFieldId(dest);
		switch (fieldId)
		{
		case 1u:
		{
			putBlock = new CSTlogBlockStat();
			int dest14 = 0;
			result = srcBuf.readInt32(ref dest14);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest14 > 0)
			{
				result = putBlock.unpackTLV(ref srcBuf, dest14, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 2u:
		{
			delBlock = new CSTlogBlockStat();
			int dest25 = 0;
			result = srcBuf.readInt32(ref dest25);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest25 > 0)
			{
				result = delBlock.unpackTLV(ref srcBuf, dest25, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 3u:
		{
			useToolCopyArea = new CSTlogBlockStat();
			int dest16 = 0;
			result = srcBuf.readInt32(ref dest16);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest16 > 0)
			{
				result = useToolCopyArea.unpackTLV(ref srcBuf, dest16, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 4u:
		{
			beginDownload = new CSTlogClictMapEvent();
			int dest9 = 0;
			result = srcBuf.readInt32(ref dest9);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest9 > 0)
			{
				result = beginDownload.unpackTLV(ref srcBuf, dest9, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 5u:
		{
			mapDetail = new CSTlogClictMapEvent();
			int dest28 = 0;
			result = srcBuf.readInt32(ref dest28);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest28 > 0)
			{
				result = mapDetail.unpackTLV(ref srcBuf, dest28, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 7u:
		{
			getPC = new CSAccountKey();
			int dest30 = 0;
			result = srcBuf.readInt32(ref dest30);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest30 > 0)
			{
				result = getPC.unpackTLV(ref srcBuf, dest30, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 8u:
		{
			getMyWork = new CSAccountKey();
			int dest10 = 0;
			result = srcBuf.readInt32(ref dest10);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest10 > 0)
			{
				result = getMyWork.unpackTLV(ref srcBuf, dest10, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 9u:
		{
			getMyPlay = new CSAccountKey();
			int dest20 = 0;
			result = srcBuf.readInt32(ref dest20);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest20 > 0)
			{
				result = getMyPlay.unpackTLV(ref srcBuf, dest20, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 10u:
		{
			getMyFollower = new CSAccountKey();
			int dest4 = 0;
			result = srcBuf.readInt32(ref dest4);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest4 > 0)
			{
				result = getMyFollower.unpackTLV(ref srcBuf, dest4, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 12u:
		{
			endDownload = new CSTlogClictMapEvent();
			int dest19 = 0;
			result = srcBuf.readInt32(ref dest19);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest19 > 0)
			{
				result = endDownload.unpackTLV(ref srcBuf, dest19, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 14u:
		{
			dailySign = new CSTlogClickEvent();
			int dest7 = 0;
			result = srcBuf.readInt32(ref dest7);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest7 > 0)
			{
				result = dailySign.unpackTLV(ref srcBuf, dest7, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 15u:
		{
			todoTask = new CSTlogClickEvent();
			int dest24 = 0;
			result = srcBuf.readInt32(ref dest24);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest24 > 0)
			{
				result = todoTask.unpackTLV(ref srcBuf, dest24, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 18u:
		{
			subscribe = new CSTlogSns();
			int dest11 = 0;
			result = srcBuf.readInt32(ref dest11);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest11 > 0)
			{
				result = subscribe.unpackTLV(ref srcBuf, dest11, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 19u:
		{
			addFriend = new CSTlogSns();
			int dest31 = 0;
			result = srcBuf.readInt32(ref dest31);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest31 > 0)
			{
				result = addFriend.unpackTLV(ref srcBuf, dest31, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 20u:
		{
			deleteLocalMap = new CSTlogClictMapEvent();
			int dest22 = 0;
			result = srcBuf.readInt32(ref dest22);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest22 > 0)
			{
				result = deleteLocalMap.unpackTLV(ref srcBuf, dest22, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 22u:
		{
			useToolDelArea = new CSTlogBlockStat();
			int dest15 = 0;
			result = srcBuf.readInt32(ref dest15);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest15 > 0)
			{
				result = useToolDelArea.unpackTLV(ref srcBuf, dest15, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 23u:
		{
			useToolMoveArea = new CSTlogBlockStat();
			int dest2 = 0;
			result = srcBuf.readInt32(ref dest2);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest2 > 0)
			{
				result = useToolMoveArea.unpackTLV(ref srcBuf, dest2, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 24u:
		{
			useToolCopyWidget = new CSTlogBlockStat();
			int dest27 = 0;
			result = srcBuf.readInt32(ref dest27);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest27 > 0)
			{
				result = useToolCopyWidget.unpackTLV(ref srcBuf, dest27, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 25u:
		{
			useToolReplaceWidget = new CSTlogBlockStat();
			int dest18 = 0;
			result = srcBuf.readInt32(ref dest18);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest18 > 0)
			{
				result = useToolReplaceWidget.unpackTLV(ref srcBuf, dest18, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 26u:
		{
			useTrigger = new CSTlogTrigger();
			int dest13 = 0;
			result = srcBuf.readInt32(ref dest13);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest13 > 0)
			{
				result = useTrigger.unpackTLV(ref srcBuf, dest13, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 28u:
		{
			achievementDetail = new CSTlogClickEvent();
			int dest5 = 0;
			result = srcBuf.readInt32(ref dest5);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest5 > 0)
			{
				result = achievementDetail.unpackTLV(ref srcBuf, dest5, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 29u:
		{
			achievementActivate = new CSTlogAchievement();
			int dest29 = 0;
			result = srcBuf.readInt32(ref dest29);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest29 > 0)
			{
				result = achievementActivate.unpackTLV(ref srcBuf, dest29, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 30u:
		{
			createNewMap = new CSTlogNewMap();
			int dest23 = 0;
			result = srcBuf.readInt32(ref dest23);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest23 > 0)
			{
				result = createNewMap.unpackTLV(ref srcBuf, dest23, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 31u:
		{
			materialLib = new CSTlogMaterialLib();
			int dest17 = 0;
			result = srcBuf.readInt32(ref dest17);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest17 > 0)
			{
				result = materialLib.unpackTLV(ref srcBuf, dest17, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 32u:
		{
			mapCardClick = new CSTlogMapCardClick();
			int dest12 = 0;
			result = srcBuf.readInt32(ref dest12);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest12 > 0)
			{
				result = mapCardClick.unpackTLV(ref srcBuf, dest12, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 33u:
		{
			share = new CSShare();
			int dest6 = 0;
			result = srcBuf.readInt32(ref dest6);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest6 > 0)
			{
				result = share.unpackTLV(ref srcBuf, dest6, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 34u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt32(ref guideMap);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt32(ref guideMap);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 35u:
		{
			recomment = new CSTlogRecommentEvent();
			int dest26 = 0;
			result = srcBuf.readInt32(ref dest26);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest26 > 0)
			{
				result = recomment.unpackTLV(ref srcBuf, dest26, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 36u:
		{
			uiOperation = new CSTlogUIOperation();
			int dest21 = 0;
			result = srcBuf.readInt32(ref dest21);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest21 > 0)
			{
				result = uiOperation.unpackTLV(ref srcBuf, dest21, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 37u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt64(ref visitFriendLand);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt64(ref visitFriendLand);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 38u:
			if (useVarInt)
			{
				result = srcBuf.readVarUInt32(ref npcDialog);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			else
			{
				result = srcBuf.readUInt32(ref npcDialog);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		case 39u:
		{
			minifigure = new CSTlogMinifigure();
			int dest8 = 0;
			result = srcBuf.readInt32(ref dest8);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest8 > 0)
			{
				result = minifigure.unpackTLV(ref srcBuf, dest8, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		case 40u:
		{
			clickVedio = new CSClickVedio();
			int dest3 = 0;
			result = srcBuf.readInt32(ref dest3);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			if (dest3 > 0)
			{
				result = clickVedio.unpackTLV(ref srcBuf, dest3, useVarInt);
				if (result != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return result;
				}
			}
			break;
		}
		default:
		{
			uint typeId = TdrTLV.getTypeId(dest);
			result = TdrTLV.skipUnknownFields(ref srcBuf, (TdrTLV.TdrTLVTypeId)typeId);
			if (result != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return result;
			}
			break;
		}
		}
		if (srcBuf.getUsedSize() > usedSize + length)
		{
			return TdrError.ErrorType.TDR_ERR_UNMATCHED_LENGTH;
		}
		selector = fieldId;
		return result;
	}
}

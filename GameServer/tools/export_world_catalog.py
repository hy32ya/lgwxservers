"""从指定 APK 导出原表及本地生存砍树规则。"""
import argparse
import json
from pathlib import Path
import xml.etree.ElementTree as ET
import zipfile

from client_resources import decrypt_resource


# 仅列成熟树，避免把家具、树苗等当作木材。
SURVIVAL_TREE_MATERIALS = {
    **{name: 'Cube_CYellow' for name in (
        'Pine3', 'Pine4', 'Pine5', 'Pine6',
        'Pine_Iceplain_1', 'Pine_Iceplain_2', 'Pine_Iceplain_3', 'Pine_Iceplain_4')},
    **{name: 'Cube_LNougat' for name in ('Betula_1', 'Betula_2')},
    **{name: 'Cube_EarthOrange' for name in (
        'Oak0', 'Oak1', 'Oak2', 'Oak3', 'Oak4', 'Oak5', 'Oak6',
        'Poplar_Euphratica_1', 'Poplar_Euphratica_2', 'Poplar_Euphratica_3',
        'Palm1', 'Palm2', 'Palm_1', 'Palm_2',
        'Tree_1', 'Tree_2', 'Tree_3', 'Tree_4', 'Tree_5', 'Tree_6', 'Tree_7',
        'Tree_Plain_1', 'Tree_Plain_2', 'Tree_Plain_3',
        'Tree_Snowy_1', 'Tree_Snowy_2',
        'Tree_Swamp_1', 'Tree_Swamp_2', 'Tree_Swamp_3',
        'Tree_Swamp_4', 'Tree_Swamp_5', 'Tree_Swamp_6')},
}


def export(apk, destination):
    with zipfile.ZipFile(apk) as archive:
        def xml(name):
            return ET.fromstring(decrypt_resource(archive.read('assets/External/Mods/' + name)))

        items = {}
        by_name = {}
        for element in xml('Base/ItemTables/ItemClasses.xml'):
            if element.tag == 'TagItem' or 'id' not in element.attrib:
                continue
            attr = {key: value for key, value in element.attrib.items() if value != ''}
            item_id = int(attr['id'])
            durability = int(attr.get('durability', 0))
            equip = element.tag in {'EquipmentItem', 'MeleeWeaponItem', 'RangedWeaponItem'} or (
                durability > 0 and element.tag not in {'VehicleEggItem', 'AnimalEggItem'})
            items[item_id] = {
                'Id': item_id, 'Name': attr.get('name', ''), 'Label': attr.get('desc', ''),
                'Type': 1 if equip else 2,
                'Stack': 1 if equip else max(1, min(65535, int(attr.get('stackCount', 1)))),
                'Durability': durability, 'HarvestLevel': int(attr.get('harvestLevel', 0)),
                'WearPerUse': int(attr.get('durableConsumePerTime', 10)),
                'Category': attr.get('category', attr.get('toolClass', '')),
                'FoodLevel': int(attr.get('foodLevel', 0)),
                'Saturation': int(attr.get('saturationModifier', 0)),
                'BuffId': int(attr.get('buffID', 0)),
                'Cooldown': int(attr.get('cooldownTime', 0)),
                'CooldownGroup': int(attr.get('coolDownGroupId', 0)),
                'Efficiency': int(attr.get('efficiencyProper', 0)),
                'Tags': [int(attr[f'tag{i}']) for i in range(1, 4)
                         if int(attr.get(f'tag{i}', 0)) > 0]}
            if element.tag == 'BlockItem':
                by_name.setdefault(attr.get('name'), item_id)

        block_items = {}
        first_ids = {}
        survival_tree_drops = {}
        for group in xml('Base/BlockIDMapping.xml'):
            first = int(group.get('FirstBlockID', 0))
            count = int(group.get('BlockCount', 0))
            material = SURVIVAL_TREE_MATERIALS.get(group.get('Name'))
            for block_id in range(first, first + count):
                block_items[block_id] = by_name.get(group.get('Name'), 0)
                first_ids[block_id] = first
                if material:
                    # 每棵五个，为本地设定，非原服产量。
                    survival_tree_drops[block_id] = {'ItemId': by_name[material], 'Count': 5}

        def choices(attr, id_pattern, factor_pattern):
            return [{'Id': int(attr.get(id_pattern.format(i), 0)),
                     'Factor': int(attr.get(factor_pattern.format(i), 0))}
                    for i in range(1, 6) if int(attr.get(id_pattern.format(i), 0)) > 0]

        blocks, events, options = {}, {}, {}
        for element in xml('Base/DropTable.xml'):
            attr = {key: value for key, value in element.attrib.items() if value != ''}
            entry_id = int(attr['ID'])
            if element.tag == 'BlockDrop':
                blocks[entry_id] = {
                    'ItemId': block_items.get(entry_id, 0), 'FirstId': first_ids.get(entry_id, entry_id),
                    'Enabled': attr.get('isDrop', '').lower() in ('true', '1'),
                    'Self': attr.get('isDropSelf', '').lower() in ('true', '1'),
                    'Events': choices(attr, 'dropEventID{}', 'dropEventFactor{}')}
            elif element.tag == 'DropEvent':
                events[entry_id] = {'Probability': attr.get('dropType') == '概率',
                                    'Choices': choices(attr, 'dropOption{}ID', 'dropOption{}Factor')}
            elif element.tag == 'DropOption':
                options[entry_id] = {
                    'Probability': attr.get('dropType') == '概率',
                    'Items': [{'Id': int(attr.get(f'item{i}ID', 0)),
                               'Min': int(attr.get(f'item{i}Count', 0)),
                               'Max': int(attr.get(f'item{i}MaxCount', attr.get(f'item{i}Count', 0))),
                               'Factor': int(attr.get(f'Item{i}Factor', 0))}
                              for i in range(1, 6) if int(attr.get(f'item{i}ID', 0)) > 0]}

        recipes = {}
        for element in xml('Base/Recipes/CraftingTable.xml'):
            attr = {key: value for key, value in element.attrib.items() if value != ''}
            # 客户端也跳过无工作台名称的行。
            if 'ID' not in attr or 'Workbench' not in attr:
                continue
            recipe_id = int(attr['ID'])
            benches = {int(attr.get(f'WorkbenchItem{i}', 0)) for i in range(1, 4)} - {0}
            recipes[recipe_id] = {
                'Id': recipe_id, 'TargetId': int(attr.get('TargetID', 0)),
                'TargetCount': int(attr.get('TargetCount', 0)),
                'InHands': any(name in {'InHands', 'InHandsOld'}
                               for name in attr['Workbench'].split('/')),
                'WorkbenchBlocks': [block_id for block_id, item_id in block_items.items()
                                    if item_id in benches],
                'Gold': int(attr.get('Gold', 0)), 'Blueprint': int(attr.get('Blueprint', 0)),
                'UsableInit': attr.get('UsableInit', 'true').lower() == 'true',
                'Sources': [{'ItemId': int(attr.get(f'SourceID{i}', 0)),
                             'Tag': int(attr.get(f'Tag{i}', 0)),
                             'Count': int(attr.get(f'Count{i}', 0))}
                            for i in range(1, 5) if int(attr.get(f'Count{i}', 0)) > 0]}

        challenges = {}
        for element in xml('Base/ChallengeTable.xml'):
            attr = element.attrib
            if (attr.get('isNPCType', '').lower() == 'true' or
                    attr.get('eventType') not in {'GetItems', 'ItemMake', 'PutBlockReferItemID'}):
                continue
            challenge_id = int(attr['id'])
            challenges[challenge_id] = {
                'Id': challenge_id, 'Event': attr['eventType'],
                'Target': int(attr['eventTarget']), 'IsTag': attr.get('idBit') == '1',
                'Count': int(attr['eventCount']),
                'Prerequisites': [int(attr[f'preChallenge{i}']) for i in (1, 2)
                                  if int(attr.get(f'preChallenge{i}', 0)) > 0],
                'Rewards': [{'ItemId': int(attr[id_key]), 'Count': int(attr.get(count_key, 0))}
                            for id_key, count_key in (('awardID', 'awardCount'), ('award2ID', 'award2Count'))
                            if int(attr.get(id_key, 0)) > 0 and int(attr.get(count_key, 0)) > 0]}

        park_buildings = {}
        for element in xml('Base/Base_LegoZone.xml'):
            if element.tag in {'LegoZoneBuild', 'LegoZoneDecoration'} and 'id' in element.attrib:
                a = element.attrib
                park_buildings[int(a['id'])] = {'Prosperity': int(a.get('boom') or 0)}
        park_presets = json.loads(decrypt_resource(archive.read('assets/External/Global/LegoZoneBuilding.json')))
        # 本地初始布局采用 APK 中的方案 1。
        preset = next(p for p in park_presets['setInfos'] if p.get('setID') == 1)
        park_starter = [{'X': b.get('culumn', 0), 'Z': b.get('row', 0),
                         'Rotation': b.get('rotation', 0), 'Id': b['resID']} for b in preset['buildings']]

        # 教程自定义表为空；保留原表来源。
        catalog = {'Source': 'apk.apk / assets/External/Mods/Base',
                   'Items': items, 'Blocks': blocks, 'Events': events, 'Options': options,
                   'Recipes': recipes, 'SurvivalTreeDrops': survival_tree_drops,
                   'Challenges': challenges, 'ParkBuildings': park_buildings, 'ParkStarter': park_starter}
        destination.parent.mkdir(parents=True, exist_ok=True)
        destination.write_text(json.dumps(catalog, ensure_ascii=False, separators=(',', ':')), encoding='utf-8')
        print(str(destination))


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('apk', type=Path)
    parser.add_argument('destination', type=Path)
    args = parser.parse_args()
    export(args.apk, args.destination)

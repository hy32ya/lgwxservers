"""修改服务器地址，并加解密客户端服务器列表。"""
import argparse
import ipaddress
import json
from pathlib import Path
import sys
import zipfile

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / 'GameServer' / 'tools'))
from client_resources import decrypt_resource, encrypt_resource


def json_data(data):
    return json.loads(data.decode('utf-8-sig'))


def json_bytes(value):
    return (json.dumps(value, ensure_ascii=False, indent=2) + '\n').encode('utf-8')


def output_file(path, data):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_bytes(data)
    print('已生成：', path)


def different_file(output, *inputs):
    if any(source is not None and output.resolve() == source.resolve() for source in inputs):
        raise ValueError('输出文件不能覆盖输入文件或加密模板')


def port(value):
    number = int(value)
    if not 1 <= number <= 65535:
        raise argparse.ArgumentTypeError('端口范围为 1～65535')
    return number


def configure(args):
    address = ipaddress.ip_address(args.host)
    if address.version != 4:
        raise ValueError('当前配置使用 IPv4，请填写电脑的 IPv4 地址')
    if address.is_unspecified or address.is_multicast or str(address) == '255.255.255.255':
        raise ValueError('请填写电脑实际 IP，不能用 0.0.0.0 或广播地址')
    if args.port == args.map_port:
        raise ValueError('游戏端口与地图端口不能相同')
    host = str(address)
    endpoint = 'tcp://' + host + ':' + str(args.port)
    if args.apk:
        with zipfile.ZipFile(args.apk) as archive:
            raw = archive.read('assets/External/ServerBetaList.txt')
        template = raw
    else:
        raw = args.source.read_bytes()
        template = raw if raw[-4:] in (b'\x16\x5b\x5f\x00', b'\x63\xa5\x5f\x00') else None
    listing = json_data(decrypt_resource(raw))
    entries = listing.get('serList', [])
    key_id = args.key_id or str(listing.get('serverKeyID', ''))
    selected = [entry for entry in entries if str(entry.get('keyID')) == key_id]
    if len(selected) != 1:
        raise ValueError('服务器条目不存在或重复，请用 --key-id 指定编号')
    selected[0]['serverUrl'] = endpoint
    selected[0]['name'] = '本地服务器'
    listing['serverKeyID'] = key_id
    settings = json_data(args.server_config.read_bytes())
    settings['ListenAddress'] = '0.0.0.0'
    settings['Port'] = args.port
    settings['MapPort'] = args.map_port
    settings['MapPublicAddress'] = host + ':' + str(args.map_port)
    content = json_bytes(listing)
    encrypted = encrypt_resource(content, template=template)
    files = [
        (args.output_dir / 'ServerBetaList.json', content),
        (args.output_dir / 'ServerBetaList.txt', encrypted),
        (args.output_dir / 'local_server.txt', (endpoint + '\n').encode('utf-8')),
    ]
    for output, _ in files:
        different_file(output, args.source, args.apk, args.server_config)
    for output, data in files:
        output_file(output, data)
    output_file(args.server_config, json_bytes(settings))
    print('客户端连接：', endpoint)
    print('地图地址：', settings['MapPublicAddress'])


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    commands = parser.add_subparsers(dest='command', required=True)
    for name, help_text in [('decrypt', '解密为 JSON'), ('encrypt', '加密 JSON')]:
        command = commands.add_parser(name, help=help_text)
        command.add_argument('input', type=Path)
        command.add_argument('output', type=Path)
        if name == 'encrypt':
            command.add_argument('--template', type=Path, help='原始加密文件，沿用尾部参数')
    command = commands.add_parser('configure', help='同时配置服务端、客户端和登录 Hook')
    command.add_argument('--host', required=True, help='手机能访问的电脑实际 IP')
    command.add_argument('--port', type=port, default=2001)
    command.add_argument('--map-port', type=port, default=2002)
    sources = command.add_mutually_exclusive_group()
    sources.add_argument('--source', type=Path, default=ROOT / 'ClientConfig' / 'ServerBetaList.template.json')
    sources.add_argument('--apk', type=Path, help='从自己的原始 APK 读取服务器列表')
    command.add_argument('--key-id', help='要修改的服务器编号，默认跟随当前选择')
    command.add_argument('--server-config', type=Path, default=ROOT / 'GameServer' / 'server.json')
    command.add_argument('--output-dir', type=Path, default=ROOT / 'ClientConfig')
    args = parser.parse_args()
    try:
        if args.command == 'configure':
            configure(args)
            return
        template_path = getattr(args, 'template', None)
        different_file(args.output, args.input, template_path)
        data = args.input.read_bytes()
        if args.command == 'decrypt':
            output_file(args.output, json_bytes(json_data(decrypt_resource(data))))
        else:
            json_data(data)
            template = template_path.read_bytes() if template_path else None
            output_file(args.output, encrypt_resource(data.decode('utf-8-sig').encode('utf-8'), template=template))
    except (OSError, ValueError, KeyError, zipfile.BadZipFile) as error:
        parser.error(str(error))


if __name__ == '__main__':
    main()

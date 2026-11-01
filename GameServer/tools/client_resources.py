"""读取 APK 内的客户端加密资源。"""
import struct


def decrypt_resource(data):
    if len(data) < 12:
        return data
    code, value, mark = struct.unpack('<III', data[-12:])
    if mark not in (6249238, 6268259):
        return data
    result = bytearray(data[:-12])
    for index in range(len(result)):
        delta = ((index ^ value) | ((index >> 8) ^ code)) if mark == 6268259 else value
        result[index] = (result[index] - delta) & 255
        if mark != 6268259:
            value = (((value ^ code) >> 1) | 0x80000000) if value & 1 else value >> 1
    return bytes(result)


def encrypt_resource(data, *, template=None, code=4587365, value=543824, mark=6249238):
    """按客户端格式加密，保留原文件的尾部参数。"""
    if template is not None:
        if len(template) < 12:
            raise ValueError('加密模板太短')
        code, value, mark = struct.unpack('<III', template[-12:])
    if mark not in (6249238, 6268259):
        raise ValueError('不支持的加密格式')
    footer = struct.pack('<III', code, value, mark)
    result = bytearray(data)
    for index in range(len(result)):
        delta = ((index ^ value) | ((index >> 8) ^ code)) if mark == 6268259 else value
        result[index] = (result[index] + delta) & 255
        if mark != 6268259:
            value = (((value ^ code) >> 1) | 0x80000000) if value & 1 else value >> 1
    return bytes(result) + footer

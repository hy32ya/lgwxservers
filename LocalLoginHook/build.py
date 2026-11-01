"""编译 ARMv7 本地登录 SO，不启动游戏。"""
import argparse
import os
from pathlib import Path
import shutil
import subprocess
import tempfile

SOURCE = Path(__file__).resolve().parent
ROOT = SOURCE.parent


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--zig', default=shutil.which('zig'), help='Zig 0.13 的可执行文件路径')
    parser.add_argument('--references', type=Path, default=SOURCE / 'references')
    args = parser.parse_args()
    if not args.zig:
        parser.error('需要 Zig 0.13，请用 --zig 指定 zig.exe')
    sdk_lines = subprocess.check_output(['dotnet', '--list-sdks'], text=True).splitlines()
    sdks = [line for line in sdk_lines if line.startswith('8.')]
    if not sdks:
        parser.error('需要安装 .NET 8 SDK')
    version, sdk_root = sdks[-1].split(' [', 1)
    compiler = Path(sdk_root.rstrip(']')) / version / 'Roslyn' / 'bincore' / 'csc.dll'
    temporary = ROOT / '.build'
    temporary.mkdir(exist_ok=True)
    output = SOURCE / 'v1.0.0.0' / 'liblocal_login_hook.so'
    output.parent.mkdir(exist_ok=True)
    with tempfile.TemporaryDirectory(prefix='hook-', dir=temporary) as folder:
        work = Path(folder)
        helper = work / 'LocalLoginHarness.dll'
        references = ['-r:' + str(args.references / name) for name in ['mscorlib.dll', 'System.dll']]
        subprocess.run([
            'dotnet', str(compiler), '-nologo', '-noconfig', '-nostdlib+', '-target:library',
            '-langversion:7.3', '-optimize+', '-debug-', '-deterministic+', *references,
            '-out:' + str(helper), str(SOURCE / 'LocalLoginHarness.cs')
        ], check=True)
        data = helper.read_bytes()
        (work / 'harness_bytes.h').write_text(
            'static const unsigned char harness_bytes[] = {\n' +
            ',\n'.join(','.join('0x%02x' % value for value in data[index:index+20])
                      for index in range(0, len(data), 20)) + '\n};\n', encoding='ascii')
        (work / 'libc_stub.c').write_text(
            '#define S(n) void n(void) {}\n'
            'S(open) S(close) S(read) S(write) S(snprintf) S(usleep)\n'
            'S(pthread_create) S(pthread_detach) S(mprotect) S(getpagesize)\n'
            'S(fopen) S(fgets) S(fclose) S(sscanf) S(memcpy) S(memset) S(memmove)\n', encoding='ascii')
        (work / 'libdl_stub.c').write_text('void dlopen(void) {}\nvoid dlsym(void) {}\n', encoding='ascii')
        (work / 'liblog_stub.c').write_text(
            'int __android_log_write(int p,const char *t,const char *s){return 0;}\n', encoding='ascii')
        environment = os.environ.copy()
        environment['ZIG_GLOBAL_CACHE_DIR'] = str(work / 'zig-cache')
        environment['ZIG_LOCAL_CACHE_DIR'] = str(work / 'zig-local-cache')
        common = [str(args.zig), 'cc', '-target', 'arm-linux-android', '-mcpu=cortex_a9',
                  '-mfloat-abi=soft', '-marm', '-O0', '-fPIC', '-fno-builtin',
                  '-fno-stack-protector', '-nostdlib', '-shared', '-Wl,--hash-style=both',
                  '-Wl,-z,max-page-size=4096', '-Wl,-z,noexecstack']
        for name in ['libc', 'libdl', 'liblog']:
            subprocess.run(common + [str(work / (name + '_stub.c')), '-Wl,-soname,' + name + '.so',
                                    '-o', str(work / (name + '.so'))], check=True, env=environment)
        subprocess.run(common + ['-fvisibility=hidden', '-I', str(work), str(SOURCE / 'local_login_hook.c'),
                                *[str(work / (name + '.so')) for name in ['libc', 'libdl', 'liblog']],
                                '-Wl,--no-undefined', '-Wl,-soname,liblocal_login_hook.so', '-s',
                                '-o', str(output)], check=True, env=environment)
    print('已编译：', output)


if __name__ == '__main__':
    main()

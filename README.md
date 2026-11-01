# 乐高无限本地服务端

版本：**v1.0.0.0**。C# 编写，适配当前安卓 Unity Mono、32 位 ARM 客户端。

## 目前适配

| 功能 | 情况 |
| --- | --- |
| 本地登录、建角、进入大厅 | 已接入，使用登录 SO，服务端按客户端 IP 分配账号 |
| 新手教程 | 已补指引、砍树、拾取、合成与工作台放置流程 |
| 生存世界 | 已接入建房、进出世界、地图上传与下载 |
| 物品与任务 | 支持基础背包、合成、方块放置及部分任务；成熟树每棵掉 5 个木材 |
| 生存状态 | 已加入工具耐久、饥饿、缺氧、环境伤害、普通进食与原点复活 |
| 玩家存档 | 保存背包、耐久、状态、位置和已支持的任务进度 |
| 乐高乐园 | 已补入口初始化、基础建筑布局和改名；商城、扩地及奖励未完成 |
| 其他玩法 | 多人联机、怪物战斗、完整地图状态保存、药水效果等未完成 |

当前仍是部分适配，不能当作完整原服。最新补充的乐园和生存功能尚待游戏内确认。

## 使用

1. 安装 Python 3.10 或以上版本。在项目目录运行下方命令，把 `电脑实际IP` 换成手机能访问的电脑地址：

   ```powershell
   python -B tools/server_list_tool.py configure --host 电脑实际IP
   ```

2. 将生成的 `ClientConfig/ServerBetaList.txt` 替换客户端实际使用的同名文件，原包位置为 `assets/External/ServerBetaList.txt`；已有缓存也需同步更新。
3. 将 `ClientConfig/local_server.txt` 放入游戏私有目录 `/data/data/com.tencent.LEGOCUBEPreview/files/`。完全退出游戏，用现有注入工具仅加载 `LocalLoginHook/v1.0.0.0/liblocal_login_hook.so`，再启动游戏并点击 QQ 或微信登录。
4. 双击 `GameServer/start_server.cmd`。Windows x64 程序已附带运行环境，首次进入游戏需要建角。手机需能访问电脑的 `2001`、`2002` 端口。

服务端监听地址为 `0.0.0.0`；客户端连接地址和 `MapPublicAddress` 必须填写手机能访问的实际 IP，不能使用 `0.0.0.0`。地址保存在配置中，换 IP 无需重新编译 SO。工具不修改、重签或安装 APK。

账号和世界数据会写入 `GameServer/data`，日志写入 `GameServer/logs`，更新时保留这两个目录。

同一来源 IP 重登沿用原账号，不同 IP 分开保存；QQ、微信按钮共用该 IP 的账号。更换 IP 会分配新账号，多台设备共用一个公网 IP 时也会共用账号。

继续使用旧版角色时，停服后在对应账号记录中补上 `"ClientIp": "手机的来源IP"`。一个 IP 只能绑定一个账号，无需删库或删地图。

## 单独解密、加密

```powershell
python -B tools/server_list_tool.py decrypt "原始ServerBetaList.txt" "解密.json"
python -B tools/server_list_tool.py encrypt "修改后.json" "重新加密.txt" --template "原始ServerBetaList.txt"
```

加密后将文件名改回 `ServerBetaList.txt`。手工改地址时，需同步修改 `local_server.txt` 和服务端的 `MapPublicAddress`。也可在一次配置命令后追加 `--apk "原始安装包.apk"`，保留原服务器列表的其他条目。

## 文件

- `GameServer/`：C# 服务端源码、配置和 `v1.0.0.0` 程序。
- `LocalLoginHook/`：本地登录源码、编译脚本和 `v1.0.0.0` 登录 SO。
- `tools/server_list_tool.py`：改地址、解密和加密工具，无需额外 Python 库。
- `ClientConfig/`：客户端配置模板及工具生成的文件。

登录源码为 `LocalLoginHook/local_login_hook.c` 和 `LocalLoginHarness.cs`：SO 提供本地登录凭据，建角、进大厅和游戏请求继续等待服务端回复。它不生成真实 QQ、微信账号凭据。

重新编译服务端需要 .NET 8 SDK，运行 `GameServer/build.ps1`。编译登录 SO 还需要 Python 3.10+ 和 Zig 0.13，运行 `python -B LocalLoginHook/build.py --zig "你的zig.exe路径"`。

## 版权与免责声明

Copyright (c) 2026 **星海游戏HY32**。本项目原创代码与文档按仓库的 [GPL-2.0](LICENSE) 许可发布。游戏名称、商标、原始客户端、恢复的协议代码及第三方组件的权利和许可归各自权利人所有。

本项目为非官方的本地研究与兼容性实验，不代表原游戏及其运营方。请在获得相应授权的客户端和环境中使用，遵守适用法律及相关协议；本项目不授予任何游戏或第三方资产的使用许可。

项目按现状提供，不保证功能完整、稳定或存档安全，使用前请备份数据。在法律允许的范围内，作者不对使用本项目造成的损失承担责任。

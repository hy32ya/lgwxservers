// 本地服务端入口：账号、地图与游戏连接。
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using LocalGameServer;
using LocalGameServer.Storage;
using LocalGameServer.Transport;

var configPath = args.Length switch
{
    0 => File.Exists(Path.Combine(AppContext.BaseDirectory, "..", "server.json"))
        ? Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "server.json"))
        : Path.Combine(AppContext.BaseDirectory, "server.json"),
    2 when args[0] == "--config" => Path.GetFullPath(args[1]),
    _ => null
};
if (configPath == null)
{
    Console.Error.WriteLine("Usage: LocalGameServer.exe [--config <server.json>]");
    return 2;
}

try
{
    var settings = ServerSettings.Load(configPath);
    using var accounts = new AccountStore(settings);
    using var log = new ServerLog(settings);
    using var stopping = new CancellationTokenSource();
    var maps = new LocalMapStorage(settings, accounts, log);
    await using var mapHttp = maps.CreateHttpServer();
    using var slots = new SemaphoreSlim(settings.MaxConnections);
    var connections = new ConcurrentDictionary<string, Task>();
    var listener = new TcpListener(IPAddress.Parse(settings.ListenAddress), settings.Port);
    Console.CancelKeyPress += (_, e) => { e.Cancel = true; stopping.Cancel(); };
    await mapHttp.StartAsync(stopping.Token);
    listener.Start();
    log.Write("server", "listening", new { version = "v" + typeof(TgcpSession).Assembly.GetName().Version?.ToString(4),
        settings.ListenAddress, settings.Port, settings.MapPort, settings.MapPublicAddress,
        settings.DataDirectory, settings.LogDirectory }, true);
    var clientAddress = new UriBuilder("tcp", new Uri("http://" + settings.MapPublicAddress).Host, settings.Port)
        .Uri.GetLeftPart(UriPartial.Authority);
    Console.WriteLine($"游戏客户端目标：{clientAddress}（手机需能访问此地址）");
    Console.WriteLine($"地图文件地址：http://{settings.MapPublicAddress}（原协议自动下发）");
    Console.WriteLine("停止：Ctrl+C。账号与角色保存在 data/accounts.json。首次登录需要在客户端创建角色。");

    async Task RunConnectionAsync(string id, TcpClient client)
    {
        try { await new TgcpSession(id, client, settings, accounts, maps, log).RunAsync(stopping.Token); }
        catch (Exception ex) { client.Dispose(); log.Write(id, "connection_error", new { error = ex.ToString() }, true); }
        finally { slots.Release(); }
    }

    try
    {
        while (!stopping.IsCancellationRequested)
        {
            var client = await listener.AcceptTcpClientAsync(stopping.Token);
            if (!slots.Wait(0))
            {
                log.Write("server", "connection_limit", new { remote = client.Client.RemoteEndPoint?.ToString() }, true);
                client.Dispose();
                continue;
            }
            client.NoDelay = true;
            var id = Guid.NewGuid().ToString("N")[..12];
            var task = RunConnectionAsync(id, client);
            connections[id] = task;
            _ = task.ContinueWith(_ => { connections.TryRemove(id, out var removed); },
                CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }
    }
    catch (OperationCanceledException) when (stopping.IsCancellationRequested) { }
    finally
    {
        stopping.Cancel();
        listener.Stop();
        await Task.WhenAll(connections.Values);
        using var mapStop = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        await mapHttp.StopAsync(mapStop.Token);
        log.Write("server", "stopped", new { }, true);
    }
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine("服务端无法启动或已停止：" + ex.Message);
    return 1;
}

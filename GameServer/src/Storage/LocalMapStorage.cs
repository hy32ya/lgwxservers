using System.Collections.Concurrent;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using cs_msg;
using LocalGameServer.Protocol;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LocalGameServer.Storage;

// 原协议授权，本地 HTTP 保存地图原始文件。
public sealed class LocalMapStorage(ServerSettings settings, AccountStore accounts, ServerLog log)
{
    public const string AccessId = "local-map";
    private const int Invalid = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
    private const int Missing = (int)ECSErrorCode.CS_ERR_WORK_NOT_EXIST;
    private readonly ConcurrentDictionary<string, Ticket> tickets = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, Ticket> uploads = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<ulong, SemaphoreSlim> workLocks = new();
    private long nextDownloadBatch;

    private sealed class DownloadBatch
    {
        public required long Id;
        public required int Expected;
        public int Completed;
        public int Missing;
    }

    private sealed class Ticket
    {
        public required ulong Owner;
        public required ulong WorkId;
        public required string Path;
        public required string FileName;
        public required string Method;
        public required string Token;
        public required uint Start;
        public required uint End;
        public required uint Size;
        public required string Session;
        public DownloadBatch? Batch;
        public int DownloadReported;
        public int Completed;
    }

    private SemaphoreSlim WorkLock(ulong id) => workLocks.GetOrAdd(id, _ => new(1, 1));
    private static string Number(long value) => value.ToString(CultureInfo.InvariantCulture);
    private static string Number(ulong value) => value.ToString(CultureInfo.InvariantCulture);
    private static string UploadKey(ulong owner, string path) => Number(owner) + path;
    private string FilePath(ulong workId, string fileName) =>
        System.IO.Path.Combine(settings.DataDirectory, "maps", Number(workId), "private", fileName);
    private static bool Active(LocalWork? work) => work is { Deleted: false, WorkType: 1, GameMode: 302 or 303 };

    public bool HasMainFile(ulong workId)
    {
        var file = new FileInfo(FilePath(workId, "1.dlc"));
        return file.Exists && file.Length > 0;
    }

    public WebApplication CreateHttpServer()
    {
        var builder = WebApplication.CreateSlimBuilder(new WebApplicationOptions
        {
            Args = [], ApplicationName = typeof(LocalMapStorage).Assembly.FullName,
            ContentRootPath = AppContext.BaseDirectory
        });
        builder.Configuration.Sources.Clear();
        builder.Logging.ClearProviders();
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Limits.MaxRequestBodySize = settings.MaxMapFileBytes;
            options.Limits.MaxConcurrentConnections = settings.MaxConnections;
            options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(15);
            options.Listen(IPAddress.Parse(settings.ListenAddress), settings.MapPort);
        });
        var app = builder.Build();
        app.Run(HandleHttpAsync);
        return app;
    }

    public GameResponse ConfigResponse() => GameResponse.Of<CSRspCloudStorageConfig>(
        (int)ECSMsgCmdID.CS_RSP_CLOUD_STORAGE_CONFIG, rsp =>
        {
            // cosUrl 由客户端补 http://。
            rsp.config.cosUrl = LocalAccount.TextBytes(settings.MapPublicAddress, 100);
            rsp.config.qpicUrl = LocalAccount.TextBytes("http://" + settings.MapPublicAddress + "/images/", 64);
            rsp.config.cosSecretId = LocalAccount.TextBytes(AccessId, 64);
        });

    public async Task<GameResponse> SignAsync(CSReqCosSignature request, ulong owner,
        string session, CancellationToken ct)
    {
        var gate = WorkLock(request.workID);
        await gate.WaitAsync(ct);
        try
        {
            var work = await accounts.GetWorkAsync(owner, request.workID, ct);
            var result = !Active(work) ? Missing :
                request.workType != 1 || request.useType != 1 || request.version != 0 ||
                request.patchVersion != 0 || request.isUpload > 1 || request.fileSuffix is not (0 or 2) ||
                request.dlcCount is < 1 or > 32 ? Invalid : 0;
            var entries = new List<(CSCosFileAttr File, string Name)>();
            if (result == 0)
            {
                foreach (var file in request.dlcData.Take(request.dlcCount))
                {
                    var name = request.fileSuffix == 2 ? Number(file.newID) + ".cell" : Number(file.id) + ".dlc";
                    if ((request.fileSuffix == 0 && file.id != 1) ||
                        file.size > settings.MaxMapFileBytes || entries.Any(e => e.Name == name))
                    { result = Invalid; break; }
                    entries.Add((file, name));
                }
            }
            var start = checked((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var end = checked(start + 600);
            foreach (var old in tickets.Where(t => t.Value.End < start)) tickets.TryRemove(old.Key, out _);
            if (result == 0 && (tickets.Count + entries.Count > 8192 || uploads.Count + entries.Count > 16384))
                result = (int)ECSErrorCode.CS_ERR_SYSTEM_IS_DISABLED;
            var signatures = new List<CSCosSignature>();
            if (result == 0)
            {
                var batch = request.isUpload == 0 ? new DownloadBatch
                {
                    Id = Interlocked.Increment(ref nextDownloadBatch), Expected = entries.Count
                } : null;
                foreach (var (file, name) in entries)
                {
                    var bytes = RandomNumberGenerator.GetBytes(20);
                    var ticket = new Ticket
                    {
                        Owner = owner, WorkId = request.workID, FileName = name,
                        Path = "/" + Number(request.workID) + "/private/" + name,
                        Method = request.isUpload == 1 ? "PUT" : "GET", Size = file.size,
                        Token = Convert.ToHexString(bytes).ToLowerInvariant(), Start = start, End = end,
                        Session = session, Batch = batch
                    };
                    tickets[ticket.Token] = ticket;
                    if (request.isUpload == 1) uploads[UploadKey(owner, ticket.Path)] = ticket;
                    signatures.Add(new CSCosSignature { id = file.id, newID = file.newID, data = bytes });
                }
                if (batch != null)
                    log.Write(session, "map_download_batch_signed", new
                    { batchId = batch.Id, request.workID, expected = batch.Expected, request.fileSuffix }, true);
            }
            log.Write(session, "map_signature", new { result, request.workID, request.isUpload,
                request.fileSuffix, request.reason, count = signatures.Count }, true);
            return GameResponse.Of<CSRspCosSignature>((int)ECSMsgCmdID.CS_RSP_COS_SIGNATURE, rsp =>
            {
                rsp.result = result; rsp.workID = request.workID; rsp.useType = request.useType;
                rsp.workType = request.workType; rsp.version = request.version; rsp.patchVersion = request.patchVersion;
                rsp.isUpload = request.isUpload; rsp.reason = request.reason;
                rsp.keyTimeStart = start; rsp.keyTimeEnd = end; rsp.dlcCount = (ushort)signatures.Count;
                for (var i = 0; i < signatures.Count; i++) rsp.dlcSignature[i] = signatures[i];
            });
        }
        finally { gate.Release(); }
    }

    public bool CellAvailable(ulong owner, ulong workId, long id, bool completed)
    {
        var path = "/" + Number(workId) + "/private/" + Number(id) + ".cell";
        return uploads.TryGetValue(UploadKey(owner, path), out var ticket) &&
            (!completed || Volatile.Read(ref ticket.Completed) == 1);
    }

    public async Task<int> FinishAsync(ulong owner, ulong workId, string name, bool areaManaged,
        CancellationToken ct)
    {
        var gate = WorkLock(workId);
        await gate.WaitAsync(ct);
        try
        {
            var work = await accounts.GetWorkAsync(owner, workId, ct);
            if (!Active(work)) return Missing;
            var file = new FileInfo(FilePath(workId, "1.dlc"));
            if (!file.Exists || file.Length == 0 ||
                uploads.Values.Any(t => t.Owner == owner && t.WorkId == workId && Volatile.Read(ref t.Completed) != 1))
                return Invalid;
            await accounts.UpdateWorkAsync(owner, workId, w =>
            {
                w.UploadedAt = checked((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                w.FileSize = checked((uint)file.Length);
                if (name.Length > 0) w.Name = name;
                w.AreaManaged |= areaManaged;
            }, ct);
            return 0;
        }
        finally { gate.Release(); }
    }

    public async Task<int> DeleteAsync(ulong owner, ulong workId, CancellationToken ct)
    {
        var gate = WorkLock(workId);
        await gate.WaitAsync(ct);
        try
        {
            if (!await accounts.UpdateWorkAsync(owner, workId, w => w.Deleted = true, ct)) return Missing;
            foreach (var ticket in tickets.Where(t => t.Value.Owner == owner && t.Value.WorkId == workId))
                tickets.TryRemove(ticket.Key, out _);
            foreach (var upload in uploads.Where(t => t.Value.Owner == owner && t.Value.WorkId == workId))
                uploads.TryRemove(upload.Key, out _);
            // 保留原文件，删除仅标记元数据。
            return 0;
        }
        finally { gate.Release(); }
    }

    public async Task<int> MarkEmptyCellAsync(ulong owner, ulong workId, long id, CancellationToken ct)
    {
        var gate = WorkLock(workId);
        await gate.WaitAsync(ct);
        try
        {
            if (!Active(await accounts.GetWorkAsync(owner, workId, ct))) return Missing;
            await accounts.UpdateWorkAsync(owner, workId, w =>
            { if (!w.EmptyCells.Contains(id)) w.EmptyCells.Add(id); }, ct);
            return 0;
        }
        finally { gate.Release(); }
    }

    private Ticket? Authorize(HttpRequest request, out string reason)
    {
        reason = "invalid_header";
        var fields = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var part in request.Headers.Authorization.ToString().Split('&'))
        {
            var pair = part.Split('=', 2);
            if (pair.Length != 2 || !fields.TryAdd(pair[0], pair[1])) return null;
        }
        if (fields.GetValueOrDefault("q-ak") != AccessId || fields.GetValueOrDefault("q-sign-algorithm") != "sha1" ||
            !tickets.TryGetValue(fields.GetValueOrDefault("q-signature") ?? "", out var ticket)) return null;
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var time = ticket.Start + ";" + ticket.End;
        if (now < ticket.Start || now > ticket.End) reason = "expired";
        else if (request.Method != ticket.Method) reason = "method_mismatch";
        else if (request.Path.Value != ticket.Path || request.QueryString.Value is not (null or ""))
            reason = "path_mismatch";
        else if (fields.GetValueOrDefault("q-sign-time") != time || fields.GetValueOrDefault("q-key-time") != time)
            reason = "time_mismatch";
        else { reason = "accepted"; return ticket; }
        return null;
    }

    private static void EmptyResponse(HttpContext context, int status)
    {
        context.Response.StatusCode = status;
        context.Response.ContentLength = 0;
        context.Response.Headers.CacheControl = "no-store";
        // 空响应直接结束，兼容旧版下载器。
        context.Response.Headers.Connection = "close";
    }

    private void TrackDownload(HttpContext context, Ticket ticket)
    {
        var started = System.Diagnostics.Stopwatch.GetTimestamp();
        log.Write(ticket.Session, "map_download_requested", new
        { ticket.WorkId, ticket.FileName, batchId = ticket.Batch?.Id });
        context.Response.OnCompleted(() =>
        {
            var status = context.Response.StatusCode;
            log.Write(ticket.Session, "map_download_http_completed", new
            {
                ticket.WorkId, ticket.FileName, batchId = ticket.Batch?.Id, status,
                size = context.Response.ContentLength,
                elapsedMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(started).TotalMilliseconds
            });
            var batch = ticket.Batch;
            if (batch != null && status is 200 or 404 &&
                Interlocked.CompareExchange(ref ticket.DownloadReported, 1, 0) == 0)
            {
                lock (batch)
                {
                    batch.Completed++;
                    if (status == 404) batch.Missing++;
                    if (batch.Completed == batch.Expected)
                        log.Write(ticket.Session, "map_download_batch_http_completed", new
                        {
                            ticket.WorkId, batchId = batch.Id, expected = batch.Expected,
                            completed = batch.Completed, missing = batch.Missing
                        }, true);
                }
            }
            return Task.CompletedTask;
        });
    }

    private async Task HandleHttpAsync(HttpContext context)
    {
        var ticket = Authorize(context.Request, out var reason);
        if (ticket == null)
        {
            EmptyResponse(context, 403);
            log.Write("maps", "map_http_rejected", new
            {
                method = context.Request.Method, path = context.Request.Path.Value,
                remote = context.Connection.RemoteIpAddress?.ToString(), reason
            }, true);
            return;
        }
        context.Response.Headers.CacheControl = "no-store";
        if (ticket.Method == "GET") TrackDownload(context, ticket);
        var ct = context.RequestAborted;
        var gate = WorkLock(ticket.WorkId);
        await gate.WaitAsync(ct);
        string? temporary = null;
        try
        {
            var work = await accounts.GetWorkAsync(ticket.Owner, ticket.WorkId, ct);
            if (!Active(work)) { EmptyResponse(context, 404); return; }
            var path = FilePath(ticket.WorkId, ticket.FileName);
            if (ticket.Method == "GET")
            {
                if (ticket.FileName.EndsWith(".cell", StringComparison.Ordinal) &&
                    work!.EmptyCells.Contains(long.Parse(ticket.FileName[..^5], CultureInfo.InvariantCulture)))
                { EmptyResponse(context, 404); return; }
                if (!File.Exists(path)) { EmptyResponse(context, 404); return; }
                await using var input = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read,
                    65536, FileOptions.Asynchronous | FileOptions.SequentialScan);
                context.Response.ContentType = "application/octet-stream";
                context.Response.ContentLength = input.Length;
                await input.CopyToAsync(context.Response.Body, ct);
                log.Write(ticket.Session, "map_downloaded", new { ticket.WorkId, ticket.FileName, size = input.Length });
                return;
            }
            if (context.Request.ContentLength != ticket.Size || ticket.Size > settings.MaxMapFileBytes ||
                !uploads.TryGetValue(UploadKey(ticket.Owner, ticket.Path), out var latest) || latest != ticket)
            { EmptyResponse(context, 400); return; }
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path)!);
            temporary = path + ".upload-" + Guid.NewGuid().ToString("N") + ".tmp";
            using var hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA1);
            long count = 0;
            await using (var output = new FileStream(temporary, FileMode.CreateNew, FileAccess.Write, FileShare.None,
                65536, FileOptions.Asynchronous | FileOptions.WriteThrough))
            {
                var buffer = new byte[65536];
                int read;
                while ((read = await context.Request.Body.ReadAsync(buffer, ct)) > 0)
                {
                    count += read;
                    if (count > ticket.Size) { EmptyResponse(context, 400); return; }
                    hash.AppendData(buffer, 0, read);
                    await output.WriteAsync(buffer.AsMemory(0, read), ct);
                }
                if (count != ticket.Size) { EmptyResponse(context, 400); return; }
                await output.FlushAsync(ct);
                output.Flush(true);
            }
            var digest = Convert.ToHexString(hash.GetHashAndReset()).ToLowerInvariant();
            var suppliedHash = context.Request.Headers["x-cos-content-sha1"].ToString();
            if (suppliedHash.Length > 0 && !string.Equals(suppliedHash, digest, StringComparison.OrdinalIgnoreCase))
            { EmptyResponse(context, 400); return; }
            File.Move(temporary, path, true);
            temporary = null;
            if (ticket.FileName.EndsWith(".cell", StringComparison.Ordinal))
            {
                var id = long.Parse(ticket.FileName[..^5], CultureInfo.InvariantCulture);
                if (work!.EmptyCells.Contains(id))
                    await accounts.UpdateWorkAsync(ticket.Owner, ticket.WorkId, w => w.EmptyCells.Remove(id), ct);
            }
            Volatile.Write(ref ticket.Completed, 1);
            context.Response.StatusCode = 200;
            context.Response.ContentLength = 0;
            context.Response.Headers.ETag = digest;
            log.Write("maps", "map_uploaded", new { ticket.WorkId, ticket.FileName, size = count }, true);
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested) { }
        catch (Exception ex)
        {
            log.Write("maps", "map_storage_error", new { ticket.WorkId, ticket.FileName, error = ex.Message }, true);
            if (!context.Response.HasStarted) EmptyResponse(context, 500);
        }
        finally
        {
            if (temporary != null)
            {
                try { File.Delete(temporary); }
                catch (Exception ex) { log.Write("maps", "map_temporary_cleanup_failed", new { path = temporary, error = ex.Message }, true); }
            }
            gate.Release();
        }
    }
}

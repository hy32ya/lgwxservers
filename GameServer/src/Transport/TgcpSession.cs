using System.Buffers.Binary;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using LocalGameServer.Protocol;
using LocalGameServer.Storage;

namespace LocalGameServer.Transport;

public sealed class TgcpSession(string id, TcpClient client, ServerSettings settings,
    AccountStore accounts, LocalMapStorage maps, ServerLog log)
{
    private enum Phase { Syn, Auth, Ready }
    private Phase phase;
    private TgcpSyn? syn;
    private byte[]? key;
    private uint sequence;
    private GameDispatcher? dispatcher;
    private readonly NetworkStream stream = client.GetStream();

    public async Task RunAsync(CancellationToken stopping)
    {
        var deadline = DateTimeOffset.UtcNow.AddSeconds(settings.HandshakeTimeoutSeconds);
        log.Write(id, "connected", new { remote = client.Client.RemoteEndPoint?.ToString() }, true);
        try
        {
            while (!stopping.IsCancellationRequested)
            {
                using var timeout = CancellationTokenSource.CreateLinkedTokenSource(stopping);
                var remaining = phase == Phase.Ready ? TimeSpan.FromSeconds(settings.IdleTimeoutSeconds) :
                    deadline - DateTimeOffset.UtcNow;
                if (remaining <= TimeSpan.Zero) throw new TimeoutException("TGCP handshake timed out.");
                timeout.CancelAfter(remaining);
                var frame = await TgcpFrame.ReadAsync(stream, settings.MaxFrameBytes, timeout.Token);
                if (frame == null) break;
                log.Frame(id, "client->server", frame.Command, frame.Wire);
                if (frame.Schema != 10 || frame.Version != 10)
                    throw new NotSupportedException($"Only this client's TGCP 10/10 is supported; got {frame.Schema}/{frame.Version}.");
                switch (phase)
                {
                    case Phase.Syn:
                        await SynAsync(frame, timeout.Token);
                        break;
                    case Phase.Auth:
                        if (frame.Command != 0x2001)
                            throw new InvalidDataException($"Expected AUTH, got 0x{frame.Command:X4}.");
                        await AuthAsync(frame, timeout.Token);
                        break;
                    case Phase.Ready:
                        await ReadyAsync(frame, timeout.Token);
                        break;
                }
            }
        }
        catch (OperationCanceledException) when (stopping.IsCancellationRequested) { }
        catch (OperationCanceledException)
        { log.Write(id, "timeout", new { phase = phase.ToString() }, true); }
        catch (Exception ex)
        { log.Write(id, "session_error", new { phase = phase.ToString(), error = ex.ToString() }, true); }
        finally
        {
            if (dispatcher != null)
            {
                try { await dispatcher.CloseAsync(CancellationToken.None); }
                catch (Exception ex) { log.Write(id, "world_save_error", new { error = ex.ToString() }, true); }
            }
            if (key != null) CryptographicOperations.ZeroMemory(key);
            client.Dispose();
            log.Write(id, "disconnected", new { phase = phase.ToString() }, true);
        }
    }

    private async Task SynAsync(TgcpFrame frame, CancellationToken ct)
    {
        if (frame.Command != 0x1001 || frame.Body.Length != 0)
            throw new InvalidDataException("First frame must be an empty-body SYN (0x1001).");
        syn = TgcpSyn.Read(frame.Extension);
        log.Write(id, "syn_received", new { transportServiceId = syn.AppId,
            allowedTransportServiceIds = settings.AppIds, syn.ClientType, syn.KeyType, syn.Algorithm,
            syn.Account.OpenId, syn.Account.Category, syn.RouteType, syn.RouteId, syn.ZoneId, syn.HadRelay });
        if (!settings.AppIds.Contains(syn.AppId))
            throw new InvalidDataException($"Unexpected TGCP transport ServiceId {syn.AppId}; " +
                $"allowed: [{string.Join(", ", settings.AppIds)}]. AppIds in server.json is the SYN ServiceId list, " +
                "not the QQ/WX OAuth AppId list.");
        if (string.IsNullOrWhiteSpace(syn.Account.OpenId) ||
            (!settings.AllowOtherAccounts && syn.Account.OpenId != settings.LocalOpenId))
            throw new InvalidDataException("The OpenId is not enabled on this local server.");
        if (syn.RouteType == 1 && (syn.RouteId != settings.TypeId || syn.ZoneId != settings.ZoneId))
            throw new InvalidDataException($"Wrong route: type={syn.RouteId}, zone={syn.ZoneId}.");
        if (syn.RouteType is 2 or 4 && syn.RouteId != settings.ServerId)
            throw new InvalidDataException($"Wrong server route {syn.RouteId}.");
        if (syn.EmbeddedAuth != null)
            throw new NotSupportedException("Embedded authentication/cloud channels are not implemented; use the default MSDKv3 channel.");
        key = syn.KeyType == 2 ? RandomNumberGenerator.GetBytes(16) : null;
        var extension = new WireWriter().U8(syn.KeyType);
        if (key != null) extension.U8((byte)key.Length).Bytes(key);
        extension.U8(0).U32(0).U32((uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        // ACK 扩展头明文携带密钥，正文无嵌入认证。
        await SendAsync(0x1002, extension.ToArray(), [0], false, ct);
        phase = Phase.Auth;
        log.Write(id, "syn_accepted", new { syn.AppId, syn.ClientType, syn.KeyType, syn.Algorithm,
            syn.Account.OpenId, syn.Account.Category, syn.RouteType, syn.RouteId, syn.ZoneId, syn.HadRelay }, true);
    }

    private byte[] DecodeBody(TgcpFrame frame)
    {
        if (frame.Body.Length == 0) return [];
        // 上行标志为 0 仍需解密；下行标志仅用 0/1。
        return syn!.Algorithm == 3
            ? TgcpAes.Decrypt(frame.Body, key ?? throw new InvalidDataException("Missing AES key."))
            : frame.Body;
    }

    private async Task AuthAsync(TgcpFrame frame, CancellationToken ct)
    {
        if (frame.Extension.Length != 0) throw new InvalidDataException("Unexpected AUTH extension.");
        var reader = new WireReader(DecodeBody(frame));
        var auth = TgcpAuth.Read(reader);
        reader.End();
        log.Write(id, "auth_received", new { wireType = auth.Type,
            wireTypeHex = $"0x{auth.Type:X4}", auth.AppId, dataLength = auth.Data.Length }, true);
        if (auth.Type != TgcpAuth.MsdkV3WireType)
            throw new NotSupportedException($"Unsupported wire authentication type {auth.Type} (0x{auth.Type:X4}); " +
                "MSDKv3 uses 65535 (0xFFFF) on the wire, distinct from API enum 32767 (0x7FFF).");
        if (auth.AppId is not ("1109676129" or "wx3fa54dc8b0624afd"))
            throw new InvalidDataException($"Unexpected authentication AppId {auth.AppId}.");
        if (!GameDispatcher.TokenMatches(auth.AccessToken(), settings.LocalToken))
            throw new InvalidDataException("The local AUTH token does not match server.json.");
        if (client.Client.RemoteEndPoint is not IPEndPoint peer)
            throw new InvalidDataException("无法取得客户端来源 IP。");
        var account = await accounts.GetOrCreateByIpAsync(peer.Address,
            syn!.Account.OpenId, syn.Account.Category, ct);
        log.Write(id, "ip_account_selected", new { account.ClientIp, account.Gid, account.HasRole }, true);
        var response = new WireWriter().Bytes(syn.Account.Encode(account.Gid))
            .U16(0x1003).U16(0).U32(0).U16(0).U32(0).U16(0).U16(0).ToArray();
        await SendAsync(0x2002, [], response, true, ct);
        var sessionId = BinaryPrimitives.ReadUInt32BigEndian(RandomNumberGenerator.GetBytes(4)) | 1U;
        var bingo = new WireWriter().U32(sessionId).Bytes(RandomNumberGenerator.GetBytes(16))
            .U64(settings.ServerId).U8(0).U32(0).ToArray();
        await SendAsync(0x6002, [], bingo, true, ct);
        dispatcher = new GameDispatcher(settings, accounts, maps, log, id, account);
        phase = Phase.Ready;
        log.Write(id, "tgcp_ready", new { account.Gid, account.ClientIp, sessionId, auth.Type, auth.AppId }, true);
    }

    private async Task ReadyAsync(TgcpFrame frame, CancellationToken ct)
    {
        if (frame.Command == 0x9001)
        {
            // 仅记录传输上报；业务心跳使用 241/242。
            log.Write(id, "transport_heartbeat", new { extension = Convert.ToHexString(frame.Extension),
                frame.Sequence, frame.Body.Length });
            return;
        }
        if (frame.Command != 0x4013)
            throw new NotSupportedException($"Unsupported TGCP command 0x{frame.Command:X4}.");
        var reader = new WireReader(frame.Extension);
        var compressed = reader.U8();
        reader.U8(); // 允许丢包标志，TCP 仍可靠传输。
        var routeType = reader.U8();
        TgcpSyn.ReadRoute(reader, routeType);
        var count = reader.U8();
        if (count == 255) throw new InvalidDataException("TGCP packet count 255 is reserved.");
        var lengths = new ushort[count];
        for (var i = 0; i < count; i++) lengths[i] = reader.U16();
        reader.End();
        if (compressed != 0) throw new NotSupportedException("Compressed DATA arrived after compression was disabled.");
        var data = DecodeBody(frame);
        if (count == 0)
            await ProcessPacketAsync(data, frame.Sequence, ct);
        else
        {
            if (lengths.Sum(n => (int)n) != data.Length) throw new InvalidDataException("TGCP packet lengths do not sum to body size.");
            var offset = 0;
            foreach (var length in lengths)
            {
                await ProcessPacketAsync(data.AsSpan(offset, length).ToArray(), frame.Sequence, ct);
                offset += length;
            }
        }
    }

    private async Task ProcessPacketAsync(byte[] packet, uint frameSequence, CancellationToken ct)
    {
        if (packet.Length < 4) throw new InvalidDataException("Missing client DATA sequence prefix.");
        var prefix = BinaryPrimitives.ReadUInt32BigEndian(packet);
        if (prefix != frameSequence)
            throw new InvalidDataException("DATA sequence prefix differs from its TGCP header.");
        var payload = packet.AsSpan(4).ToArray();
        GameRequest request;
        try { request = GameCodec.Decode(payload); }
        catch
        {
            // 解码失败也保留原始消息。
            log.Payload(id, "client->server", 0, payload);
            throw;
        }
        log.Payload(id, "client->server", request.Command, payload, request.Body?.GetType().Name);
        var showInConsole = request.Command is not (241 or 215 or 217 or 219 or 224 or 270 or 271 or 2400);
        log.Write(id, "request", new { request.Command, name = Enum.GetName(typeof(cs_msg.ECSMsgCmdID), request.Command),
            type = request.Body?.GetType().Name, request.Timestamp, frameSequence }, showInConsole);
        var responses = await dispatcher!.HandleAsync(request, ct);
        foreach (var intendedResponse in responses)
        {
            var response = intendedResponse;
            byte[] encoded;
            try { encoded = GameCodec.Encode(response, settings.MaxFrameBytes); }
            catch (InvalidDataException ex) when (response.Command != 64)
            {
                // 响应编码失败时记录原因，返回通用错误。
                log.Write(id, "response_encode_error", new { request.Command,
                    responseCommand = response.Command, error = ex.Message }, true);
                response = GameResponse.Of<cs_msg.CSRspShowErrorMsg>(64, rsp =>
                {
                    rsp.errNo = (int)cs_msg.ECSErrorCode.CS_ERR_SYSTEM_IS_DISABLED;
                    rsp.errMsg = LocalAccount.TextBytes($"本地服务无法生成请求 {request.Command} 的响应", 64);
                });
                encoded = GameCodec.Encode(response, settings.MaxFrameBytes);
            }
            log.Payload(id, "server->client", response.Command, encoded, response.Union.select(response.Command)?.GetType().Name);
            // 下行正文无需添加序号前缀。
            await SendAsync(0x4013, [0, 0, 0, 0], encoded, true, ct);
            var responseBody = response.Union.select(response.Command);
            var responseType = responseBody?.GetType();
            var resultField = responseType?.GetField("result") ?? responseType?.GetField("errCode") ??
                responseType?.GetField("errNo");
            log.Write(id, "response", new { requestCommand = request.Command, command = response.Command,
                type = responseType?.Name, result = resultField?.GetValue(responseBody) }, showInConsole);
        }
    }

    private async Task SendAsync(ushort command, byte[] extension, byte[] body, bool encrypt, CancellationToken ct)
    {
        var encrypted = encrypt && syn!.Algorithm == 3 && body.Length != 0;
        var wireBody = encrypted ? TgcpAes.Encrypt(body, key!) : body;
        var wire = TgcpFrame.Encode(10, 10, command, encrypted ? (byte)1 : (byte)0,
            sequence++, extension, wireBody);
        if (wire.Length > settings.MaxFrameBytes) throw new InvalidDataException("Response exceeds configured frame limit.");
        log.Frame(id, "server->client", command, wire);
        await stream.WriteAsync(wire, ct);
    }
}

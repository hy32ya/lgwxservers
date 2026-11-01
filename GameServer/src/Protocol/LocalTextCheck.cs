using System.Text;
using cs_msg;
using LocalGameServer.Transport;

namespace LocalGameServer.Protocol;

public static class LocalTextCheck
{
    public static GameResponse Respond(CSReqCheckUic request, ServerLog log, string session)
    {
        var count = request.count;
        if (count is < 1 or > 10)
            return GameResponse.Of<CSRspShowErrorMsg>(64, rsp =>
            {
                rsp.errNo = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                rsp.errMsg = Storage.LocalAccount.TextBytes("文本数量无效", 64);
            });
        var results = new int[count];
        var texts = new CSUic[count];
        for (var i = 0; i < count; i++)
        {
            var input = request.uic[i];
            string text;
            try { text = WireReader.CString(input.str); }
            catch (DecoderFallbackException)
            {
                return GameResponse.Of<CSRspShowErrorMsg>(64, rsp =>
                {
                    rsp.errNo = (int)ECSErrorCode.CS_ERR_ILLEGAL_REQ_PARAM;
                    rsp.errMsg = Storage.LocalAccount.TextBytes("文本编码无效", 64);
                });
            }
            var invalid = text.Any(char.IsControl);
            results[i] = invalid ? (int)ECSErrorCode.CS_ERR_ROLE_NAME_CONTAINS_ILLEGAL_CHARACTERS : 0;
            // 保留批次和分片回调编号。
            texts[i] = new CSUic
            {
                callback = input.callback, replaceDirty = input.replaceDirty,
                str = invalid && input.replaceDirty != 0
                    ? Storage.LocalAccount.TextBytes(new string(text.Select(c => char.IsControl(c) ? '*' : c).ToArray()), 303)
                    : input.str.ToArray()
            };
        }
        log.Write(session, "text_checked", new { count, callbacks = texts.Select(t => t.callback).ToArray(), results }, true);
        return GameResponse.Of<CSRspCheckUic>((int)ECSMsgCmdID.CS_RSP_CHECK_UIC, rsp =>
        {
            rsp.count = count;
            for (var i = 0; i < count; i++) { rsp.result[i] = results[i]; rsp.uic[i] = texts[i]; }
        });
    }
}

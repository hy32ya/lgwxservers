using System;
using System.Collections;
using System.IO;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyCompany("星海游戏HY32")]
[assembly: AssemblyCopyright("Copyright (c) 2026 星海游戏HY32")]

namespace LocalLoginHarness
{
    public static class Bridge
    {
        private const string EndpointFile = "/data/data/com.tencent.LEGOCUBEPreview/files/local_server.txt";
        private static string endpoint;
        public static string Endpoint
        {
            get
            {
                if (endpoint != null) return endpoint;
                if (!File.Exists(EndpointFile))
                    throw new InvalidOperationException("缺少登录地址配置：" + EndpointFile);
                string value = File.ReadAllText(EndpointFile).Trim();
                Uri uri;
                if (!Uri.TryCreate(value, UriKind.Absolute, out uri) ||
                    uri.Scheme != "tcp" || String.IsNullOrEmpty(uri.Host) ||
                    uri.Host == "0.0.0.0" || uri.Host == "::" || uri.Host == "[::]" ||
                    uri.Port < 1 || uri.Port > 65535 || uri.UserInfo.Length != 0 ||
                    uri.Query.Length != 0 || uri.Fragment.Length != 0 ||
                    (uri.AbsolutePath.Length != 0 && uri.AbsolutePath != "/"))
                    throw new InvalidOperationException("local_server.txt 需要填写 tcp://实际IP:端口。");
                endpoint = value;
                return endpoint;
            }
        }
        // 握手占位值，实际账号由服务端按 IP 分配。
        public const string OpenId = "00000000000000000000000000001001";
        public const string AccessToken = "local-test-token-1001";
        private static readonly BindingFlags Flags = BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
        private static object account;

        private static FieldInfo Field(Type type, string name)
        {
            while (type != null)
            {
                FieldInfo field = type.GetField(name, Flags);
                if (field != null) return field;
                type = type.BaseType;
            }
            throw new MissingFieldException(name);
        }

        private static MethodInfo Method(Type type, string name, int count)
        {
            while (type != null)
            {
                foreach (MethodInfo method in type.GetMethods(Flags))
                    if (method.Name == name && method.GetParameters().Length == count)
                        return method;
                type = type.BaseType;
            }
            throw new MissingMethodException(name);
        }

        private static object Call(object self, string name, params object[] args)
        {
            return Method(self.GetType(), name, args.Length).Invoke(self, args);
        }

        private static void Set(object self, string name, object value)
        {
            FieldInfo field = Field(self.GetType(), name);
            if (field.FieldType.IsEnum && value is int)
                value = Enum.ToObject(field.FieldType, value);
            field.SetValue(self, value);
        }

        private static void Property(object self, string name, object value)
        {
            PropertyInfo property = self.GetType().GetProperty(name);
            if (property == null) throw new MissingMemberException(name);
            if (property.PropertyType.IsEnum && value is int)
                value = Enum.ToObject(property.PropertyType, value);
            property.SetValue(self, value, null);
        }

        private static bool Local(object holder)
        {
            object server = Call(holder, "GetCurServer");
            if (server == null) return false;
            return String.Equals((string)Field(server.GetType(), "serverUrl").GetValue(server),
                Endpoint, StringComparison.Ordinal);
        }

        private static void AddToken(Assembly game, object target, int type, string value)
        {
            object token = Activator.CreateInstance(game.GetType("Apollo.ApolloToken", true));
            Set(token, "Type", type);
            Set(token, "Value", value);
            Set(token, "Expire", 2147483000L);
            IList list = (IList)target.GetType().GetProperty("TokenList").GetValue(target, null);
            list.Add(token);
        }

        public static object ResolveHolder(ulong objectId)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = assembly.GetType("NetworkHolder", false);
                if (type == null) continue;
                MethodInfo getter = type.GetMethod("GetInstance", BindingFlags.Public |
                    BindingFlags.NonPublic | BindingFlags.Static, null, Type.EmptyTypes, null);
                if (getter == null) throw new MissingMethodException("NetworkHolder.GetInstance");
                object holder = getter.Invoke(null, null);
                if (holder == null) throw new InvalidOperationException("NetworkHolder instance is missing.");
                object service = Field(type, "accountService").GetValue(holder);
                if (service == null) throw new InvalidOperationException("Account service is not initialized.");
                PropertyInfo id = service.GetType().GetProperty("ObjectId");
                if (id == null || (ulong)id.GetValue(service, null) != objectId)
                    throw new InvalidOperationException("Native login object does not match NetworkHolder.accountService.");
                return holder;
            }
            throw new TypeLoadException("The current domain has no NetworkHolder type.");
        }

        // 准备本地登录凭据。
        public static object Prepare(object holder, int platform)
        {
            if (!Local(holder))
            {
                object selected = Call(holder, "GetCurServer");
                string actual = selected == null ? "<null>" :
                    (string)Field(selected.GetType(), "serverUrl").GetValue(selected);
                throw new InvalidOperationException("Select " + Endpoint + " before login; current=" + actual);
            }
            if (platform == 6 && account == null) return null;
            if (platform == 6)
                platform = Convert.ToInt32(account.GetType().GetProperty("Platform").GetValue(account, null));
            if (platform == 257) platform = 1;
            if (platform == 258) platform = 2;
            if (platform != 1 && platform != 2) platform = 2;
            object service = Field(holder.GetType(), "accountService").GetValue(holder);
            if (service == null) throw new InvalidOperationException("Account service is not initialized.");
            Delegate callback = Field(service.GetType(), "LoginEvent").GetValue(service) as Delegate;
            if (callback == null) throw new InvalidOperationException("Login callback is not registered.");
            Call(holder, "disconnect");
            Set(holder, "csAccessToken", String.Empty);
            Set(holder, "csPayToken", String.Empty);
            Set(holder, "pf", String.Empty);
            Assembly game = holder.GetType().Assembly;
            object next = Activator.CreateInstance(game.GetType("Apollo.ApolloAccountInfo", true));
            Property(next, "Platform", platform);
            Property(next, "Channel", 0);
            Property(next, "OpenId", OpenId);
            Property(next, "UserId", OpenId);
            Property(next, "Uin", 1001UL);
            Property(next, "Pf", "local");
            Property(next, "PfKey", String.Empty);
            Property(next, "STKey", String.Empty);
            Property(next, "Prajna_ext", String.Empty);
            AddToken(game, next, 1, AccessToken);
            AddToken(game, next, 3, String.Empty);
            account = next;
            Set(holder, "curApolloPlatform", platform);
            Set(holder, "loginAccountType", platform == 1 ? 2 : 1);
            return next;
        }

        public static void Complete(object holder, object prepared)
        {
            if (prepared == null || prepared != account || !Local(holder))
                throw new InvalidOperationException("No local test account is prepared.");
            object service = Field(holder.GetType(), "accountService").GetValue(holder);
            Delegate callback = Field(service.GetType(), "LoginEvent").GetValue(service) as Delegate;
            if (callback == null) throw new InvalidOperationException("Login callback is missing.");
            Type result = holder.GetType().Assembly.GetType("Apollo.ApolloResult", true);
            callback.DynamicInvoke(new object[] { Enum.ToObject(result, 0), prepared });
        }

        public static IEnumerator Tree(object holder, int platform)
        {
            if (account == null || !Local(holder))
                throw new InvalidOperationException("Local endpoint/account required.");
            Type apolloPlatform = holder.GetType().Assembly.GetType("Apollo.ApolloPlatform", true);
            Call(holder, "CreateConnect", Enum.ToObject(apolloPlatform, platform));
            return Empty();
        }

        private static IEnumerator Empty()
        {
            yield break;
        }
    }
}

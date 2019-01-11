using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Greatbone.Device
{
    public class Host
    {
        public const string HOST_JSON = "host.json";


        public const string CERT_PFX = "cert.pfx";


        internal static readonly HostConfig Config;

        internal static readonly string Sign;

        static readonly Logger Logger;

        // configured connectors that connect to peer services
        static readonly Map<string, WebClient> Ref;

        static AgentSet RootAgent { get; set; }


        static Host()
        {
            // setup logger
            string logfile = DateTime.Now.ToString("yyyyMM") + ".log";
            Logger = new Logger(logfile);
            if (!File.Exists(HOST_JSON))
            {
                Logger.Log(5, null, HOST_JSON + " not found");
                return;
            }

            // load the configuration file
            byte[] bytes = File.ReadAllBytes(HOST_JSON);
            JsonParser parser = new JsonParser(bytes, bytes.Length);
            JObj jo = (JObj)parser.Parse();
            Config = new HostConfig();
            Config.Read(jo, 0xff);

            if (Config.logging > 0)
            {
                Logger.Level = Config.logging;
            }

            // references
            var r = Config.@ref;
            if (r != null)
            {
                for (int i = 0; i < r.Count; i++)
                {
                    var e = r.EntryAt(i);
                    if (Ref == null)
                    {
                        Ref = new Map<string, WebClient>(16);
                    }
                    Ref.Add(new WebClient(e.Key, e.Value)
                    {
                        Clustered = true
                    });
                }
            }

            Sign = Encrypt(Config.cipher.ToString());

        }


        // LOGGING

        public static void TRC(string msg, Exception ex = null)
        {
            if (msg != null)
            {
                Logger.Log(LogLevel.Trace, 0, msg, ex, null);
            }
        }

        public static void DBG(string msg, Exception ex = null)
        {
            if (msg != null)
            {
                Logger.Log(LogLevel.Debug, 0, msg, ex, null);
            }
        }

        public static void INF(string msg, Exception ex = null)
        {
            if (msg != null)
            {
                Logger.Log(LogLevel.Information, 0, msg, ex, null);
            }
        }

        public static void WAR(string msg, Exception ex = null)
        {
            if (msg != null)
            {
                Logger.Log(LogLevel.Warning, 0, msg, ex, null);
            }
        }

        public static void ERR(string msg, Exception ex = null)
        {
            if (msg != null)
            {
                Logger.Log(LogLevel.Error, 0, msg, ex, null);
            }
        }



        public static S MakeRootAgent<S>() where S : AgentSet
        {
            // create work instance through reflection
            Type typ = typeof(S);
            ConstructorInfo ci = typ.GetConstructor(new Type[] { });
            if (ci == null)
            {
                //                throw new WebException(typ + " missing WebWorkInfo");
            }
            AgentInfo wwi = new AgentInfo()
            {
            };
            S w = (S)ci.Invoke(new object[] { wwi });
            RootAgent = w;
            return w;
        }

    }
}

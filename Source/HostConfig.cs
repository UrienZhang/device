using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Greatbone.Device
{
    /// <summary>
    /// The configuration for an applicaion.
    /// </summary>
    public class HostConfig : IData
    {
        // the sharding notation for this service instance
        public string shard;

        // the descriptive information of this service instance
        public string descr;

        // logging level
        public int logging = 3;

        public int cipher;

        public string certpasswd;


        // references to remote services in form of svcname[-idx] and url pairs
        public JObj @ref;


        X509Certificate2 certificate;

        volatile string connstr;

        public string ConnectionString
        {
            get
            {
                if (connstr == null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(";Read Buffer Size=").Append(1024 * 32);
                    sb.Append(";Write Buffer Size=").Append(1024 * 32);
                    sb.Append(";No Reset On Close=").Append(true);

                    connstr = sb.ToString();
                }
                return connstr;
            }
        }

        public void Read(ISource s, byte proj = 0x0f)
        {
            s.Get(nameof(shard), ref shard);
            s.Get(nameof(descr), ref descr);
            s.Get(nameof(logging), ref logging);
            s.Get(nameof(cipher), ref cipher);
            s.Get(nameof(certpasswd), ref certpasswd);
            s.Get(nameof(@ref), ref @ref);
        }

        public void Write(ISink s, byte proj = 0x0f)
        {
            s.Put(nameof(shard), shard);
            s.Put(nameof(descr), descr);
            s.Put(nameof(logging), logging);
            s.Put(nameof(cipher), cipher);
            s.Put(nameof(certpasswd), certpasswd);
            s.Put(nameof(@ref), @ref);
        }
    }

}
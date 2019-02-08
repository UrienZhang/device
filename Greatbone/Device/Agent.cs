
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using Greatbone;

namespace Greatbone.Device
{

    /// <summary>
    /// The structural and functional descriptor for a controller class.
    /// </summary>
    /// <remarks>
    /// A controller consists of remote management and signal processing
    /// </remarks>
    public class Agent
    {

        AgentSet parent;


        public void Enqueue(Signal sig)
        {

        }

        public virtual void Init()
        {

        }

        // event management
        ConcurrentQueue<Signal> signals;


        // all handler methods
        Map<string, Routine> routines;


        // threading
        Task runner;

        // remote instrumentation and monitoring
        short status;


        protected internal Agent()
        {
            routines = new Map<string, Routine>(32);

            foreach (MethodInfo mi in GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                // verify the return type
                Type ret = mi.ReturnType;
                bool async;
                if (ret == typeof(Task)) async = true;
                else if (ret == typeof(void)) async = false;
                else continue;

                ParameterInfo[] pis = mi.GetParameters();
                Routine rtn;
                if (pis.Length == 1 && pis[0].ParameterType == typeof(SignalContext))
                {
                    rtn = new Routine(this, mi, async, null);
                }
                else continue;

                routines.Add(rtn.Name, rtn);
            }
        }

        public void Add(Signal sig)
        {

        }

    }
}
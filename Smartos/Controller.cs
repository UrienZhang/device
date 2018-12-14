
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Smartos
{

    /// <summary>
    /// The structural and functional descriptor for a controller class.!--
    /// A controller consists of remote management and signal processing
    /// </summary>
    public abstract class Controller
    {
        // event management
        ConcurrentQueue<Signal> signals;


        Map<string, Handler> handlers;


        // threading
        Thread runner;

        // remote instrumentation and monitoring
        short status;


        public Controller()
        {
            handlers = new Map<string, Handler>(32);

            foreach (MethodInfo mi in GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                // verify the return type
                Type ret = mi.ReturnType;
                bool async;
                if (ret == typeof(Task)) async = true;
                else if (ret == typeof(void)) async = false;
                else continue;

                ParameterInfo[] pis = mi.GetParameters();
                Handler act;
                if (pis.Length == 1 && pis[0].ParameterType == typeof(SignalContext))
                {
                    act = new Handler(this, mi, async, null);
                }
                else continue;

                handlers.Add(act.Name, act);
            }
        }

        public void Add(Signal sig)
        {

        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;

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
        Map<string, Action> actions;


        // threading
        Thread runner;

        // remote instrumentation and monitoring
        short status;


        protected internal Agent()
        {
            actions = new Map<string, Action>(32);

            foreach (MethodInfo mi in GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                // verify the return type
                Type ret = mi.ReturnType;
                bool async;
                if (ret == typeof(Task)) async = true;
                else if (ret == typeof(void)) async = false;
                else continue;

                ParameterInfo[] pis = mi.GetParameters();
                Action act;
                if (pis.Length == 1 && pis[0].ParameterType == typeof(SignalContext))
                {
                    act = new Action(this, mi, async, null);
                }
                else continue;

                actions.Add(act.Name, act);
            }
        }

        public void Add(Signal sig)
        {

        }

    }
}
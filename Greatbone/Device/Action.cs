using System;
using System.Reflection;

namespace Greatbone.Device
{

    /// signal action
    ///
    public class Action
    {
        Agent declarer;

        string name;

        bool async;

        readonly Action<SignalContext> @do;

        internal Action(Agent declarer, MethodInfo mi, bool async, string name)
        {
            this.declarer = declarer;
            this.name = name;
        }

        public string Name => name;
    }
}
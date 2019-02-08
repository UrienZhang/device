using System;
using System.Reflection;

namespace Greatbone.Device
{

    /// signal action
    ///
    public class Routine
    {
        Agent declarer;

        string name;

        bool async;

        readonly Action<SignalContext> @do;

        internal Routine(Agent declarer, MethodInfo mi, bool async, string name)
        {
            this.declarer = declarer;
            this.name = name;
        }

        public string Name => name;
    }
}
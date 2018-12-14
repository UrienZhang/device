using System;
using System.Reflection;

namespace Smartos
{

    public class Handler
    {
        Controller declarer;

        string name;

        bool async;


        readonly Action<SignalContext> @do;

        internal Handler(Controller ctr, MethodInfo mi, bool async, string name)
        {
            this.declarer = ctr;
            this.name = name;
        }

        public string Name => name;
    }
}
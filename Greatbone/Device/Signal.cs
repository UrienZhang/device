
using System;
using Greatbone;

namespace Greatbone.Device
{

    public class Signal : IData
    {
        public void Read(ISource s, byte proj = 15)
        {
            throw new NotImplementedException();
        }

        public void Write(ISink s, byte proj = 15)
        {
            throw new NotImplementedException();
        }
    }
}
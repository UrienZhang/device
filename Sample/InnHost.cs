
using System;
using Greatbone.Device;

namespace Inn
{

    public class InnHost : Device
    {

        public InnHost()
        {
            Add(new ScreenAgent());

            Add(new CardRwAgent());
        }

    }
}
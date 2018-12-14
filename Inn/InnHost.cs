
using System;
using Smartos;

namespace Inn
{

    public class InnHost : Host
    {

        public InnHost()
        {
            Add(new ScreenAgent());

            Add(new CardRwAgent());
        }

    }
}
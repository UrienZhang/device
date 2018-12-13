
using System;
using Sharpi;

namespace Inn
{

    public class DeskHost : Host
    {

        public DeskHost()
        {
            Add(new DisplayAgent());

            Add(new CardDrawerAgent());
        }

    }
}
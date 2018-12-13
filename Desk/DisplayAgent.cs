
using System;
using System.Threading;
using Sharpi;

namespace Desk
{

    /// <summary>
    /// </summary>
    public class DisplayAgent : WpfAgent
    {
        // event management

        Thread sta;

        // threading
        public override void Init()
        {
            sta = new Thread(x => App.Run(new MyWindow()));
            sta.SetApartmentState(ApartmentState.STA);
            sta.Start();
        }
    }
}
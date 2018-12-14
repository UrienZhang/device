
using System;
using System.Threading;
using System.Windows.Threading;
using Smartos;

namespace Inn
{

    /// <summary>
    /// </summary>
    public class ScreenAgent : WpfAgent
    {
        // event management

        Thread sta;

        // threading
        public override void Init()
        {
            sta = new Thread(x =>
            {
                var win = new MyWindow();
                win.Show();
                Dispatcher.Run();
            });
            sta.SetApartmentState(ApartmentState.STA);
            sta.Start();
        }
    }
}
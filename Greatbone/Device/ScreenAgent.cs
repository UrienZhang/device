
using System;
using System.Windows;

namespace Greatbone.Device
{

    /// <summary>
    /// A screen in WPF
    /// </summary>
    public class ScreenAgent : Agent
    {
        // app
        Application app;

        public ScreenAgent()
        {
            app = new Application();
        }

        // threading


        // remote instrumentation and monitoring

        public Application App => app;
    }
}

using System;
using System.Windows;

namespace Sharpi
{

    /// <summary>
    /// A host is a controller of device.
    /// </summary>
    public class WpfAgent : Agent
    {
        // app
        Application app;


        public WpfAgent() 
        {
            app = new Application();
        }

        // threading


        // remote instrumentation and monitoring

        public Application App => app;
    }
}
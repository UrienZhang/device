
using System;
using System.Windows;

namespace Sharpi
{

    /// <summary>
    /// An agent with Windows Presentation Foundation interface.
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
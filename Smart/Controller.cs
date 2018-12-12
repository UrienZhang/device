
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Smart
{

    /// <summary>
    /// A ontroller of device.
    /// </summary>
    public class Controller : Handler
    {
        // event management

        ConcurrentQueue<Signal> signals;

        // threading
        Thread runner;


        // remote instrumentation and monitoring

        short status;

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Pause()
        {

        }


    }
}
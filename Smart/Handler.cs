
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Smart
{

    /// <summary>
    /// A event handler
    /// </summary>
    public class Handler 
    {
        // event management

        ConcurrentQueue<Signal> msgs;

        // threading
        Thread runner;


        // remote instrumentation and monitoring

        short status;


    }
}
using System;

namespace Smartos
{
    public interface IPlayable
    {
        void start(SignalContext sc);

        void stop(SignalContext sc);

        void restart(SignalContext sc);

        void pause(SignalContext sc);
    }
}
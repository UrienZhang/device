using System;

namespace Greatbone.Device
{
    public interface IManageable
    {
        void start(SignalContext sc);

        void stop(SignalContext sc);

        void restart(SignalContext sc);

        void pause(SignalContext sc);
    }
}
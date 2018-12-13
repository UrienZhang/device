
using System;
using Sharpi;

namespace Kiosk
{

    public class KioskHost : Host
    {

        public KioskHost()
        {
            Add(new DisplayAgent());

            Add(new CameraAgent());
        }
    }
}
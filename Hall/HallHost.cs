
using System;
using Greatbone.Device;

namespace Hall
{

    public class HallHost : Device
    {

        public HallHost()
        {
            Add(new ScreenAgent());

            Add(new CameraAgent());
        }
    }
}
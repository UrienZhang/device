
using System;
using Smartos;

namespace Hall
{

    public class HallHost : Host
    {

        public HallHost()
        {
            Add(new ScreenAgent());

            Add(new CameraAgent());
        }
    }
}
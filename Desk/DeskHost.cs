
using System;
using Sharpi;

namespace Desk
{

    public class DeskHost : Host
    {

        public DeskHost()
        {
            Add(new DisplayAgent());

            Add(new CameraController());
        }

    }
}
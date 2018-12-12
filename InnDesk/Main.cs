
using System;
using Smart;

namespace Reception
{

    public class Main : Orchestrater
    {

        public Main()
        {
            Add(new DisplayController());

            Add(new CameraController());
        }

    }
}
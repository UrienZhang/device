
using System;
using System.Collections.Generic;

namespace Smartos
{
    public class Host : Controller
    {

        List<Agent> agents = new List<Agent>(8);

        public void Add(Agent ctr)
        {
            agents.Add(ctr);
        }

        public void Start()
        {
            for (int i = 0; i < agents.Count; i++)
            {
                var a = agents[i];
                a.Init();
            }
        }

    }
}
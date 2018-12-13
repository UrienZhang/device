
using System;
using System.Collections.Generic;

namespace Sharpi
{
    public class Host : Controller
    {

        List<Agent> agents = new List<Agent>(8);

        public void Add(Agent ctr)
        {
            agents.Add(ctr);
        }
    }
}
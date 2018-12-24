
using System;
using System.Collections.Generic;

namespace Greatbone.Device
{
    public abstract class AgentSet : Agent
    {
        List<Agent> agents = new List<Agent>(8);

        protected AgentSet() 
        {
        }

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
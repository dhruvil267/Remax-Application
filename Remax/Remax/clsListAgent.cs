using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsListAgent
    {
        private Dictionary<string, clsAgent> myList;

        public clsListAgent()
        {
            myList = new Dictionary<string, clsAgent>();
        }

        public Dictionary<string,clsAgent>.ValueCollection Elements
        {
            get => myList.Values;
        }

        public int Quantity
        {
            get => myList.Count;
        }

        public bool Add(clsAgent agent)
        {
            if (Exist(agent.AgentNo) == false)
            {
                myList.Add(agent.AgentNo, agent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string agentno)
        {
            return myList.Remove(agentno);
        }

        public string Display()
        {
            string info = "";
            foreach (clsAgent itm in Elements)
            {
                info += itm.Display() + "\n";
            }
            return info;
        }

        public bool Exist(string agentno)
        {
            return myList.ContainsKey(agentno);
        }

        public clsAgent Find(string agentno)
        {
            if (Exist(agentno) == true)
            {
                return myList[agentno];
            }
            else
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsAgent
    {
        private string vAgentNo;
        private string vPin;
        private string vAgentName;
        private string vMail;
        private clsListClient vClients;
        private clsListHouse vHouses;

        public clsAgent(string agentno,string pin, string agentname,string mail,clsListClient clients,clsListHouse houses)
        {
            vAgentNo = agentno;
            vPin = pin;
            vAgentName = agentname;
            vMail = mail;
            vClients = clients;
            vHouses = houses;
        }

        public clsAgent(string agentno,string pin, string agentname, string mail)
        {
            vAgentNo = agentno;
            vPin = pin;
            vAgentName = agentname;
            vMail = mail;
            vClients = new clsListClient();
            vHouses = new clsListHouse();
        }

        public clsAgent()
        {
            vAgentName = vAgentNo = vPin= vMail = "Not Assigned";
            vClients = new clsListClient();
            vHouses = new clsListHouse();
        }

        public string AgentNo
        {
            get => vAgentNo;
            set
            {
                vAgentNo = value;
            }
        }
        public string Pin
        {
            get => vPin;
            set
            {
                vPin = value;
            }
        }

        public string AgentName
        {
            get => vAgentName;
            set
            {
                vAgentName = value;
            }
        }

        public string Mail
        {
            get => vMail;
            set
            {
                vMail = value;
            }
        }

        public clsListClient Clients
        {
            get => vClients;
            set
            {
                vClients = value;
            }
        }

        public clsListHouse Houses
        {
            get => vHouses;
            set
            {
                vHouses = value;
            }
        }

        public string Display()
        {
            string info = "----- Agents -----\n Agent Number: " + vAgentNo +"\n Agent Pin: " + vPin + "\nAgent Name: " + vAgentName
                + "\nAgent mail: " + vMail + "\n-----Agent Clients-----\n " + vClients.Display() + "\n-----Agent Houses-----\n "
                + vHouses.Display() + "\n";
            return info;
        }

        public void Register(string agentno,string pin, string agentname, string mail)
        {
            vAgentNo = agentno;
            vPin = pin;
            vAgentName = agentname;
            vMail = mail;
        }
    }
}
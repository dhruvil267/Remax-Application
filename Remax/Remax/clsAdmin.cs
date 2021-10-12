using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsAdmin
    {
        private string vAdminNo;
        private string vAdminName;
        private string vPin;
        private clsListAgent vAgents;
      

        public clsAdmin(string adminno,string adminname,string pin,clsListAgent agent)
        {
            vAdminNo = adminno;
            vAdminName = adminname;
            vPin = pin;
            vAgents = agent;
            
        }

        public clsAdmin()
        {
            vAdminName = vAdminNo = vPin = "Not Assigned";
            vAgents = new clsListAgent();
         
        }
        public clsAdmin(string adminno, string adminname, string pin)
        {
            vAdminName = adminname;
            vAdminNo = adminno;
            vPin = pin;
            vAgents = new clsListAgent();
           
        }

        public string AdminName
        {
            get => vAdminName;
            set
            {
                vAdminName = value;
            }
        }

        public string AdminNo
        {
            get => vAdminNo;
            set
            {
                vAdminNo = value;
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

        public clsListAgent Agents
        {
            get => vAgents;
            set
            {
                vAgents = value;
            }
        }

      

        public string Display()
        {
            string info = "----- Admin -----\n Admin Number: " + vAdminNo + "\nAdmin Name: " + vAdminName
                   + "\nAdmin Pin: " + vPin + "\n-----Admin's Agent-----\n " + vAgents.Display();
            return info;
        }
    }
}
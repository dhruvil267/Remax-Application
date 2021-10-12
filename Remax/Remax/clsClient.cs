using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsClient
    {
        private string vClientNo;
        private string vClientName;
        private string vType;
        private string vMail;

        public clsClient(string clientno,string clientname,string clienttype, string mail)
        {
            vClientNo = clientno;
            vClientName = clientname;
            vType = clienttype;
            vMail = mail;
        }

        public clsClient()
        {
            vClientName = vClientNo = vType = vMail = "Not Assigned";
        }

        public string ClientNo
        {
            get => vClientNo;
            set
            {
                vClientNo = value;
            }
        }

        public string ClientName
        {
            get => vClientName;
            set
            {
                vClientName = value;
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

        public string Type
        {
            get => vType;
            set
            {
                vType = value;
            }
        }

        public string Display()
        {
            string info = "----- Client -----\n Client Number: " + vClientNo + "\nClient Name: " + vClientName
                + "\nClient Type: " + vType + "\nClient mail: " + vMail;
            return info;
        }

        public void Register(string clientno, string clientname, string clienttype, string mail)
        {
            vClientNo = clientno;
            vClientName = clientname;
            vType = clienttype;
            vMail = mail;
        }
    }
}
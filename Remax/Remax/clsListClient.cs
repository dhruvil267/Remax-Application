using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsListClient
    {
        private Dictionary<string, clsClient> myList;

        public clsListClient()
        {
            myList = new Dictionary<string, clsClient>();
        }

        public Dictionary<string,clsClient>.ValueCollection Elements
        {
            get => myList.Values;
        }

        public int Quantity
        {
            get => myList.Count;
        }

        public bool Add(clsClient client)
        {
            if (Exist(client.ClientNo) == false)
            {
                myList.Add(client.ClientNo, client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string cliennum)
        {
            return myList.Remove(cliennum);
        }

        public string Display()
        {
            string info = "";
            foreach (clsClient itm in Elements)
            {
                info += itm.Display() + "\n";
            }
            return info;
        }

        public bool Exist(string cliennum)
        {
            return myList.ContainsKey(cliennum);
        }

        public clsClient Find(string cliennum)
        {
            if (Exist(cliennum) == true)
            {
                return myList[cliennum];
            }
            else
            {
                return null;
            }
        }
    }
}
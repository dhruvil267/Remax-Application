using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsListHouse
    {
        private Dictionary<string, clsHouse> myList;

        public clsListHouse()
        {
            myList = new Dictionary<string, clsHouse>();
        }

        public Dictionary<string,clsHouse>.ValueCollection Elements
        {
            get => myList.Values;

        }

        public int Quantity
        {
            get => myList.Count;
          
        }

        public bool Add(clsHouse house)
        {
            if (Exist(house.HouseNo) == false)
            {
                myList.Add(house.HouseNo, house);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string housenum)
        {
            return myList.Remove(housenum);
        }

        public string Display()
        {
            string info = "";
            foreach (clsHouse itm in Elements)
            {
                info += itm.Display() + "\n";
            }
            return info;
        }

        public bool Exist(string housenum)
        {
            return myList.ContainsKey(housenum);
        }

        public clsHouse Find(string housenum)
        {
            if (Exist(housenum) == true)
            {
                return myList[housenum];
            }
            else
            {
                return null;
            }
        }
    }
}
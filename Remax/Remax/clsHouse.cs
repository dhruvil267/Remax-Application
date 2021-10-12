using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remax
{
    public class clsHouse
    {
        private string vHouseNo;
        private string vAddress;
        private string vSize;
        private int vPrice;
        

        public clsHouse(string houseno,string address,string size,int price)
        {
            vHouseNo = houseno;
            vAddress = address;
            vSize = size;
            vPrice = price;
         
        }

        public clsHouse()
        {
            vHouseNo = vAddress = vSize = "Not Assigned";
            vPrice = -1;
        }

        public string HouseNo
        {
            get =>vHouseNo;
            set
            {
                vHouseNo = value;
            }
        }

        public string Address
        {
            get => vAddress;
            set
            {
                vAddress = value;
            }
        }

        public string Size
        {
            get => vSize;
            set
            {
                vSize = value;
            }
        }

        public int Price
        {
            get => vPrice;
            set
            {
                vPrice = value;
            }
        }

       

        public string Display()
        {
            string info = "----- House -----\n Number: " + vHouseNo + "\nAddress: " + vAddress
                + "\nSize: " + vSize + "\nPrice: " + vPrice;
            return info;
        }

        public void Register(string houseno, string address, string size, int price,string clientno)
        {
            vHouseNo = houseno;
            vAddress = address;
            vSize = size;
            vPrice = price;
            
        }
    }
}
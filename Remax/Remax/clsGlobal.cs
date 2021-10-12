using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Remax
{
    public static class Clsglobal
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static SqlDataAdapter adpadmin, adpAgent,adpHouses,adpClients;
    }
}

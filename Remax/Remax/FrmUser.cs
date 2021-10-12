using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Remax
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        SqlConnection myCon;
        SqlDataReader myRder;
        DataTable tmp;
        
        private void FrmUser_Load(object sender, EventArgs e)
        {
            
            myCon = new SqlConnection();
            myCon.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_Remax;Integrated Security=True";
            myCon.Open();
        }

        private void btnSearchHouse_Click(object sender, EventArgs e)
        {

            string sql = "";
            tmp = new DataTable();

            if (radAllHouse.Checked)
            {
                sql = "select * from houses";
                SqlCommand mycmd = new SqlCommand(sql, myCon);
                myRder = mycmd.ExecuteReader();
                tmp.Load(myRder);
            }
            else if (radoneHouse.Checked)
            {
                sql = "select * from houses where HouseNo=@hno";
                SqlCommand mycmd = new SqlCommand(sql, myCon);
                mycmd.Parameters.AddWithValue("@hno", txtrefnoHouse.Text);
                myRder = mycmd.ExecuteReader();
                tmp.Load(myRder);
            }  
            gridSearch.DataSource = tmp;
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
            string sql = "";
            tmp = new DataTable();

            if (radAllAgent.Checked)
            {
                sql = "select * from Agents";
                SqlCommand mycmd = new SqlCommand(sql, myCon);
                myRder = mycmd.ExecuteReader();
                tmp.Load(myRder);
            }
            else if (radoneAgent.Checked)
            {
                sql = "select * from Agents where AgentNo=@ano";
                SqlCommand mycmd = new SqlCommand(sql, myCon);
                mycmd.Parameters.AddWithValue("@ano", txtRefNoAgent.Text);
                myRder = mycmd.ExecuteReader();
                tmp.Load(myRder);
            }
            gridSearch.DataSource = tmp;
        }

       
    }
}

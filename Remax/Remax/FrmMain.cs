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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void mnuUser_Click(object sender, EventArgs e)
        {
            FrmUser myuser = new FrmUser();
            myuser.MdiParent = this;
            myuser.Show();
        }

        private void mnuAgent_Click(object sender, EventArgs e)
        {
            FrmAgent myagent = new FrmAgent();
            myagent.MdiParent = this;
            myagent.Show();
        }

        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            FrmAdmin myadmin = new FrmAdmin();
            myadmin.MdiParent = this;
            myadmin.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Clsglobal.mySet = new DataSet();
            Clsglobal.myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_Remax;Integrated Security=True");
            Clsglobal.myCon.Open();

            SqlCommand myCmd = new SqlCommand("select * from Admin",Clsglobal.myCon);
            Clsglobal.adpadmin = new SqlDataAdapter(myCmd);
            Clsglobal.adpadmin.Fill(Clsglobal.mySet, "Admin");

            myCmd = new SqlCommand("select * from Agents",Clsglobal.myCon);
            Clsglobal.adpAgent = new SqlDataAdapter(myCmd);
            Clsglobal.adpAgent.Fill(Clsglobal.mySet, "Agents");
            

            myCmd = new SqlCommand("select * from Houses",Clsglobal.myCon);
           Clsglobal.adpHouses = new SqlDataAdapter(myCmd);
           Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");


            myCmd = new SqlCommand("select * from Clients",Clsglobal.myCon);
           Clsglobal.adpClients = new SqlDataAdapter(myCmd);
           Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Are you sure you want to quit this program ?";
            string title = "Application Closing";

            if (MessageBox.Show(info, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

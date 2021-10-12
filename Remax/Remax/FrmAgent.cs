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
    public partial class FrmAgent : Form
    {
        public FrmAgent()
        {
            InitializeComponent();
        }
        
       
        DataTable tabAgents;
        DataTable tabClients;
        DataTable tabHouses;
        

        string mode = "";
        int flag;
        int currentIndx;
        int currentIndx2;
        private void FrmAgent_Load(object sender, EventArgs e)
        {
           
            tabAgents =Clsglobal.mySet.Tables["Agents"];
            groupBox1.Visible = false;
            groupBox2.Visible = false;

        }
        private void ActivateButtons(bool add, bool edit, bool delete, bool save, bool cancel, bool navigs)
        {
            btnadd.Enabled = btadd.Enabled=add;
            btnedit.Enabled = btedit.Enabled = edit;
            btndelete.Enabled = btdelete.Enabled = delete;
            btnsave.Enabled = btsave.Enabled = save;
            btnCancel.Enabled = btcancel.Enabled = cancel;
            btnFirst.Enabled = btnPrevious.Enabled = btnNext.Enabled = btnLast.Enabled = btfirst.Enabled = btprevious.Enabled = btnext.Enabled = btlast.Enabled = navigs;

        }
        
        private void DisplayDataRow2Txt()
        {
            
            var lstclnt = from clnt in tabClients.AsEnumerable()
                         where clnt.Field<int>("AgentNo").ToString() == textBox1.Text
                         select clnt;

            if (lstclnt.Count()==0)
            {
                cbogender.Text = "N/A";
                txtName.Text = "N/A";
                cbotype.Text = "N/A";
                txtMail.Text = "N/A";

                lblInfo.Text = "N/A";
            }
            else
            {
                cbogender.Text = lstclnt.ElementAt(currentIndx)["Gender"].ToString();
                txtName.Text = lstclnt.ElementAt(currentIndx)["ClientName"].ToString();
                cbotype.Text = lstclnt.ElementAt(currentIndx)["Type"].ToString();
                txtMail.Text = lstclnt.ElementAt(currentIndx)["ClientMail"].ToString();

                lblInfo.Text = "Client " + (currentIndx + 1) + " on a total of " + lstclnt.Count();

            }
            

        }
        private void DisplayDataRow2Txt2()
        {
            var lsthouse = from house in tabHouses.AsEnumerable()
                          where house.Field<int>("AgentNo").ToString() == textBox1.Text
                          select house;
            if (lsthouse.Count()==0)
            {
                txtcity.Text ="N/A";
                textBox5.Text = "N/A";
                textBox4.Text = "N/A";
                textBox3.Text = "N/A";

                labelinfo.Text = "N/A";
            }
            else
            {
                txtcity.Text = lsthouse.ElementAt(currentIndx2)["City"].ToString();
                textBox5.Text = lsthouse.ElementAt(currentIndx2)["Address"].ToString();
                textBox4.Text = lsthouse.ElementAt(currentIndx2)["Size"].ToString();
                textBox3.Text = lsthouse.ElementAt(currentIndx2)["price"].ToString();

                labelinfo.Text = "House " + (currentIndx2 + 1) + " on a total of " + lsthouse.Count();
            }
            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text.Trim();
            foreach (DataRow myRow in tabAgents.Rows)
            {
                flag = 0;
                if (myRow["AgentNo"].ToString() == textBox1.Text)
                {
                    this.Height = 205;
                    break;
                }
                flag = 1;
            }
            if (flag == 1)
            {
                MessageBox.Show("Agent Not Found, Try Again.", "Not Found",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                textBox1.Clear();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pin = textBox2.Text;
            foreach (DataRow myRow in tabAgents.Rows)
            {

                if (myRow["AgentNo"].ToString() == textBox1.Text)
                {
                    if (myRow["Pin"].ToString() == textBox2.Text)
                    {
                        this.Height = 318;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try Again.", "Pin : Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Focus();
                        textBox2.Clear();
                        return;
                    }
                }

            }



            tabClients = Clsglobal.mySet.Tables["Clients"];
            tabHouses = Clsglobal.mySet.Tables["Houses"];
            ActivateButtons(true, true, true, false, false, true);
            currentIndx = 0;
            DisplayDataRow2Txt();
            currentIndx2 = 0;
            DisplayDataRow2Txt2();

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtName.Text = cbogender.Text = cbotype.Text = txtMail.Text = "";
            txtName.Focus();
            lblInfo.Text = "--Adding Mode--";
            ActivateButtons(false, false, false, true, true,false);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtName.Focus();
            lblInfo.Text = "--Editing Mode--";
            ActivateButtons(false, false, false, true, true,false);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var lstclnt = from clnt in tabClients.AsEnumerable()
                          where clnt.Field<int>("AgentNo").ToString() == textBox1.Text
                          select clnt;
            if (MessageBox.Show("R u sure to delete this Client?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lstclnt.ElementAt(currentIndx).Delete();
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
                tabClients = Clsglobal.mySet.Tables["Clients"];
                currentIndx = 0;
                DisplayDataRow2Txt();

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var lstclnt = from clnt in tabClients.AsEnumerable()
                          where clnt.Field<int>("AgentNo").ToString() == textBox1.Text
                          select clnt;
            DataRow currentRow;
            if (mode == "add")
            {
                currentRow = tabClients.NewRow();
                currentRow["Gender"] = cbogender.SelectedItem.ToString();
                currentRow["Type"] = cbotype.SelectedItem.ToString();
                currentRow["ClientName"] = txtName.Text;
                currentRow["ClientMail"] = txtMail.Text;
                currentRow["AgentNo"] = textBox1.Text;
                tabClients.Rows.Add(currentRow);
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
                tabClients = Clsglobal.mySet.Tables["Clients"];
                currentIndx = lstclnt.Count()-1;

            }
            else if (mode == "edit")
            {
                currentRow = lstclnt.ElementAt(currentIndx); //tabClients.Rows[currentIndx];
                currentRow["Gender"] = cbogender.SelectedItem.ToString();
                currentRow["Type"] = cbotype.SelectedItem.ToString();
                currentRow["ClientName"] = txtName.Text;
                currentRow["ClientMail"] = txtMail.Text;
                currentRow["AgentNo"] = textBox1.Text;
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
                tabClients = Clsglobal.mySet.Tables["Clients"];

            }
            
            mode = "";
            DisplayDataRow2Txt();
            ActivateButtons(true, true, true, false, false, true);

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            mode = "addhouse";
            textBox3.Text = textBox4.Text = textBox5.Text = txtcity.Text = "";
            txtcity.Focus();
            labelinfo.Text = "--Adding Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = "edithouse";
          
            txtcity.Focus();
            labelinfo.Text = "--Editing Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var lsthouse = from house in tabHouses.AsEnumerable()
                           where house.Field<int>("AgentNo").ToString() == textBox1.Text
                           select house;
            if (MessageBox.Show("R u sure to delete this House?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lsthouse.ElementAt(currentIndx2).Delete();
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
               Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");
                tabHouses = Clsglobal.mySet.Tables["Houses"];
                currentIndx2 = 0;
                DisplayDataRow2Txt2();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lsthouse = from house in tabHouses.AsEnumerable()
                           where house.Field<int>("AgentNo").ToString() == textBox1.Text
                           select house;
            DataRow currentRow;
            if (mode == "addhouse")
            {
                currentRow = tabHouses.NewRow();
                currentRow["City"] = txtcity.Text;
                currentRow["Address"] = textBox5.Text;
                currentRow["Size"] = textBox4.Text;
                currentRow["Price"] = Convert.ToDecimal(textBox3.Text);
                currentRow["AgentNo"] = textBox1.Text;
                tabHouses.Rows.Add(currentRow);
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
               Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");
                tabHouses = Clsglobal.mySet.Tables["Houses"];
                currentIndx2 = lsthouse.Count()-1;
            }
            else if (mode == "edithouse")
            {
                currentRow = lsthouse.ElementAt(currentIndx2);
                currentRow["City"] = txtcity.Text;
                currentRow["Address"] = textBox5.Text;
                currentRow["Size"] = textBox4.Text;
                currentRow["Price"] = Convert.ToDecimal(textBox3.Text);
                currentRow["AgentNo"] = textBox1.Text;
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
                Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");
                tabHouses = Clsglobal.mySet.Tables["Houses"];

            }

            mode = "";
            DisplayDataRow2Txt2();
            ActivateButtons(true, true, true, false, false, true);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayDataRow2Txt();
            ActivateButtons(true, true, true, false, false, true);
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            DisplayDataRow2Txt2();
           
            ActivateButtons(true, true, true, false, false, true);
        }
        private void radioHouse_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            currentIndx2 = 0;
            DisplayDataRow2Txt2();
            this.Height = 675;
        }
        private void radioClients_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            currentIndx = 0;
            DisplayDataRow2Txt();
            cbogender.Items.Clear();
            cbotype.Items.Clear();
            cbogender.Items.Add("Male");
            cbogender.Items.Add("Female");
            cbogender.Items.Add("Unknown");
            cbotype.Items.Add("Buyer");
            cbotype.Items.Add("Seller");
            
            
            this.Height = 675;
        }

        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            currentIndx = 0;
            DisplayDataRow2Txt();
        }

        private void btfirst_Click(object sender, EventArgs e)
        {
            currentIndx2 = 0;
            DisplayDataRow2Txt2();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentIndx > 0)
            {
                currentIndx--;
                DisplayDataRow2Txt();

            }
        }

        private void btprevious_Click_1(object sender, EventArgs e)
        {
            if (currentIndx2 > 0)
            {
                currentIndx2--;
                DisplayDataRow2Txt2();

            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            var lstclnt = from clnt in tabClients.AsEnumerable()
                          where clnt.Field<int>("AgentNo").ToString() == textBox1.Text
                          select clnt;
            if (currentIndx < lstclnt.Count() - 1)
            {
                currentIndx++;
                DisplayDataRow2Txt();

            }
        }

        private void btnext_Click_1(object sender, EventArgs e)
        {
            var lsthouse = from house in tabHouses.AsEnumerable()
                           where house.Field<int>("AgentNo").ToString() == textBox1.Text
                           select house;
            if (currentIndx2 < lsthouse.Count() - 1)
            {
                currentIndx2++;
                DisplayDataRow2Txt2();

            }
        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {
            var lstclnt = from clnt in tabClients.AsEnumerable()
                          where clnt.Field<int>("AgentNo").ToString() == textBox1.Text
                          select clnt;
            currentIndx = lstclnt.Count() - 1;
            DisplayDataRow2Txt();
        }

        private void btlast_Click(object sender, EventArgs e)
        {
            var lsthouse = from house in tabHouses.AsEnumerable()
                           where house.Field<int>("AgentNo").ToString() == textBox1.Text
                           select house;
            currentIndx2 = lsthouse.Count() - 1;
            DisplayDataRow2Txt2();
        }

    
    }
}





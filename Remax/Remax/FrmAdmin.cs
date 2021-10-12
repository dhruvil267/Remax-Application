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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        
        DataTable tabAdmin;
        DataTable tabAgents;
        DataTable tabClients;
        DataTable tabHouses;
        

        string mode = "";
        int flag;
        int currentIndx;
        int currentIndx2;
        int currentIndx3;
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            
            tabAdmin =Clsglobal.mySet.Tables["Admin"];
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;


        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            string number = txtadmin.Text.Trim();
            foreach (DataRow myRow in tabAdmin.Rows)
            {
                flag = 0;
                if (myRow["AdminNo"].ToString() == txtadmin.Text)
                {
                    this.Height = 205;
                    break;
                }
                flag = 1;
            }
            if (flag == 1)
            {
                MessageBox.Show("Admin Not Found, Try Again.", "Not Found",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtadmin.Clear();
                txtadmin.Focus();
                return;
            }
        }

        private void btnpass_Click(object sender, EventArgs e)
        {
            string pin = txtadminpass.Text;
            foreach (DataRow myRow in tabAdmin.Rows)
            {

                if (myRow["AdminNo"].ToString() == txtadmin.Text)
                {
                    if (myRow["Pin"].ToString() == txtadminpass.Text)
                    {
                        this.Height = 318;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try Again.", "Pin : Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtadminpass.Focus();
                        txtadminpass.Clear();
                        return;
                    }
                }

            }
            
            tabAgents =Clsglobal.mySet.Tables["Agents"];

           


            
            currentIndx =currentIndx2=currentIndx3= 0;
            DisplayDataRow2Txt();
            DisplayDataRow2Txt2();
            DisplayDataRow2Txt3();
            ActivateButtons(true, true, true, false, false, true);


            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboclient.Items.Add(myRow["AgentName"]);
                cbohouse.Items.Add(myRow["AgentName"]);
            }
           

        }

        private void radagent_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            currentIndx3 = 0;
            DisplayDataRow2Txt3();
            this.Height = 675;
        }

        private void radioClients_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            currentIndx  = 0;
            DisplayDataRow2Txt();
            this.Height = 675;
            cbogender.Items.Clear();
            cbotype.Items.Clear();
            cbogender.Items.Add("Male");
            cbogender.Items.Add("Female");
            cbogender.Items.Add("Unknown");
            cbotype.Items.Add("Buyer");
            cbotype.Items.Add("Seller");
        }

        private void radioHouse_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
           currentIndx2 = 0;
         
            DisplayDataRow2Txt2();
   
            this.Height = 675;
        }
        private void DisplayDataRow2Txt3()
        {
            tabAgents =Clsglobal.mySet.Tables["Agents"];

            tNumber.Text = tabAgents.Rows[currentIndx3]["AgentNo"].ToString();
            tName.Text = tabAgents.Rows[currentIndx3]["AgentName"].ToString();
            tmail.Text = tabAgents.Rows[currentIndx3]["AgentMail"].ToString();
            tpin.Text = tabAgents.Rows[currentIndx3]["Pin"].ToString();

            linfo.Text = "Agent " + (currentIndx3 + 1) + " on a total of " + tabAgents.Rows.Count;

        }
        private void DisplayDataRow2Txt()
        {
            tabClients =Clsglobal.mySet.Tables["Clients"];

            txtName.Text = tabClients.Rows[currentIndx]["ClientName"].ToString();
            cbogender.Text = tabClients.Rows[currentIndx]["Gender"].ToString();
            cbotype.Text = tabClients.Rows[currentIndx]["Type"].ToString();
            txtMail.Text = tabClients.Rows[currentIndx]["ClientMail"].ToString();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = tabAgents.Columns["AgentNo"];
            tabAgents.PrimaryKey = keys;

            DataRow myrow = tabAgents.Rows.Find(tabClients.Rows[currentIndx]["AgentNo"]);
            if(myrow==null)
            {
                cboclient.Text = "N/A";
            }
            else
            {
                cboclient.Text = myrow["AgentName"].ToString();

            }

            lblInfo.Text = "Client " + (currentIndx + 1) + " on a total of " + tabClients.Rows.Count;

        }
        private void DisplayDataRow2Txt2()
        {
            tabHouses =Clsglobal.mySet.Tables["Houses"];

            txtcity.Text = tabHouses.Rows[currentIndx2]["City"].ToString();
            textBox5.Text = tabHouses.Rows[currentIndx2]["Address"].ToString();
            textBox4.Text = tabHouses.Rows[currentIndx2]["Size"].ToString();
            textBox3.Text = tabHouses.Rows[currentIndx2]["price"].ToString();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = tabAgents.Columns["AgentNo"];
            tabAgents.PrimaryKey = keys;

            DataRow myrow = tabAgents.Rows.Find(tabHouses.Rows[currentIndx2]["AgentNo"]);
            if (myrow == null)
            {
                cbohouse.Text = "N/A";
            }
            else
            {
                cbohouse.Text = myrow["AgentName"].ToString();

            }

            labelinfo.Text = "House " + (currentIndx2 + 1) + " on a total of " + tabHouses.Rows.Count;

        }
        private void ActivateButtons(bool add, bool edit, bool delete, bool save, bool cancel, bool navigs)
        {
            btnadd.Enabled = btadd.Enabled = badd.Enabled = add;
            btnedit.Enabled = btedit.Enabled = bedit.Enabled = edit;
            btndelete.Enabled = btdelete.Enabled = bdelete.Enabled = delete;
            btnsave.Enabled = btsave.Enabled = bsave.Enabled = save;
            btnCancel.Enabled = btcancel.Enabled = bcancel.Enabled = cancel;
            btnFirst.Enabled = btnPrevious.Enabled = btnNext.Enabled = btnLast.Enabled = btfirst.Enabled = btprevious.Enabled = btnext.Enabled = btlast.Enabled = bfirst.Enabled = bprevious.Enabled = bnext.Enabled = blast.Enabled = navigs;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtName.Text = cbogender.Text = cbotype.Text = txtMail.Text =cboclient.Text= "";
            txtName.Focus();
            lblInfo.Text = "--Adding Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtName.Focus();
            lblInfo.Text = "--Editing Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("R u sure to delete this Client?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabClients.Rows[currentIndx].Delete();
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
                currentIndx = 0;
                DisplayDataRow2Txt();

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
           
            if (mode == "add")
            {
                currentRow = tabClients.NewRow();
                currentRow["Gender"] = cbogender.SelectedItem.ToString();
                currentRow["Type"] = cbotype.Text;
                currentRow["ClientName"] = txtName.Text;
                currentRow["ClientMail"] = txtMail.Text;
                foreach (DataRow myrow in tabAgents.Rows)
                {
                    if (myrow["AgentName"].ToString() == cboclient.SelectedItem.ToString())
                    {
                        currentRow["AgentNo"] = myrow["AgentNo"];
                    }
                }

                tabClients.Rows.Add(currentRow);
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");
                currentIndx = tabClients.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                currentRow = tabClients.Rows[currentIndx];
                currentRow["Gender"] = cbogender.SelectedItem.ToString();
                currentRow["Type"] = cbotype.Text;
                currentRow["ClientName"] = txtName.Text;
                currentRow["ClientMail"] = txtMail.Text;
                foreach (DataRow myrow in tabAgents.Rows)
                {
                    if (myrow["AgentName"].ToString() == cboclient.SelectedItem.ToString())
                    {
                        currentRow["AgentNo"] = myrow["AgentNo"];
                    }
                }
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpClients);
               Clsglobal.adpClients.Update(Clsglobal.mySet, "Clients");
               Clsglobal.mySet.Tables.Remove("Clients");
               Clsglobal.adpClients.Fill(Clsglobal.mySet, "Clients");

            }

            mode = "";
            DisplayDataRow2Txt();
            ActivateButtons(true, true, true, false, false, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayDataRow2Txt();
            ActivateButtons(true, true, true, false, false, true);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndx = 0;
            DisplayDataRow2Txt();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndx > 0)
            {
                currentIndx--;
                DisplayDataRow2Txt();

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndx < tabClients.Rows.Count - 1)
            {
                currentIndx++;
                DisplayDataRow2Txt();

            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentIndx = tabClients.Rows.Count - 1;
            DisplayDataRow2Txt();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            mode = "addhouse";
            textBox3.Text = textBox4.Text = textBox5.Text = txtcity.Text =cbohouse.Text= "";
            txtcity.Focus();
            labelinfo.Text = "--Adding Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            mode = "edithouse";

            txtcity.Focus();
            labelinfo.Text = "--Editing Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("R u sure to delete this House?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabHouses.Rows[currentIndx2].Delete();
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
               Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");
                currentIndx2 = 0;
                DisplayDataRow2Txt2();

            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
           if (mode == "addhouse")
            {
                currentRow = tabHouses.NewRow();
                currentRow["City"] = txtcity.Text;
                currentRow["Address"] = textBox5.Text;
                currentRow["Size"] = textBox4.Text;
                currentRow["Price"] = Convert.ToDecimal(textBox3.Text);
                foreach (DataRow myrow in tabAgents.Rows)
                {
                    if (myrow["AgentName"].ToString() == cbohouse.SelectedItem.ToString())
                    {
                        currentRow["AgentNo"] = myrow["AgentNo"];
                    }
                }
                tabHouses.Rows.Add(currentRow);
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
               Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");
                currentIndx2 = tabHouses.Rows.Count - 1;
            }
            else if (mode == "edithouse")
            {
                currentRow = tabHouses.Rows[currentIndx2];
                currentRow["City"] = txtcity.Text;
                currentRow["Address"] = textBox5.Text;
                currentRow["Size"] = textBox4.Text;
                currentRow["Price"] = Convert.ToDecimal(textBox3.Text);
                foreach (DataRow myrow in tabAgents.Rows)
                {
                    if (myrow["AgentName"].ToString() == cbohouse.SelectedItem.ToString())
                    {
                        currentRow["AgentNo"] = myrow["AgentNo"];
                    }
                }
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpHouses);
               Clsglobal.adpHouses.Update(Clsglobal.mySet, "Houses");
               Clsglobal.mySet.Tables.Remove("Houses");
               Clsglobal.adpHouses.Fill(Clsglobal.mySet, "Houses");

            }

            mode = "";
            DisplayDataRow2Txt2();
            ActivateButtons(true, true, true, false, false, true);
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            DisplayDataRow2Txt2();

            ActivateButtons(true, true, true, false, false, true);
        }

        private void btfirst_Click(object sender, EventArgs e)
        {
            currentIndx2 = 0;
            DisplayDataRow2Txt2();
        }

        private void btprevious_Click(object sender, EventArgs e)
        {
            if (currentIndx2 > 0)
            {
                currentIndx2--;
                DisplayDataRow2Txt2();

            }
        }

        private void btnext_Click(object sender, EventArgs e)
        {
            if (currentIndx2 < tabHouses.Rows.Count - 1)
            {
                currentIndx2++;
                DisplayDataRow2Txt2();

            }
        }

        private void btlast_Click(object sender, EventArgs e)
        {
            currentIndx2 = tabHouses.Rows.Count - 1;
            DisplayDataRow2Txt2();
        }

        private void bfirst_Click(object sender, EventArgs e)
        {
            currentIndx3 = 0;
            DisplayDataRow2Txt3();
        }

        private void bprevious_Click(object sender, EventArgs e)
        {
            if (currentIndx3 > 0)
            {
                currentIndx3--;
                DisplayDataRow2Txt3();

            }
        }

        private void bnext_Click(object sender, EventArgs e)
        {
            if (currentIndx3 < tabAgents.Rows.Count - 1)
            {
                currentIndx3++;
                DisplayDataRow2Txt3();

            }
        }

        private void blast_Click(object sender, EventArgs e)
        {
            currentIndx3 = tabAgents.Rows.Count - 1;
            DisplayDataRow2Txt3();
        }

        private void badd_Click(object sender, EventArgs e)
        {
            mode = "addagent";
            tName.Text = tNumber.Text = tpin.Text = tmail.Text = "";
            tNumber.Focus();
            linfo.Text = "--Adding Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void bedit_Click(object sender, EventArgs e)
        {
            mode = "editagent";
            tNumber.Enabled = false;
            tName.Focus();
            linfo.Text = "--Editing Mode--";
            ActivateButtons(false, false, false, true, true, false);
        }

        private void bdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("R u sure to delete this Agent?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabAgents.Rows[currentIndx3].Delete();
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpAgent);
               Clsglobal.adpAgent.Update(Clsglobal.mySet, "Agents");
               Clsglobal.mySet.Tables.Remove("Agents");
               Clsglobal.adpAgent.Fill(Clsglobal.mySet, "Agents");
                currentIndx3 = 0;
                DisplayDataRow2Txt3();
                

            }
            cbohouse.Items.Clear();
            cboclient.Items.Clear();
            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboclient.Items.Add(myRow["AgentName"]);
                cbohouse.Items.Add(myRow["AgentName"]);
            }
        }

        private void bcancel_Click(object sender, EventArgs e)
        {
            DisplayDataRow2Txt3();
            tNumber.Enabled = true;
            ActivateButtons(true, true, true, false, false, true);
        }

        private void bsave_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
            if (mode == "addagent")
            {
                currentRow = tabAgents.NewRow();
                foreach(DataRow myrow in tabAgents.Rows)
                {
                    if(myrow["AgentNo"].ToString()==tNumber.Text)
                    {
                        MessageBox.Show("Agent No already exist!", "Exist");
                        tNumber.Clear();
                        tNumber.Focus();
                        return;
                    }
                }
                currentRow["AgentNo"] = tNumber.Text;
                currentRow["AgentName"] = tName.Text;
                currentRow["AgentMail"] = tmail.Text;
                currentRow["Pin"] = tpin.Text;

                tabAgents.Rows.Add(currentRow);
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpAgent);
                Clsglobal.adpAgent.Update(Clsglobal.mySet, "Agents");
               Clsglobal.mySet.Tables.Remove("Agents");
                Clsglobal.adpAgent.Fill(Clsglobal.mySet, "Agents");
                currentIndx3 = tabAgents.Rows.Count - 1;
            }
            else if (mode == "editagent")
            {
                currentRow = tabAgents.Rows[currentIndx3];
                currentRow["AgentName"] = tName.Text;
                currentRow["AgentMail"] = tmail.Text;
                currentRow["Pin"] = tpin.Text;
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(Clsglobal.adpAgent);
               Clsglobal.adpAgent.Update(Clsglobal.mySet, "Agents");
               Clsglobal.mySet.Tables.Remove("Agents");
               Clsglobal.adpAgent.Fill(Clsglobal.mySet, "Agents");
                tNumber.Enabled = true;
            }
            mode = "";
            DisplayDataRow2Txt3();
            ActivateButtons(true, true, true, false, false, true);
            cbohouse.Items.Clear();
            cboclient.Items.Clear();
            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboclient.Items.Add(myRow["AgentName"]);
                cbohouse.Items.Add(myRow["AgentName"]);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

namespace Remax
{
    partial class FrmUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchHouse = new System.Windows.Forms.Button();
            this.txtrefnoHouse = new System.Windows.Forms.TextBox();
            this.radAllHouse = new System.Windows.Forms.RadioButton();
            this.radoneHouse = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchAgent = new System.Windows.Forms.Button();
            this.txtRefNoAgent = new System.Windows.Forms.TextBox();
            this.radAllAgent = new System.Windows.Forms.RadioButton();
            this.radoneAgent = new System.Windows.Forms.RadioButton();
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchHouse);
            this.groupBox1.Controls.Add(this.txtrefnoHouse);
            this.groupBox1.Controls.Add(this.radAllHouse);
            this.groupBox1.Controls.Add(this.radoneHouse);
            this.groupBox1.Location = new System.Drawing.Point(105, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Houses";
            // 
            // btnSearchHouse
            // 
            this.btnSearchHouse.Location = new System.Drawing.Point(445, 21);
            this.btnSearchHouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchHouse.Name = "btnSearchHouse";
            this.btnSearchHouse.Size = new System.Drawing.Size(117, 55);
            this.btnSearchHouse.TabIndex = 11;
            this.btnSearchHouse.Text = "Search House";
            this.btnSearchHouse.UseVisualStyleBackColor = true;
            this.btnSearchHouse.Click += new System.EventHandler(this.btnSearchHouse_Click);
            // 
            // txtrefnoHouse
            // 
            this.txtrefnoHouse.Location = new System.Drawing.Point(248, 24);
            this.txtrefnoHouse.Name = "txtrefnoHouse";
            this.txtrefnoHouse.Size = new System.Drawing.Size(149, 22);
            this.txtrefnoHouse.TabIndex = 10;
            // 
            // radAllHouse
            // 
            this.radAllHouse.AutoSize = true;
            this.radAllHouse.Location = new System.Drawing.Point(37, 55);
            this.radAllHouse.Margin = new System.Windows.Forms.Padding(4);
            this.radAllHouse.Name = "radAllHouse";
            this.radAllHouse.Size = new System.Drawing.Size(93, 21);
            this.radAllHouse.TabIndex = 9;
            this.radAllHouse.Text = "Search All";
            this.radAllHouse.UseVisualStyleBackColor = true;
            // 
            // radoneHouse
            // 
            this.radoneHouse.AutoSize = true;
            this.radoneHouse.Location = new System.Drawing.Point(37, 24);
            this.radoneHouse.Margin = new System.Windows.Forms.Padding(4);
            this.radoneHouse.Name = "radoneHouse";
            this.radoneHouse.Size = new System.Drawing.Size(204, 21);
            this.radoneHouse.TabIndex = 8;
            this.radoneHouse.Text = "Search One by Ref Number";
            this.radoneHouse.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Houses And Agents";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchAgent);
            this.groupBox2.Controls.Add(this.txtRefNoAgent);
            this.groupBox2.Controls.Add(this.radAllAgent);
            this.groupBox2.Controls.Add(this.radoneAgent);
            this.groupBox2.Location = new System.Drawing.Point(105, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Agents";
            // 
            // btnSearchAgent
            // 
            this.btnSearchAgent.Location = new System.Drawing.Point(445, 21);
            this.btnSearchAgent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchAgent.Name = "btnSearchAgent";
            this.btnSearchAgent.Size = new System.Drawing.Size(117, 55);
            this.btnSearchAgent.TabIndex = 11;
            this.btnSearchAgent.Text = "Search Agent";
            this.btnSearchAgent.UseVisualStyleBackColor = true;
            this.btnSearchAgent.Click += new System.EventHandler(this.btnSearchAgent_Click);
            // 
            // txtRefNoAgent
            // 
            this.txtRefNoAgent.Location = new System.Drawing.Point(248, 24);
            this.txtRefNoAgent.Name = "txtRefNoAgent";
            this.txtRefNoAgent.Size = new System.Drawing.Size(149, 22);
            this.txtRefNoAgent.TabIndex = 10;
            // 
            // radAllAgent
            // 
            this.radAllAgent.AutoSize = true;
            this.radAllAgent.Location = new System.Drawing.Point(37, 55);
            this.radAllAgent.Margin = new System.Windows.Forms.Padding(4);
            this.radAllAgent.Name = "radAllAgent";
            this.radAllAgent.Size = new System.Drawing.Size(93, 21);
            this.radAllAgent.TabIndex = 9;
            this.radAllAgent.Text = "Search All";
            this.radAllAgent.UseVisualStyleBackColor = true;
            // 
            // radoneAgent
            // 
            this.radoneAgent.AutoSize = true;
            this.radoneAgent.Location = new System.Drawing.Point(37, 24);
            this.radoneAgent.Margin = new System.Windows.Forms.Padding(4);
            this.radoneAgent.Name = "radoneAgent";
            this.radoneAgent.Size = new System.Drawing.Size(204, 21);
            this.radoneAgent.TabIndex = 8;
            this.radoneAgent.Text = "Search One by Ref Number";
            this.radoneAgent.UseVisualStyleBackColor = true;
//            this.radoneAgent.CheckedChanged += new System.EventHandler(this.radoneAgent_CheckedChanged);
            // 
            // gridSearch
            // 
            this.gridSearch.AllowUserToAddRows = false;
            this.gridSearch.AllowUserToDeleteRows = false;
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Location = new System.Drawing.Point(13, 275);
            this.gridSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.ReadOnly = true;
            this.gridSearch.RowHeadersWidth = 51;
            this.gridSearch.Size = new System.Drawing.Size(774, 244);
            this.gridSearch.TabIndex = 13;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.gridSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Houses";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchHouse;
        private System.Windows.Forms.TextBox txtrefnoHouse;
        private System.Windows.Forms.RadioButton radAllHouse;
        private System.Windows.Forms.RadioButton radoneHouse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchAgent;
        private System.Windows.Forms.TextBox txtRefNoAgent;
        private System.Windows.Forms.RadioButton radAllAgent;
        private System.Windows.Forms.RadioButton radoneAgent;
        private System.Windows.Forms.DataGridView gridSearch;
    }
}
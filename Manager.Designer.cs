namespace JustRipe2018
{
    partial class Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.tabManager = new System.Windows.Forms.TabControl();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabTimeTable = new System.Windows.Forms.TabPage();
            this.tabJob = new System.Windows.Forms.TabPage();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.Store = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabStoreOpt = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbCropAmount = new System.Windows.Forms.ComboBox();
            this.cbCropType = new System.Windows.Forms.ComboBox();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.txtContactNum = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.btnBuyer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBuyers = new System.Windows.Forms.Button();
            this.btnViewBuyers = new System.Windows.Forms.Button();
            this.btnViewStock = new System.Windows.Forms.Button();
            this.tabManager.SuspendLayout();
            this.Store.SuspendLayout();
            this.tabStoreOpt.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabManager
            // 
            this.tabManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabManager.Controls.Add(this.tabReport);
            this.tabManager.Controls.Add(this.tabTimeTable);
            this.tabManager.Controls.Add(this.tabJob);
            this.tabManager.Controls.Add(this.tabUser);
            this.tabManager.Controls.Add(this.Store);
            this.tabManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManager.Location = new System.Drawing.Point(1, 26);
            this.tabManager.Name = "tabManager";
            this.tabManager.SelectedIndex = 0;
            this.tabManager.Size = new System.Drawing.Size(1451, 1320);
            this.tabManager.TabIndex = 0;
            // 
            // tabReport
            // 
            this.tabReport.BackColor = System.Drawing.Color.Tan;
            this.tabReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabReport.BackgroundImage")));
            this.tabReport.Location = new System.Drawing.Point(8, 51);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1435, 1261);
            this.tabReport.TabIndex = 0;
            this.tabReport.Text = "Report";
            // 
            // tabTimeTable
            // 
            this.tabTimeTable.BackColor = System.Drawing.Color.Tan;
            this.tabTimeTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabTimeTable.BackgroundImage")));
            this.tabTimeTable.Location = new System.Drawing.Point(8, 51);
            this.tabTimeTable.Name = "tabTimeTable";
            this.tabTimeTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimeTable.Size = new System.Drawing.Size(1435, 1261);
            this.tabTimeTable.TabIndex = 1;
            this.tabTimeTable.Text = "Time table";
            // 
            // tabJob
            // 
            this.tabJob.BackColor = System.Drawing.Color.Tan;
            this.tabJob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabJob.BackgroundImage")));
            this.tabJob.Location = new System.Drawing.Point(8, 51);
            this.tabJob.Name = "tabJob";
            this.tabJob.Padding = new System.Windows.Forms.Padding(3);
            this.tabJob.Size = new System.Drawing.Size(1435, 1261);
            this.tabJob.TabIndex = 2;
            this.tabJob.Text = "Manage Job";
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.Tan;
            this.tabUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabUser.BackgroundImage")));
            this.tabUser.Location = new System.Drawing.Point(8, 51);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(1435, 1261);
            this.tabUser.TabIndex = 3;
            this.tabUser.Text = "Manage User";
            // 
            // Store
            // 
            this.Store.BackColor = System.Drawing.Color.Tan;
            this.Store.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Store.BackgroundImage")));
            this.Store.Controls.Add(this.textBox1);
            this.Store.Controls.Add(this.tabStoreOpt);
            this.Store.Controls.Add(this.btnAddBuyers);
            this.Store.Controls.Add(this.btnViewBuyers);
            this.Store.Controls.Add(this.btnViewStock);
            this.Store.Location = new System.Drawing.Point(8, 51);
            this.Store.Name = "Store";
            this.Store.Padding = new System.Windows.Forms.Padding(3);
            this.Store.Size = new System.Drawing.Size(1435, 1261);
            this.Store.TabIndex = 4;
            this.Store.Text = "Store";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tan;
            this.textBox1.Location = new System.Drawing.Point(280, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1159, 60);
            this.textBox1.TabIndex = 9;
            // 
            // tabStoreOpt
            // 
            this.tabStoreOpt.Controls.Add(this.tabPage1);
            this.tabStoreOpt.Controls.Add(this.tabPage2);
            this.tabStoreOpt.Location = new System.Drawing.Point(280, 46);
            this.tabStoreOpt.Name = "tabStoreOpt";
            this.tabStoreOpt.SelectedIndex = 0;
            this.tabStoreOpt.Size = new System.Drawing.Size(1159, 1065);
            this.tabStoreOpt.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(8, 51);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1143, 1006);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stock/Buyers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Tan;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Tan;
            this.dataGridView1.Location = new System.Drawing.Point(-8, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1232, 993);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Tan;
            this.tabPage2.Controls.Add(this.cbCropAmount);
            this.tabPage2.Controls.Add(this.cbCropType);
            this.tabPage2.Controls.Add(this.txtUserEmail);
            this.tabPage2.Controls.Add(this.txtContactNum);
            this.tabPage2.Controls.Add(this.txtSurname);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnCancelUser);
            this.tabPage2.Controls.Add(this.btnBuyer);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(8, 51);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1143, 1006);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add User";
            // 
            // cbCropAmount
            // 
            this.cbCropAmount.FormattingEnabled = true;
            this.cbCropAmount.Location = new System.Drawing.Point(236, 305);
            this.cbCropAmount.Name = "cbCropAmount";
            this.cbCropAmount.Size = new System.Drawing.Size(340, 45);
            this.cbCropAmount.TabIndex = 15;
            // 
            // cbCropType
            // 
            this.cbCropType.FormattingEnabled = true;
            this.cbCropType.Location = new System.Drawing.Point(236, 247);
            this.cbCropType.Name = "cbCropType";
            this.cbCropType.Size = new System.Drawing.Size(340, 45);
            this.cbCropType.TabIndex = 14;
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(679, 170);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(458, 44);
            this.txtUserEmail.TabIndex = 13;
            // 
            // txtContactNum
            // 
            this.txtContactNum.Location = new System.Drawing.Point(797, 108);
            this.txtContactNum.Name = "txtContactNum";
            this.txtContactNum.Size = new System.Drawing.Size(340, 44);
            this.txtContactNum.TabIndex = 12;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(196, 170);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(340, 44);
            this.txtSurname.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(196, 105);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(340, 44);
            this.txtName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(542, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 37);
            this.label5.TabIndex = 7;
            this.label5.Text = "Contact Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email:";
            // 
            // btnCancelUser
            // 
            this.btnCancelUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelUser.Location = new System.Drawing.Point(610, 427);
            this.btnCancelUser.Name = "btnCancelUser";
            this.btnCancelUser.Size = new System.Drawing.Size(243, 79);
            this.btnCancelUser.TabIndex = 5;
            this.btnCancelUser.Text = "Cancel";
            this.btnCancelUser.UseVisualStyleBackColor = false;
            this.btnCancelUser.Click += new System.EventHandler(this.btnCancelUser_Click_1);
            // 
            // btnBuyer
            // 
            this.btnBuyer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyer.Location = new System.Drawing.Point(309, 427);
            this.btnBuyer.Name = "btnBuyer";
            this.btnBuyer.Size = new System.Drawing.Size(243, 79);
            this.btnBuyer.TabIndex = 4;
            this.btnBuyer.Text = "Save Buyer";
            this.btnBuyer.UseVisualStyleBackColor = false;
            this.btnBuyer.Click += new System.EventHandler(this.btnBuyer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Crops Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Crops Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Surname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // btnAddBuyers
            // 
            this.btnAddBuyers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddBuyers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBuyers.Location = new System.Drawing.Point(20, 525);
            this.btnAddBuyers.Name = "btnAddBuyers";
            this.btnAddBuyers.Size = new System.Drawing.Size(241, 149);
            this.btnAddBuyers.TabIndex = 7;
            this.btnAddBuyers.Text = "Add Buyers";
            this.btnAddBuyers.UseVisualStyleBackColor = false;
            this.btnAddBuyers.Click += new System.EventHandler(this.btnAddBuyers_Click_1);
            // 
            // btnViewBuyers
            // 
            this.btnViewBuyers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewBuyers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBuyers.Location = new System.Drawing.Point(20, 327);
            this.btnViewBuyers.Name = "btnViewBuyers";
            this.btnViewBuyers.Size = new System.Drawing.Size(241, 149);
            this.btnViewBuyers.TabIndex = 6;
            this.btnViewBuyers.Text = "View Buyers";
            this.btnViewBuyers.UseVisualStyleBackColor = false;
            this.btnViewBuyers.Click += new System.EventHandler(this.btnViewBuyers_Click_1);
            // 
            // btnViewStock
            // 
            this.btnViewStock.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStock.Location = new System.Drawing.Point(20, 129);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(241, 149);
            this.btnViewStock.TabIndex = 5;
            this.btnViewStock.Text = "View Stock";
            this.btnViewStock.UseVisualStyleBackColor = false;
            this.btnViewStock.Click += new System.EventHandler(this.btnViewStock_Click_1);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1728, 1182);
            this.Controls.Add(this.tabManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.tabManager.ResumeLayout(false);
            this.Store.ResumeLayout(false);
            this.Store.PerformLayout();
            this.tabStoreOpt.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabManager;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabTimeTable;
        private System.Windows.Forms.TabPage tabJob;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage Store;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabStoreOpt;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbCropAmount;
        private System.Windows.Forms.ComboBox cbCropType;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.TextBox txtContactNum;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelUser;
        private System.Windows.Forms.Button btnBuyer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBuyers;
        private System.Windows.Forms.Button btnViewBuyers;
        private System.Windows.Forms.Button btnViewStock;
    }
}
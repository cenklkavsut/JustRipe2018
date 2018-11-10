using System;
using System.Drawing;
using System.Windows.Forms;


namespace JustRipe2018
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            //Helps to keep the form maximized.
            //WindowState = FormWindowState.Maximized;
            Login page = new Login();
            page.Close();
            //Helps to maximize tab 
            //tabManager.SizeMode = TabSizeMode.Fixed;
            //tabManager.ItemSize = new Size(tabManager.Width / tabManager.TabCount, 0);

            //Hides tabs of inner window for Manage Users tab.
            tabUserCntrl.Appearance = TabAppearance.FlatButtons;
            tabUserCntrl.ItemSize = new Size(0, 1);
            tabUserCntrl.SizeMode = TabSizeMode.Fixed;
            //Hides the tabs on the Manage Job Page.
            formManageJob.Appearance =
            TabAppearance.FlatButtons;
            formManageJob.ItemSize = new Size(0, 1);
            formManageJob.SizeMode = TabSizeMode.Fixed;
            //Hides the tabs on the Reports page.
            tabReportOpt.Appearance = TabAppearance.FlatButtons;
            tabReportOpt.ItemSize = new Size(0, 1);
            tabReportOpt.SizeMode = TabSizeMode.Fixed;

            //add an event to close the 1st form When shut down!
            tabStoreOpt.Appearance = TabAppearance.FlatButtons;
            tabStoreOpt.ItemSize = new Size(0, 1);
            tabStoreOpt.SizeMode = TabSizeMode.Fixed;
        }

        private void btnAddBuyers_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            //Allows To Clean text in the text box and dropdowns.
            txtName.Text = "";
            txtSurname.Text = "";
            txtContactNum.Text = "";
            txtUserEmail.Text = "";
            cbCropAmount.Text = "";
            cbCropType.Text = "";
        }

        private void btnAddBuyers_Click_1(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabStoreOpt.TabCount;
            for (int i = 0; i < tabStoreOpt.RowCount; i++)
            {
                tabStoreOpt.SelectTab(1);
                //implementation

            }
        }

        private void btnViewBuyers_Click_1(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabStoreOpt.TabCount;
            for (int i = 0; i < tabStoreOpt.RowCount; i++)
            {
                tabStoreOpt.SelectTab(0);
                //implementation

            }
        }

        private void btnViewStock_Click_1(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabStoreOpt.TabCount;
            for (int i = 0; i < tabStoreOpt.RowCount; i++)
            {
                tabStoreOpt.SelectTab(0);
                //implementation

            }
        }

        private void btnBuyer_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelUser_Click_1(object sender, EventArgs e)
        {
            //Allows To Clean text in the text box and dropdowns.
            txtName.Text = "";
            txtSurname.Text = "";
            txtContactNum.Text = "";
            txtUserEmail.Text = "";
            cbCropAmount.Text = "";
            cbCropType.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabUserCntrl.TabCount;
            for (int i = 0; i < tabUserCntrl.RowCount; i++)
            {
                tabUserCntrl.SelectTab(1);
                //implementation
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateUsr_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabUserCntrl.TabCount;
            for (int i = 0; i < tabUserCntrl.RowCount; i++)
            {
                tabUserCntrl.SelectTab(0);
                //implementation

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResetCreate_Click(object sender, EventArgs e)
        {
            //Allows To Clean text in the text box and checkboxes.
            txtFNUsrCreate.Text = "";
            txtLNUsrCreate.Text = "";
            txtUsrnameCreate.Text = "";
            txtPsswrdCreate.Text = "";
            chkbxLaborCreate.Checked = false;
            chkbxManagerCreate.Checked = false;
        }

        private void btnResetEdit_Click(object sender, EventArgs e)
        {
            //Allows To Clean text in the text box, dropdowns and checkboxes.
            txtFNUsrEdit.Text = "";
            txtLNUsrEdit.Text = "";
            txtUsrnameEdit.Text = "";
            txtPsswrdEdit.Text = "";
            drpdwnSelectUsr.Text = "";
            chkbxLaborEdit.Checked = false;
            chkbxManagerEdit.Checked = false;
        }

        private void tabUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJobCancel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJob_Click_1(object sender, EventArgs e)
        {
            //Tab Selection
            int Tabcount = formManageJob.TabCount;
            for (int count = 0; count < formManageJob.RowCount; count++)
            {
                //Change Tab
                formManageJob.SelectTab(0);
            }
        }

        private void btnEditJob_Click(object sender, EventArgs e)
        {
            //Tab Selection
            int Tabcount = formManageJob.TabCount;
            for (int count = 0; count < formManageJob.RowCount; count++)
            {
                //Changes the Tab
                formManageJob.SelectTab(1);
            }
        }

        private void btnAddJobSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJobCancel_Click_1(object sender, EventArgs e)
        {
            //Clears the Job Text Boxes
            cbJCrop.Text = "";
            cbJLabouer.Text = "";
            Cbjamount.Text = "";
            addJobType.Text = "";
            
        }

        private void btnEditJobSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteJobSave_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbJDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRep1_Click(object sender, EventArgs e)
        {

            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(0);
                //implementation

            }
        }

        private void btnRep2_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(1);
                //implementation

            }
        }

        private void btnRep3_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(2);
                //implementation

            }
        }

        private void btnRep4_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(3);
                //implementation

            }
        }

        private void btnRep5_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(4);
                //implementation

            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void txtUsrnameEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLNUsrCreate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
       
        }

        private void btnLogoutTime_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void btnLogoutMJ_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void btnLogoutMU_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void btnLogoutStore_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void addJobType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabDeleteJob_Click(object sender, EventArgs e)
        {

        }
    }
}

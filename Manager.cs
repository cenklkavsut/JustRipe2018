using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace JustRipe2018
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            fillcomboCropType();
            fillcomboJobType();
            fillcomboLabourer();
        }
        private static string mdfPath = Path.Combine(Application.StartupPath, "JustRipeDatabase.mdf");
        //private string connectionStr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JustRipeDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        //private string connectionStr = Properties.Settings.Default.connectionToDB;

        //var select = "SELECT DISTINCT [Crop_Name] FROM [dbo].[Crop]";//sql query to be executed
        //var ds2 = dbDropDown.dataToCb(select);//the data to be selected
        //cbCropType.DropDownStyle = ComboBoxStyle.DropDownList;//makes it a list
        //    cbCropType.Enabled = true;//enables the dropdown.
        //    cbCropType.SelectedIndex = -1;//allows to select the value from empty.
        //    for (int i = 0; i<ds2.Tables[0].Rows.Count; i++)//a loop that inputs values based on the row.
        //    {
        //        cbCropType.Items.Add(ds2.Tables[0].Rows[i][0]); }


        void fillcomboCropType()
        {
            cbJCrop.Items.Clear();
            DatabaseClass Connect = DatabaseClass.Instance;
            string queryCropsSelect = "Select * From [dbo].[Crop]";
            DataSet DropDownCrop = Connect.dataToCb(queryCropsSelect);
            cbJCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJCrop.Enabled = true;
            cbJCrop.SelectedIndex = -1;
            for (int i = 0; i < DropDownCrop.Tables[0].Rows.Count; i++)
            {
                cbJCrop.Items.Add(DropDownCrop.Tables[0].Rows[i][1].ToString());
            }
        }
        void fillcomboJobType()
        {
            addJobType.Items.Clear();
            DatabaseClass Connect = DatabaseClass.Instance;
            string queryJobsTypeSelect = "Select * From [dbo].[JobType]";
            DataSet DropDownJob = Connect.dataToCb(queryJobsTypeSelect);
            addJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            addJobType.Enabled = true;
            addJobType.SelectedIndex = -1;
            for (int i = 0; i < DropDownJob.Tables[0].Rows.Count; i++)
            {
                addJobType.Items.Add(DropDownJob.Tables[0].Rows[i][1].ToString());
            }

        }
        void fillcomboLabourer()
        {
            cbJLabouer.Items.Clear();
            DatabaseClass Connect = DatabaseClass.Instance;
            string queryLabourerSelect = "SELECT * From [dbo].[users] WHERE [Role] = 'Labourer' ";
            DataSet DropDownLabourer = Connect.dataToCb(queryLabourerSelect);
            cbJLabouer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJLabouer.Enabled = true;
            cbJLabouer.SelectedIndex = -1;
            for (int i = 0; i < DropDownLabourer.Tables[0].Rows.Count; i++)
            {
                cbJLabouer.Items.Add(DropDownLabourer.Tables[0].Rows[i][3].ToString());
            }
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
            //DatabaseClass dbDropDown = new DatabaseClass(ConnectionStrDB);
            //var select = "SELECT [Crop_Name] FROM [dbo].[Crop]";
            //var ds2 = dbDropDown.dataToCb(select);
            //cbCropType.ValueMember = select;
            //cbCropType.DataSource = ds2.Tables[select];
            //cbCropType.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbCropType.Enabled = true;

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
            //change the query based on the buyers

            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Select * From [dbo].[Orders]";
            var ds = dbCon.getDataSet(select);
            dataGridAddStore.ReadOnly = true;
            dataGridAddStore.DataSource = ds.Tables[0];
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

            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Select * From [dbo].[CropsStorage]";
            var ds = dbCon.getDataSet(select);
            dataGridAddStore.ReadOnly = true;
            dataGridAddStore.DataSource = ds.Tables[0];
        }

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            if (txtName.Text == null || txtName.Text == "" || txtSurname.Text == null || txtSurname.Text == "" ||
                            txtContactNum.Text == null || txtContactNum.Text == "" || txtUserEmail.Text == null || txtUserEmail.Text == "" ||
                            cbCropAmount.Text == null || cbCropAmount.Text == "")
            {
                MessageBox.Show("No value entered!");
            }
            else
            {
                DatabaseClass dataB = DatabaseClass.Instance;//class and confirms the connection string.
                dataB.AdderOfStore(txtName.Text, txtSurname.Text, txtContactNum.Text, txtUserEmail.Text,
                double.Parse(cbCropAmount.Text)/*, cbCropType.Text*/); //input that info to the database.
                MessageBox.Show("Customer Saved!");//the result if no error.                                            
            }
            //Allows To Clean text in the text box and dropdowns after finished.
            txtName.Text = "";
            txtSurname.Text = "";
            txtContactNum.Text = "";
            txtUserEmail.Text = "";
            cbCropAmount.Text = "";
            cbCropType.Text = "";
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



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //prevents Labourer check box from being selected if Manager is checked
            if (chkbxLaborCreate.Checked == true)
            {
                chkbxManagerCreate.Enabled = false;
            }
            else if (chkbxLaborCreate.Checked == false)
            {
                chkbxManagerCreate.Enabled = true;
            }

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
            // Data Containers
            string cropContainer;
            string labourerContainer;
            string dateContainer;
            string jobTypeContainer;
            string amountContainer;
            // Valid Data Container for uncontrolled Variables
            DateTime validDateContainer;
            int validAmountContainer;

            // Ifnest to Check for blank/null Entry
            if (cbJCrop.Text == "" || cbJCrop.Text == null)
            {
                MessageBox.Show("Please Select a Crop Type");
            }
            else if (cbJLabouer.Text == "" || cbJLabouer.Text == null)
            {
                MessageBox.Show("Please Select a Labourer");
            }
            else if (cbJDate.Text == "" || cbJDate.Text == null)
            {
                MessageBox.Show("Please Enter a Date");
            }
            else if (addJobType.Text == "" || addJobType.Text == null)
            {
                MessageBox.Show("Please Select a Job Type");
            }
            else if (Cbjamount.Text == "" || Cbjamount.Text == null)
            {
                MessageBox.Show("Please Enter a Valid Crop Amount");
            }
            else
            {
                // Saving User Input In Variables
                cropContainer = cbJCrop.SelectedText;
                labourerContainer = cbJLabouer.SelectedText;
                dateContainer = cbJDate.Text;
                jobTypeContainer = addJobType.SelectedText;
                amountContainer = Cbjamount.SelectedText;
                // Date Validation + Conversion to Date
                //Checks that Date is of valid format 
                DateTime dateContainerTest;
                string date;
                DateTime.TryParse(dateContainer, out dateContainerTest);

                if (dateContainerTest.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString() ||
                    dateContainerTest.DayOfWeek.ToString() == DayOfWeek.Sunday.ToString())
                {
                    MessageBox.Show("No Work On Weekends!");
                    return;

                }
                //Checks date is greater than todays date
                if (dateContainerTest < DateTime.Now.Date)
                {
                    MessageBox.Show("Date entered is less than the current date");
                    cbJDate.Text = "";
                    dateContainer = null;
                    validDateContainer = DateTime.Now;
                    return;
                }
                else
                {

                    date = dateContainerTest.ToShortDateString();
                }
                // Amount Valdation +Conversion to Int
                if (int.TryParse(Cbjamount.Text, out validAmountContainer))
                {
                    // Int is Valid
                }
                else
                {
                    MessageBox.Show("Amount Entered is not a whole number");
                    cbCropAmount.Text = "";
                    amountContainer = "";
                    return;
                }

                DatabaseClass Data = DatabaseClass.Instance;
                Data.GetDate = date;
                Data.GetIDCrop = cbJCrop.SelectedItem.ToString();
                Data.GetIDJobType = addJobType.SelectedItem.ToString();
                Data.GetIDUser = cbJLabouer.SelectedItem.ToString();
                Data.Addjob(cbJLabouer.Text, cbJCrop.Text, date, validAmountContainer, addJobType.Text, 1);
                MessageBox.Show("Saved Job");
              
                // Harvest Date Autoset (30Days) from Sowing! 
                // Harvest Amount = Sowing Amount 
                // Amount set to NULL if Fertlise or Special 
                // Fertalizer Tab 
                // Pulls Job List
                //Add Job name Autoset Crop+DatetoString() 








            }


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

        private void chkbxManagerCreate_CheckedChanged(object sender, EventArgs e)
        {
            //prevents Manager check box from being selected if Labourer is checked
            if (chkbxManagerCreate.Checked == true)
            {
                chkbxLaborCreate.Enabled = false;

            }
            else if (chkbxManagerCreate.Checked == false)
            {
                chkbxLaborCreate.Enabled = true;

            }

        }

        private void chkbxLaborEdit_CheckedChanged(object sender, EventArgs e)
        {
            //prevents Labourer check box from being selected if Manager is checked
            if (chkbxLaborEdit.Checked == true)
            {
                chkbxManagerEdit.Enabled = false;

            }
            else if (chkbxLaborEdit.Checked == false)
            {
                chkbxManagerEdit.Enabled = true;

            }

        }

        private void chkbxManagerEdit_CheckedChanged(object sender, EventArgs e)
        {
            //prevents Manager check box from being selected if Labourer is checked
            if (chkbxManagerEdit.Checked == true)
            {
                chkbxLaborEdit.Enabled = false;

            }
            else if (chkbxManagerEdit.Checked == false)
            {
                chkbxLaborEdit.Enabled = true;
            }

        }

        private void dataGridAddStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //www.dreamincode.net/forums/topic/235102-restricting-datetimepickermonthcalendar-to-specific-days/
            var DateSeleciton = sender as DateTimePicker;
            var SelectedDate = DateSeleciton.Value;

            if (SelectedDate.DayOfWeek != DayOfWeek.Monday)
            {
                var set = (int)DayOfWeek.Monday - (int)SelectedDate.DayOfWeek;
                var Monday = SelectedDate + TimeSpan.FromDays(set);
                DateSeleciton.Value = Monday;
               
            }
            var Selectedval = SelectedDate;
        }           
            
        

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabTimeTable_Click(object sender, EventArgs e)
        {

        }

      

        private void cbDayofWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnMWednesday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Wednesday = Date.AddDays(2);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetWednesday = "SELECT [Crop_Name],[JobName],[FirstName],[Last Name] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Wednesday.ToShortDateString() + "'";
            DataSet Wednesdaydata = Connect.getDataSet(GetWednesday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Wednesdaydata.Tables[0];

        }

        private void btnMTuesday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Tuesday = Date.AddDays(1);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetTuesday = "SELECT [Crop_Name],[JobName],[FirstName],[Last Name] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Tuesday.ToShortDateString() + "'";
            DataSet Tuesdaydata = Connect.getDataSet(GetTuesday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource =Tuesdaydata.Tables[0]; ;
        }

        private void btnMMonday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Monday = Date;
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetMonday = "SELECT [Crop_Name],[JobName],[FirstName],[Last Name] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Monday.ToShortDateString() + "'";
            DataSet Mondaydata = Connect.getDataSet(GetMonday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Mondaydata.Tables[0]; ;
        }

        private void btnMThursday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Thursday = Date.AddDays(3);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetThursday = "SELECT [Crop_Name],[JobName],[FirstName],[Last Name] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Thursday.ToShortDateString() + "'";
            DataSet Thursdaydata = Connect.getDataSet(GetThursday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Thursdaydata.Tables[0]; ;
        }

        private void btnMFriday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Friday = Date.AddDays(4);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetFriday = "SELECT [Crop_Name],[JobName],[FirstName],[Last Name] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Friday.ToShortDateString() + "'";
            DataSet Fridaydata = Connect.getDataSet(GetFriday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Fridaydata.Tables[0];
        }
    }           // "Select Crop_Name AS 'Crop Name',StorageName AS 'Storage Name' ,Capacity ,Temperature AS 'Temperature (°C)' From [dbo].[CropsStorage] " +
                //" JOIN Crop ON CropsStorage.CropID=Crop.CropID JOIN StorageType ON CropsStorage.StorageTypeId=StorageType.StorageTypeId "
}


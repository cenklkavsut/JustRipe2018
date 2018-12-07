using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;




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
            fillcomboFertalJobSelect();
            fillcomboDeleteJobSelect();
            Setdate();

        }
        
        string getcropfert;
        string getcropfertamount;
        int getamountfert;
        public string GetCropfertAmount { get { return getcropfertamount; } set { getcropfertamount = value; } }
        public string GetcropFert { get { return getcropfert; } set { getcropfert = value; } }
        public int GetamountFert { get { return getamountfert; } set { getamountfert = value; } }
        void Setdate()
        {
           
            var SelectedDate = DateTime.Now;

            if (SelectedDate.DayOfWeek != DayOfWeek.Monday)
            {
                var set = (int)DayOfWeek.Monday - (int)SelectedDate.DayOfWeek;
                var Monday = SelectedDate + TimeSpan.FromDays(set);
                SelectedDate = Monday;

            }
            var Selectedval = SelectedDate;
            dateTimePicker1.Value = Selectedval;
        }
    
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
            string queryJobsTypeSelect = "Select * From [dbo].[JobType] WHERE [JobName] = 'Sowing' OR [JobName] = 'Special' ";
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
            SelectLabourerFertalise.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJLabouer.Enabled = true;
            SelectLabourerFertalise.Enabled = true;
            cbJLabouer.SelectedIndex = -1;
            SelectLabourerFertalise.SelectedIndex = -1;
            for (int i = 0; i < DropDownLabourer.Tables[0].Rows.Count; i++)
            {
                cbJLabouer.Items.Add(DropDownLabourer.Tables[0].Rows[i][3].ToString());
                SelectLabourerFertalise.Items.Add(DropDownLabourer.Tables[0].Rows[i][3].ToString());
            }
        }
        void fillcomboFertalJobSelect()
        {
            SelectJobFert.Items.Clear();
            DatabaseClass Connect = DatabaseClass.Instance;
            string querySelectJobs = "SELECT [Job] FROM [dbo].[Job] WHERE [JobTypeID] = '1' ";
            DataSet DropdownFert = Connect.dataToCb(querySelectJobs);
            SelectJobFert.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectJobFert.Enabled = true;
            SelectJobFert.SelectedIndex = -1;
            for (int i = 0; i < DropdownFert.Tables[0].Rows.Count; i++)
            {

                SelectJobFert.Items.Add(DropdownFert.Tables[0].Rows[i][0].ToString());
            }
        }
        void fillcomboDeleteJobSelect()
        {
            cbJSelectJob.Items.Clear();
            DatabaseClass Connect = DatabaseClass.Instance;
            string querySelectJobs = "SELECT [Job] FROM [dbo].[Job]";
            DataSet DropdownDel = Connect.dataToCb(querySelectJobs);
            cbJSelectJob.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJSelectJob.Enabled = true;
            cbJSelectJob.SelectedIndex = -1;
            for (int i = 0; i < DropdownDel.Tables[0].Rows.Count; i++)
            {

                cbJSelectJob.Items.Add(DropdownDel.Tables[0].Rows[i][0].ToString());
            }
        }
        public string Getusernameedit;
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
            cbCropType.Items.Clear();//clears the items when starts.
            DatabaseClass dbDropDown = DatabaseClass.Instance;//takes info from the connection string
            var select = "SELECT DISTINCT [Crop_Name] FROM [dbo].[Crop]";//sql query to be executed
            var ds2 = dbDropDown.dataToCb(select);//the data to be selected
            cbCropType.DropDownStyle = ComboBoxStyle.DropDownList;//makes it a list
            cbCropType.Enabled = true;//enables the dropdown.
            cbCropType.SelectedIndex = -1;//allows to select the value from empty.   
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)//a loop that inputs values based on the row.
            {
                cbCropType.Items.Add(ds2.Tables[0].Rows[i][0]);
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
            } //change the query based on the buyers
            DatabaseClass dbCon = DatabaseClass.Instance;//id to fix the not name display issue due to logic.
            var select = "Select Amount,Crop_Name AS 'Crop Name',Customer.FirstName AS 'Customer Name',Customer.Surname AS 'Customer Surname' From [dbo].[Orders] "
                +"INNER JOIN Crop ON Orders.CropID=Crop.CropID"
                + " INNER JOIN Customer ON Orders.CustomerID=Customer.CustomerID;";
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
            }
        try
        {
                //requirment anylis error need to display name near that customer only fix displaying id.
                DatabaseClass dbCon = DatabaseClass.Instance;//3rth error not displaying customer name.
                var select = "Select Crop_Name AS 'Crop Name',StorageName AS 'Storage Name' ,Capacity ,Amount,Temperature AS 'Temperature (°C)' From [dbo].[CropsStorage] " +
                " JOIN Crop ON CropsStorage.CropID=Crop.CropID JOIN StorageType ON CropsStorage.StorageTypeId=StorageType.StorageTypeId ";
                var ds = dbCon.getDataSet(select);
                dataGridAddStore.ReadOnly = true;
                dataGridAddStore.DataSource = ds.Tables[0];
            try
            {
                dbCon.getVal();//it gives a error when their are no available dates

            }
            catch (Exception)
            {
                MessageBox.Show(" No stocks currently available!");
            }
        }
        catch (Exception)
        {
                MessageBox.Show("Wrong input value try again!");
        }
}

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                double CropAmountCheck = double.Parse(cbCropAmount.Text.ToString());//allows for checking the crop amount 
                if (cbCropAmount.Text == "-" || CropAmountCheck < 0)//if the amount is negative give message.
                {
                    MessageBox.Show("Wrong value entered!");
                    cbCropAmount.Text = "";

                }
                else if (txtName.Text == null || txtName.Text == "" || txtSurname.Text == null || txtSurname.Text == "" ||
                            txtContactNum.Text == null || txtContactNum.Text == "" || txtUserEmail.Text == null || txtUserEmail.Text == "" ||
                            cbCropAmount.Text == null || cbCropAmount.Text == "")
            {
                MessageBox.Show("No value entered!");
            } 
            else
            {
                DatabaseClass dataB =DatabaseClass.Instance;//class and confirms the connection string.
                dataB.GetID = cbCropType.SelectedItem.ToString();//this lets it add all values should limit the values.
                dataB.AdderOfStore(txtName.Text, txtSurname.Text, txtContactNum.Text, txtUserEmail.Text,
                double.Parse(cbCropAmount.Text), cbCropType.Text); //input that info to the database.
                MessageBox.Show("Customer Saved!");//the result if no error.                  
            } 
            }
            catch (Exception)
            {
                //MessageBox.Show("Wrong value entered!");
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
            ////Allows To Clean text in the text box and dropdowns.
            //txtName.Text = "";
            //txtSurname.Text = "";
            //txtContactNum.Text = "";
            //txtUserEmail.Text = "";
            //cbCropAmount.Text = "";
            //cbCropType.Text = "";
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

            //pulling the users names from the db to display in the drop down
            drpdwnSelectUsr.Items.Clear();//clears the items when starts.
            DatabaseClass dbDropDown = DatabaseClass.Instance;//takes info from the connection string
            var usrname = "SELECT [Username] FROM [dbo].[users]";//sql query to be executed
            var dataUser = dbDropDown.dataToCb(usrname);//the data to be selected
            drpdwnSelectUsr.DropDownStyle = ComboBoxStyle.DropDownList;//makes it a list
            drpdwnSelectUsr.Enabled = true;//enables the dropdown.
            drpdwnSelectUsr.SelectedIndex = -1;//allows to select the value from empty.   
            for (int i = 0; i < dataUser.Tables[0].Rows.Count; i++)//a loop that inputs values based on the row.
            {
                drpdwnSelectUsr.Items.Add(dataUser.Tables[0].Rows[i][0]);
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
            //declaring variables to be inputed
            string managerRole = "Manager";
            string labourerRole = "Labourer";

            //assinging values to checkboxes depending on which role they are
            if (chkbxLaborCreate.Checked)
            {
                chkbxLaborCreate.Text = labourerRole;
            }

            if (chkbxManagerCreate.Checked)
            {
                chkbxManagerCreate.Text = managerRole;
            }

            //determines if any fields are null and sends an error to the user
            if (txtFNUsrCreate.Text == null || txtFNUsrCreate.Text == "" || txtLNUsrCreate.Text == null || txtLNUsrCreate.Text == "" ||
                txtUsrnameCreate.Text == null || txtUsrnameCreate.Text == "" || txtPsswrdCreate.Text == null || txtPsswrdCreate.Text == "")

            {
                MessageBox.Show("Error! Empty Fields Detected!");
                return;
            }
            if (!chkbxLaborCreate.Checked && !chkbxManagerCreate.Checked)
            {
                MessageBox.Show("Error! Please Check a Role!");
                return;
            }

            //calls the database and checks to see if the created username matches any of the
            //existing usernames in the database
            DatabaseClass Connect = DatabaseClass.Instance;
            Connect.GetUserName = txtUsrnameCreate.Text;
            Connect.getUsrName();
            string newUsername = Connect.getUsrName();

            //checks the current username to see if there are any matches in the database
            if (txtUsrnameCreate.Text == newUsername)
            {
                MessageBox.Show("Username already in use! Please enter a new username.");
            }

            //if all boxes are filled, create user with different parameters based on which role is selected
            else
            {
                if (chkbxManagerCreate.Checked)
                {
                    DatabaseClass dataB = DatabaseClass.Instance;//class and confirms the connection string.
                    dataB.UserCreator(txtUsrnameCreate.Text, txtPsswrdCreate.Text, txtFNUsrCreate.Text, txtLNUsrCreate.Text, chkbxManagerCreate.Text); //input that info to the database.
                    MessageBox.Show("User Created!");//the result if no error.                                            
                }
                else
                {
                    DatabaseClass dataB = DatabaseClass.Instance;//class and confirms the connection string.
                    dataB.UserCreator(txtUsrnameCreate.Text, txtPsswrdCreate.Text, txtFNUsrCreate.Text, txtLNUsrCreate.Text, chkbxLaborCreate.Text); //input that info to the database.
                    MessageBox.Show("User Created!");//the result if no error.   
                }
            }
            //Allows To Clean text in the text box and dropdowns after user is created.
            txtFNUsrCreate.Text = "";
            txtLNUsrCreate.Text = "";
            txtUsrnameCreate.Text = "";
            txtPsswrdCreate.Text = "";
            chkbxLaborCreate.Checked = false;
            chkbxManagerCreate.Checked = false;
            fillcomboLabourer();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseClass Connect = DatabaseClass.Instance;
            Connect.getUserID();

            int valFromUsername = Connect.getUserID();

            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Delete From [dbo].[users] Where UserID='" + valFromUsername + "'";
            var ds = dbCon.getDataSet(select);

            //updating dropdown box with current users
            //pulling the users names from the db to display in the drop down
            drpdwnSelectUsr.Items.Clear();//clears the items when starts.
            DatabaseClass dbDropDown = DatabaseClass.Instance;//takes info from the connection string
            var usrname = "SELECT [Username] FROM [dbo].[users]";//sql query to be executed
            var dataUser = dbDropDown.dataToCb(usrname);//the data to be selected
            drpdwnSelectUsr.DropDownStyle = ComboBoxStyle.DropDownList;//makes it a list
            drpdwnSelectUsr.Enabled = true;//enables the dropdown.
            drpdwnSelectUsr.SelectedIndex = -1;//allows to select the value from empty.   
            for (int i = 0; i < dataUser.Tables[0].Rows.Count; i++)//a loop that inputs values based on the row.
            {
                drpdwnSelectUsr.Items.Add(dataUser.Tables[0].Rows[i][0]);
            }

            //clearing fields of data
            txtFNUsrEdit.Text = "";
            txtLNUsrEdit.Text = "";
            txtUsrnameEdit.Text = "";
            txtPsswrdEdit.Text = "";
            drpdwnSelectUsr.Text = "";
            chkbxLaborEdit.Checked = false;
            chkbxManagerEdit.Checked = false;

            //shows user that they are successful in removing another user
            MessageBox.Show("User Successfully Deleted!");
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pulls userID from the selected user in the database
            DatabaseClass Connect = DatabaseClass.Instance;
            Connect.GetUsrNameID = drpdwnSelectUsr.Text;

            int valFromUsername = Connect.getUserID();

            //display first name of selected user in text box
            var select = "Select [First Name] From [dbo].[users] Where UserID='" + valFromUsername + "'";
            var ds = Connect.getDataSet(select);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                txtFNUsrEdit.Text = ds.Tables[0].Rows[i]["First Name"].ToString();

            //display last name of selected user in text box
            var select1 = "Select [Last Name] From [dbo].[users] Where UserID='" + valFromUsername + "'";
            var ds1 = Connect.getDataSet(select1);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                txtLNUsrEdit.Text = ds1.Tables[0].Rows[i]["Last Name"].ToString();

            //display username of selected user in text box
            var select2 = "Select [Username] From [dbo].[users] Where UserID='" + valFromUsername + "'";
            var ds2 = Connect.getDataSet(select2);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string UsernameEdit = ds2.Tables[0].Rows[i]["Username"].ToString();
                Getusernameedit = UsernameEdit;
                txtUsrnameEdit.Text = UsernameEdit;
            }

            //SqlCommand selectRole = new SqlCommand("Select [Role] From [dbo].[users] Where UserID='" + valFromUsername + "'");
            var select3 = "Select [Role] From [dbo].[users] Where UserID='" + valFromUsername + "'";
            var ds3 = Connect.getDataSet(select3);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string Role = ds3.Tables[0].Rows[i]["Role"].ToString();

                if (Role == "Manager")
                {
                    chkbxManagerEdit.CheckState = CheckState.Checked;
                }

                if (Role == "Labourer")
                {
                    chkbxLaborEdit.CheckState = CheckState.Checked;
                }
            }
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
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(0);
                //implementation

            }

            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Select Crop_Name AS 'Crop Name', FertaliserAmountNeeded As 'Fertaliser Amount', CropStorageTemperature As 'Storage Temperature' From [dbo].[Job] JOIN Crop ON Job.CropID=Crop.CropID Where Date BETWEEN '"
                + DateTime.Now.ToShortDateString() +"' AND '"+ DateTime.Now.AddDays(35).ToShortDateString() +"' AND JobTypeID = '1'";
            var ds = dbCon.getDataSet(select);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
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

            DatabaseClass dbCon = DatabaseClass.Instance;
          
            var select = "Select FertilizerName AS 'Fertaliser Name' ,SUM(Job.amount) as 'Amount'  From [dbo].[Job] JOIN Crop ON Job.CropID=Crop.CropID JOIN Fertiliser ON Crop.FertiliserID=Fertiliser.FertiliserID WHERE Job.Date BETWEEN '"
                + DateTime.Now.ToShortDateString() + "' AND '" + DateTime.Now.AddDays(6).ToShortDateString() + "' AND JobTypeID = '4' GROUP BY FertilizerName";
            var ds = dbCon.getDataSet(select);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0]; //sum fertiliser of the week //join crop sum fertiliser amount needer//datetime +6
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

            DatabaseClass dbCon = DatabaseClass.Instance;
            //copy paste query
            var select = 
                "Select " +
                    "ST.StorageName AS 'Storage Type', " +
                    "C.Crop_Name AS 'Crop Name'," +
                    "ST.Capacity, " +
                    "CS.Amount AS 'Amount Stored', " +
                    "(ST.Capacity - CS.Amount) AS 'Amount Left'," +
                    "ST.Temperature AS 'Temperature (°C)' " +
                "From [dbo].[CropsStorage] CS " + 
                "JOIN StorageType ST ON CS.StorageTypeID=ST.StorageTypeID " + 
                "JOIN Crop C ON CS.CropID = C.CropID";
            var ds = dbCon.getDataSet(select);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];//only display used storage and how much.//sum - capacity amount as Total left storage and amount
        }//display storage type to table and display
       
        private void btnRep4_Click(object sender, EventArgs e)
        {
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(3);
                //implementation

            }
            DatabaseClass dbCon = DatabaseClass.Instance;
            //copy and paste query
            var select = "Select VehicleModel AS 'Vehicle Model' ,VehicleType AS 'Vehicle Type',VehicleRegistation AS 'Vehicle Registation'"
                + ",VehicleAvailability AS 'Vehicle Available' From [dbo].[Vehicle] Where VehicleID=2";
            var ds = dbCon.getDataSet(select);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];
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
                chkbxManagerEdit.Enabled=false ;
            } else if (chkbxLaborEdit.Checked == false)
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

            } else if (chkbxManagerEdit.Checked == false)
            {
                chkbxLaborEdit.Enabled = true;
            }
        }

        private void dataGridAddStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCropType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //declaring variables to be inputed
            string managerRole = "Manager";
            string labourerRole = "Labourer";

            //assinging values to checkboxes depending on which role they are
            if (chkbxLaborCreate.Checked)
            {
                chkbxLaborEdit.Text = labourerRole;
            }

            if (chkbxManagerEdit.Checked)
            {
                chkbxManagerEdit.Text = managerRole;
            }

            //determines if any fields are null and sends an error to the user
            if (txtFNUsrEdit.Text == null || txtFNUsrEdit.Text == "" || txtLNUsrEdit.Text == null || txtLNUsrEdit.Text == "" ||
                txtUsrnameEdit.Text == null || txtUsrnameEdit.Text == "" || txtPsswrdEdit.Text == "")
            {
                MessageBox.Show("Error! Empty Fields Detected!");
                return;
            }
            if (!chkbxLaborEdit.Checked && !chkbxManagerEdit.Checked)
            {
                MessageBox.Show("Error! Please Check a Role!");
                return;
            }
            if (txtPsswrdEdit.Text == null)
            {
                MessageBox.Show("Error! Please enter an existing password or create a new password!");
                return;
            }

            //calls the database and checks to see if the created username matches any of the
            //existing usernames in the database
            DatabaseClass Connect = DatabaseClass.Instance;
            Connect.GetUserName = txtUsrnameEdit.Text;
            string newUsername = Connect.getUsrName();

            Connect.GetUsrNameID = drpdwnSelectUsr.Text;
            int userID = Connect.getUserID();

            //checks the current username to see if there are any matches in the database
            if (txtUsrnameEdit.Text != Getusernameedit)
            {
                if (txtUsrnameEdit.Text == newUsername)
                {
                    MessageBox.Show("Username already in use! Please enter a new username.");
                    return;
                }


            } //if all boxes are filled, create user with different parameters based on which role is selected

            if (chkbxManagerEdit.Checked)
            {
                DatabaseClass dataB = DatabaseClass.Instance;//class and confirms the connection string.
                dataB.UserEditor(txtUsrnameEdit.Text, txtPsswrdEdit.Text, txtFNUsrEdit.Text, txtLNUsrEdit.Text, chkbxManagerEdit.Text, userID); //input that info to the database.
                MessageBox.Show("User Updated!");//the result if no error.                                            
            }
            else
            {
                DatabaseClass dataB = DatabaseClass.Instance;//class and confirms the connection string.
                dataB.UserEditor(txtUsrnameEdit.Text, txtPsswrdEdit.Text, txtFNUsrEdit.Text, txtLNUsrEdit.Text, chkbxLaborEdit.Text, userID); //input that info to the database.
                MessageBox.Show("User Updated!");//the result if no error.   
            }


            //updating dropdown box with current users
            //pulling the users names from the db to display in the drop down
            drpdwnSelectUsr.Items.Clear();//clears the items when starts.
            DatabaseClass dbDropDown = DatabaseClass.Instance;//takes info from the connection string
            var usrname = "SELECT [Username] FROM [dbo].[users]";//sql query to be executed
            var dataUser = dbDropDown.dataToCb(usrname);//the data to be selected
            drpdwnSelectUsr.DropDownStyle = ComboBoxStyle.DropDownList;//makes it a list
            drpdwnSelectUsr.Enabled = true;//enables the dropdown.
            drpdwnSelectUsr.SelectedIndex = -1;//allows to select the value from empty.   
            for (int i = 0; i < dataUser.Tables[0].Rows.Count; i++)//a loop that inputs values based on the row.
            {
                drpdwnSelectUsr.Items.Add(dataUser.Tables[0].Rows[i][0]);
            }

            //Allows To Clean text in the text box and dropdowns after user is created.
            txtFNUsrEdit.Text = "";
            txtLNUsrEdit.Text = "";
            txtUsrnameEdit.Text = "";
            txtPsswrdEdit.Text = "";
            chkbxLaborEdit.Checked = false;
            chkbxManagerEdit.Checked = false;
        }

        private void txtPsswrdCreate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJob_Click_2(object sender, EventArgs e)
        {
            //Tab Selection
            int Tabcount = formManageJob.TabCount;
            for (int count = 0; count < formManageJob.RowCount; count++)
            {
                //Change Tab
                formManageJob.SelectTab(0);
            }
        }

        private void btnEditJob_Click_1(object sender, EventArgs e)
        {
            //Tab Selection
            int Tabcount = formManageJob.TabCount;
            for (int count = 0; count < formManageJob.RowCount; count++)
            {
                //Changes the Tab
                formManageJob.SelectTab(1);
            }
        }

        private void BtnaddFertaliserJob_Click(object sender, EventArgs e)
        {
            int Tabcount = formManageJob.TabCount;
            for (int count = 0; count < formManageJob.RowCount; count++)
            {
                //Changes the Tab
                formManageJob.SelectTab(2);
            }
        }

        private void addJobType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Cbjamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbJCrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbJDate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void cbJLabouer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddJobSave_Click_1(object sender, EventArgs e)
        {
            // Data Containers
            string JobName;
            string cropContainer;
            string labourerContainer;
            string dateContainer;
            string jobTypeContainer;
            string amountContainer;
            string jobnameHarvest;
            // Valid Data Container for uncontrolled Variables
            DateTime validDateContainer;
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
                DateTime dateContainerTest;
                DateTime dateContainerHarvest;
                string date;
                string dateHarvest;
                DateTime.TryParse(dateContainer, out dateContainerTest);
                // Test for Weekend Selection
                if (dateContainerTest.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString() ||
                    dateContainerTest.DayOfWeek.ToString() == DayOfWeek.Sunday.ToString())
                {
                    MessageBox.Show("No Work On Weekends!");
                    return;

                }
                //Checks date is greater than todays date
                else if (dateContainerTest < DateTime.Now.Date)
                {
                    MessageBox.Show("Date entered is less than the current date");
                    cbJDate.Text = "";
                    dateContainer = null;
                    validDateContainer = DateTime.Now;
                    return;
                }
                else
                {
                    //sets validated dates and calculates harvest date assumed 30 days growth
                    date = dateContainerTest.ToShortDateString();
                    dateContainerHarvest = dateContainerTest.AddDays(35);
                    if (dateContainerHarvest.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString() || dateContainerHarvest.DayOfWeek.ToString() == DayOfWeek.Sunday.ToString())
                    {
                        dateContainerHarvest.AddDays(2);
                    }
                    dateHarvest = dateContainerHarvest.ToShortDateString();

                }
                // Amount Valdation +Conversion to Int
                if (int.TryParse(Cbjamount.Text, out int validAmountContainer))
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
                // if jobs is sowing auto add harvest aswell 
                if (addJobType.Text == "Sowing")
                {
                    DatabaseClass Data = DatabaseClass.Instance;
                    Data.GetDate = date;
                    JobName = addJobType.Text + " " + cbJCrop.Text.ToString() + " " + date + " " + cbJLabouer.Text + " " + validAmountContainer;
                    jobnameHarvest = "Harvest" + " " + cbJCrop.Text.ToString() + " " + dateHarvest + " " + cbJLabouer.Text + " " + validAmountContainer;
                    Data.GetIDCrop = cbJCrop.Text.ToString();
                    Data.GetIDJobType = addJobType.Text.ToString();
                    Data.GetIDUser = cbJLabouer.Text.ToString();

                    string Vehicle = Data.Getvehicle(addJobType.Text.ToString(), date);
                    if (Vehicle == "0")
                    {
                        MessageBox.Show("No Available Vehicle for selected date please select another date");
                        return;
                    }
                    string HarvestVehicle = Data.Getvehicle("Harvest", dateHarvest);
                    //getvehicle();
                    Data.Addjob(cbJLabouer.Text, cbJCrop.Text, date, validAmountContainer, addJobType.Text, Vehicle, JobName);
                    Data.AddHarvest(cbJLabouer.Text, cbJCrop.Text, dateHarvest, validAmountContainer, "Harvest", HarvestVehicle, jobnameHarvest);
                    MessageBox.Show("Saved Job as " + JobName);
                }
                //else just add special
                if (addJobType.Text == "Special")
                {
                    DatabaseClass Data = DatabaseClass.Instance;
                    Data.GetDate = date;
                    JobName = addJobType.Text + " " + cbJCrop.Text.ToString() + " " + date + " " + cbJLabouer.Text + " " + validAmountContainer;
                    Data.GetIDCrop = cbJCrop.SelectedItem.ToString();
                    Data.GetIDJobType = addJobType.SelectedItem.ToString();
                    Data.GetIDUser = cbJLabouer.SelectedItem.ToString();
                    //string Vehicle = Data.Getvehicle(addJobType.Text, date);
                    //if (Vehicle == "0")
                    //{
                    //   MessageBox.Show("No Available Vehicle for selected date please select another date");
                    //   return;
                    // }
                    Data.Addjob(cbJLabouer.Text, cbJCrop.Text, date, 0, addJobType.Text, null, JobName);
                    MessageBox.Show("Saved Job as " + JobName);
                }
                fillcomboFertalJobSelect();
                fillcomboDeleteJobSelect();
            }


        
    }

        private void btnAddJobCancel_Click_2(object sender, EventArgs e)
        {
            //Clears the Job Text Boxes
            cbJCrop.SelectedIndex = -1;
            cbJLabouer.SelectedIndex = -1;
            Cbjamount.Text = "";
            addJobType.SelectedIndex = -1;

        }

        private void btnDeleteJobSave_Click_1(object sender, EventArgs e)
        {
            DatabaseClass Connect = DatabaseClass.Instance;
            Connect.GetJobID = cbJSelectJob.SelectedItem.ToString();

            var valJob = Connect.GetIDJob(Connect.GetJobID);
            var select = "DELETE From [dbo].[Job] Where JobID=" + valJob;
            Connect.DeleteJob(select);
            
            
            MessageBox.Show("Job Successfully Deleted!");
            fillcomboDeleteJobSelect();
        }

        private void cbJSelectJob_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectJobFert_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectLabourerFertalise_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DatePickFertaliser_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddFertaliserConfirm_Click(object sender, EventArgs e)
        {
            //SELECT job where
            DatabaseClass Connect = DatabaseClass.Instance;
            string queryFindJob = "Select * From [dbo].[Job] WHERE [Job] = '" + SelectJobFert.SelectedText + "'";
            DataSet FindJobname = Connect.dataToCb(queryFindJob);

            string User = SelectLabourerFertalise.Text;

            string valDate = DatePickFertaliser.Text;
            DateTime valdatetest;
            DateTime.TryParse(valDate, out valdatetest);
            string valdateconfirmed;

            if (valdatetest.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString() ||
                valdatetest.DayOfWeek.ToString() == DayOfWeek.Sunday.ToString())
            {
                MessageBox.Show("No Work On Weekends!");
                return;

            }
            //Checks date is greater than todays date
            else if (valdatetest < DateTime.Now.Date)
            {
                MessageBox.Show("Date entered is less than the current date");
                DatePickFertaliser = null;
                return;
            }
            else
            {

                valdateconfirmed = valdatetest.ToShortDateString();
                string Vehicle = Connect.Getvehicle("Fertiliser", valdateconfirmed);
                if (Vehicle == "0")
                {
                    MessageBox.Show("No Available Vehicle for selected date please select another date");
                    return;
                }

                var CropQuery = "Select * From [dbo].[Job] JOIN Crop ON Job.CropID=Crop.CropID WHERE Job='" + SelectJobFert.Text + "'";
                DataSet dsCrop = Connect.getDataSet(CropQuery);
                for (int i = 0; i < dsCrop.Tables[0].Rows.Count; i++)
                {
                    GetcropFert = dsCrop.Tables[0].Rows[i]["CropID"].ToString();
                    GetCropfertAmount = dsCrop.Tables[0].Rows[i]["FertaliserAmountNeeded"].ToString();
                }

                string AmountQuery = "Select [amount] From [dbo].[Job] WHERE [Job] = '" + SelectJobFert.Text + "'";
                DataSet dsAmount = Connect.getDataSet(AmountQuery);
                for (int i = 0; i < dsCrop.Tables[0].Rows.Count; i++)
                {
                    GetamountFert = int.Parse(dsAmount.Tables[0].Rows[i]["amount"].ToString());
                }
                string jobname = "Fertalise" + " " + getcropfert + " " + valDate + " " + User + " " + getamountfert;
                Connect.GetIDUser = User;
                int getamounttotal = int.Parse(GetCropfertAmount) * GetamountFert;
                Connect.AddFertalizer(User, getcropfert, valdateconfirmed, getamounttotal, "4", Vehicle, jobname);
                MessageBox.Show("Saved Job as: " + jobname);
                fillcomboFertalJobSelect();
                fillcomboDeleteJobSelect();

            }
        }

        private void btnMThursday_Click(object sender, EventArgs e)
        {

        }

        private void btnMWednesday_Click(object sender, EventArgs e)
        {

        }

        private void btnMTuesday_Click(object sender, EventArgs e)
        {

        }

        private void btnMMonday_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            //www.dreamincode.net/forums/topic/235102-restricting-datetimepickermonthcalendar-to-specific-days/
            // sets the date to monday on selected week
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

        private void btnMThursday_Click_1(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Thursday = Date.AddDays(3);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetThursday = "SELECT [Crop_Name],[JobName],[First Name],[Last Name],[VehicleModel] FROM [dbo].[Job]" 
                + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID= users.UserID JOIN vehicle ON Job.JobTypeID=vehicle.JobTypeID  WHERE Date ='" 
                + Thursday.ToShortDateString() + "'";
            DataSet Thursdaydata = Connect.getDataSet(GetThursday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Thursdaydata.Tables[0];
        }

        private void btnMWednesday_Click_1(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Wednesday = Date.AddDays(2);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetWednesday = "SELECT [Crop_Name],[JobName],[First Name],[Last Name],[VehicleModel] FROM [dbo].[Job]" 
                + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID= users.UserID  JOIN vehicle ON Job.JobTypeID=vehicle.JobTypeID WHERE Date ='" 
                + Wednesday.ToShortDateString() + "'";
            DataSet Wednesdaydata = Connect.getDataSet(GetWednesday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Wednesdaydata.Tables[0];
        }

        private void btnMTuesday_Click_1(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Tuesday = Date.AddDays(1);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetTuesday = "SELECT [Crop_Name],[JobName],[First Name],[Last Name],[VehicleModel] FROM [dbo].[Job]" 
                + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID= users.UserID  JOIN vehicle ON Job.JobTypeID=vehicle.JobTypeID WHERE Date ='"
                + Tuesday.ToShortDateString() + "'";
            DataSet Tuesdaydata = Connect.getDataSet(GetTuesday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Tuesdaydata.Tables[0]; 
        }

        private void btnMMonday_Click_1(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Monday = Date;
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetMonday = "SELECT [Crop_Name],[JobName],[First Name],[Last Name],[VehicleModel] FROM [dbo].[Job]" 
                + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID= users.UserID  JOIN vehicle ON Job.JobTypeID=vehicle.JobTypeID WHERE Date ='" 
                + Monday.ToShortDateString() + "'";
            DataSet Mondaydata = Connect.getDataSet(GetMonday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Mondaydata.Tables[0]; 
        }

        private void btnMFriday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker1.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Friday = Date.AddDays(4);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetFriday = "SELECT [Crop_Name],[JobName],[First Name],[Last Name],[VehicleModel] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID= users.UserID JOIN vehicle ON Job.JobTypeID=vehicle.JobTypeID WHERE Date ='" + Friday.ToShortDateString() + "'";
            DataSet Fridaydata = Connect.getDataSet(GetFriday);
            DataViewDaily.ReadOnly = true;
            DataViewDaily.DataSource = Fridaydata.Tables[0];
        }

        private void DataViewDaily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }
}

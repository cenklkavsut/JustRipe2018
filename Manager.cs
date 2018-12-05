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
            //allows selecting tab
            int tabCount = tabReportOpt.TabCount;
            for (int i = 0; i < tabReportOpt.RowCount; i++)
            {
                tabReportOpt.SelectTab(0);
                //implementation
            }
            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Select Crop_Name AS ' Crop Name', FertaliserAmountNeeded As 'Fertaliser Amount', CropStorageTemperature As 'Storage Temperature' From [dbo].[Crop]";
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
            var select = "Select FertilizerName AS 'Fertaliser Name' ,amount  From [dbo].[Fertiliser]";
            var ds = dbCon.getDataSet(select);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];
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
            var select = "Select StorageName AS 'Storage Name',Capacity,Temperature AS 'Temperature (°C)' From [dbo].[StorageType]";
            var ds = dbCon.getDataSet(select);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];
         
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
            DatabaseClass dbCon = DatabaseClass.Instance;
            var select = "Select VehicleModel AS 'Vehicle Model' ,VehicleType AS 'Vehicle Type',VehicleRegistation AS 'Vehicle Registation'"
                +",VehicleAvailability AS 'Vehicle Available' From [dbo].[Vehicle]";
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
    }
}

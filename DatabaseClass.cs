using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;


namespace JustRipe2018
{
    class DatabaseClass
    {
        private string getUsrNameID;
        private string getUserName;
        private string getID;
        private string getIDCrop;
        private string getIDUser;
        private string getDate;
        private string getIDJobType;
        private string getJobname;
        private string getJobID;
        // Get sets
        public string GetJobID { get { return getJobID; } set { getJobID = value; } }
        public string GetID { get { return getID; } set { getID = value; } }
        public string GetUsrNameID { get { return getUsrNameID; } set { getUsrNameID = value; } }
        public string GetUserName { get { return getUserName; } set { getUserName = value; } }
        public string GetJobname { get { return getJobname; } set { getJobname = value; } }
        public string GetDate { get { return getDate; } set { getDate = value; } }
        public string GetIDCrop { get { return getIDCrop; } set { getIDCrop = value; } }
        public string GetIDUser { get { return getIDUser; } set { getIDUser = value; } }
        public string GetIDJobType { get { return getIDJobType; } set { getIDJobType = value; } }
        //private string connectionStr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JustRipeDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        private string connectionStr = Properties.Settings.Default.connectionToDB;
        //Connection string for connecting to the db
        SqlConnection connectionToDB;//change to db name this is the string that connect the database.
        private SqlDataAdapter dataAdapter;

        public void openConnection()
        {   //create the connection to the database as an instance of 
            SqlConnection connectionToDB = new SqlConnection(connectionStr);
            //open the connection
            connectionToDB.Open();//change to db name
        }

        public void closeConnection()
        {//close the connection to the database
            connectionToDB.Close();//change to db name
        }

        //fill the data base with the sql statment.
        public DataSet getDataSet(string sqlStatement)
        {
            dataAdapter = new SqlDataAdapter(sqlStatement, connectionStr);// create the 
            var dataSet = new DataSet();
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet);//return the dataSet
            return dataSet;
        }
        
        public void AdderOfStore(string valFirstN, string valSurname, string valContact, string valEmail, double ValAmount, string ValCrop)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);
           try            
            { //This is command class which will handle the query and connection object.  

            cnn.Open();//open the database connection.
            SqlCommand cmdInserOrderId = new SqlCommand();

            //allows for a nested query
            int valFromCrop= getBasicCrop();//

                SqlCommand cmdInserCustomer = new SqlCommand();
                cmdInserCustomer.CommandType = CommandType.Text;
                cmdInserCustomer.CommandText = "INSERT INTO [dbo].[Customer] ([FirstName],[Surname],[Contact Number],[Email]) VALUES" +
                  "('" + valFirstN + "','" + valSurname + "'," + valContact + ",'" + valEmail + "')";
                cmdInserCustomer.Connection = cnn;
                cmdInserCustomer.ExecuteNonQuery();//execute query.           
               
                int returnCustomerId = getBasicCustomer(valFirstN, valSurname);//
                
                cmdInserOrderId.CommandType = CommandType.Text;//queries that input data and retive data based on the values from the store.
                cmdInserOrderId.CommandText = "INSERT INTO [dbo].[Orders] ([CropID],[CustomerID],[Amount]) Values (" + valFromCrop + "," + returnCustomerId + "," + ValAmount + ")";//get the id from the class.
                cmdInserOrderId.Connection = cnn;
                cmdInserOrderId.ExecuteNonQuery();//execute query.

                cnn.Close();//close the database connection.


            }
            catch (Exception ex) 
             {
              //if error close application
              //Environment.Exit(1);
            }  // Create a SqlDataAdapter based on a SELECT query.
        }

        public DataSet dataToCb(string select)
        {
            SqlConnection conn = new SqlConnection();//call the connection.
            conn.ConnectionString = connectionStr;//connection string to connect.
            conn.Open();//open connection.
            SqlDataAdapter daSearch = new SqlDataAdapter(select, conn);//execute the sql and confirm connection.
            DataSet ds2 = new DataSet();//call the data set
            daSearch.Fill(ds2, select);//fill it with the dataset and sql value.
            return ds2;
        }

        ////
        //public string ComputeSha256HashConverter(string rawData)
        //{
        //    // Create a SHA256 
        //    SHA256 sha256Hash = SHA256.Create();  //create a sha 256    after it works change sha to md5

        //   // ComputeHash - returns byte array  
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));//store sha256 data in a bytes
        //        // Convert byte array to a string   
        //        StringBuilder builder = new StringBuilder();//use the string builder to store a bytes.
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString(rawData));//loop through the data and convert it to sha256.
        //        }
        //        return builder.ToString();//return the builder as a sha256 string.Also store as nvarchar in database to store.
        //}
             //

        public bool loginFul(string name,string password)
        {
            //hash
            //string plainData = password.ToLower();//
            //string hashedData = ComputeSha256HashConverter(plainData);//after hash is finished then add hashedData in place of passwort to lower in query.
            //hash and add in place of password

            //variables for implementation.
            bool x = false;//confirms login
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [dbo].[users] WHERE username='" + name+ "' AND password='" + password 
                + "'" ,connectionStr);//gets data from the database system through a adapter
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user.*/
            DataTable dt = new DataTable();//this is creating a virtual table  
            sda.Fill(dt);

            // This return input fromthe query         
            string job=getBasicVal(name,password);

            //and stores it in the string job.
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (job == "Manager")//
                {//
                    Manager settingsForm = new Manager();
                 //Show the settings form
                settingsForm.Show();
                }//
                else if (job == "Labourer")//
                {//
                    //displays the labourer form
                    Labourer labrerForm = new Labourer();
                    labrerForm.Show();
                }//                    
                x = true;
            }
            else
            {
                x = false;
            }
            return x;
        }

        public string getBasicVal(string name,string password)
        {
            //query of the value
            var selJob = "SELECT [Role] FROM [dbo].[users] WHERE username='" + name + "' AND password='" + password + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selJob, sql);//the command to search for it
            myCommand.Connection.Open();//open the connection
            string job= (string)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return job ;
        }
        //Gets Crop ID
        public int getBasicCrop()
        {
            //query of the value
            var selCropId = "SELECT [CropID] FROM [dbo].[Crop] WHERE Crop_Name='" + GetID +"'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selCropId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int CropId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return CropId;//return null error.
        }
        //gets user ID 
        public int getBasicCustomer(string valFirstN, string valSurname)
        {
            //query of the value
            var selCustomerId = "SELECT [CustomerID] FROM [dbo].[Customer] WHERE FirstName='" + valFirstN + "' AND Surname = '" + valSurname +"'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selCustomerId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int CustomerId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
           
            return CustomerId;//return null error.
        }

        // The attribute for replacing the calling part.
        private static DatabaseClass instance;
        //properties for calling the database class 
        public static DatabaseClass Instance
        {
            get//allows for getting the information
            {
                if (instance == null)
                {
                    instance = new DatabaseClass();
                }
                return instance;
            }
        }   
        //constructor for the patern
        private DatabaseClass()
        {
           //empty constructor.
        }

        private int dateCounter = 1;
        private int ChooserData = 1;
        public void getVal()
        {  int idCounter = 1;
            for (int i = 0; i < dateCounter; i++)
            {
                if (dateCounter == 0 || idCounter == 5)//it does not set to zero.
                {
                    break;
                }
                DateTime date = DateTime.Parse(getBasicDate());
                SqlConnection cnn = new SqlConnection(connectionStr);
                //This is command class which will handle the query and connection object.  
                SqlCommand cmdUpdateDate = new SqlCommand();
                SqlCommand cmdUpdateStorage = new SqlCommand();//
                cnn.Open();//open the database connection.               
                if (DateTime.Now.ToShortDateString() != date.ToShortDateString() && DateTime.Now > date||date==null||getBasicAmount()==0&&getBasicAmount()>getBasicAmount())//compares the dates//
                {
                    if (date == null || dateCounter == 0 || idCounter == 0)//||basic date 0 then break or null
                    {
                        dateCounter = 0;
                    }
                    else
                    {
                        cmdUpdateDate.CommandType = CommandType.Text;//change the counter.
                        cmdUpdateDate.CommandText = "UPDATE [dbo].[CropsStorage] SET UpdateDate ='" + DateTime.Now.ToShortDateString() + "' Where StorageID=" + idCounter;//get the id from the class.
                        cmdUpdateDate.Connection = cnn;
                        cmdUpdateDate.ExecuteNonQuery();//execute query. 

                        cmdUpdateStorage.CommandType = CommandType.Text;//change the counter.
                        cmdUpdateStorage.CommandText = "UPDATE [dbo].[CropsStorage] SET Amount=Amount +" + getBasicAmount() + " Where StorageID = " + idCounter;
                        cmdUpdateStorage.Connection = cnn; //set c3SUM = coalesce(c1, 0) + coalesce(c2, 0),
                        cmdUpdateStorage.ExecuteNonQuery();//execute query. 
                        dateCounter += 1;
                        idCounter += 1;//add one to the id counter
                    }
                }
                else if (DateTime.Now.ToShortDateString() == date.ToShortDateString())
                {
                    dateCounter = 0;//
                }  cnn.Close();
            }
        }
        //counter to choose a different id //error only gets one id.
        public string getBasicDate()// also add incremention  based on the id. if it only takes one id.
        {
            //query of the value
            var selDate = "SELECT Date FROM [dbo].[Job] WHERE JobTypeID=2";// increment through the query or change to a counter.
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selDate, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN 
            string dateResult = (string)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection    
          
            return dateResult;
        }

        //error only gets one id.
        public int getBasicAmount()
        {
            //query of the value
            var selAmount = "SELECT Amount FROM [dbo].[Job] WHERE JobTypeID=2 AND JobID="+ChooserData;// increment through the query 
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selAmount, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN 
            int AmountResult=0;

            try
            {
             AmountResult = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.


            }
            catch (Exception)
            {

            }
            myCommand.Connection.Close();//Close the connection                 
           //if null return =0             
            ChooserData += 1;

            if (AmountResult==0)
            {
                AmountResult = 0;
            }
            //
            return AmountResult;
        }

        int capacityCounter =1;
        public int getBasicCapacity()// also add incremention  based on the id. if it only takes one id.
        {
            //query of the value
            var selStorageType= "SELECT Capacity FROM [dbo].[StorageType] WHERE StorageTypeId="+capacityCounter;// increment through the query or change to a counter.
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selStorageType, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN             
            int AmountResult = 0;
            int dateResult;

            try
            {
             dateResult = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            }
            catch (Exception)
            {

                throw;
            }
            myCommand.Connection.Close();//Close the connection
            
            //
            if (AmountResult == 0)
            {
                AmountResult = 0;
            }
            //

            return dateResult;
        }

        public void UserCreator(string valUsername, string valPassword, string valFirstName, string valLastName, string valRole)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);

            //This is command class which will handle the query and connection object.  
            SqlCommand cmdAddUser = new SqlCommand();
            //SqlCommand MyCommand3 = new SqlCommand();

            //This insert query 
            //queries that input data and retive data based on the values from the store.
            cmdAddUser.CommandType = CommandType.Text;
            cmdAddUser.CommandText = "INSERT INTO dbo.users (Username, Password, [First Name], [Last Name], Role)" +
                "VALUES ('" + valUsername + "', '" + valPassword + "', '" + valFirstName + "', '" + valLastName + "', '" + valRole + "')";
            cmdAddUser.Connection = cnn;

            cnn.Open();
            cmdAddUser.ExecuteNonQuery();
            cnn.Close();
        }

        public void UserEditor(string valUsername, string valPassword, string valFirstName, string valLastName, string valRole, int userID)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);

            //This is command class which will handle the query and connection object.  
            SqlCommand cmdUpdateUser = new SqlCommand();
            //SqlCommand MyCommand3 = new SqlCommand();


            //This insert query 
            //queries that input data and retive data based on the values from the store.
            cmdUpdateUser.CommandType = CommandType.Text;
            cmdUpdateUser.CommandText = "UPDATE dbo.users SET Username='" + valUsername + "', Password='" + valPassword + "', [First Name]='" + valFirstName + "', [Last Name]='" + valLastName + "', Role='" + valRole + "' Where UserID='" + userID + "'";
            cmdUpdateUser.Connection = cnn;

            cnn.Open();
            cmdUpdateUser.ExecuteNonQuery();
            cnn.Close();
        }

        public int getUserID()
        {
            //query to return the userID from the selected username
            var usrID = "SELECT [UserID] FROM [dbo].[users] WHERE Username='" + GetUsrNameID + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(usrID, sql);//the command tos search for it
            myCommand.Connection.Open();//open the connection
            try
            {

                int UserId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.//

                myCommand.Connection.Close();//Close the connection
                return UserId;//return null error.
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string getUsrName()
        {
            //query to pull username and match with created username if possible
            var username = "SELECT [Username] FROM [dbo].[users] WHERE Username='" + GetUserName + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(username, sql);//the command tos search for it
            myCommand.Connection.Open();//open the connection
            string Username = (string)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return Username;//return null error.
        }
        // Adds Job to database 
        public void Addjob(string valUser, string valCrop, string valDate, int valAmount, string valJobID, string ValVehicleID, string valJname)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);

            Connect.Open();

            int valFromCrop = getBasicCrops();
            int valFromUser = getBasicUser();
            int valFromType = getBasicJobType();
            using (SqlCommand sendJob = new SqlCommand("INSERT INTO[dbo].[Job] ([UserID], [CropID],[Date],[amount],[JobTypeID],[VehicleID] ,[Job]) VALUES" +
            "('" + valFromUser + "','" + valFromCrop + "','" + valDate + "','" + valAmount + "','" + valFromType + "','" + ValVehicleID + "','" + valJname + "')"))
            {
                sendJob.Connection = Connect;
                try
                {
                    sendJob.ExecuteNonQuery();

                }
                catch (Exception)
                {


                }
                Connect.Close();

            }
        }
        //Adds Fertaliser Jobs to database 
        public void AddFertalizer(string valUser, string valCrop, string valDate, int valAmount, string valJobID, string ValVehicleID, string valJname)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);

            Connect.Open();
            int valFromUser = getBasicUser();
            SqlCommand sendJob = new SqlCommand("INSERT INTO[dbo].[Job](UserID, CropID,Date,amount,JobTypeID,VehicleID ,Job) VALUES" +
            "('" + valFromUser + "','" + valCrop + "','" + valDate + "','" + valAmount + "','" + valJobID + "','" + ValVehicleID + "','" + valJname + "')");

            sendJob.Connection = Connect;
            try
            {
                sendJob.ExecuteNonQuery();
            }
            catch
            {

            }
            Connect.Close();


        }
        //Adds Harvest Job To database 
        public void AddHarvest(string valUser, string valCrop, string valDate, int valAmount, string valJobID, string ValVehicleID, string valJname)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);

            Connect.Open();
            GetIDCrop = valCrop;
            GetIDJobType = valJobID;
            GetIDUser = valUser;
            int valFromCrop = getBasicCrops();
            int valFromUser = getBasicUser();
            int valFromType = getBasicJobType();
            using (SqlCommand sendJob = new SqlCommand("INSERT INTO[dbo].[Job] ([UserID], [CropID],[Date],[amount],[JobTypeID],[VehicleID] ,[Job]) VALUES" +
            "('" + valFromUser + "','" + valFromCrop + "','" + valDate + "','" + valAmount + "','" + valFromType + "','" + ValVehicleID + "','" + valJname + "')"))
            {
                sendJob.Connection = Connect;
                try
                {
                    sendJob.ExecuteNonQuery();

                }
                catch (Exception)
                {


                }
                Connect.Close();

            }
        }

        //Gets Timetable Data
        public void ShowTimetable(string SelectDate)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);
            Connect.Open();
            SqlCommand sendDate = new SqlCommand();
            sendDate.CommandType = CommandType.Text;
            sendDate.CommandText = "SELECT [CropID],[JobTypeID],[UserID] FROM [dbo].[Job] WHERE Date ='" + SelectDate + "'";



        }
        //gets Crop ID
        public int getBasicCrops()
        {
            //query of the value
            var selCropId = "SELECT [CropID] FROM [dbo].[Crop] WHERE Crop_Name='" + GetIDCrop + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selCropId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int CropId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return CropId;//return null error.

        }
        //Gets User ID
        public int getBasicUser()
        {
            //query of the value
            var selUserId = "SELECT [UserID] FROM [dbo].[users] WHERE [First Name]='" + GetIDUser + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selUserId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int UserId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return UserId;//return null error.
        }
        // Gets Job Type ID
        public int getBasicJobType()
        {
            //query of the value
            var selJobTypeId = "SELECT [JobTypeID] FROM [dbo].[JobType] WHERE JobName='" + GetIDJobType + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selJobTypeId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int JobTypeId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return JobTypeId;//return null error.
        }
        // Gets JobID
        public int GetIDJob(string job)
        {            //query of the value
            int JobId = 0;
            var selJobId = "SELECT [JobID] FROM [dbo].[Job] WHERE Job='" + job + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selJobId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            try
            {
                 JobId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            }
            catch
            {

            }
        
            myCommand.Connection.Close();//Close the connection
            return JobId;//return null error.

        }
        private string thisAvailableVehicle;
        // Vehicle availibilty loop
        public string Getvehicle(string Jobtype, string Date)// GET DATE
        {
            var getvehicle = "SELECT [VehicleID] FROM [dbo].[vehicle] JOIN [JobType] ON [vehicle].[JobTypeID] = [JobType].[JobTypeID] WHERE [JobName]='" + Jobtype + "'";
            var getJobs = "SELECT VehicleID FROM Job WHERE Date = '" + Date + "'";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.ConnectionString = connectionStr;
            conn.Open();
            // Gets the 2 datasets 
            SqlDataAdapter myvehicle = new SqlDataAdapter(getvehicle, conn);
            SqlDataAdapter myjob = new SqlDataAdapter(getJobs, conn);
            DataSet VehicleList = new DataSet();
            DataSet JobList = new DataSet();
            myvehicle.Fill(VehicleList, getvehicle);
            myjob.Fill(JobList, getJobs);
            string AvailableVehicle = "";
            bool unavailablevehicle = false;
            // loops through dataset and compares the values of Vehicle ID for a match
            if (JobList.Tables[0].Rows.Count == 0)
            {
                AvailableVehicle = VehicleList.Tables[0].Rows[0][0].ToString();
                return AvailableVehicle;
            }
            for (int i = 0; i < VehicleList.Tables[0].Rows.Count; i++)
            {

                unavailablevehicle = false;
                for (int j = 0; j < JobList.Tables[0].Rows.Count; j++)
                    if (VehicleList.Tables[0].Rows[i][0].ToString() == JobList.Tables[0].Rows[j][0].ToString())
                    {
                        AvailableVehicle = "0";
                        unavailablevehicle = true;
                    }
                    else
                    {
                        // Stores Available vehicle 
                        thisAvailableVehicle = VehicleList.Tables[0].Rows[i][0].ToString();

                    }

                

                if (unavailablevehicle == false)
                {
                    // returns available vehicle breaking loop 
                    return thisAvailableVehicle;

                }
            }
            return AvailableVehicle;

        }
        // Deletes Job 
        public void DeleteJob(string SelectJob)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);
            SqlCommand sendJob = new SqlCommand(SelectJob,Connect);
            sendJob.CommandType = CommandType.Text;
            sendJob.CommandText = SelectJob;
            sendJob.Connection = Connect;
            Connect.Open();
            sendJob.ExecuteNonQuery();
            Connect.Close();
        }
    }
}
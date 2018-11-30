using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace JustRipe2018
{
    class DatabaseClass

    {
        string getIDCrop;
        string getIDUser;
        string getDate;
        string getIDJobType;
        public string GetDate { get { return getDate; } set { getDate = value; } }
        public string GetIDCrop { get { return getIDCrop; } set { getIDCrop = value; } }
        public string GetIDUser { get { return getIDUser; } set { getIDUser = value; } }
        public string GetIDJobType { get { return getIDJobType; } set { getIDJobType = value; } }
        private string connectionStr = Properties.Settings.Default.connectionToDB; // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JustRipeDatabase.mdf;Integrated Security=True;Connect Timeout=30";
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
            DataSet dataSet = new DataSet();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet);//return the dataSet
            return dataSet;
        }

        public void AdderOfStore(string valFirstN, string valSurname, string valContact, string valEmail, double ValAmount/*, string ValCrop*/)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);
            //try
            //{
            //This is command class which will handle the query and connection object.  
            SqlCommand MyCommand1 = new SqlCommand();
            SqlCommand MyCommand2 = new SqlCommand();
            //SqlCommand MyCommand3 = new SqlCommand();

            //This insert query 
            //queries that input data and retive data based on the values from the store.
            MyCommand1.CommandType = CommandType.Text;
            MyCommand1.CommandText = "INSERT [dbo].[Customer] ([First Name], [Surname],[Contact Number],[Email]) VALUES" +
          "('" + valFirstN + "','" + valSurname + "'," + valContact + ",'" + valEmail + "')";
            MyCommand1.Connection = cnn;


            MyCommand2.CommandType = CommandType.Text;
            MyCommand2.CommandText = "INSERT [dbo].[Orders] ([Amount]) VALUES (" + ValAmount + ")";
            MyCommand2.Connection = cnn;
            //// NEED TO ADD IN CROPS AND DROP DOWN NEEDS TO LINK TO CROPS 
            //MyCommand3.CommandType = CommandType.Text;
            //MyCommand3.CommandText = "INSERT [dbo].[crop] VALUES (" + ValCrop + ")";
            //MyCommand3.Connection = cnn;

            cnn.Open();
            //MyCommand3.ExecuteNonQuery();
            MyCommand2.ExecuteNonQuery();
            MyCommand1.ExecuteNonQuery();
            cnn.Close();//close the database connection.
            //}
            /*catch (Exception ex)
            {
                //if error close application
                
              //  Environment.Exit(1);
            } */
        }
        //public void GetID ()
        //{
        //    SqlConnection Connect = new SqlConnection(connectionStr);
        //    SqlCommand FetchUserID = new SqlCommand();
        //    FetchUserID.CommandType = CommandType.Text;
        //    FetchUserID.CommandText = "SELECT 'UserID From [dbo].[users] WHERE [First name] =" + labourerContainer;
        //    FetchUserID.Connection = Connect;
        //    Connect.Open();
        //    FetchUserID.ExecuteNonQuery();
        //    Connect.Close();
        //}
        public void Addjob(string valUser, string valCrop, string valDate, int valAmount, string valJobID, int ValVehicleID, string valJname)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);

            Connect.Open();

            int valFromCrop = getBasicCrop();
            int valFromUser = getBasicUser();
            int valFromType = getBasicJobType();
            using (SqlCommand sendJob = new SqlCommand("INSERT INTO[dbo].[Job]([UserID], [CropID],[Date],[amount],[JobTypeID],[VehicleID] [JobName]) VALUES" +
            "('" + valFromUser + "','" + valFromCrop + "','" + valDate + "','" + valAmount + "','" + valFromType + "','" + ValVehicleID + "','" + valJname + "')"))
            {
                sendJob.Connection = Connect;
                sendJob.ExecuteNonQuery();
                Connect.Close();

            }
        }

                //sendJob.CommandType = CommandType.Text;
                //sendJob.CommandText = "INSERT INTO [dbo].[Job] ([UserID], [CropID],[Date],[amount],[JobTypeID],[VehicleID]) VALUES" +
                //  "('" + valFromUser + "','" + valFromCrop + "','  @Date  ','" + valAmount + "','" + valFromType + "','" + ValVehicleID + "')";
                //sendJob.Connection = Connect;
                //sendJob.ExecuteNonQuery();
                //Connect.Close();

                //"SELECT [CropID] FROM [dbo].[Crop] WHERE Crop_Name='" + GetID +"'";
                //"INSERT INTO [dbo].[Orders] ([CropID],[Amount]) Values (" + valFromCrop +","+ ValAmount + ")"



                public void ShowTimetable(string SelectDate)
                {
                    SqlConnection Connect = new SqlConnection(connectionStr);
                    Connect.Open();
                    SqlCommand sendDate = new SqlCommand();
                    sendDate.CommandType = CommandType.Text;
                    sendDate.CommandText = "SELECT [CropID],[JobTypeID],[UserID] FROM [dbo].[Job] WHERE Date ='" + SelectDate + "'";



                }
        DataSet ds2;
        public DataSet dataToCb(string select)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.ConnectionString = connectionStr;
            conn.Open();
            SqlDataAdapter daSearch = new SqlDataAdapter(select, conn);
            ds2 = new DataSet();
            daSearch.Fill(ds2, select);
            return ds2;
        }
        public int getBasicCrop()
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
        public int getBasicUser()
        {
            //query of the value
            var selUserId = "SELECT [UserID] FROM [dbo].[users] WHERE FirstName='" + GetIDUser + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(selUserId, sql);//the command to search for it
            myCommand.Connection.Open();//open the connectionN [Crop]
            int UserId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return UserId;//return null error.
        }
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
    }
}
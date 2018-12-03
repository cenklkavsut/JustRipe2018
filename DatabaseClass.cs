﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JustRipe2018
{
    class DatabaseClass
    {
        string getIDCrop;
        string getIDUser;
        string getDate;
        string getIDJobType;
        string getUsrNameID;
        string getUserName;
        public string GetDate { get { return getDate; } set { getDate = value; } }
        public string GetIDCrop { get { return getIDCrop; } set { getIDCrop = value; } }
        public string GetIDUser { get { return getIDUser; } set { getIDUser = value; } }
        public string GetIDJobType { get { return getIDJobType; } set { getIDJobType = value; } }
        public string GetUsrNameID { get { return getUsrNameID; } set { getUsrNameID = value; } }
        public string GetUserName { get { return getUserName; } set { getUserName = value; } }

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
            //try
            //{
                //This is command class which will handle the query and connection object.  
                SqlCommand MyCommand1 = new SqlCommand();
                SqlCommand MyCommand2 = new SqlCommand();
            SqlCommand MyCommand3 = new SqlCommand();

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
            MyCommand3.CommandType = CommandType.Text;
            MyCommand3.CommandText = "INSERT [dbo].[crop] VALUES (" + ValCrop + ")";
            MyCommand3.Connection = cnn;

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

        public bool loginToSystem(string n, string pwd)
        {
            DatabaseClass con = new DatabaseClass();
            bool r;

            SqlCommand select0 = new SqlCommand("Select [Username] From [dbo].[users] WHERE ([Username] =" + n + ")");
            SqlCommand select1 = new SqlCommand("Select [Password] From [dbo].[users] WHERE ([Password] =" + pwd + ")");

            //for loggin add database to the place where admin  is typed and connection
            //in place of admin it need to be changed to the place from the database.
            if (n.ToLower() == select0.ToString() && pwd.ToLower() == select1.ToString() || n.ToLower() == "admin" && pwd.ToLower() == "admin")//this is gonne be the name inputed in from the database
            {
                r = true;
                SqlCommand selectJo = new SqlCommand("Select [JobName] From [dbo].[JobType] WHERE ([JobName] = Manager)");
                SqlCommand selectJo1 = new SqlCommand("Select [JobName] From [dbo].[JobType] WHERE ([JobName] = Labourer)");
                string M = "Manager";
                string L = "Labourer";
                //closes the login Page
                Login loginForm = new Login();
                loginForm.Hide();
                loginForm.Close();

                if (n.ToLower() == "admin" && pwd.ToLower() == "admin")
                {//for testing
                    // Create a new instance of the Form2 class
                    Manager settingsForm = new Manager();
                    // Show the settings form
                    settingsForm.Show();
                }//For testing

                if (selectJo.ToString() == M && selectJo.ToString() != L)
                {
                    // Create a new instance of the Form2 class
                    Manager settingsForm = new Manager();
                    // Show the settings form
                    settingsForm.Show();
                }
                else if (selectJo1.ToString() == L && selectJo1.ToString() != M)
                {
                    //displays the labourer form
                    Labourer labrerForm = new Labourer();
                    labrerForm.Show();
                }
            }
            else
            {
                r = false;
            }

            return r;
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
            cmdAddUser.CommandText = "INSERT INTO dbo.users (Username, Password, First_Name, Last_Name, Role) " +
                "VALUES ('" + valUsername + "', '" + valPassword + "', '" + valFirstName + "', '" + valLastName + "', '" + valRole + "')";
            cmdAddUser.Connection = cnn;

            cnn.Open();
            cmdAddUser.ExecuteNonQuery();
            cnn.Close();
        }

        public int getUserID()
        {
            //query to return the userID from the selected username
            var usrID = "SELECT [UserID] FROM [dbo].[users] WHERE Username='" + GetUsrNameID + "'";
            SqlConnection sql = new SqlConnection(connectionStr);//set up the connection of it
            SqlCommand myCommand = new SqlCommand(usrID, sql);//the command tos search for it
            myCommand.Connection.Open();//open the connection
            int UserId = (int)myCommand.ExecuteScalar();//input the query result into the string through casting.
            myCommand.Connection.Close();//Close the connection
            return UserId;//return null error.
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

        private static DatabaseClass instance;

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
    }
}
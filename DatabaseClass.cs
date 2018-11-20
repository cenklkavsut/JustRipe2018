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
        private string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JustRipeDatabase.mdf;Integrated Security=True;Connect Timeout=30";
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

        public void Addjob (int valUser, int valCrop, DateTime valDate, int valAmount, int valJobID, int ValVehicleID)
        {
            SqlConnection Connect = new SqlConnection(connectionStr);
            SqlCommand sendJob = new SqlCommand();

            sendJob.CommandType = CommandType.Text;
            sendJob.CommandText = "INSERT [dbo].[Job] ([UserID], [CropID],[Date],[amount],[JobTypeID],[VehicleID]) VALUES" +
              "('" + valUser + "','" + valCrop + "'," + valDate + ",'" + valAmount + "'," + valJobID + "'," + ValVehicleID + "')";
            sendJob.Connection = Connect;
            Connect.Open();
            sendJob.ExecuteNonQuery();
            Connect.Close();
        }

        //DataSet ds2;
        //public DataSet dataToCb(string select)
        //{

        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = connectionStr;
        //    conn.Open();
        //    SqlDataAdapter daSearch = new SqlDataAdapter(select, conn);
        //    ds2 = new DataSet();
        //    daSearch.Fill(ds2, select);
        //    return ds2;
        //}


        public DatabaseClass(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
    }
}
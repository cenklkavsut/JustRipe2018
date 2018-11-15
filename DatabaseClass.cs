using System;
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
        private string connectionStr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JustRipeDatabase.mdf;Integrated Security=True;Connect Timeout=30";
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

        //this needs to be changed based on the implementation and the database
        public void FillInTextFields(DataTable table, int ind)
        {
        //// get the table row specified 
        //byte ind
        DataRow dataRow= table.Rows[ind];//allows for obtaining data from table
        ////get the SID
       //username.Text= dataRow.ItemArray.GetValue(0).ToString();//name based on the colum and on the table
        ////get the name
        //tbName.Text= dataRow.ItemArray.GetValue(1).ToString();//name based on the colum and on the table
        ////get the start
        //tbStart.Text= dataRow.ItemArray.GetValue(2).ToString();//name based on the colum and on the table
        }

        public void AdderOfStore(string valFirstN, string valSurname, string valContact, string valEmail, string ValAmount, string ValCrop)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);
            try
            {
                //This is command class which will handle the query and connection object.  
                SqlCommand MyCommand1 = new SqlCommand();
                SqlCommand MyCommand2 = new SqlCommand();
                SqlCommand MyCommand3 = new SqlCommand();

                //This insert query 
                //queries that input data and retive data based on the values from the store.
                MyCommand1.CommandType = CommandType.Text;
                MyCommand1.CommandText = "INSERT [dbo].[Customer] ([First Name], [Surname],[Contact Number],[Email]) VALUES" +
              "(" + valFirstN + "," + valSurname + "," + valContact + "," + valEmail + ")";
                MyCommand1.Connection = cnn;


                MyCommand2.CommandType = CommandType.Text;
                MyCommand2.CommandText = "INSERT [dbo].[Orders] ([Amount]) VALUES (" + ValAmount + ")";
                MyCommand2.Connection = cnn;

                MyCommand3.CommandType = CommandType.Text;
                MyCommand3.CommandText = "INSERT [dbo].[Crop] ([Crop Name]) VALUES (" + ValCrop + ")";
                MyCommand3.Connection = cnn;

                cnn.Open();
                MyCommand1.ExecuteNonQuery();
                MyCommand2.ExecuteNonQuery();
                MyCommand3.ExecuteNonQuery();
                cnn.Close();//close the database connection.
            }
            catch (Exception ex)
            {
                //if error close application
                Environment.Exit(1);
            }
        }
            public DatabaseClass(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
    }
}
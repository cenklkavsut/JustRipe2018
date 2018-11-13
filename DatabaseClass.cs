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
            dataAdapter = new SqlDataAdapter(sqlStatement,connectionToDB);// create the 
           DataSet dataSet = new System.Data.DataSet();

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
        //add this to the place of implementation.also this connects to the grid.
        //using System.Data.SqlClient;
        //using System.Data;
        //// get the connectionStringfrom the Settings 
        //string connectionString= Properties.Settings.Default.Setting;// create the connection to the DB and open it 
        //DatabaseClass dbCon = new DatabaseClass(connectionString);
        //dbCon.openConnection();//get the dataSet 
        //dataSet= dbCon.getDataSet(Constants.selectAll);
        //DataTabletable = dataSet.Tables[0];FillInTextFields(table, 1);
        ////set up the data grid 
        //viewdgvStudents.DataSource= table;

        public DatabaseClass(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
    }
}
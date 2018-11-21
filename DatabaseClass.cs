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
        string getID;
        public string GetID { get { return getID; } set { getID = value; } }
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

        public void AdderOfStore(string valFirstN, string valSurname, string valContact, string valEmail, double ValAmount, string ValCrop)
        {
            //This is the connection string that assigns to the database. 
            SqlConnection cnn = new SqlConnection(connectionStr);
            //try
            //{ //This is command class which will handle the query and connection object.  
                SqlCommand MyCommand1 = new SqlCommand();
                SqlCommand MyCommand2 = new SqlCommand();
                 SqlCommand MyCommand3 = new SqlCommand();

            //This insert query 
            //queries that input data and retive data based on the values from the store.
            MyCommand1.CommandType = CommandType.Text;
                MyCommand1.CommandText = "INSERT INTO [dbo].[Customer] ([First Name],[Surname],[Contact Number],[Email]) VALUES" +
              "('" + valFirstN + "','" + valSurname + "'," + valContact + ",'" + valEmail + "')";
                MyCommand1.Connection = cnn;

            MyCommand2.CommandType = CommandType.Text;
            MyCommand2.CommandText = "INSERT INTO [dbo].[Orders] ([Amount]) VALUES (" + ValAmount + ")";
            MyCommand2.Connection = cnn;

            //allows for a nested query
        MyCommand3.CommandType = CommandType.Text;
        MyCommand3.CommandText = "INSERT INTO [dbo].[Orders] ([CropID])"
         + " SELECT [dbo].[Orders].[CropID] FROM [Orders] RIGHT JOIN [Crop] ON [Orders].[CropID]=[Crop].[CropID] WHERE ([Crop].[Crop_Name] = '" + GetID + "')";
            MyCommand3.Connection = cnn;
            //
            var val = MyCommand3.CommandText;
            SqlDataAdapter adapter = new SqlDataAdapter(val, connectionStr);
            // Create a DataTable and fill it.
            DataTable categories = new DataTable();
            adapter.Fill(categories);

            var val1 = MyCommand1.CommandText;            
                SqlDataAdapter adapter1 = new SqlDataAdapter(val1, connectionStr);
            // Create a DataTable and fill it.
            DataTable categories1 = new DataTable();
            adapter.Fill(categories1);

            var val2 = MyCommand2.CommandText;
            SqlDataAdapter adapter2 = new SqlDataAdapter(val2, connectionStr);
            // Create a DataTable and fill it.
            DataTable categories2 = new DataTable();
            adapter.Fill(categories2);

            cnn.Open();
            MyCommand3.ExecuteNonQuery();
            MyCommand2.ExecuteNonQuery();
            MyCommand1.ExecuteNonQuery();
            MyCommand3.CommandType = CommandType.StoredProcedure;//Allows for saving
            MyCommand2.CommandType = CommandType.StoredProcedure;//Allows for saving 
            MyCommand1.CommandType = CommandType.StoredProcedure;//Allows for saving
            cnn.Close();//close the database connection.

            //}
            /*catch (Exception ex)
            {
                //if error close application
              //  Environment.Exit(1);
            } */

            // Create a SqlDataAdapter based on a SELECT query.
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

        public bool loginFul(string name,string password)
        {
            //variables for implementation.
            bool x = false;//confirms login
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [dbo].[users] WHERE username='" + name.ToLower() + "' AND password='" + password.ToLower()  
                + "'" ,connectionStr);//gets data from the database system through a adapter
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);

            //         
            string job=getBasicVal(name,password);
            //

            if (dt.Rows[0][0].ToString() == "1")
            {
                if (job == "Manager")//
                {//
                    Manager settingsForm = new Manager();
                 //Show the settings form
                settingsForm.Show();
                    x = true;
                }//
                else if (job == "Labourer")//
                {//
                    //displays the labourer form
                    Labourer labrerForm = new Labourer();
                    labrerForm.Show();
                }//
            }
            else
            {
                x = false;
            }
            return x;
        }
        //
        public string getBasicVal(string name,string password)
        {
            var selJob = "SELECT [Role] FROM [dbo].[users] WHERE username='" + name.ToLower() + "' AND password='" + password.ToLower() + "'";

            SqlConnection sql = new SqlConnection(connectionStr);
                SqlCommand myCommand = new SqlCommand(selJob, sql);
                myCommand.Connection.Open();
               string job= (string)myCommand.ExecuteScalar();
         
            return job ;
        }
        //
        public DatabaseClass(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
    }
}
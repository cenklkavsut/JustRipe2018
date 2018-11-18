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

        DataSet ds2;
        public DataSet dataToCb(string select)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionStr;
            conn.Open();
            SqlDataAdapter daSearch = new SqlDataAdapter(select, conn);
            ds2 = new DataSet();
            daSearch.Fill(ds2, select);
            return ds2;
        }

        public int passwordCounter = 0;//a counter for the password!
        public bool loginToSystem(string n, string pwd)
        {
            DatabaseClass con = new DatabaseClass(connectionStr);
            bool r;
            //SqlCommand select = new SqlCommand("Select * From [dbo].[users] WHERE [Username]="+n+"  AND [Password] ="+pwd+"");

            SqlCommand select0 = new SqlCommand("Select * From [dbo].[users] WHERE ([Username] =" + n + ")");
            SqlCommand select1 = new SqlCommand("Select * From [dbo].[users] WHERE ([Password] =" + pwd + ")");

            //for loggin add database to the place where admin  is typed and connection
            //in place of admin it need to be changed to the place from the database.
            if (n.ToLower() == select0.ToString() && pwd.ToLower() == select1.ToString() || n.ToLower() == "admin" && pwd.ToLower() == "admin")//this is gonne be the name inputed in from the database
            {
                r = true;
                SqlCommand selectJo = new SqlCommand("Select * From [dbo].[JobType] WHERE ([JobName] = Manager)");
                SqlCommand selectJo1 = new SqlCommand("Select * From [dbo].[JobType] WHERE ([JobName] = Labourer)");
                string M = "Manager";
                string L = "Labourer";
                //closes the login Page
                Login loginForm = new Login();
                loginForm.Hide();
                loginForm.Close();

                if (n.ToLower() == "admin" && pwd.ToLower() == "admin")
                {
                    // Create a new instance of the Form2 class
                    Manager settingsForm = new Manager();
                    // Show the settings form
                    settingsForm.Show();
                }

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
            //return n+""+pwd ;

            //string dummyun = txtUserName.Text;
            //string dummypw = txtPassword.Text;
            //con.openConnection();
            //SqlCommand StrQuer = new SqlCommand("Select * From[dbo].[Orders] WHERE Username=@userid AND Password =@password");
            //    StrQuer.Parameters.AddWithValue("@userid", dummyun);
            //    StrQuer.Parameters.AddWithValue("@password", dummypw);
            //    SqlDataReader user = StrQuer.ExecuteReader();
            //    if(use.HasRows)
            //      {
            //        MessageBox.Show("loginSuccess");
            //    }
            //  else
            //    {
            //        //invalid login
            //    }

            return r;
        }

        public DatabaseClass(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
    }
}
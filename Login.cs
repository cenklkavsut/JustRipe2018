using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
//using System.Data;


//[Name]:Brett leary
//[SID]:1553265
//[last updated]:06/11/2018
//[Name]:Cenk latif kavsut
//[SID]:1572556
//[last updated]:06/11/2018
//[Name]:Charlie bryant
//[SID]:1706224
//[last updated]:06/11/2018
//[Name]:Bailey McQue
//[SID]:1708431
//[last updated]:06/11/2018


namespace JustRipe2018
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
         public int passwordCounter=0;//a counter for the password!
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseClass con = new DatabaseClass();

            bool r = con.loginToSystem(txtUserName.Text, txtPassword.Text);
            //for loggin add database to the place where admin  is typed and connection
            if (/*txtUserName.Text.ToLower()=="admin" && txtPassword.Text.ToLower()=="admin"*/r == true)//this is gonne be the name inputed in from the database
            {
                ////closes the login Page
                Login loginForm = new Login();
                this.Hide();
                loginForm.Close();
                passwordCounter = 0;
            }//this part in place of password counter it need to be txt user or password!= database value to activvate this code!
            else if (/*txtUserName.Text!="admin" && txtPassword.Text!= "admin"||*/r == false)//if password is wrong!
            {
                if (passwordCounter == 3 || passwordCounter > 3)//if 3 times or more
                {
                    if (passwordCounter == 3 || passwordCounter > 3)
                    {
                        MessageBox.Show("3rd attempt failed: Forcing Shutdown");
                        Application.Exit();
                    }
                }
                else if (passwordCounter == 2)
                {
                    MessageBox.Show("Last Attempt: Please Contact a Manager");
                    lblLogin.Text = "2nd attempt failed: username or password is incorrect";
                }
                else if (passwordCounter == 1)
                {
                    lblLogin.Location = new Point(30, 160);
                    lblLogin.Text = "1st attempt failed: username or password is incorrect";
                }
                passwordCounter += 1;//the counter for each time wrong
            }
    }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
         
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

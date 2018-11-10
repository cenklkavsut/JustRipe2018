using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //for loggin add database to the place where admin  is typed and connection
            //in place of admin it need to be changed to the place from the database.
            if (txtUserName.Text=="admin" && txtPassword.Text=="admin")//this is gonne be the name inputed in from the database
            {    
            //closes the login Page
            Login loginForm = new Login();
            this.Hide();
            loginForm.Close();
            MessageBox.Show("Welcome");
            // Create a new instance of the Form2 class
            Manager settingsForm = new Manager();
            //displays the labourer form
            //Labourer labrer = new Labourer();
            //labrer.show();
            // Show the settings form
            settingsForm.Show();
                passwordCounter = 0;
            }//this part in place of password counter it need to be txt user or password!= database value to activvate this code!
            else if (txtUserName.Text!="admin" && txtPassword.Text!= "admin")//if password is wrong!
            {
                if (passwordCounter == 3 ||passwordCounter>3)//if 3 times or more
                {
                    if (passwordCounter > 3)//if more than 3
                    {
                        MessageBox.Show("Exited the maximun limit of tries!");
                        Application.Exit();
                    }
                    else if (passwordCounter == 3)
                    {
                        lblLogin.Text = "3th try please "+"\nConntact a manager "+"\nbefore application shuts down!";
                    }
                }
                else if (passwordCounter == 2)
                {
                    lblLogin.Text = "2nd try pleas try again!";
                }
                else if (passwordCounter == 1)
                {
                    lblLogin.Text = "1st try pleas try again!";
                }
                passwordCounter += 1;//the counter for each time wrong
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text.ToLower();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Text.ToLower();
        }
    }
}

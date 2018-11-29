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
        string UsernameCurrent;
        public Login()
        {
            InitializeComponent();
            
        }
        public int passwordCounter=0;//a counter for the password!
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseClass dbLogin = DatabaseClass.Instance;

            bool r=dbLogin.loginFul(txtUserName.Text.ToLower(),txtPassword.Text.ToLower());

            if (r==true)
            {
                passwordCounter = 0;
                //Login loginForm = new Login();
                this.Hide();//hides
                //loginForm.Close();//closes after hiding.
            }
            else if (r == false)//if password is wrong!
            {
                if ( passwordCounter >= 3)//if 3 times or more
                {

                    lblLogin.Text = "3rd attempt failed: Forcing Shutdown";
                        MessageBox.Show("3rd attempt failed: Forcing Shutdown");
                        Application.Exit();
                    
                }
                else if (passwordCounter == 2)
                {
                    lblLogin.Text = "2nd attempt failed: username or password is incorrect";
                    MessageBox.Show("Last Attempt: Please Contact a Manager");

                }
                else if (passwordCounter == 1)
                {
                    lblLogin.Location = new Point(30, 160);
                    lblLogin.Text = "1st attempt failed: username or password is incorrect";
                }
                passwordCounter += 1;//the counter for each time wrong

            }

            UsernameCurrent = txtUserName.Text.ToLower();
            Labourer Username = new Labourer();
            Username.LabUName = UsernameCurrent;

            
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

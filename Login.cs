using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class

            //closes the login Page
            Login loginForm = new Login();
            this.Hide();
            loginForm.Close();
            MessageBox.Show("Welcome");

            Manager settingsForm = new Manager();
            // Show the settings form
            settingsForm.Show();
            //Note When Close then Exit code add later.

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

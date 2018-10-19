﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MessageBox.Show("Welcome");
            // Create a new instance of the Form2 class
            Manager settingsForm = new Manager();

            //closes the login Page
            Login loginForm = new Login();
            this.Hide();
            loginForm.Close();

            // Show the settings form
            settingsForm.Show();
            //Note When Close then Exit code add later.

        }
    }
}
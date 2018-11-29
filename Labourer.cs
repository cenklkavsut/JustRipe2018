using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace JustRipe2018
{
    public partial class Labourer : Form
    {
        string username;
        public Labourer()
        {
            MessageBox.Show(Login.Instance.GetUser);

            InitializeComponent();
            getusername();
            
        }

        private void btnLogoutLabourer_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Labourer_Load(object sender, EventArgs e)
        {
           

        }

        private void tabTimetableLabourer_Click(object sender, EventArgs e)
        {
            
        }

        private void LabUNameTest_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void DailyTasksRtb_TextChanged(object sender, EventArgs e)
        {

        }

        public void getusername()
        {
          
            username = Login.Instance.GetUser;
        }

        private void monLabTt_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

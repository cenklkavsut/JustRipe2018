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
        public Labourer()
        {
            InitializeComponent();
            
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

        private string labUName = "";
        public string LabUName
        {

            
            get
            {
                return labUName;
            }
            set
            {

                LabUNameTest.Text = labUName;
            }
        }



    }

}

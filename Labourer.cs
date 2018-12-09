using System;
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
    public partial class Labourer : Form
    {
        string username;
        public Labourer()
        {
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
        public void getusername()
        {

            username = Login.Instance.GetUser;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            var DateSelection = sender as DateTimePicker;
            var SelectedDate = DateSelection.Value;

            if (SelectedDate.DayOfWeek != DayOfWeek.Monday)
            {
                var set = (int)DayOfWeek.Monday - (int)SelectedDate.DayOfWeek;
                var Monday = SelectedDate + TimeSpan.FromDays(set);
                DateSelection.Value = Monday;
            }
            var Selectedval = SelectedDate;
        }

        private void btnMMonday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker2.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Monday = Date;
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetMonday = "SELECT [Crop_Name],[JobName],[amount] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Monday.ToShortDateString() + "' AND  Username = '" + username + "'";
            DataSet Mondaydata = Connect.getDataSet(GetMonday);
            DataViewDailyL.ReadOnly = true;
            DataViewDailyL.DataSource = Mondaydata.Tables[0];
        }

        private void btnMTuesday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker2.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Tuesday = Date.AddDays(1);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetTuesday = "SELECT [Crop_Name],[JobName],[amount] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Tuesday.ToShortDateString() + "' AND  Username = '" + username + "'";
            DataSet Tuesdaydata = Connect.getDataSet(GetTuesday);
            DataViewDailyL.ReadOnly = true;
            DataViewDailyL.DataSource = Tuesdaydata.Tables[0];
        }

        private void btnMWednesday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker2.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Wednesday = Date.AddDays(2);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetWednesday = "SELECT [Crop_Name],[JobName],[amount] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Wednesday.ToShortDateString() + "' AND  Username = '" + username + "'";
            DataSet Wednesdaydata = Connect.getDataSet(GetWednesday);
            DataViewDailyL.ReadOnly = true;
            DataViewDailyL.DataSource = Wednesdaydata.Tables[0];
        }

        private void btnMThursday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker2.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Thursday = Date.AddDays(3);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetThursday = "SELECT [Crop_Name],[JobName],[amount] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Thursday.ToShortDateString() + "' AND  Username = '" + username + "'";
            DataSet Thursdaydata = Connect.getDataSet(GetThursday);
            DataViewDailyL.ReadOnly = true;
            DataViewDailyL.DataSource = Thursdaydata.Tables[0];
        }

        private void btnMFriday_Click(object sender, EventArgs e)
        {
            string Datestring = dateTimePicker2.Text;
            DateTime Date = DateTime.Parse(Datestring);
            DateTime Friday = Date.AddDays(4);
            DatabaseClass Connect = DatabaseClass.Instance;
            String GetFriday = "SELECT [Crop_Name],[JobName],[amount] FROM [dbo].[Job]" + " JOIN Crop ON Job.CropID=Crop.CropID JOIN JobType ON Job.JobTypeId=JobType.JobtypeID JOIN users ON Job.UserID = users.UserID WHERE Date ='" + Friday.ToShortDateString() + "' AND  Username = '" + username + "'";
            DataSet Fridaydata = Connect.getDataSet(GetFriday);
            DataViewDailyL.ReadOnly = true;
            DataViewDailyL.DataSource = Fridaydata.Tables[0];
        }

        private void DataViewDailyL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

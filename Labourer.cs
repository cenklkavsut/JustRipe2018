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
    }
}

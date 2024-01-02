using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Parking_Ecosystem
{
    public partial class Carwash : Form
    {
        public Carwash()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Service Accepted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Service Accepted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Service Accepted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

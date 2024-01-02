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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Startpage()
        {
            Startpage startpageForm = new Startpage();
            startpageForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2ProgressBar1.Value < 100)
            {
                guna2ProgressBar1.Value += 1;
                label2.Text = guna2ProgressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                Startpage();
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

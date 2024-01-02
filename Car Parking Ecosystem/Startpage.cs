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
    public partial class Startpage : Form
    {
        public Startpage()
        {
            InitializeComponent();
        }

        private void Startpage_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            EmpLogin log = new EmpLogin();
            this.Hide();
            log.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Login LogForm = new Login();
            this.Hide();
            LogForm.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Registration RegistrationForm = new Registration();
            this.Hide();
            RegistrationForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

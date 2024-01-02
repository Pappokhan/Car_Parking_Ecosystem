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
    public partial class tk : Form
    {
        public tk()
        {
            InitializeComponent();
        }

        public void DisplayBookingData(string slot, string date_time, string name, string brand, string model, string year, string type, string plate, string how_long)
        {
            label1.Text = date_time;
            label19.Text = name;
            label20.Text = brand;
            label21.Text = model;
            label22.Text = year;
            label23.Text = type;
            label24.Text = plate;
            label11.Text = $"{slot}";
        }

        private void tk_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Payment pays = new Payment();
            pays.Show();
        }
    }
}

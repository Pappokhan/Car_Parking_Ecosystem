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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Customer back = new Customer();
            this.Hide();
            back.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = new string(textBox9.Text.Where(char.IsDigit).ToArray());
            if (IsCreditCardNumberValid(input))
            {
                textBox9.ForeColor = Color.Black;
            }
            else
            {
                textBox9.ForeColor = Color.Red;
            }
        }

        private bool IsCreditCardNumberValid(string creditCardNumber)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(creditCardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string cvc = textBox8.Text;
            if (IsCvcValid(cvc))
            {
                textBox8.ForeColor = Color.Black;
            }
            else
            {
                textBox8.ForeColor = Color.Red;
            }
        }

        private bool IsCvcValid(string cvc)
        {
            if (cvc.Length == 3 && cvc.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox7.Text.ToUpper();
            textBox7.SelectionStart = textBox7.Text.Length;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IsCreditCardNumberValid(textBox9.Text) && IsCvcValid(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && guna2DateTimePicker3.Value != null)
            {
                MessageBox.Show("Payment is successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields with valid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Card Payment is successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cash Payment is successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bikash Payment is successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nogod Payment is successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Customer cu = new Customer();
            cu.Show();
        }
    }
}

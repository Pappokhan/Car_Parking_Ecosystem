using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Car_Parking_Ecosystem
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox6.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox3.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox4.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox5.Text))
                {
                    MessageBox.Show("Please fill in all the fields before submitting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(guna2TextBox3.Text))
                {
                    MessageBox.Show("Please enter a valid email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidBangladeshiPhoneNumber(guna2TextBox4.Text))
                {
                    MessageBox.Show("Please enter a valid 11-digit phone number starting with 01.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidPassword(guna2TextBox6.Text))
                {
                    MessageBox.Show("Password must contain at least one special character & 8-digit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidBangladeshiNID(guna2TextBox2.Text))
                {
                    MessageBox.Show("Please enter a valid Bangladeshi NID (National ID) with 13 digits.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();

                    SqlCommand sq1 = new SqlCommand("INSERT INTO CUST(Name, Password, ID, Email, Phone_Number, Address) VALUES(@Name, @Password, @ID, @Email, @Phone_Number, @Address)", con);
                    sq1.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                    sq1.Parameters.AddWithValue("@Password", guna2TextBox6.Text);
                    sq1.Parameters.AddWithValue("@ID", guna2TextBox2.Text);
                    sq1.Parameters.AddWithValue("@Email", guna2TextBox3.Text);
                    sq1.Parameters.AddWithValue("@Phone_Number", guna2TextBox4.Text);
                    sq1.Parameters.AddWithValue("@Address", guna2TextBox5.Text);

                    sq1.ExecuteNonQuery();
                    MessageBox.Show("Your Registration is Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            this.Hide();
            LoginForm.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidBangladeshiPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^01\d{9}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[a-zA-Z0-9]).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidBangladeshiNID(string nid)
        {
            string nidPattern = @"^\d{13}$";
            return Regex.IsMatch(nid, nidPattern);
        }
    }
}

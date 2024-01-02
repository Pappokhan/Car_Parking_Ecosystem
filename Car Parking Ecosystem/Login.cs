using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Car_Parking_Ecosystem
{
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30");

        public Login()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registration RegistrationForm = new Registration();
            this.Hide();
            RegistrationForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please fill in all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    connect.Open();
                    String selectData = "select * from CUST WHERE Name = @Name AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
                        {
                            MessageBox.Show("Please fill in all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            
                            Customer cs = new Customer();
                            cs.SetLoggedInUser(guna2TextBox1.Text);

                            cs.CustomerName = reader["Name"].ToString();
                            cs.CustomerID = reader["ID"].ToString();
                            cs.CustomerEmail = reader["Email"].ToString();
                            cs.CustomerPhoneNumber = reader["Phone_Number"].ToString();
                            cs.CustomerAddress = reader["Address"].ToString();

                            cs.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = !guna2CheckBox1.Checked;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Startpage st = new Startpage();
            this.Hide();
            st.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

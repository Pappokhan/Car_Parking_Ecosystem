using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Car_Parking_Ecosystem
{
    public partial class EmpLogin : Form
    {
        public EmpLogin()
        {
            InitializeComponent();
            guna2CheckBox1.CheckedChanged += guna2CheckBox1_CheckedChanged;
        }

        private void EmpLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SubmitID();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                SubmitID();
                guna2Button1.PerformClick();
            }
            else
            {
                MessageBox.Show("Please show your ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SubmitID()
        {
            string enteredID = guna2TextBox1.Text;

            if (string.IsNullOrWhiteSpace(enteredID))
            {
                MessageBox.Show("Please enter an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string query = "SELECT * FROM EMPLOG WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", enteredID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Employee employeeForm = new Employee();
                                employeeForm.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

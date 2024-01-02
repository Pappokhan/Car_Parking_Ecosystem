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
    public partial class Employee : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30";
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
            ShowTotalSlots();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM CUST";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        guna2DataGridView1.DataSource = dataTable;
                        label6.Text = $"{dataTable.Rows.Count}";
                    }

                    string query1 = "SELECT * FROM BOOKED";
                    using (SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection))
                    {
                        DataTable dataTable1 = new DataTable();
                        adapter1.Fill(dataTable1);
                        guna2DataGridView2.DataSource = dataTable1;
                        label8.Text = $"{dataTable1.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2VScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ShowTotalSlots()
        {
            label9.Text = "300";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            Startpage start = new Startpage();
            this.Hide();
            start.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Please enter the ID to delete the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        string queryDelete = "DELETE FROM CUST WHERE ID = @ID";
                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, con))
                        {
                            cmdDelete.Parameters.AddWithValue("@ID", guna2TextBox1.Text);

                            int rowsAffected = cmdDelete.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        string queryRefresh = "SELECT * FROM CUST";
                        using (SqlCommand cmdRefresh = new SqlCommand(queryRefresh, con))
                        {
                            DataTable dtRefresh = new DataTable();
                            using (SqlDataReader sdrRefresh = cmdRefresh.ExecuteReader())
                            {
                                dtRefresh.Load(sdrRefresh);
                            }
                            guna2DataGridView1.DataSource = dtRefresh;
                        }

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) || string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                MessageBox.Show("Please enter the Name and Plate to delete the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string queryDelete = "DELETE FROM BOOKED WHERE Name = @Name AND Plate = @Plate";
                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, con))
                        {
                            cmdDelete.Parameters.AddWithValue("@Name", guna2TextBox2.Text);
                            cmdDelete.Parameters.AddWithValue("@Plate", guna2TextBox3.Text);

                            int rowsAffected = cmdDelete.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        string queryRefresh = "SELECT * FROM BOOKED";
                        using (SqlCommand cmdRefresh = new SqlCommand(queryRefresh, con))
                        {
                            DataTable dtRefresh = new DataTable();
                            using (SqlDataReader sdrRefresh = cmdRefresh.ExecuteReader())
                            {
                                dtRefresh.Load(sdrRefresh);
                            }
                            guna2DataGridView2.DataSource = dtRefresh;
                        }

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}

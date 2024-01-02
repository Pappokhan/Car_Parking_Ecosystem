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
    public partial class Admin : Form
    {
        private string userRole;
        public Admin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    SqlCommand sq1 = new SqlCommand("SELECT * FROM CUST", con);
                    DataTable dt1 = new DataTable();
                    using (SqlDataReader sdr1 = sq1.ExecuteReader())
                    {
                        dt1.Load(sdr1);
                    }
                    guna2DataGridView1.DataSource = dt1;
                    label13.Text = $"{dt1.Rows.Count}";

                    SqlCommand sq2 = new SqlCommand("SELECT * FROM BOOKED", con);
                    DataTable dt2 = new DataTable();
                    using (SqlDataReader sdr2 = sq2.ExecuteReader())
                    {
                        dt2.Load(sdr2);
                    }
                    guna2DataGridView2.DataSource = dt2;

                    SqlCommand sq3 = new SqlCommand("SELECT * FROM EMPLOG", con);
                    DataTable dt3 = new DataTable();

                    using (SqlDataReader sdr3 = sq3.ExecuteReader())
                    {
                        dt3.Load(sdr3);
                    }
                    dataGridView01.DataSource = dt3;
                    label3.Text = $"{dt3.Rows.Count}";

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView1.Show();
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) || 
                string.IsNullOrWhiteSpace(guna2TextBox3.Text) || 
                string.IsNullOrWhiteSpace(guna2TextBox4.Text) || 
                string.IsNullOrWhiteSpace(guna2TextBox5.Text) || 
                string.IsNullOrWhiteSpace(guna2TextBox6.Text) || 
                string.IsNullOrWhiteSpace(guna2ComboBox1.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string query = "INSERT INTO EMPLOG (ID, Name, Phone, Email, Address, Post) VALUES (@ID, @Name, @Phone, @Email, @Address, @Post)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@Name", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@Phone", guna2TextBox4.Text);
                        cmd.Parameters.AddWithValue("@Email", guna2TextBox5.Text);
                        cmd.Parameters.AddWithValue("@Address", guna2TextBox6.Text);
                        cmd.Parameters.AddWithValue("@Post", guna2ComboBox1.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record added successfully!");
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string query = "SELECT * FROM EMPLOG";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            dt.Load(sdr);
                        }
                        dataGridView01.DataSource = dt;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox11.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox10.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox9.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox8.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox7.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string queryUpdate = "UPDATE CUST SET Password = @Password, Name = @Name, Email = @Email, Phone_Number = @Phone, Address = @Address WHERE ID = @ID";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("@ID", guna2TextBox11.Text);
                        cmdUpdate.Parameters.AddWithValue("@Password", guna2TextBox1.Text);
                        cmdUpdate.Parameters.AddWithValue("@Name", guna2TextBox10.Text);
                        cmdUpdate.Parameters.AddWithValue("@Email", guna2TextBox9.Text);
                        cmdUpdate.Parameters.AddWithValue("@Phone", guna2TextBox8.Text);
                        cmdUpdate.Parameters.AddWithValue("@Address", guna2TextBox7.Text);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
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

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox11.Text))
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
                            cmdDelete.Parameters.AddWithValue("@ID", guna2TextBox11.Text);

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

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(guna2ComboBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        string.IsNullOrWhiteSpace(guna2ComboBox5.Text) ||
        string.IsNullOrWhiteSpace(guna2ComboBox3.Text) ||
        string.IsNullOrWhiteSpace(textBox6.Text) ||
        string.IsNullOrWhiteSpace(guna2ComboBox4.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string queryUpdate = "UPDATE BOOKED SET Brand = @Brand, Model = @Model, Year = @Year, Type = @Type, Plate = @Plate, How_Long = @How_Long WHERE Name = @Name";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmdUpdate.Parameters.AddWithValue("@Brand", guna2ComboBox2.Text);
                        cmdUpdate.Parameters.AddWithValue("@Model", textBox3.Text);
                        cmdUpdate.Parameters.AddWithValue("@Year", guna2ComboBox5.Text);
                        cmdUpdate.Parameters.AddWithValue("@Type", guna2ComboBox3.Text);
                        cmdUpdate.Parameters.AddWithValue("@Plate", textBox6.Text);
                        cmdUpdate.Parameters.AddWithValue("@How_Long", guna2ComboBox4.Text);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the Name to delete the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string queryDelete = "DELETE FROM BOOKED WHERE Name = @Name";
                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, con))
                        {
                            cmdDelete.Parameters.AddWithValue("@Name", textBox1.Text);

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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox3.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox4.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox5.Text) ||
        string.IsNullOrWhiteSpace(guna2TextBox6.Text) ||
        string.IsNullOrWhiteSpace(guna2ComboBox1.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string queryUpdate = "UPDATE EMPLOG SET Name = @Name, Phone = @Phone, Email = @Email, Address = @Address, Post = @Post WHERE ID = @ID";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("@ID", guna2TextBox2.Text);
                        cmdUpdate.Parameters.AddWithValue("@Name", guna2TextBox3.Text);
                        cmdUpdate.Parameters.AddWithValue("@Phone", guna2TextBox4.Text);
                        cmdUpdate.Parameters.AddWithValue("@Email", guna2TextBox5.Text);
                        cmdUpdate.Parameters.AddWithValue("@Address", guna2TextBox6.Text);
                        cmdUpdate.Parameters.AddWithValue("@Post", guna2ComboBox1.Text);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string queryRefresh = "SELECT * FROM EMPLOG";
                    using (SqlCommand cmdRefresh = new SqlCommand(queryRefresh, con))
                    {
                        DataTable dtRefresh = new DataTable();
                        using (SqlDataReader sdrRefresh = cmdRefresh.ExecuteReader())
                        {
                            dtRefresh.Load(sdrRefresh);
                        }
                        dataGridView01.DataSource = dtRefresh;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
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
                        string queryDelete = "DELETE FROM EMPLOG WHERE ID = @ID";
                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, con))
                        {
                            cmdDelete.Parameters.AddWithValue("@ID", guna2TextBox2.Text);

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

                        string queryRefresh = "SELECT * FROM EMPLOG";
                        using (SqlCommand cmdRefresh = new SqlCommand(queryRefresh, con))
                        {
                            DataTable dtRefresh = new DataTable();
                            using (SqlDataReader sdrRefresh = cmdRefresh.ExecuteReader())
                            {
                                dtRefresh.Load(sdrRefresh);
                            }
                            dataGridView01.DataSource = dtRefresh;
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

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Car_Parking_Ecosystem
{
    public partial class Customer : Form
    {
        public string CustomerName
        {
            set { label3.Text = value; }
        }

        public string CustomerID
        {
            set { label4.Text = value; }
        }

        public string CustomerEmail
        {
            set { label5.Text = value; }
        }

        public string CustomerPhoneNumber
        {
            set { label6.Text = value; }
        }

        public string CustomerAddress
        {
            set { label7.Text = value; }
        }


        public Customer()
        {
            InitializeComponent();
            guna2GradientButton2.Click += guna2GradientButton2_Click;
        }

        public void SetLoggedInUser(string userName)
        {
            Name = userName;
            label2.Text = $"Welcome, {Name}!";
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_lot(object sender, KeyPressEventArgs e)
        {
            Registration RegistrationForm = new Registration();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            RefreshChart();
            label31.Text = "300";

            label38.Text = string.Empty;
            label39.Text = string.Empty;
            label40.Text = string.Empty;
            label41.Text = string.Empty;
            label42.Text = string.Empty;
            label43.Text = string.Empty;
            label44.Text = string.Empty;
            label45.Text = string.Empty;
            label46.Text = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();
                    int totalCustomers = GetTotalCustomerRows(connection);
                    label33.Text = $"{totalCustomers}";
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..." + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2DateTimePicker1.Text) ||
                    string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(guna2ComboBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(guna2ComboBox4.Text) ||
                    string.IsNullOrWhiteSpace(guna2ComboBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(guna2ComboBox1.Text))
                {
                    MessageBox.Show("Please fill in all the fields before submitting.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();
                    int slotNumber = GenerateUniqueSlotNumber(connection);

                    // Save booking data to the BOOKED table
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO BOOKED(Slot, Date_Time, Name, Brand, Model, Year, Type, Plate, How_Long) VALUES(@Slot, @Date_Time, @Name, @Brand, @Model, @Year, @Type, @Plate, @How_Long)", connection);
                    insertCommand.Parameters.AddWithValue("@Slot", $"SLOT-{slotNumber}");
                    insertCommand.Parameters.AddWithValue("@Date_Time", guna2DateTimePicker1.Text);
                    insertCommand.Parameters.AddWithValue("@Name", textBox1.Text);
                    insertCommand.Parameters.AddWithValue("@Brand", guna2ComboBox2.Text);
                    insertCommand.Parameters.AddWithValue("@Model", textBox3.Text);
                    insertCommand.Parameters.AddWithValue("@Year", guna2ComboBox4.Text);
                    insertCommand.Parameters.AddWithValue("@Type", guna2ComboBox3.Text);
                    insertCommand.Parameters.AddWithValue("@Plate", textBox6.Text);
                    insertCommand.Parameters.AddWithValue("@How_Long", guna2ComboBox1.Text);

                    insertCommand.ExecuteNonQuery();

                    // Display booking details in labels
                    label38.Text = $"Slot: SLOT-{slotNumber}";
                    label39.Text = $"Date and Time: {guna2DateTimePicker1.Text}";
                    label40.Text = $"Name: {textBox1.Text}";
                    label41.Text = $"Brand: {guna2ComboBox2.Text}";
                    label42.Text = $"Model: {textBox3.Text}";
                    label43.Text = $"Year: {guna2ComboBox4.Text}";
                    label44.Text = $"Type: {guna2ComboBox3.Text}";
                    label45.Text = $"Plate: {textBox6.Text}";
                    label46.Text = $"How Long: {guna2ComboBox1.Text}";

                    MessageBox.Show("Booking Successful!");
                    RefreshChart();
                }
                RefreshChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void RefreshChart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\MYSQL.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();

                    SqlCommand sq1 = new SqlCommand("SELECT Slot, COUNT(*) AS BookingCount FROM BOOKED GROUP BY Slot", con);
                    DataTable dt1 = new DataTable();
                    using (SqlDataReader sdr1 = sq1.ExecuteReader())
                    {
                        dt1.Load(sdr1);
                    }

                    List<string> allSlots = new List<string>();
                    for (int i = 1; i <= 300; i++)
                    {
                        allSlots.Add($"SLOT-{i}");
                    }

                    int totalBookings = dt1.AsEnumerable().Sum(row => row.Field<int>("BookingCount"));
                    label30.Text = $"{totalBookings}";

                    int remainingSlots = 300 - totalBookings;
                    label32.Text = $"{remainingSlots}";

                    var mergedData = allSlots.GroupJoin(dt1.AsEnumerable(),
                        allSlot => allSlot,
                        bookedSlotGroup => bookedSlotGroup.Field<string>("Slot"),
                        (allSlot, bookedSlotGroup) => new
                        {
                            Slot = allSlot,
                            BookingCount = bookedSlotGroup.Sum(row => row?.Field<int>("BookingCount") ?? 0)
                        });

                    chart1.DataSource = mergedData.ToList();
                    chart1.Series.Clear();
                    chart1.Series.Add("Bookings");
                    chart1.Series["Bookings"].XValueMember = "Slot";
                    chart1.Series["Bookings"].YValueMembers = "BookingCount";
                    chart1.DataBind();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private int GenerateUniqueSlotNumber(SqlConnection connection)
        {
            string query = "SELECT MAX(CAST(SUBSTRING(Slot, CHARINDEX('-', Slot) + 1, LEN(Slot) - CHARINDEX('-', Slot)) AS INT)) FROM BOOKED";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return Convert.ToInt32(result) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            tk t = new tk();
            t.DisplayBookingData(label38.Text, label39.Text, label40.Text, label41.Text, label42.Text, label43.Text, label44.Text, label45.Text, label46.Text);
            t.ShowDialog();
        }


        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Food foodForm = new Food();
            foodForm.ShowDialog();
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Carwash cars = new Carwash();
            cars.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login back = new Login();
            this.Hide();
            back.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Payment pays = new Payment();
            this.Hide();
            pays.Show();
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {
            label31.Text = "300";
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private int GetTotalCustomerRows(SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM CUST", connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return 0;
            }
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Startpage lg = new Startpage();
                this.Hide();
                lg.Show();
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Startpage st = new Startpage();
            st.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            EditInfo ed = new EditInfo();
            ed.Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using project_clz.Model;
using System.Collections;
using System.Net;

namespace project_clz
{
    public partial class Report : Form
    {
        private string connectionString;

        public Report()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            //Populate ComboBox on form load
            FetchDataStudent();
            FetchDataBook();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Report_Load(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }


        // FOR STUDENT DETAIL

        private void FetchDataStudent()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var data = db.Query<User>("SELECT ID, FirstName, LastName, ContactNumber FROM STUDENTDETAIL");

                    // Check if data contains any items
                    if (data != null && data.Any())
                    {
                        comboBox1.DataSource = null; // Clear existing DataSource
                        comboBox1.Items.Clear(); // Clear existing items
                        comboBox1.DataSource = data.ToList();
                        comboBox1.ValueMember = "ID";
                        comboBox1.DisplayMember = "ID";
                        comboBox1.SelectedIndex = 0; // No selection by default
                    }
                    else
                    {
                        MessageBox.Show("No data found in STUDENTDETAIL.");
                        comboBox1.DataSource = null;
                        comboBox1.Items.Clear();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private void fetchingID()
        {
            try
            {
                var x = comboBox1.SelectedItem as User;
                if (x != null && !string.IsNullOrEmpty(comboBox1.Text))
                {
                    textBox4.Text = $"{x.FirstName} {x.LastName}".Trim();
                    textBox3.Text = x.ContactNumber;
                    // Debug: Log the fetched data
                    Console.WriteLine($"Fetched: ID={x.ID}, Name={textBox4.Text}, Contact={x.ContactNumber}");
                }
                else
                {
                    textBox4.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    MessageBox.Show("No item selected or invalid ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying data: {ex.Message}");
            }
        }





        // FOR BOOK DETAIL
        private void FetchDataBook()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var data = db.Query<Book>("SELECT BookId, BookName, Faculty, Semester FROM BookDetail");

                    // Check if data contains any items
                    if (data != null && data.Any())
                    {
                        comboBox2.DataSource = null; // Clear existing DataSource
                        comboBox2.Items.Clear(); // Clear existing items
                        comboBox2.DataSource = data.ToList();
                        comboBox2.ValueMember = "BookId"; // Changed from "ID" to "BookId"
                        comboBox2.DisplayMember = "BookId"; // Changed from "ID" to "BookId"
                        comboBox2.SelectedIndex = 0; // No selection by default
                    }
                    else
                    {
                        MessageBox.Show("No data found in Book Detail");
                        comboBox2.DataSource = null;
                        comboBox2.Items.Clear();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private void fetchingBookData()
        {
            try
            {
                var y = comboBox2.SelectedItem as Book;
                if (y != null && !string.IsNullOrEmpty(comboBox2.Text))
                {
                    textBox5.Text = y.BookName;
                    textBox1.Text = y.Semester;
                    textBox6.Text = y.Faculty;
                    // Debug: Log the fetched data
                    Console.WriteLine($"Fetched: ID={y.BookId}, Name={y.BookName}, SEm={y.Semester}, faculty={y.Faculty}");
                }
                else
                {
                    textBox5.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    MessageBox.Show("No item selected or invalid ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying data: {ex.Message}");
            }
        }





        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //
            ReturnBook();
            fetchDataInTable();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //   fetchingID();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            fetchingID();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchingBookData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDate();
        }

        // SAVING DATA OF ISSUE BOOK FOR STUDENT

        private void SaveDate()
        {
            string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
            string query = @"INSERT INTO LibraryRecords (StudentID, StudentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, IssueID)
                 VALUES (@stId, @stname, @contact, @bookId, @bookName, @faculty, @semester, @issueDate, @issueId)";

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Bind parameters with values from text boxes and controls
                        cmd.Parameters.AddWithValue("@stId", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@stname", textBox4.Text);
                        cmd.Parameters.AddWithValue("@contact", textBox3.Text);
                        cmd.Parameters.AddWithValue("@issueDate", dateTimePicker1.Value); // Assuming dateTimePicker1 is a DateTimePicker control
                        cmd.Parameters.AddWithValue("@issueId", textBox2.Text);
                        cmd.Parameters.AddWithValue("@bookId", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@bookName", textBox5.Text);
                        cmd.Parameters.AddWithValue("@semester", textBox1.Text);
                        cmd.Parameters.AddWithValue("@faculty", textBox6.Text);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record inserted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were inserted.");
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            fetchDataInTable();
        }


        //FETCH DATA FOR RETURN
        private void ReturnBook()
        {
            try
            {
                string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True"; //DESKTOP-LG8ALSU\SQLEXPRESS
                using (SqlConnection con = new SqlConnection(conStr))
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var data2 = db.Query<IssueBook>("SELECT * FROM LibraryRecords");// StudentID, StudentName, Contact, BookID,BookName,Faculty,Semester

                    // Check if data contains any items
                    if (data2 != null && data2.Any())
                    {
                        comboBox3.DataSource = null; // Clear existing DataSource
                        comboBox3.Items.Clear(); // Clear existing items
                        comboBox3.DataSource = data2.ToList();
                        comboBox3.ValueMember = "StudentID"; // Changed from "ID" to "BookId"
                        comboBox3.DisplayMember = "StudentID"; // Changed from "ID" to "BookId"
                        comboBox3.SelectedIndex = 0; // No selection by default
                    }
                    else
                    {
                        MessageBox.Show("No data found in Book Detail");
                        comboBox3.DataSource = null;
                        comboBox3.Items.Clear();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }
        void fetchDataInTable()
        {
            var x = comboBox3.SelectedItem as IssueBook;
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                textBox10.Text = x.StudentName;
                textBox9.Text = x.Contact;
               // dateTimePicker2= x.IssueDate;
                comboBox4.Text = x.BookID;
                textBox12.Text = x.BookName;
                textBox8.Text = x.Semester;
                textBox9.Text = x.Faculty;

                // Handle photo
               
               
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
         

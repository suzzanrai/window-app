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
using System.Transactions;

namespace project_clz
{
    public partial class Form5 : Form
    {
        private string connectionString;

        public Form5()
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
                        comboBox4.DataSource = null; // Clear existing DataSource
                        comboBox4.Items.Clear(); // Clear existing items
                        comboBox4.DataSource = data.ToList();
                        comboBox4.ValueMember = "ID";
                        comboBox4.DisplayMember = "ID";
                        comboBox4.SelectedIndex = 0; // No selection by default
                    }
                    else
                    {
                        MessageBox.Show("No data found in STUDENTDETAIL.");
                        comboBox4.DataSource = null;
                        comboBox4.Items.Clear();
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
                var x = comboBox4.SelectedItem as User;
                if (x != null && !string.IsNullOrEmpty(comboBox4.Text))
                {
                    textBox11.Text = $"{x.FirstName} {x.LastName}".Trim();
                    textBox10.Text = x.ContactNumber;
                    // Debug: Log the fetched data
                    Console.WriteLine($"Fetched: ID={x.ID}, Name={textBox11.Text}, Contact={x.ContactNumber}");
                }
                else
                {
                    textBox11.Text = string.Empty;
                    textBox10.Text = string.Empty;
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
                    var data = db.Query<Book>("SELECT BookId, BookName, Faculty, Semester, Quantity FROM BookDetail");

                    // Check if data contains any items
                    if (data != null && data.Any())
                    {
                        comboBox3.DataSource = null; // Clear existing DataSource
                        comboBox3.Items.Clear(); // Clear existing items
                        comboBox3.DataSource = data.ToList();
                        comboBox3.ValueMember = "BookId"; // Changed from "ID" to "BookId"
                        comboBox3.DisplayMember = "BookId"; // Changed from "ID" to "BookId"
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

        // Fix for CS0029: Cannot implicitly convert type 'int' to 'string'
        // Update the assignment to convert the integer value to a string using the ToString() method.

        private void fetchingBookData()
        {
            try
            {
                var y = comboBox3.SelectedItem as Book;
                if (y != null && !string.IsNullOrEmpty(comboBox3.Text))
                {
                    textBox12.Text = y.BookName;
                    textBox9.Text = y.Semester;
                    textBox8.Text = y.Faculty;
                    textBox1.Text = y.Quantity.ToString(); // Convert int to string
                    // Debug: Log the fetched data
                    Console.WriteLine($"Fetched: ID={y.BookId}, Name={y.BookName}, SEm={y.Semester}, faculty={y.Faculty}");
                }
                else
                {
                    textBox12.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    textBox8.Text = string.Empty;
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

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    fetchingID();
        //}

        //private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fetchingBookData();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDate();
        }

        // SAVING DATA OF ISSUE BOOK FOR STUDENT

        //private void SaveDate()
        //{
        //    string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
        //    string query = @"INSERT INTO LibraryRecords (StudentID, StudentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, IssueID)
        //         VALUES (@stId, @stname, @contact, @bookId, @bookName, @faculty, @semester, @issueDate, @issueId)";

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conStr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                // Bind parameters with values from text boxes and controls
        //                cmd.Parameters.AddWithValue("@stId", comboBox4.Text);
        //                cmd.Parameters.AddWithValue("@stname", textBox11.Text);
        //                cmd.Parameters.AddWithValue("@contact", textBox10.Text);
        //                cmd.Parameters.AddWithValue("@issueDate", dateTimePicker2.Value); // Assuming dateTimePicker1 is a DateTimePicker control
        //                cmd.Parameters.AddWithValue("@issueId", textBox7.Text);
        //                cmd.Parameters.AddWithValue("@bookId", comboBox3.Text);
        //                cmd.Parameters.AddWithValue("@bookName", textBox12.Text);
        //                cmd.Parameters.AddWithValue("@semester", textBox9.Text);
        //                cmd.Parameters.AddWithValue("@faculty", textBox8.Text);

        //                con.Open();
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Record inserted successfully.");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No rows were inserted.");
        //                }

        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred: {ex.Message}");
        //    }

        //}



        private void SaveDate()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Validate inputs
                            if (string.IsNullOrWhiteSpace(comboBox4.Text) || string.IsNullOrWhiteSpace(comboBox3.Text))
                            {
                                MessageBox.Show("Please select a student ID and book ID.", "Input Error");
                                return;
                            }

                            if (!int.TryParse(comboBox4.Text, out int studentId))
                            {
                                MessageBox.Show("Invalid Student ID format.", "Input Error");
                                return;
                            }

                            if (!int.TryParse(comboBox3.Text, out int bookId))
                            {
                                MessageBox.Show("Invalid Book ID format.", "Input Error");
                                return;
                            }

                            // Check if book quantity is available
                            string checkQuantityQuery = "SELECT Quantity FROM BookDetail WHERE BookId = @BookId";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuantityQuery, con, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@BookId", bookId);
                                object result = checkCmd.ExecuteScalar();
                                if (result == null || Convert.ToInt32(result) <= 0)
                                {
                                    MessageBox.Show("The selected book is out of stock.", "Stock Error");
                                    return;
                                }
                            }


                            // Check if the book is already taken by the student
                            string checkExistingQuery = "SELECT COUNT(*) FROM LibraryRecords WHERE StudentID = @StudentId AND BookID = @BookId";
                            using (SqlCommand checkExistingCmd = new SqlCommand(checkExistingQuery, con, transaction))
                            {
                                checkExistingCmd.Parameters.AddWithValue("@StudentId", studentId);
                                checkExistingCmd.Parameters.AddWithValue("@BookId", bookId);
                                int existingCount = Convert.ToInt32(checkExistingCmd.ExecuteScalar());
                                if (existingCount > 0)
                                {
                                    MessageBox.Show("This book is already taken by the selected student.", "Error");
                                    return;
                                }
                            }

                            // Insert into LibraryRecords
                            string insertQuery = @"INSERT INTO LibraryRecords (StudentID, StudentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, IssueID)
                                                  VALUES (@stId, @stname, @contact, @bookId, @bookName, @faculty, @semester, @issueDate, @issueId)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@stId", studentId);
                                insertCmd.Parameters.AddWithValue("@stname", textBox11.Text);
                                insertCmd.Parameters.AddWithValue("@contact", textBox10.Text);
                                insertCmd.Parameters.AddWithValue("@issueDate", dateTimePicker2.Value);
                                insertCmd.Parameters.AddWithValue("@issueId", textBox7.Text ?? string.Empty);
                                insertCmd.Parameters.AddWithValue("@bookId", bookId);
                                insertCmd.Parameters.AddWithValue("@bookName", textBox12.Text);
                                insertCmd.Parameters.AddWithValue("@semester", textBox9.Text);
                                insertCmd.Parameters.AddWithValue("@faculty", textBox8.Text);

                                int rowsAffected = insertCmd.ExecuteNonQuery();
                                if (rowsAffected <= 0)
                                {
                                    MessageBox.Show("No rows were inserted into LibraryRecords.", "Error");
                                    return;
                                }
                            }

                            // Decrease quantity in BookDetail
                            string updateQuery = "UPDATE BookDetail SET Quantity = Quantity - 1 WHERE BookId = @BookId";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@BookId", bookId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();
                            MessageBox.Show("Record inserted successfully and book quantity updated.", "Success");

                            // Refresh book data to reflect updated quantity
                            FetchDataBook();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction on error
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                        }
                    }
                    con.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error");
            }
            catch (Exception ex)
            {
               MessageBox.Show($"An error occurred: {ex.Message}", "Error");
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
                dateTimePicker2.Value = x.IssueDate; // Assign IssueDate to dateTimePicker2
                textBox7.Text = x.Contact;
                comboBox4.Text = x.BookID.ToString(); 
                textBox12.Text = x.BookName;
                textBox8.Text = x.Semester;
                textBox9.Text = x.Faculty;

                // Handle photo


            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

  
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fetchingBookData();

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fetchingID();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


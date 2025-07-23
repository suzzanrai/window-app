


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using MySql.Data.MySqlClient;
using project_clz.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DbShell.Driver.Common.CommonDataLayer;
using Google.Protobuf.WellKnownTypes;
using Mysqlx.Crud;
using System.Collections;
using Dapper;
using Microsoft.IdentityModel.Tokens;


namespace project_clz
{
    public partial class Form6 : Form
    {
        private string connectionString;
        private object textBox7;

        public Form6()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            fetchcomplaindata();

            fetchDataInTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               SaveDate();
        }

        private void SaveDate()
        {
            //string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
            //string query = @"INSERT INTO ReturnBook (studentID, studentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, ReturnDate)
            //     VALUES (@stId, @stname, @contact, @bookId, @bookName, @faculty, @semester, @issueDate, @returnDate)";

            //try
            //{
            //    using (SqlConnection con = new SqlConnection(conStr))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(query, con))
            //        {
            //            // Bind parameters with values from text boxes and controls
            //            cmd.Parameters.AddWithValue("@stId", comboBox4.Text);
            //            cmd.Parameters.AddWithValue("@stname", textBox11.Text);
            //            cmd.Parameters.AddWithValue("@contact", textBox10.Text);
            //            cmd.Parameters.AddWithValue("@issueDate", dateTimePicker2.Value); 
            //            cmd.Parameters.AddWithValue("@returnDate", dateTimePicker1.Value);

            //            // Assuming dateTimePicker1 is a DateTimePicker control
            //            //cmd.Parameters.AddWithValue("@issueId", textBox7.Text);
            //            cmd.Parameters.AddWithValue("@bookId", comboBox3.Text);
            //            cmd.Parameters.AddWithValue("@bookName", textBox12.Text);
            //            cmd.Parameters.AddWithValue("@semester", textBox9.Text);
            //            cmd.Parameters.AddWithValue("@faculty", textBox8.Text);

            //            con.Open();
            //            int rowsAffected = cmd.ExecuteNonQuery();
            //            if (rowsAffected > 0)
            //            {
            //                MessageBox.Show("Record inserted successfully.");
            //            }
            //            else
            //            {
            //                MessageBox.Show("No rows were inserted.");
            //            }


            //            con.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //}

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

                            // Check if book exists in BookDetail
                            string checkBookQuery = "SELECT COUNT(*) FROM BookDetail WHERE BookId = @BookId";
                            using (SqlCommand checkCmd = new SqlCommand(checkBookQuery, con, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@BookId", bookId);
                                int bookCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                                if (bookCount == 0)
                                {
                                    MessageBox.Show("The selected book does not exist in BookDetail.", "Error");
                                    return;
                                }
                            }
                            // Delete from LibraryRecords
                            string deleteQuery = "DELETE FROM LibraryRecords WHERE StudentID = @studentId AND BookID = @bookId";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@studentId", studentId);
                                deleteCmd.Parameters.AddWithValue("@bookId", bookId);
                                deleteCmd.ExecuteNonQuery();
                            }
                            // Insert into ReturnBook
                            string insertQuery = @"INSERT INTO ReturnBook (studentID, studentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, ReturnDate)
                                                  VALUES (@stId, @stname, @contact, @bookId, @bookName, @faculty, @semester, @issueDate, @returnDate)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@stId", studentId);
                                insertCmd.Parameters.AddWithValue("@stname", textBox11.Text);
                                insertCmd.Parameters.AddWithValue("@contact", textBox10.Text);
                                insertCmd.Parameters.AddWithValue("@issueDate", dateTimePicker2.Value);
                                insertCmd.Parameters.AddWithValue("@returnDate", dateTimePicker1.Value);
                                insertCmd.Parameters.AddWithValue("@bookId", bookId);
                                insertCmd.Parameters.AddWithValue("@bookName", textBox12.Text);
                                insertCmd.Parameters.AddWithValue("@semester", textBox9.Text);
                                insertCmd.Parameters.AddWithValue("@faculty", textBox8.Text);

                                int rowsAffected = insertCmd.ExecuteNonQuery();
                                if (rowsAffected <= 0)
                                {
                                    MessageBox.Show("No rows were inserted into ReturnBook.", "Error");
                                    return;
                                }
                            }

                            // Increase quantity in BookDetail
                            string updateQuery = "UPDATE BookDetail SET Quantity = Quantity + 1 WHERE BookId = @BookId";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@BookId", bookId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();
                            MessageBox.Show("Record inserted successfully and book quantity updated.", "Success");

                            // Refresh book data to reflect updated quantity
                            fetchBookIdsForStudent();
                        }
                        catch (Exception ex)
                        {
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

        public void fetchcomplaindata()
        {
            try
            {
                string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(conStr))
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    // Fetch only unique StudentIDs with associated first record details
                    //var data = db.Query<IssueBook>(@"
                    //    SELECT StudentID, StudentName, Contact, IssueDate, BookID, BookName, Semester, Faculty
                    //    FROM LibraryRecords
                    //    WHERE StudentID IN (
                    //        SELECT DISTINCT StudentID FROM LibraryRecords
                    //    )");



                    // Fetch only students with at least one active book in LibraryRecords
                    var data = db.Query<IssueBook>(@"
                        SELECT DISTINCT lr.StudentID, lr.StudentName, lr.Contact, lr.IssueDate, lr.BookID, lr.BookName, lr.Semester, lr.Faculty
                        FROM LibraryRecords lr
                        WHERE EXISTS (
                            SELECT 1 FROM LibraryRecords lr2 
                            WHERE lr2.StudentID = lr.StudentID
                        )");
                    if (data != null && data.Any())
                    {
                        // Group by StudentID to ensure only one entry per ID (using First or Last record)
                        var uniqueData = data.GroupBy(x => x.StudentID)
                                           .Select(g => g.First())
                                           .ToList();

                        comboBox4.DataSource = uniqueData;
                        comboBox4.ValueMember = "StudentID";
                        comboBox4.DisplayMember = "StudentID"; // Displays unique StudentIDs
                        comboBox4.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No data found.");
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }


        // New method to fetch all BookIDs for the selected StudentID
        // New method to fetch all BookIDs for the selected StudentID
        // New method to fetch all BookIDs for the selected StudentID
        private void fetchBookIdsForStudent()
        {
            try
            {
                string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var selectedStudent = comboBox4.SelectedItem as IssueBook;
                    if (selectedStudent != null && !string.IsNullOrEmpty(selectedStudent.StudentID.ToString()))
                    {
                        var bookData = db.Query<IssueBook>(@"
                    SELECT BookID, BookName, Faculty, Semester, IssueDate
                    FROM LibraryRecords
                    WHERE StudentID = @StudentID",
                            new { StudentID = selectedStudent.StudentID.ToString() }); // Fixed line

                        if (bookData != null && bookData.Any())
                        {
                            comboBox3.DataSource = bookData.ToList();
                            comboBox3.ValueMember = "BookID";
                            comboBox3.DisplayMember = "BookID"; // Still display BookID, but data includes Faculty and Semester
                            comboBox3.SelectedIndex = 0;
                            // Update fields based on the first selected BookID
                            var firstBook = comboBox3.SelectedItem as IssueBook;
                            textBox12.Text = firstBook?.BookName ?? string.Empty;
                            textBox9.Text = firstBook?.Semester ?? string.Empty;
                            textBox8.Text = firstBook?.Faculty ?? string.Empty;
                            //dateTimePicker2.Value = firstBook?.IssueDate ?? DateTime.Now;                     
                        }
                        else
                        {
                            comboBox3.DataSource = null;
                            comboBox3.Text = string.Empty;
                            textBox12.Text = string.Empty;
                            textBox9.Text = string.Empty;
                            textBox8.Text = string.Empty;
                            MessageBox.Show("No books found for this student.");
                        }
                    }
                    else
                    {
                        comboBox3.DataSource = null;
                        comboBox3.Text = string.Empty;
                        textBox12.Text = string.Empty;
                        textBox9.Text = string.Empty;
                        textBox8.Text = string.Empty;
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching book data: " + ex.Message);
            }
        }

      
        void fetchDataInTable()
        {
            var x = comboBox4.SelectedItem as IssueBook;
            if (!string.IsNullOrEmpty(comboBox4.Text))
            {
                textBox11.Text = x.StudentName;
                textBox10.Text = x.Contact;
                dateTimePicker2.Value = x.IssueDate;
                // comboBox3.Text = x.BookID;
                fetchBookIdsForStudent();
                textBox12.Text = x.BookName;
                textBox9.Text = x.Semester;
                textBox8.Text = x.Faculty;
            }
            else
            {
                textBox11.Text = string.Empty;
                textBox10.Text = string.Empty;
                // dateTimePicker2 = x.IssueDate;
                comboBox3.Text = string.Empty;
                textBox12.Text = string.Empty;
                textBox9.Text = string.Empty;
                textBox8.Text = string.Empty;

                MessageBox.Show("No item selected or invalid ID.");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchDataInTable();

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            var x = comboBox3.SelectedItem as IssueBook;
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                textBox12.Text = x.BookName;
                textBox9.Text = x.Semester;
                textBox8.Text = x.Faculty;
                dateTimePicker2.Value = x.IssueDate;
                //dateTimePicker2.Value = x.IssueDate;
            }
            else
            {
                textBox12.Text = string.Empty;
                textBox9.Text = string.Empty;
                textBox8.Text = string.Empty;
                MessageBox.Show("No item selected or invalid ID.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
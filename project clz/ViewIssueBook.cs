using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using project_clz.Model;
using System.Collections.Generic;

namespace project_clz
{
    public partial class ViewIssueBook : Form
    {
        private string connectionString;

        public ViewIssueBook()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string 'myconn' is missing or invalid.");
                return;
            }

            // Load issue records when form loads
            this.Load += ViewIssueBook_Load;
        }

        private void ViewIssueBook_Load(object sender, EventArgs e)
        {
            LoadIssueRecordsIntoGrid();
        }

        private void LoadIssueRecordsIntoGrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT  StudentId, StudentName, BookId, IssueDate FROM LibraryRecords";

                    var issueRecords = connection.Query<IssueBook>(query).ToList();

                    dataGridView1.AutoGenerateColumns = false; // Prevent auto-columns
                    dataGridView1.Columns.Clear();             // Remove any existing columns
                    dataGridView1.DataSource = issueRecords;

                    // Add only required columns
                    //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    //{
                    //    DataPropertyName = "IssueId",
                    //    HeaderText = "Issue ID"
                    //});
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StudentId",
                        HeaderText = "Student ID"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StudentName",
                        HeaderText = "Student Name"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "BookId",
                        HeaderText = "Book ID"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "IssueDate",
                        HeaderText = "Issue Date"
                    });
                    //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    //{
                    //    DataPropertyName = "ReturnDate",
                    //    HeaderText = "Return Date"
                    //});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading issue records: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentId = textBox1.Text.Trim();
            string studentName = textBox2.Text.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT  StudentId, StudentName, BookId, IssueDate 
                                    FROM LibraryRecords 
                                    WHERE (@StudentId = '' OR StudentId = @StudentId) 
                                    AND (@StudentName = '' OR StudentName LIKE @SearchName)";

                    var issueRecords = connection.Query<IssueBook>(query, new
                    {
                        StudentId = studentId,
                        StudentName = studentName,
                        SearchName = "%" + studentName + "%"
                    }).ToList();

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = issueRecords;

                    // Re-add columns
                   // dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueId", HeaderText = "Issue ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentId", HeaderText = "Student ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Student Name" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookId", HeaderText = "Book ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueDate", HeaderText = "Issue Date" });
                   // dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReturnDate", HeaderText = "Return Date" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            LoadIssueRecordsIntoGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle click events on DataGridView cells
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string studentId = textBox1.Text.Trim();
            string studentName = textBox2.Text.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT  StudentId, StudentName, BookId, IssueDate 
                                    FROM LibraryRecords 
                                    WHERE (@StudentId = '' OR StudentId = @StudentId) 
                                    AND (@StudentName = '' OR StudentName LIKE @SearchName)";

                    var issueRecords = connection.Query<IssueBook>(query, new
                    {
                        StudentId = studentId,
                        StudentName = studentName,
                        SearchName = "%" + studentName + "%"
                    }).ToList();

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = issueRecords;

                    // Re-add columns
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueId", HeaderText = "Issue ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentId", HeaderText = "Student ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Student Name" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookId", HeaderText = "Book ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueDate", HeaderText = "Issue Date" });
                   // dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReturnDate", HeaderText = "Return Date" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
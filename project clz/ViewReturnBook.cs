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
    public partial class ViewReturnBook : Form
    {
        private string connectionString;

        public ViewReturnBook()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string 'myconn' is missing or invalid.");
                return;
            }

            // Load return records when form loads
            this.Load += ViewReturnBook_Load;
        }

        private void ViewReturnBook_Load(object sender, EventArgs e)
        {
            LoadReturnRecordsIntoGrid();
        }

        private void LoadReturnRecordsIntoGrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT StudentID, StudentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, ReturnDate FROM ReturnBook";

                    var returnRecords = connection.Query<ReturnBook>(query).ToList();

                    dataGridView1.AutoGenerateColumns = false; // Prevent auto-columns
                    dataGridView1.Columns.Clear();             // Remove any existing columns
                    dataGridView1.DataSource = returnRecords;

                    // Add only required columns
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StudentID",
                        HeaderText = "Student ID"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StudentName",
                        HeaderText = "Student Name"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Contact",
                        HeaderText = "Contact"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "BookID",
                        HeaderText = "Book ID"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "BookName",
                        HeaderText = "Book Name"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Faculty",
                        HeaderText = "Faculty"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Semester",
                        HeaderText = "Semester"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "IssueDate",
                        HeaderText = "Issue Date"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "ReturnDate",
                        HeaderText = "Return Date"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading return records: " + ex.Message);
            }
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

                    string query = @"SELECT StudentID, StudentName, Contact, BookID, BookName, Faculty, Semester, IssueDate, ReturnDate 
                                    FROM ReturnBook 
                                    WHERE (@StudentID = '' OR StudentID = @StudentID) 
                                    AND (@StudentName = '' OR StudentName LIKE @SearchName)";

                    var returnRecords = connection.Query<ReturnBook>(query, new
                    {
                        StudentID = studentId,
                        StudentName = studentName,
                        SearchName = "%" + studentName + "%"
                    }).ToList();

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = returnRecords;

                    // Re-add columns
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentID", HeaderText = "Student ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Student Name" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Contact", HeaderText = "Contact" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookID", HeaderText = "Book ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookName", HeaderText = "Book Name" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Faculty", HeaderText = "Faculty" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Semester", HeaderText = "Semester" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueDate", HeaderText = "Issue Date" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReturnDate", HeaderText = "Return Date" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            LoadReturnRecordsIntoGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle click events on DataGridView cells
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
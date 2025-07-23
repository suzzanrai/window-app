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
    public partial class ViewBook : Form
    {
        private string connectionString;

        public ViewBook()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string 'myconn' is missing or invalid.");
                return;
            }

            // Load books when form loads
            this.Load += ViewBook_Load;
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            LoadBooksIntoGrid();
        }

        private void LoadBooksIntoGrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT BookId, BookName, Faculty, Semester, Quantity FROM BookDetail";

                    var books = connection.Query<Book>(query).ToList();

                    dataGridView1.AutoGenerateColumns = false; // 🔒 Prevent auto-columns
                    dataGridView1.Columns.Clear();             // ❌ Remove any existing columns
                    dataGridView1.DataSource = books;

                    // 🧱 Add only required columns
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "BookId",
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
                        DataPropertyName = "Quantity",
                        HeaderText = "Quantity"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT BookId, BookName, Faculty, Semester, Quantity 
                             FROM BookDetail 
                             WHERE (@BookId = '' OR BookId = @BookId) 
                             AND (@BookName = '' OR BookName LIKE @SearchName)";

                    var books = connection.Query<Book>(query, new
                    {
                        BookId = id,
                        BookName = name,
                        SearchName = "%" + name + "%"
                    }).ToList();

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = books;

                    // Re-add columns as above
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookId", HeaderText = "Book ID" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookName", HeaderText = "Book Name" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Faculty", HeaderText = "Faculty" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Semester", HeaderText = "Semester" });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Quantity" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        

      
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // You can implement row click actions here if needed.
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            LoadBooksIntoGrid();
        }

        private void ViewBook_Load_1(object sender, EventArgs e)
        {

        }
    }
}

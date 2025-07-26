using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Dapper;
using project_clz.Model;

namespace project_clz
{
    public partial class Form3 : Form
    {
        private string action;
        private string connectionString = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";

        public Form3()
        {
            InitializeComponent();
            //comboBox1.Visible = false;
            //label1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Ensure event is wired
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            action = "add";
            ClearBoxes();
            BoxEnable();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void txtbookid_TextChanged(object sender, EventArgs e)
        {
        }

        private void bpublication_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            action = "add";
        //    BoxEnable();
            //comboBox1.Visible = false;
            //label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  action = "editt";
          ////  BoxEnable();
          //  //comboBox1.Visible = true;
          //  //label1.Visible = true;
          //  fetchBookData();
          //  fetchDataInTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            action = "delete";
         //   BoxEnable();
            //comboBox1.Visible = true;
            //label1.Visible = true;
            fetchBookData();
            fetchDataInTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                datalink();
                ClearBoxes();
            }
            else if (action == "editt")
            {
                edit();
                ClearBoxes();
            }
            else if (action == "delete")
            {
                delete();
                ClearBoxes();
            }
        }

        private void datalink()
        {
            try
            {
                if (txtbookide == null || txtbookname == null || txtfaculty == null || txtauthor == null || txtpublication == null || textBox1 == null || quantityy == null)
                {
                    MessageBox.Show("One or more TextBox controls are not initialized.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtbookide.Text) ||
                    string.IsNullOrWhiteSpace(txtbookname.Text) ||
                    string.IsNullOrWhiteSpace(txtfaculty.Text) ||
                    string.IsNullOrWhiteSpace(txtauthor.Text) ||
                    string.IsNullOrWhiteSpace(txtpublication.Text) ||
                    string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(quantityy.Text))
                {
                    MessageBox.Show("All fields must be filled before saving the data.");
                    return;
                }

                if (!int.TryParse(txtbookide.Text, out int bookId))
                {
                    MessageBox.Show("Please enter a valid Book ID.");
                    return;
                }

                if (!int.TryParse(quantityy.Text, out int quantity))
                {
                    MessageBox.Show("Please enter a valid Quantity.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM BookDetail WHERE BookId = @id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@id", bookId);
                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existingCount > 0)
                        {
                            MessageBox.Show("A book with this ID already exists.");
                            con.Close();
                            return;
                        }
                    }

                    string query = "INSERT INTO BookDetail (BookId, BookName, Faculty, Author, Publication, Semester, Quantity) VALUES (@id, @bookname, @faculty, @author, @publication, @semester, @Qnt)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", bookId);
                        cmd.Parameters.Add("@bookname", SqlDbType.NVarChar).Value = txtbookname.Text;
                        cmd.Parameters.AddWithValue("@faculty", txtfaculty.Text);
                        cmd.Parameters.AddWithValue("@author", txtauthor.Text);
                        cmd.Parameters.AddWithValue("@publication", txtpublication.Text);
                        cmd.Parameters.AddWithValue("@semester", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Qnt", quantity);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book added successfully. Book ID: " + bookId);
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

        private void edit()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtbookide.Text) ||
                    string.IsNullOrWhiteSpace(txtbookname.Text) ||
                    string.IsNullOrWhiteSpace(txtfaculty.Text) ||
                    string.IsNullOrWhiteSpace(txtauthor.Text) ||
                    string.IsNullOrWhiteSpace(txtpublication.Text) ||
                    string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(quantityy.Text))
                {
                    MessageBox.Show("All fields must be filled before updating the data.");
                    return;
                }

                if (!int.TryParse(comboBox1.Text, out int bookId))
                {
                    MessageBox.Show("Please select a valid Book ID.");
                    return;
                }

                if (!int.TryParse(quantityy.Text, out int quantity))
                {
                    MessageBox.Show("Please enter a valid Quantity.");
                    return;
                }

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var updateQuery = @"UPDATE BookDetail
                                      SET BookName = @bookname,
                                          Faculty = @faculty,
                                          Author = @author,
                                          Publication = @publication,
                                          Semester = @semester,
                                          Quantity = @Qnt
                                      WHERE BookId = @id";

                    var affectedRows = db.Execute(updateQuery, new
                    {
                        bookname = txtbookname.Text,
                        faculty = txtfaculty.Text,
                        author = txtauthor.Text,
                        publication = txtpublication.Text,
                        semester = textBox1.Text,
                        Qnt = quantity,
                        id = bookId
                    });


                    MessageBox.Show("Record inserted successfully.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void delete()
        {
            try
            {
                if (!int.TryParse(comboBox1.Text, out int bookId))
                {
                    MessageBox.Show("Please select a valid Book ID.");
                    return;
                }

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var deleteQuery = @"DELETE FROM BookDetail WHERE BookId = @id";

                    var affectedRows = db.Execute(deleteQuery, new
                    {
                        id = bookId
                    });

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No record found with the specified Book ID.");
                    }

                    db.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting data: {ex.Message}");
            }
        }

        public void fetchBookData()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var data = db.Query<Book>("SELECT * FROM BookDetail");

                    if (data != null && data.Any())
                    {
                        comboBox1.DataSource = null; // Clear existing data
                        comboBox1.DataSource = data.ToList();
                        comboBox1.ValueMember = "BookId";
                        comboBox1.DisplayMember = "BookId";
                        comboBox1.SelectedIndex = 0; // Select the first item
                    }
                    else
                    {
                        MessageBox.Show("No book data found.");
                        comboBox1.DataSource = null;
                        ClearBoxes();
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        void fetchDataInTable()
        {
            try
            {
                var x = comboBox1.SelectedItem as Book;
                if (x != null && !string.IsNullOrEmpty(comboBox1.Text))
                {
                    txtbookide.Text = x.BookId.ToString();
                    txtbookname.Text = x.BookName ?? string.Empty;
                    txtfaculty.Text = x.Faculty ?? string.Empty;
                    txtauthor.Text = x.Author ?? string.Empty;
                    txtpublication.Text = x.Publication ?? string.Empty;
                    textBox1.Text = x.Semester ?? string.Empty;
                    quantityy.Text = x.Quantity.ToString();
                }
                else
                {
                    ClearBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating form fields: {ex.Message}");
            }
        }

        private void BoxEnable()
        {
            txtbookide.Enabled = action == "add";
            txtbookname.Enabled = true;
            txtfaculty.Enabled = true;
            txtauthor.Enabled = true;
            txtpublication.Enabled = true;
            textBox1.Enabled = true;
            quantityy.Enabled = true;
        }

        private void ClearBoxes()
        {
            txtbookide.Clear();
            txtbookname.Clear();
            quantityy.Clear();
            textBox1.SelectedIndex = -1;
            txtfaculty.SelectedIndex = -1;
            txtfaculty.Text = string.Empty;
            txtauthor.Clear();
            txtpublication.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void txtbookname_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtauthor_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtpublication_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchDataInTable();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            action = "editt";
            //  BoxEnable();
            //comboBox1.Visible = true;
            //label1.Visible = true;
            fetchBookData();
            fetchDataInTable();
        }
    }
}
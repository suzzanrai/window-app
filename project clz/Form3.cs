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

namespace project_clz
{
    public partial class Form3 : Form
    {

        // private object txtbookide;

        public Form3()
        {
            InitializeComponent();
        }

      
        private void Form3_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            datalink();
        }

        private void datalink()
        {
            try
            {
                if (txtbookide == null || txtbookname == null || txtfaculty == null || txtauthor == null || txtpublication == null || textBox1 == null)
                {
                    MessageBox.Show("One or more TextBox controls are not initialized.");
                    return;
                }
                string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True";
                string query = "INSERT INTO BookDetail (BookId, BookName, Faculty,Author,Publication,Semester) VALUES (@id, @bookname, @faculty,@author,@publication,@semester)";

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", txtbookide.Text);
                        cmd.Parameters.AddWithValue("@bookname", txtbookname.Text);
                        cmd.Parameters.AddWithValue("@faculty", txtfaculty.Text);
                        cmd.Parameters.AddWithValue("@author", txtauthor.Text);
                        cmd.Parameters.AddWithValue("@publication", txtpublication.Text);
                        cmd.Parameters.AddWithValue("@semester", textBox1.Text);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully");
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

        private void button3_Click(object sender, EventArgs e)
        {
            datalink();
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
            txtbookide.Clear();
            txtbookname.Clear();
            txtfaculty.SelectedIndex = -1; // Deselects any selected item
            txtfaculty.Text = string.Empty; // Clears text in editable ComboBox
            txtauthor.Clear();
            txtpublication.Clear();  
             //textBox1.Clear();
        }
    }
}

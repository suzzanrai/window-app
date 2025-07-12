using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace project_clz
{
    public partial class Form2 : Form
    {
       // private string connectionstring;
            
        
        public Form2()
        {
            InitializeComponent();
            //connecting local host code
           // connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sinup = new Form1();
            this.Hide();
            this.Close();
            sinup.ShowDialog();
            this.Show();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void s_Click(object sender, EventArgs e)
        {
           // dapper();
           
            checkpass();
            
        }
       private void datalink()
        {
            try
            {
               //FOR MY SQLSERVER:
               //string conStr = "Server=localhost;Port=3306;Database=library_system;Uid=root;Pwd=;Charset=utf8mb4;";

               string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True"; //DESKTOP-LG8ALSU\SQLEXPRESS
                string query = "INSERT INTO project_clz (Username, email, Password, Contact, Fullname ) VALUES (@name, @email, @password, @contact, @fullname)";

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtusername.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("@contact", txtcontact.Text);
                        cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
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
      

        private void checkpass()
        {
            string newpass = txtpassword.Text;
            string checkpass = txtcheckpassword.Text;
            if (newpass!= checkpass)
            {
                label4.Visible = true;

            }
            else
            {
                label4.Visible = false;
                datalink();
                MessageBox.Show("correct");
            }

        }
        private void txtcheckpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


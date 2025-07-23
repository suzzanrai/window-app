using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Linq.Expressions;
using Dapper;
using DbShell.Driver.Common.CommonDataLayer;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities.Net;
using System.Diagnostics;
using project_clz.Model;
using Org.BouncyCastle.Tls;
using Microsoft.Data.SqlClient;

namespace project_clz
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar != '\0')
            {

            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = default;

            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var sinup = new Form2();
            this.Hide();
            sinup.ShowDialog();
            this.Show();
        }

       /* private void button2_Click_2(object sender, EventArgs e)
        {
            *//*   if (txtusername.Text == "sujan" && txtpassword.Text == "sujan1")
            {
                //new Form3().Show();
                Form4 register = new Form4();
                register.ShowDialog();
            }
            else
            {
                MessageBox.Show("Not Valid Input");
            }
*//*

        }*/

        //
     /*   private void fetchdata()
        {
            string connectionString = @"Data Source=DESKTOP-LG8ALSU\SQLEXPRESS;Initial Catalog=LibrarySystem;Integrated Security=True";
            string query = "SELECT Username,Password";
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();
                // IEnumerable<@new>
            }

        }
*/
        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source = SZN; Initial Catalog = LibararySystem; Integrated Security = True; Encrypt = False; Trust Server Certificate = True";
                    //@"Data Source=SZN;Initial Catalog=LibrarySystem;Integrated Security=False";
                var user = new @new
                {
                    Username = txtusername.Text,
                    Password = txtpassword.Text
                };
                Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
               // using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM project_clz WHERE Username = @Username AND Password = @Password";

                    connection.Open();
                    int count = connection.ExecuteScalar<int>(query, user);

                    if (count == 1)
                    {
                        // Authentication successful
                        MessageBox.Show("Login successful!");
                        this.Hide();
                        var dashboard = new Dashboard();
                        dashboard.ShowDialog();
                       // this.Close();
                        // Proceed to the next form or main application
                    }
                    else
                    {
                        // Authentication failed
                        MessageBox.Show("Username or Password is incorrect.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void lusername_Click(object sender, EventArgs e)
        {

        }

        private void lpassword_Click(object sender, EventArgs e)
        {

        }
    }

    public class @new
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }


}


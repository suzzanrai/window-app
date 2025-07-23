
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

namespace project_clz
{
    public partial class add : Form
    {
        string gender;
        string action;
        private string connectionString;
        private object studentId;

        public add()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"].ToString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            imagefile();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            imagefile();
        }
     
       
        //Function for image file 
        void imagefile()
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|all files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    photo.ImageLocation = imagelocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the image: {ex.Message}");
            }
        }

        // Select the action:
        private void button2_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                save();
                ClearBoxes();
            }
            else if (action == "editt")
            {
                edit();
            }
            else if ( action == "delete")
            {
                delete();
            }
        }

        private void save()
        {
            try
            {
                byte[] photo = null;
                if (this.photo.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        this.photo.Image.Save(ms, this.photo.Image.RawFormat);
                        photo = ms.ToArray();
                    }
                }

                DateTime parsedDob;
                if (!DateTime.TryParse(this.parsedDob.Text, out parsedDob))
                {
                    MessageBox.Show("Please enter a valid date of birth.");
                    return;
                }

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var insertQuery = @"
                            INSERT INTO STUDENTDETAIL
                            (FirstName, LastName, DOB, ContactNumber, Batch, Gender, Photo) 
                            VALUES (@fname, @lname, @dobb, @contact, @batch, @genderr, @photo)";

                    var affectedRows = db.Execute(insertQuery, new
                    {
                        fname = txtfirstname.Text,
                        lname = txtlastname.Text,
                        dobb = parsedDob,
                        contact = txtcontactnumber.Text,
                        batch = txtbatch.Text,
                        genderr = gender,
                        photo = photo,
                    });
                    if (affectedRows != null)
                    {
                        combobox.Text = affectedRows.ToString();
                        //MessageBox.Show("Record inserted successfully. New ID: " + affectedRows);
                    }
                    MessageBox.Show("Record inserted successfully.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
        }



        // EDIT 

        private void edit()
        {
            try
            {
                byte[] photo = null;
                if (this.photo.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        this.photo.Image.Save(ms, this.photo.Image.RawFormat);
                        photo = ms.ToArray();
                    }
                }

                DateTime parsedDob;
                if (!DateTime.TryParse(this.parsedDob.Text, out parsedDob))
                {
                    MessageBox.Show("Please enter a valid date of birth.");
                    return;
                }

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var UpdateQuery = @"  
                    UPDATE[STUDENTDETAIL]
                SET FirstName = @fname,
                    LastName = @lname,
                    DOB = @dobb,
                    ContactNumber = @contact,
                    Batch = @batch,
                    Gender = @genderr,
                    Photo = @photo
                WHERE ID = @id";

                    var affectedRows = db.Execute(UpdateQuery, new
                    {
                        fname = txtfirstname.Text,
                        lname = txtlastname.Text,
                        dobb = parsedDob,
                        contact = txtcontactnumber.Text,
                        batch = txtbatch.Text,
                        genderr = gender,
                        photo = photo,
                        id = combobox.Text,
                    });

                    MessageBox.Show("Record inserted successfully.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }

        }

        //delete
        private void delete()
        {

            try
            {
                int studentId;
                if (!int.TryParse(combobox.Text, out studentId))
                {
                    MessageBox.Show("Please select a valid student ID.");
                    return;
                }

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var deleteQuery = @"DELETE FROM STUDENTDETAIL WHERE ID = @id";

                    var affectedRows = db.Execute(deleteQuery, new
                    {
                        id = studentId
                    });

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No record found with the specified ID.");
                    }
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


        public void fetchcomplaindata()
        {
            try
            {
                string conStr = @"Data Source=SZN;Initial Catalog=LibararySystem;Integrated Security=True"; //DESKTOP-LG8ALSU\SQLEXPRESS
                using (SqlConnection con = new SqlConnection(conStr))
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    var data = db.Query<User>("SELECT * FROM STUDENTDETAIL");

                    // Check if data contains any items
                    if (data != null && data.Any())
                    {
                        // Assuming complainid is a valid property of the complain class
                        combobox.DataSource = data.ToList();
                        combobox.ValueMember = "ID"; // Corrected
                        combobox.DisplayMember = "ID"; // Corrected
                        combobox.SelectedIndex = 0;
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

        void fetchDataInTable()
        {
            var x = combobox.SelectedItem as User;
            if (!string.IsNullOrEmpty(combobox.Text))
            {
                txtfirstname.Text = x.FirstName;
                txtlastname.Text = x.LastName;
                parsedDob.Text = x.DOB;
                txtcontactnumber.Text = x.ContactNumber;
                txtbatch.Text = x.Batch;
                gender = x.Gender;

                // Handle photo
                if (x.Photo != null && x.Photo.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(x.Photo))
                        {
                            var img = Image.FromStream(ms);
                            photo.Image = new Bitmap(img); // Create new bitmap to avoid disposal issues
                        }
                    }
                    catch (Exception imgEx)
                    {
                        MessageBox.Show($"Error loading photo: {imgEx.Message}");
                        photo.Image = null;
                    }
                }
                else
                {
                    photo.Image = null;
                }
            }
        }

       

        private void BoxEnable()
        {
            txtfirstname.Enabled = true;
            txtlastname.Enabled = true;
            txtbatch.Enabled = true;
            txtcontactnumber.Enabled = true;
            parsedDob.Enabled = true;
            button1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }

        // CLEARING BOXE 
        private void ClearBoxes()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtbatch.Text = "";
            txtcontactnumber.Text = "";
            parsedDob.Value = DateTime.Now; // For DateTimePicker
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            photo.Image = null;
        }

        // ADD AND MODIFY BY SAVE BUTTON
        private void NEW_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            action = "add";  // Explicitly set the action
            BoxEnable();
            combobox.Visible = false;
            label1.Visible = false;
        }
        private void txtmodify_Click_1(object sender, EventArgs e)
        {
            action = "editt";  // Explicitly set the action
            BoxEnable();
            combobox.Visible = true;
            label1.Visible = true;
           
            fetchcomplaindata();
            fetchDataInTable();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            action = "delete";  // Explicitly set the action
            BoxEnable();
            combobox.Visible = true;
            label1.Visible = true;
           
            fetchcomplaindata();
            fetchDataInTable();
        }
        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           fetchDataInTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        //private void OnlyNumbers(KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true; // block the key if it's not a number
        //    }
        //}


        //private void txtcontactnumber_TextChanged(object sender, EventArgs e)
        //{
        //    OnlyNumbers(e); // allow only digits

        //    // Limit to 10 digits
        //    if (txtcontactnumber.Text.Length >= 10 && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // stop typing if already 10 digits
        //    }
        //}
    }
}

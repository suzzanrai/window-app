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

namespace project_clz
{
    public partial class add : Form
    {
        private string connectionString;
        string gender;
        string action;

        public add()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myconn"].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle pictureBox1 click event if needed
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            imagefile();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            // Handle fileSystemWatcher changed event if needed
        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {
            // Handle txtfirstname text changed event if needed
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

        // uploding photo in database
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                save();
            }
            else if (action == "editt")
            {
                edit();
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
                        INSERT INTO [STUDENTDETAIL] 
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

                    MessageBox.Show("Record inserted successfully.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }

        }

        private void txtcontactnumber_TextChanged(object sender, EventArgs e)
        {
            // Handle txtcontactnumber text changed event if needed
        }

        private void button3_Click(object sender, EventArgs e)
        {
            action = "editt";
            fetchDataInTable();
            combobox.Visible = true;
            label1.Visible = true;

            //  action ="modify";
            BoxEnable();
            fetchcomplaindata();
        }





        public void fetchcomplaindata()
        {
            try
            {
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

        private void button4_Click(object sender, EventArgs e)
        {
            action = "add";
            combobox.Visible = false;
            label1.Visible = false;
            BoxEnable();
            //  action = "add";
        }
        void editdata()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["myconn"].ToString();


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
                        var UpdateQuery = @"UPDATE STUDENTDETAIL SET FirstName=@fname, LastName= @lname, DOB=@dobb, ContactNumber=@contact, Batch=@batch, Gender=@genderr, Photo=@photo WHERE ID=@id";
                        var affectedRows = db.Execute(UpdateQuery, new
                        {
                            id = combobox.Text,
                            fname = txtfirstname.Text,
                            lname = txtlastname.Text,
                            dobb = parsedDob,
                            contact = txtcontactnumber.Text,
                            batch = txtbatch.Text,
                            genderr = gender,
                            photo = photo,
                        });
                        db.Close();
                        MessageBox.Show("edited");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
        void fetchDataInTable()
        {
                var x = combobox.SelectedItem as User;
                if (! string.IsNullOrEmpty(combobox.Text))
                {
                    txtfirstname.Text = x.FirstName;
                    txtlastname.Text = x.LastName;
                    parsedDob.Text = x.DOB;
                    txtcontactnumber.Text = x.ContactNumber;
                    txtbatch.Text = x.Batch;
                    gender = x.Gender;
                    
                }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchDataInTable();
        }

        private void remove()
        {

        }
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
                    var UpdateQuery =  @"  
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
    } 
}

    /*    private void button3_Click_1(object sender, EventArgs e)
        {
            editdata();
        }

        private void dob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchDataInTable();
        }
    }
}*/
    



using System;
using System.Data;
using System.Windows.Forms;
using project_clz.LibararySystemDataSetTableAdapters; // Correct namespace for TableAdapter

namespace project_clz
{
    public partial class StudentDetail : Form
    {
        public StudentDetail()
        {
            InitializeComponent();
        }

        private void StudentDetail_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            dataGridView1.AutoGenerateColumns = true; // Automatically generate columns
            LoadData();

            // Enable Enter key to trigger search in textboxes
            textBox1.KeyDown += TextBox_KeyDown;
            textBox2.KeyDown += TextBox_KeyDown;

            // Enable F5 key to refresh data
            this.KeyPreview = true; // Allow form to capture key events
            this.KeyDown += StudentDetail_KeyDown;
        }

        private void LoadData()
        {
            try
            {
                // Create an instance of the Typed DataSet
                LibararySystemDataSet dataSet = new LibararySystemDataSet();

                // Create an instance of the TableAdapter
                STUDENTDETAILTableAdapter tableAdapter = new STUDENTDETAILTableAdapter();

                // Fill the STUDENTDETAIL table in the DataSet
                tableAdapter.Fill(dataSet.STUDENTDETAIL);

                // Check if data was retrieved
                if (dataSet.STUDENTDETAIL.Rows.Count == 0)
                {
                    MessageBox.Show("No data found in STUDENTDETAIL table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bind the STUDENTDETAIL table to the DataGridView
                dataGridView1.DataSource = dataSet.STUDENTDETAIL;

                // Customize column headers for better readability
                dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                dataGridView1.Columns["DOB"].HeaderText = "Date of Birth";
                dataGridView1.Columns["ContactNumber"].HeaderText = "Contact Number";
                dataGridView1.Columns["Batch"].HeaderText = "Batch";
                dataGridView1.Columns["Gender"].HeaderText = "Gender";

                // Hide the Photo column (since it's a byte[])
                if (dataGridView1.Columns["Photo"] != null)
                {
                    dataGridView1.Columns["Photo"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchData()
        {
            try
            {
                // Get input from textboxes
                string idText = textBox1.Text.Trim();
                string nameText = textBox2.Text.Trim();

                // Create an instance of the Typed DataSet
                LibararySystemDataSet dataSet = new LibararySystemDataSet();

                // Create an instance of the TableAdapter
                STUDENTDETAILTableAdapter tableAdapter = new STUDENTDETAILTableAdapter();

                // Fill the STUDENTDETAIL table
                tableAdapter.Fill(dataSet.STUDENTDETAIL);

                // Check if data was retrieved
                if (dataSet.STUDENTDETAIL.Rows.Count == 0)
                {
                    MessageBox.Show("No data found in STUDENTDETAIL table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = dataSet.STUDENTDETAIL;
                    return;
                }

                // Create a DataView for filtering
                DataView dv = dataSet.STUDENTDETAIL.DefaultView;

                // Apply filter if textboxes are not empty
                if (!string.IsNullOrEmpty(idText) || !string.IsNullOrEmpty(nameText))
                {
                    string filter = "";
                    if (!string.IsNullOrEmpty(idText))
                    {
                        if (!int.TryParse(idText, out int id))
                        {
                            MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        filter += $"Id = {id}";
                    }
                    if (!string.IsNullOrEmpty(nameText))
                    {
                        if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                        filter += $"FirstName LIKE '%{nameText}%'";
                    }

                    // Apply the filter to the DataView
                    dv.RowFilter = filter;
                }
                else
                {
                    // Clear the filter if both textboxes are empty
                    dv.RowFilter = "";
                }

                // Bind the filtered DataView to the DataGridView
                dataGridView1.DataSource = dv;

                // Reapply column customizations
                dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                dataGridView1.Columns["DOB"].HeaderText = "Date of Birth";
                dataGridView1.Columns["ContactNumber"].HeaderText = "Contact Number";
                dataGridView1.Columns["Batch"].HeaderText = "Batch";
                dataGridView1.Columns["Gender"].HeaderText = "Gender";

                // Hide the Photo column
                if (dataGridView1.Columns["Photo"] != null)
                {
                    dataGridView1.Columns["Photo"].Visible = false;
                }

                // Show message if no results after filtering
                if (dv.Count == 0)
                {
                    MessageBox.Show("No matching records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
       
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData();
                e.SuppressKeyPress = true; // Prevent the beep sound
            }
        }

        private void StudentDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                buttonRefresh_Click(sender, e); // Reuse refresh button logic
                e.SuppressKeyPress = true; // Prevent default behavior
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if needed (e.g., for editing or viewing details)
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear search textboxes
            textBox1.Clear();
            textBox2.Clear();

            // Reload all data
            LoadData();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
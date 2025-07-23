using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project_clz.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_clz
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new ViewBook();
            this.Hide();
            view.ShowDialog();
            this.Show();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var book = new Form3();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var add = new add();
            this.Hide();
            add.ShowDialog();
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cont = new Form1();
            this.Hide();
            cont.ShowDialog();
            this.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cont = new Form5();
            this.Hide();
            cont.ShowDialog();
            this.Show();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cont = new Form6();
            this.Hide();
            cont.ShowDialog();
            this.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new StudentDetail();
            this.Hide();
            view.ShowDialog();
            this.Show();
        }

        private void viewBookDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void issueBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var view = new ViewIssueBook();
            this.Hide();
            view.ShowDialog();
            this.Show();
        }

        private void returnBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var view = new ViewReturnBook();
            this.Hide();
            view.ShowDialog();
            this.Show();
        }
    }
}

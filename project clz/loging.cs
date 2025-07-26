//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace project_clz
//{
//    public partial class loging : Form
//    {
//        public loging()
//        {
//            InitializeComponent();
//        }

//        private void loging_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_clz
{
    public partial class loging : Form
    {
        public loging()
        {
            InitializeComponent();
        }
        int startPos = 0;
        private object bunifuProgressBar1;

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    startPos += 1;
        //    bunifuProgressBar1.Value = startPos;
        //    PercentageLbl.Text = startPos + "%";
        //    if (bunifuProgressBar1.Value == 100)
        //    {
        //        timer1.Stop();
        //        Form1 log = new Form1();
        //        log.Show();
        //        this.Hide();
        //    }
        //}
    }
}

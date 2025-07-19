namespace project_clz
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.TextBox();
            this.txtbookide = new System.Windows.Forms.TextBox();
            this.txtsemester = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtpublication = new System.Windows.Forms.TextBox();
            this.bpublication = new System.Windows.Forms.Label();
            this.txtauthor = new System.Windows.Forms.TextBox();
            this.bauthor = new System.Windows.Forms.Label();
            this.txtfaculty = new System.Windows.Forms.ComboBox();
            this.bfaculty = new System.Windows.Forms.Label();
            this.txtbookname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bbookname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bbookid = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.quantity);
            this.panel1.Controls.Add(this.txtbookide);
            this.panel1.Controls.Add(this.txtsemester);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtpublication);
            this.panel1.Controls.Add(this.bpublication);
            this.panel1.Controls.Add(this.txtauthor);
            this.panel1.Controls.Add(this.bauthor);
            this.panel1.Controls.Add(this.txtfaculty);
            this.panel1.Controls.Add(this.bfaculty);
            this.panel1.Controls.Add(this.txtbookname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.bbookname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bbookid);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 610);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.FormattingEnabled = true;
            this.textBox1.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VII"});
            this.textBox1.Location = new System.Drawing.Point(936, 272);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 26);
            this.textBox1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 36);
            this.label2.TabIndex = 26;
            this.label2.Text = "ADD BOOK DETAIL";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // quantity
            // 
            this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(937, 138);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(69, 24);
            this.quantity.TabIndex = 23;
            // 
            // txtbookide
            // 
            this.txtbookide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookide.Location = new System.Drawing.Point(936, 94);
            this.txtbookide.Name = "txtbookide";
            this.txtbookide.Size = new System.Drawing.Size(69, 24);
            this.txtbookide.TabIndex = 23;
            // 
            // txtsemester
            // 
            this.txtsemester.AutoSize = true;
            this.txtsemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsemester.Location = new System.Drawing.Point(825, 280);
            this.txtsemester.Name = "txtsemester";
            this.txtsemester.Size = new System.Drawing.Size(80, 18);
            this.txtsemester.TabIndex = 21;
            this.txtsemester.Text = "Semester";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(530, 515);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Gomendra Multiple College";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(557, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 19;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1058, 463);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 30);
            this.button3.TabIndex = 15;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(951, 463);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtpublication
            // 
            this.txtpublication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpublication.Location = new System.Drawing.Point(936, 371);
            this.txtpublication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpublication.Name = "txtpublication";
            this.txtpublication.Size = new System.Drawing.Size(195, 24);
            this.txtpublication.TabIndex = 12;
            this.txtpublication.TextChanged += new System.EventHandler(this.txtpublication_TextChanged);
            // 
            // bpublication
            // 
            this.bpublication.AutoSize = true;
            this.bpublication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpublication.Location = new System.Drawing.Point(824, 376);
            this.bpublication.Name = "bpublication";
            this.bpublication.Size = new System.Drawing.Size(91, 18);
            this.bpublication.TabIndex = 10;
            this.bpublication.Text = "Publication";
            this.bpublication.Click += new System.EventHandler(this.bpublication_Click);
            // 
            // txtauthor
            // 
            this.txtauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtauthor.Location = new System.Drawing.Point(936, 327);
            this.txtauthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtauthor.Name = "txtauthor";
            this.txtauthor.Size = new System.Drawing.Size(195, 24);
            this.txtauthor.TabIndex = 9;
            this.txtauthor.TextChanged += new System.EventHandler(this.txtauthor_TextChanged);
            // 
            // bauthor
            // 
            this.bauthor.AutoSize = true;
            this.bauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bauthor.Location = new System.Drawing.Point(824, 332);
            this.bauthor.Name = "bauthor";
            this.bauthor.Size = new System.Drawing.Size(57, 18);
            this.bauthor.TabIndex = 8;
            this.bauthor.Text = "Author";
            // 
            // txtfaculty
            // 
            this.txtfaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfaculty.FormattingEnabled = true;
            this.txtfaculty.Items.AddRange(new object[] {
            "BCA",
            "BBA"});
            this.txtfaculty.Location = new System.Drawing.Point(936, 231);
            this.txtfaculty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfaculty.Name = "txtfaculty";
            this.txtfaculty.Size = new System.Drawing.Size(195, 26);
            this.txtfaculty.TabIndex = 7;
            this.txtfaculty.SelectedIndexChanged += new System.EventHandler(this.txtfaculty_SelectedIndexChanged);
            // 
            // bfaculty
            // 
            this.bfaculty.AutoSize = true;
            this.bfaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bfaculty.Location = new System.Drawing.Point(824, 231);
            this.bfaculty.Name = "bfaculty";
            this.bfaculty.Size = new System.Drawing.Size(62, 18);
            this.bfaculty.TabIndex = 6;
            this.bfaculty.Text = "Faculty";
            // 
            // txtbookname
            // 
            this.txtbookname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookname.Location = new System.Drawing.Point(936, 183);
            this.txtbookname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbookname.Name = "txtbookname";
            this.txtbookname.Size = new System.Drawing.Size(195, 24);
            this.txtbookname.TabIndex = 5;
            this.txtbookname.TextChanged += new System.EventHandler(this.txtbookname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 3;
            // 
            // bbookname
            // 
            this.bbookname.AutoSize = true;
            this.bbookname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbookname.Location = new System.Drawing.Point(824, 186);
            this.bbookname.Name = "bbookname";
            this.bbookname.Size = new System.Drawing.Size(97, 18);
            this.bbookname.TabIndex = 2;
            this.bbookname.Text = "Book Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(825, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantity :";
            // 
            // bbookid
            // 
            this.bbookid.AutoSize = true;
            this.bbookid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbookid.Location = new System.Drawing.Point(825, 100);
            this.bbookid.Name = "bbookid";
            this.bbookid.Size = new System.Drawing.Size(69, 18);
            this.bbookid.TabIndex = 1;
            this.bbookid.Text = "Book ID";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::project_clz.Properties.Resources._66982lms;
            this.pictureBox3.Location = new System.Drawing.Point(10, 60);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(715, 478);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::project_clz.Properties.Resources.icons8_cross_30;
            this.pictureBox2.Location = new System.Drawing.Point(1143, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 593);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bbookname;
        private System.Windows.Forms.Label bbookid;
        private System.Windows.Forms.Label bfaculty;
        private System.Windows.Forms.TextBox txtbookname;
        private System.Windows.Forms.Label bpublication;
        private System.Windows.Forms.TextBox txtauthor;
        private System.Windows.Forms.Label bauthor;
        private System.Windows.Forms.ComboBox txtfaculty;
        private System.Windows.Forms.TextBox txtpublication;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label txtsemester;
        private System.Windows.Forms.TextBox txtbookide;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox textBox1;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.Label label1;
    }
}
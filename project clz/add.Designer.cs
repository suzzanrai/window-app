using System;

namespace project_clz
{
    partial class add
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
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.NEW = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.combobox = new System.Windows.Forms.ComboBox();
            this.txtmodify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtbatch = new System.Windows.Forms.TextBox();
            this.stbatch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.photo = new System.Windows.Forms.PictureBox();
            this.parsedDob = new System.Windows.Forms.DateTimePicker();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.txtcontactnumber = new System.Windows.Forms.TextBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.stgender = new System.Windows.Forms.Label();
            this.stdate = new System.Windows.Forms.Label();
            this.stphoto = new System.Windows.Forms.Label();
            this.stcontact = new System.Windows.Forms.Label();
            this.stlname = new System.Windows.Forms.Label();
            this.stfname = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.NEW);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combobox);
            this.panel1.Controls.Add(this.txtmodify);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.txtbatch);
            this.panel1.Controls.Add(this.stbatch);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.photo);
            this.panel1.Controls.Add(this.parsedDob);
            this.panel1.Controls.Add(this.txtfirstname);
            this.panel1.Controls.Add(this.txtcontactnumber);
            this.panel1.Controls.Add(this.txtlastname);
            this.panel1.Controls.Add(this.stgender);
            this.panel1.Controls.Add(this.stdate);
            this.panel1.Controls.Add(this.stphoto);
            this.panel1.Controls.Add(this.stcontact);
            this.panel1.Controls.Add(this.stlname);
            this.panel1.Controls.Add(this.stfname);
            this.panel1.Controls.Add(this.lable1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 610);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(233, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 37);
            this.button4.TabIndex = 30;
            this.button4.Text = "DELET";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::project_clz.Properties.Resources.icons8_cross_30;
            this.pictureBox2.Location = new System.Drawing.Point(1164, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(235, 551);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 39);
            this.button3.TabIndex = 28;
            this.button3.Text = "CLEAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NEW
            // 
            this.NEW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEW.Location = new System.Drawing.Point(42, 62);
            this.NEW.Name = "NEW";
            this.NEW.Size = new System.Drawing.Size(93, 36);
            this.NEW.TabIndex = 27;
            this.NEW.Text = "ADD";
            this.NEW.UseVisualStyleBackColor = true;
            this.NEW.Click += new System.EventHandler(this.NEW_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // combobox
            // 
            this.combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox.FormattingEnabled = true;
            this.combobox.Location = new System.Drawing.Point(160, 115);
            this.combobox.Name = "combobox";
            this.combobox.Size = new System.Drawing.Size(67, 26);
            this.combobox.TabIndex = 24;
            this.combobox.Visible = false;
            this.combobox.SelectedIndexChanged += new System.EventHandler(this.combobox_SelectedIndexChanged);
            // 
            // txtmodify
            // 
            this.txtmodify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodify.Location = new System.Drawing.Point(141, 61);
            this.txtmodify.Name = "txtmodify";
            this.txtmodify.Size = new System.Drawing.Size(86, 37);
            this.txtmodify.TabIndex = 23;
            this.txtmodify.Text = "MODIFY";
            this.txtmodify.UseVisualStyleBackColor = true;
            this.txtmodify.Click += new System.EventHandler(this.txtmodify_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(339, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 39);
            this.button2.TabIndex = 22;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(248, 382);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 22);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(160, 382);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 22);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtbatch
            // 
            this.txtbatch.Enabled = false;
            this.txtbatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbatch.Location = new System.Drawing.Point(160, 336);
            this.txtbatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbatch.Name = "txtbatch";
            this.txtbatch.Size = new System.Drawing.Size(231, 24);
            this.txtbatch.TabIndex = 19;
            // 
            // stbatch
            // 
            this.stbatch.AutoSize = true;
            this.stbatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbatch.Location = new System.Drawing.Point(39, 334);
            this.stbatch.Name = "stbatch";
            this.stbatch.Size = new System.Drawing.Size(51, 18);
            this.stbatch.TabIndex = 17;
            this.stbatch.Text = "Batch";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(160, 505);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Uplode Photo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // photo
            // 
            this.photo.BackColor = System.Drawing.Color.White;
            this.photo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photo.Enabled = false;
            this.photo.Location = new System.Drawing.Point(160, 406);
            this.photo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(116, 122);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 15;
            this.photo.TabStop = false;
            this.photo.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // parsedDob
            // 
            this.parsedDob.Enabled = false;
            this.parsedDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parsedDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.parsedDob.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.parsedDob.Location = new System.Drawing.Point(160, 249);
            this.parsedDob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.parsedDob.Name = "parsedDob";
            this.parsedDob.Size = new System.Drawing.Size(231, 22);
            this.parsedDob.TabIndex = 12;
            this.parsedDob.Value = new System.DateTime(2024, 5, 29, 23, 0, 53, 0);
            // 
            // txtfirstname
            // 
            this.txtfirstname.Enabled = false;
            this.txtfirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfirstname.Location = new System.Drawing.Point(160, 155);
            this.txtfirstname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(233, 24);
            this.txtfirstname.TabIndex = 11;
            // 
            // txtcontactnumber
            // 
            this.txtcontactnumber.Enabled = false;
            this.txtcontactnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontactnumber.Location = new System.Drawing.Point(160, 290);
            this.txtcontactnumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcontactnumber.Name = "txtcontactnumber";
            this.txtcontactnumber.Size = new System.Drawing.Size(231, 24);
            this.txtcontactnumber.TabIndex = 8;
            this.txtcontactnumber.TextChanged += new System.EventHandler(this.txtcontactnumber_TextChanged);
            // 
            // txtlastname
            // 
            this.txtlastname.Enabled = false;
            this.txtlastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastname.Location = new System.Drawing.Point(160, 203);
            this.txtlastname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(233, 24);
            this.txtlastname.TabIndex = 7;
            // 
            // stgender
            // 
            this.stgender.AutoSize = true;
            this.stgender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stgender.Location = new System.Drawing.Point(39, 382);
            this.stgender.Name = "stgender";
            this.stgender.Size = new System.Drawing.Size(63, 18);
            this.stgender.TabIndex = 6;
            this.stgender.Text = "Gender";
            // 
            // stdate
            // 
            this.stdate.AutoSize = true;
            this.stdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdate.Location = new System.Drawing.Point(39, 249);
            this.stdate.Name = "stdate";
            this.stdate.Size = new System.Drawing.Size(111, 18);
            this.stdate.TabIndex = 5;
            this.stdate.Text = "Date Of Birth ";
            // 
            // stphoto
            // 
            this.stphoto.AutoSize = true;
            this.stphoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stphoto.Location = new System.Drawing.Point(39, 436);
            this.stphoto.Name = "stphoto";
            this.stphoto.Size = new System.Drawing.Size(53, 18);
            this.stphoto.TabIndex = 4;
            this.stphoto.Text = "Photo";
            // 
            // stcontact
            // 
            this.stcontact.AutoSize = true;
            this.stcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stcontact.Location = new System.Drawing.Point(39, 290);
            this.stcontact.Name = "stcontact";
            this.stcontact.Size = new System.Drawing.Size(131, 18);
            this.stcontact.TabIndex = 3;
            this.stcontact.Text = "Contact Number";
            // 
            // stlname
            // 
            this.stlname.AutoSize = true;
            this.stlname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stlname.Location = new System.Drawing.Point(39, 203);
            this.stlname.Name = "stlname";
            this.stlname.Size = new System.Drawing.Size(89, 18);
            this.stlname.TabIndex = 2;
            this.stlname.Text = "Last Name";
            // 
            // stfname
            // 
            this.stfname.AutoSize = true;
            this.stfname.BackColor = System.Drawing.Color.Transparent;
            this.stfname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stfname.Location = new System.Drawing.Point(39, 155);
            this.stfname.Name = "stfname";
            this.stfname.Size = new System.Drawing.Size(91, 18);
            this.stfname.TabIndex = 1;
            this.stfname.Text = "First Name";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.BackColor = System.Drawing.Color.Transparent;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(471, 6);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(282, 36);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Add Student Detail";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::project_clz.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(436, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(781, 526);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1239, 654);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "add";
            this.Text = "B";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);

        }

        private void txtcontactnumber_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label stdate;
        private System.Windows.Forms.Label stphoto;
        private System.Windows.Forms.Label stcontact;
        private System.Windows.Forms.Label stlname;
        private System.Windows.Forms.Label stfname;
        private System.Windows.Forms.DateTimePicker parsedDob;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.TextBox txtcontactnumber;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.Label stgender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox photo;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label stbatch;
        private System.Windows.Forms.TextBox txtbatch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button txtmodify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combobox;
        private System.Windows.Forms.Button NEW;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
    }
}
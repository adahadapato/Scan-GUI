namespace scan
{
    partial class frmnewscan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmnewscan));
            this.cbosubject = new System.Windows.Forms.ComboBox();
            this.cbostate = new System.Windows.Forms.ComboBox();
            this.txtexam_year = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblstate = new System.Windows.Forms.Label();
            this.lblexam_type = new System.Windows.Forms.Label();
            this.lblexam_year = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtexam_type = new System.Windows.Forms.TextBox();
            this.cbopaper = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictssce = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblfcount = new System.Windows.Forms.Label();
            this.lblcontent = new System.Windows.Forms.Label();
            this.lbldisplay = new System.Windows.Forms.Label();
            this.BtnHouseKeeping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LvFiles = new System.Windows.Forms.ListView();
            this.BtnReferesh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictssce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // cbosubject
            // 
            this.cbosubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbosubject.FormattingEnabled = true;
            this.cbosubject.Location = new System.Drawing.Point(287, 59);
            this.cbosubject.Name = "cbosubject";
            this.cbosubject.Size = new System.Drawing.Size(272, 23);
            this.cbosubject.TabIndex = 25;
            this.cbosubject.SelectedIndexChanged += new System.EventHandler(this.cbosubject_SelectedIndexChanged);
            this.cbosubject.MouseEnter += new System.EventHandler(this.cbosubject_MouseEnter);
            // 
            // cbostate
            // 
            this.cbostate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbostate.FormattingEnabled = true;
            this.cbostate.Location = new System.Drawing.Point(64, 59);
            this.cbostate.Name = "cbostate";
            this.cbostate.Size = new System.Drawing.Size(139, 23);
            this.cbostate.TabIndex = 24;
            this.cbostate.SelectedIndexChanged += new System.EventHandler(this.cbostate_SelectedIndexChanged);
            this.cbostate.MouseEnter += new System.EventHandler(this.cbostate_MouseEnter);
            // 
            // txtexam_year
            // 
            this.txtexam_year.Enabled = false;
            this.txtexam_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexam_year.Location = new System.Drawing.Point(120, 25);
            this.txtexam_year.MaxLength = 4;
            this.txtexam_year.Name = "txtexam_year";
            this.txtexam_year.Size = new System.Drawing.Size(80, 21);
            this.txtexam_year.TabIndex = 22;
            this.txtexam_year.TextChanged += new System.EventHandler(this.txtexam_year_TextChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(221, 59);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(59, 16);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject";
            // 
            // lblstate
            // 
            this.lblstate.AutoSize = true;
            this.lblstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstate.Location = new System.Drawing.Point(14, 59);
            this.lblstate.Name = "lblstate";
            this.lblstate.Size = new System.Drawing.Size(43, 16);
            this.lblstate.TabIndex = 20;
            this.lblstate.Text = "State";
            // 
            // lblexam_type
            // 
            this.lblexam_type.AutoSize = true;
            this.lblexam_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexam_type.Location = new System.Drawing.Point(221, 25);
            this.lblexam_type.Name = "lblexam_type";
            this.lblexam_type.Size = new System.Drawing.Size(91, 16);
            this.lblexam_type.TabIndex = 19;
            this.lblexam_type.Text = "Examination";
            // 
            // lblexam_year
            // 
            this.lblexam_year.AutoSize = true;
            this.lblexam_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexam_year.Location = new System.Drawing.Point(14, 25);
            this.lblexam_year.Name = "lblexam_year";
            this.lblexam_year.Size = new System.Drawing.Size(40, 16);
            this.lblexam_year.TabIndex = 18;
            this.lblexam_year.Text = "Year";
            // 
            // btncancel
            // 
            this.btncancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(621, 287);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 27);
            this.btncancel.TabIndex = 17;
            this.btncancel.Text = "&Close";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnok
            // 
            this.btnok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(539, 287);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 27);
            this.btnok.TabIndex = 16;
            this.btnok.Text = "&OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox1.Location = new System.Drawing.Point(7, 11);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(691, 81);
            this.PictureBox1.TabIndex = 13;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // txtexam_type
            // 
            this.txtexam_type.Enabled = false;
            this.txtexam_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexam_type.Location = new System.Drawing.Point(347, 25);
            this.txtexam_type.Name = "txtexam_type";
            this.txtexam_type.Size = new System.Drawing.Size(208, 21);
            this.txtexam_type.TabIndex = 27;
            // 
            // cbopaper
            // 
            this.cbopaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopaper.FormattingEnabled = true;
            this.cbopaper.Location = new System.Drawing.Point(625, 59);
            this.cbopaper.Name = "cbopaper";
            this.cbopaper.Size = new System.Drawing.Size(56, 23);
            this.cbopaper.TabIndex = 31;
            this.cbopaper.SelectedIndexChanged += new System.EventHandler(this.cbopaper_SelectedIndexChanged);
            this.cbopaper.MouseEnter += new System.EventHandler(this.cbopaper_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(572, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Paper";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Red;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(9, 137);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(149, 139);
            this.pictureBox4.TabIndex = 34;
            this.pictureBox4.TabStop = false;
            // 
            // pictssce
            // 
            this.pictssce.BackColor = System.Drawing.Color.SeaGreen;
            this.pictssce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictssce.Location = new System.Drawing.Point(161, 137);
            this.pictssce.Name = "pictssce";
            this.pictssce.Size = new System.Drawing.Size(536, 139);
            this.pictssce.TabIndex = 38;
            this.pictssce.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.pictureBox5.Location = new System.Drawing.Point(8, 102);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(691, 29);
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // lblfcount
            // 
            this.lblfcount.AutoSize = true;
            this.lblfcount.BackColor = System.Drawing.Color.Red;
            this.lblfcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfcount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblfcount.Location = new System.Drawing.Point(31, 144);
            this.lblfcount.Name = "lblfcount";
            this.lblfcount.Size = new System.Drawing.Size(108, 16);
            this.lblfcount.TabIndex = 43;
            this.lblfcount.Text = "Total Scanned";
            // 
            // lblcontent
            // 
            this.lblcontent.AutoSize = true;
            this.lblcontent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontent.Location = new System.Drawing.Point(227, 288);
            this.lblcontent.Name = "lblcontent";
            this.lblcontent.Size = new System.Drawing.Size(0, 16);
            this.lblcontent.TabIndex = 44;
            // 
            // lbldisplay
            // 
            this.lbldisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldisplay.AutoSize = true;
            this.lbldisplay.BackColor = System.Drawing.Color.Red;
            this.lbldisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisplay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbldisplay.Location = new System.Drawing.Point(73, 198);
            this.lbldisplay.Name = "lbldisplay";
            this.lbldisplay.Size = new System.Drawing.Size(15, 16);
            this.lbldisplay.TabIndex = 54;
            this.lbldisplay.Text = "0";
            this.lbldisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnHouseKeeping
            // 
            this.BtnHouseKeeping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHouseKeeping.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHouseKeeping.Location = new System.Drawing.Point(9, 283);
            this.BtnHouseKeeping.Name = "BtnHouseKeeping";
            this.BtnHouseKeeping.Size = new System.Drawing.Size(148, 27);
            this.BtnHouseKeeping.TabIndex = 55;
            this.BtnHouseKeeping.Text = "&House Keeping";
            this.BtnHouseKeeping.UseVisualStyleBackColor = true;
            this.BtnHouseKeeping.Click += new System.EventHandler(this.BtnHouseKeeping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(163, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Progress";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LvFiles
            // 
            this.LvFiles.HideSelection = false;
            this.LvFiles.Location = new System.Drawing.Point(161, 137);
            this.LvFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LvFiles.Name = "LvFiles";
            this.LvFiles.Size = new System.Drawing.Size(536, 139);
            this.LvFiles.TabIndex = 65;
            this.LvFiles.UseCompatibleStateImageBehavior = false;
            this.LvFiles.View = System.Windows.Forms.View.Details;
            // 
            // BtnReferesh
            // 
            this.BtnReferesh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReferesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReferesh.Location = new System.Drawing.Point(166, 283);
            this.BtnReferesh.Name = "BtnReferesh";
            this.BtnReferesh.Size = new System.Drawing.Size(93, 27);
            this.BtnReferesh.TabIndex = 66;
            this.BtnReferesh.Text = "&Refresh";
            this.BtnReferesh.UseVisualStyleBackColor = true;
            this.BtnReferesh.Click += new System.EventHandler(this.BtnReferesh_Click);
            // 
            // frmnewscan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(705, 322);
            this.ControlBox = false;
            this.Controls.Add(this.BtnReferesh);
            this.Controls.Add(this.LvFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnHouseKeeping);
            this.Controls.Add(this.lbldisplay);
            this.Controls.Add(this.lblcontent);
            this.Controls.Add(this.lblfcount);
            this.Controls.Add(this.pictssce);
            this.Controls.Add(this.cbopaper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtexam_type);
            this.Controls.Add(this.cbosubject);
            this.Controls.Add(this.cbostate);
            this.Controls.Add(this.txtexam_year);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblstate);
            this.Controls.Add(this.lblexam_type);
            this.Controls.Add(this.lblexam_year);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmnewscan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NECO SCANNING INTERFACE";
            this.Load += new System.EventHandler(this.frmnewscan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictssce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbosubject;
        internal System.Windows.Forms.ComboBox cbostate;
        internal System.Windows.Forms.TextBox txtexam_year;
        internal System.Windows.Forms.Label lblSubject;
        internal System.Windows.Forms.Label lblstate;
        internal System.Windows.Forms.Label lblexam_type;
        internal System.Windows.Forms.Label lblexam_year;
        internal System.Windows.Forms.Button btncancel;
        internal System.Windows.Forms.Button btnok;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TextBox txtexam_type;
        internal System.Windows.Forms.ComboBox cbopaper;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.PictureBox pictureBox4;
        internal System.Windows.Forms.PictureBox pictssce;
        internal System.Windows.Forms.PictureBox pictureBox5;
        internal System.Windows.Forms.Label lblfcount;
        internal System.Windows.Forms.Label lblcontent;
        internal System.Windows.Forms.Label lbldisplay;
        internal System.Windows.Forms.Button BtnHouseKeeping;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LvFiles;
        internal System.Windows.Forms.Button BtnReferesh;
    }
}


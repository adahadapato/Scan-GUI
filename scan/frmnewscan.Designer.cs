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
            this.txtsupervisor = new System.Windows.Forms.TextBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnumain = new System.Windows.Forms.MenuStrip();
            this.mnutools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsStopScanning = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsResumeScanning = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtexam_type = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbopaper = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkblind = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.mnumain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cbosubject
            // 
            this.cbosubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbosubject.FormattingEnabled = true;
            this.cbosubject.Location = new System.Drawing.Point(333, 139);
            this.cbosubject.Name = "cbosubject";
            this.cbosubject.Size = new System.Drawing.Size(193, 23);
            this.cbosubject.TabIndex = 25;
            this.cbosubject.SelectedIndexChanged += new System.EventHandler(this.cbosubject_SelectedIndexChanged);
            // 
            // cbostate
            // 
            this.cbostate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbostate.FormattingEnabled = true;
            this.cbostate.Location = new System.Drawing.Point(73, 139);
            this.cbostate.Name = "cbostate";
            this.cbostate.Size = new System.Drawing.Size(153, 23);
            this.cbostate.TabIndex = 24;
            this.cbostate.SelectedIndexChanged += new System.EventHandler(this.cbostate_SelectedIndexChanged);
            // 
            // txtexam_year
            // 
            this.txtexam_year.Enabled = false;
            this.txtexam_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexam_year.Location = new System.Drawing.Point(146, 101);
            this.txtexam_year.MaxLength = 4;
            this.txtexam_year.Name = "txtexam_year";
            this.txtexam_year.Size = new System.Drawing.Size(80, 21);
            this.txtexam_year.TabIndex = 22;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(243, 139);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(60, 16);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject";
            // 
            // lblstate
            // 
            this.lblstate.AutoSize = true;
            this.lblstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstate.Location = new System.Drawing.Point(23, 139);
            this.lblstate.Name = "lblstate";
            this.lblstate.Size = new System.Drawing.Size(44, 16);
            this.lblstate.TabIndex = 20;
            this.lblstate.Text = "State";
            // 
            // lblexam_type
            // 
            this.lblexam_type.AutoSize = true;
            this.lblexam_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexam_type.Location = new System.Drawing.Point(243, 101);
            this.lblexam_type.Name = "lblexam_type";
            this.lblexam_type.Size = new System.Drawing.Size(86, 16);
            this.lblexam_type.TabIndex = 19;
            this.lblexam_type.Text = "Exam Type";
            // 
            // lblexam_year
            // 
            this.lblexam_year.AutoSize = true;
            this.lblexam_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexam_year.Location = new System.Drawing.Point(23, 101);
            this.lblexam_year.Name = "lblexam_year";
            this.lblexam_year.Size = new System.Drawing.Size(83, 16);
            this.lblexam_year.TabIndex = 18;
            this.lblexam_year.Text = "Exam Year";
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(634, 288);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 27);
            this.btncancel.TabIndex = 17;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(553, 288);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 27);
            this.btnok.TabIndex = 16;
            this.btnok.Text = "&OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtsupervisor
            // 
            this.txtsupervisor.BackColor = System.Drawing.Color.Gray;
            this.txtsupervisor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsupervisor.Enabled = false;
            this.txtsupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsupervisor.Location = new System.Drawing.Point(138, 44);
            this.txtsupervisor.Name = "txtsupervisor";
            this.txtsupervisor.Size = new System.Drawing.Size(367, 19);
            this.txtsupervisor.TabIndex = 15;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox2.Location = new System.Drawing.Point(16, 32);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(693, 44);
            this.PictureBox2.TabIndex = 14;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox1.Location = new System.Drawing.Point(16, 90);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(693, 82);
            this.PictureBox1.TabIndex = 13;
            this.PictureBox1.TabStop = false;
            // 
            // mnumain
            // 
            this.mnumain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnumain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutools,
            this.helpToolStripMenuItem});
            this.mnumain.Location = new System.Drawing.Point(0, 0);
            this.mnumain.Name = "mnumain";
            this.mnumain.Size = new System.Drawing.Size(723, 24);
            this.mnumain.TabIndex = 26;
            this.mnumain.Text = "menuStrip1";
            // 
            // mnutools
            // 
            this.mnutools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsStopScanning,
            this.mnuToolsResumeScanning});
            this.mnutools.Name = "mnutools";
            this.mnutools.Size = new System.Drawing.Size(48, 20);
            this.mnutools.Text = "&Tools";
            // 
            // mnuToolsStopScanning
            // 
            this.mnuToolsStopScanning.Name = "mnuToolsStopScanning";
            this.mnuToolsStopScanning.Size = new System.Drawing.Size(182, 22);
            this.mnuToolsStopScanning.Text = "&Stop Scanning";
            this.mnuToolsStopScanning.Click += new System.EventHandler(this.mnuToolsStopScanning_Click);
            // 
            // mnuToolsResumeScanning
            // 
            this.mnuToolsResumeScanning.Name = "mnuToolsResumeScanning";
            this.mnuToolsResumeScanning.Size = new System.Drawing.Size(182, 22);
            this.mnuToolsResumeScanning.Text = "&Resume Scanning";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // txtexam_type
            // 
            this.txtexam_type.Enabled = false;
            this.txtexam_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexam_type.Location = new System.Drawing.Point(335, 100);
            this.txtexam_type.Name = "txtexam_type";
            this.txtexam_type.Size = new System.Drawing.Size(233, 21);
            this.txtexam_type.TabIndex = 27;
            this.txtexam_type.TextChanged += new System.EventHandler(this.txtexam_type_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(15, 200);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(693, 82);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Other Jobs";
            // 
            // cbopaper
            // 
            this.cbopaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopaper.FormattingEnabled = true;
            this.cbopaper.Location = new System.Drawing.Point(592, 139);
            this.cbopaper.Name = "cbopaper";
            this.cbopaper.Size = new System.Drawing.Size(110, 23);
            this.cbopaper.TabIndex = 31;
            this.cbopaper.SelectedIndexChanged += new System.EventHandler(this.cbopaper_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(539, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Paper";
            // 
            // chkblind
            // 
            this.chkblind.AutoSize = true;
            this.chkblind.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkblind.Location = new System.Drawing.Point(519, 46);
            this.chkblind.Name = "chkblind";
            this.chkblind.Size = new System.Drawing.Size(133, 20);
            this.chkblind.TabIndex = 32;
            this.chkblind.Text = "Blind Candidates";
            this.chkblind.UseVisualStyleBackColor = true;
            this.chkblind.CheckedChanged += new System.EventHandler(this.chkblind_CheckedChanged);
            // 
            // frmnewscan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 317);
            this.Controls.Add(this.chkblind);
            this.Controls.Add(this.cbopaper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
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
            this.Controls.Add(this.txtsupervisor);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.mnumain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnumain;
            this.Name = "frmnewscan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NECO SCANNING INTERFACE";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmnewscan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.mnumain.ResumeLayout(false);
            this.mnumain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        internal System.Windows.Forms.TextBox txtsupervisor;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.MenuStrip mnumain;
        internal System.Windows.Forms.TextBox txtexam_type;
        internal System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbopaper;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem mnutools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsStopScanning;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsResumeScanning;
        private System.Windows.Forms.CheckBox chkblind;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}


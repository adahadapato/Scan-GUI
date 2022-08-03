namespace scan
{
    partial class frmsettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.txtexamyear = new System.Windows.Forms.TextBox();
            this.cboexamType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdcontinue = new System.Windows.Forms.Button();
            this.cmdcancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year";
            // 
            // cboJob
            // 
            this.cboJob.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(60, 50);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(184, 24);
            this.cboJob.TabIndex = 2;
            this.cboJob.SelectedIndexChanged += new System.EventHandler(this.cboJob_SelectedIndexChanged);
            // 
            // txtexamyear
            // 
            this.txtexamyear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexamyear.Location = new System.Drawing.Point(60, 21);
            this.txtexamyear.Name = "txtexamyear";
            this.txtexamyear.Size = new System.Drawing.Size(100, 23);
            this.txtexamyear.TabIndex = 0;
            this.txtexamyear.TextChanged += new System.EventHandler(this.txtexamyear_TextChanged);
            // 
            // cboexamType
            // 
            this.cboexamType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboexamType.FormattingEnabled = true;
            this.cboexamType.Location = new System.Drawing.Point(60, 85);
            this.cboexamType.Name = "cboexamType";
            this.cboexamType.Size = new System.Drawing.Size(184, 24);
            this.cboexamType.TabIndex = 5;
            this.cboexamType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exam";
            // 
            // cmdcontinue
            // 
            this.cmdcontinue.Enabled = false;
            this.cmdcontinue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcontinue.Location = new System.Drawing.Point(60, 127);
            this.cmdcontinue.Name = "cmdcontinue";
            this.cmdcontinue.Size = new System.Drawing.Size(75, 23);
            this.cmdcontinue.TabIndex = 6;
            this.cmdcontinue.Text = "Continue";
            this.cmdcontinue.UseVisualStyleBackColor = true;
            this.cmdcontinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdcancel
            // 
            this.cmdcancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcancel.Location = new System.Drawing.Point(150, 127);
            this.cmdcancel.Name = "cmdcancel";
            this.cmdcancel.Size = new System.Drawing.Size(75, 23);
            this.cmdcancel.TabIndex = 7;
            this.cmdcancel.Text = "Cancel";
            this.cmdcancel.UseVisualStyleBackColor = true;
            this.cmdcancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 162);
            this.Controls.Add(this.cmdcancel);
            this.Controls.Add(this.cmdcontinue);
            this.Controls.Add(this.cboexamType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtexamyear);
            this.Controls.Add(this.cboJob);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmsettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NECO Scan Settings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.TextBox txtexamyear;
        private System.Windows.Forms.ComboBox cboexamType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdcontinue;
        private System.Windows.Forms.Button cmdcancel;
    }
}
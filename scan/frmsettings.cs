using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace scan
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
        }

        private void frmsettings_Load(object sender, EventArgs e)
        {
            cboJob.Items.Add("Essay");
            cboJob.Items.Add("Obj");
            cboJob.Items.Add("Dummy");
            cboJob.Items.Add("Cross Check/Validation");
            //cboJob.Items.Add("");

            cboexamType.Items.Add("SSCE JUN/JUL");
            cboexamType.Items.Add("SSCE NOV/DEC");
            cboexamType.Items.Add("BECE");
            cboexamType.Items.Add("NCEE");
            cboexamType.Items.Add("NEEFUSSC");
            cboexamType.Items.Add("Others"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f= new frmuid ();
            f.Show();


            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", true);
                    mICParams.SetValue("examType", cboexamType.Text .Trim ());
                    mICParams.SetValue("examYear", txtexamyear.Text .Trim ());
                    mICParams.SetValue("Job", cboJob.Text.Trim());
                    mICParams.SetValue("Status", "Active");
                    if (cboexamType.Text == "NCEE" || cboexamType.Text == "NEEFUSSC")
                    {
                        mICParams.SetValue("subject", "Paper 1");
                    }
                    else
                    {
                        mICParams.SetValue("subject", "English");
                    }
                    break;

                }

            }
            mICParams.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0; 
        }

        private void txtexamyear_TextChanged(object sender, EventArgs e)
        {
            cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0; 
        }

        private void cboJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Win32;

namespace scan
{
    public partial class frmsettings : Form

    {
        public frmsettings()
        {
            InitializeComponent();
        }
        string mExpectedSheets,mpaper,ScanType,mscanner,paperType;
        bool mBlind, mSup,mresit,normal, mblank;
        private void frmsettings_Load(object sender, EventArgs e)
        {
            optnormal.Checked = getRegistryValues.GetRegistryValue("scanType") == "Main";
            optA.Checked = getRegistryValues.GetRegistryValue("scanType") == "TypeA";
            optB.Checked = getRegistryValues.GetRegistryValue("scanType") == "TypeB";
            optC.Checked = getRegistryValues.GetRegistryValue("scanType") == "TypeC";
            optD.Checked = getRegistryValues.GetRegistryValue("scanType") == "TypeD";
            FillComboBoxes.GetScannerType(cmbscaner);
            ScanType = getRegistryValues.GetRegistryValue("scanType");  
            txtexamyear.Text = getRegistryValues.GetRegistryValue("examYear");
            cboJob.Text = getRegistryValues.GetRegistryValue("Job");
            mscanner = getRegistryValues.GetRegistryValue("Scanner");
            cmbscaner.Text = mscanner;
            cmbscaner.Refresh();
            if (getRegistryValues.GetRegistryValue("examType") == "SSCE JUN/JUL" || getRegistryValues.GetRegistryValue("examType") == "SSCE NOV/DEC" ||
                getRegistryValues.GetRegistryValue("examType") == "BECE" || getRegistryValues.GetRegistryValue("examType") == "NEEFUSSC" ||
                getRegistryValues.GetRegistryValue("examType") == "NCEE")
            {
                cboexamType.Text = getRegistryValues.GetRegistryValue("examType");
            }
            else
            {
                cboexamType.Text = "Others";
                txtothers.Text = getRegistryValues.GetRegistryValue("examType");
            }
            
            hidesettings(cboexamType.Text);
            txtexpectedsheets.Text = getRegistryValues.GetRegistryValue("ExpectedSheets");
            chkblind.Checked = Convert.ToBoolean (getRegistryValues.GetRegistryValue("Blind")) == true;   
            chksuplementry.Checked =Convert.ToBoolean(getRegistryValues.GetRegistryValue("Suplementary"))==true ;
            chkresit.Checked = Convert.ToBoolean(getRegistryValues.GetRegistryValue("resit")) == true;
            chkBlank.Checked = Convert.ToBoolean(getRegistryValues.GetRegistryValue("Blank")) == true;   
            this.Text = this.Text + " " + UtilityClass.ProgramVersion(); 
            FillComboBoxes.GetJobDescription(cboJob);
            FillComboBoxes.GetExamType(cboexamType);
            
            mBlind = false;
            mSup = false;
            mresit = false;
            mblank = false;
        }

        private void hidesettings(string examtype)
        {
            switch (examtype)
            {
                case "BECE":
                    chkresit.Enabled = true;
                    txtothers.Enabled = false;
                    chkBlank.Enabled = true;
                    
                    break;
                case "Others":
                    
                    chkresit.Enabled = false;
                    txtothers.Enabled = true;
                    chkBlank.Enabled = false;
                    
                    break;

                case "SSCE JUN/JUL":
                    txtothers.Enabled = false;
                    chkresit.Enabled = false;
                    chkBlank.Enabled = true;

                    break;
                case "SSCE NOV/DEC":
                    txtothers.Enabled = false;
                    chkresit.Enabled = false;
                    chkBlank.Enabled = true;

                    break;
                
            }
            
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mExpectedSheets = "500";
            mscanner = cmbscaner.Text.ToUpper().Trim();
            if (!String.IsNullOrEmpty(txtexpectedsheets.Text.Trim()))
            {
                if (!IsNummeric(txtexpectedsheets.Text, System.Globalization.NumberStyles.Any))
                {
                    MessageBox.Show("Invalid value of expected sheets");
                    this.Dispose();
                    Application.Exit();
                }
                else
                {
                    mExpectedSheets = txtexpectedsheets.Text.Trim();
                }
            }
            if ((cboexamType.Text == "NCEE" || cboexamType.Text == "NEEFUSSC") && cboJob.Text == "Essay" )
            {
                MessageBox.Show("Invalid Job description ", "Settings", MessageBoxButtons.OK,  MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            Form f = new frmuid();
            f.Show();
            if (cboexamType.Text == "NCEE" || cboexamType.Text == "NEEFUSSC")
            {
                mpaper= "Paper 1";
            }
            else
            {
                 mpaper ="English Language";
            }
            string regExamType,scanDIr="";
            if (cboexamType.Text == "Others")
            {
                regExamType = txtothers.Text;
                scanDIr = UtilityClass.Dialogue("Scan Path", "Enter the full path name of the scan directory",false );  
            }
            else
            {
                regExamType = cboexamType.Text;
            }
            if (cboexamType.Text == "Others" && String.IsNullOrEmpty(scanDIr))
            {
                MessageBox.Show("Please specify the scan directory", "Scan Dir",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                Application.Exit();
               
            }
            /*if (!mBlind && !mSup && !mresit && normal)
            {
                ScanType = "Main_" + GetSystemName.SystemName();  
            }*/
            string rrType = ScanType;
            ScanType += "_" + GetSystemName.SystemName();
            string[] jobs = { "Registration","Validation","Dummy","Malpractice", "Online Corrections" };
            foreach(string s in jobs)
            {
                if (cboJob.Text == s)
                {
                    ScanType = "";
                }
            }
           
            //Create the scan directory and r3turn the directory 
            //name to be written into the system registry.

            string scanDir=CreateJobDir.CreateDir(CreateJobDir.BiuldJobDir(cboexamType.Text, txtexamyear.Text, cboJob.Text, scanDIr), ScanType, "");
            string[] regKey = {"Scanner", "examType", "examYear", "Job", "Status", "ExpectedSheets","subject","Blind" ,"Suplementary","resit", "Blank","scandir","sosdir","scanType"};
            string[] rValues = { mscanner, regExamType, txtexamyear.Text, cboJob.Text, "Active", mExpectedSheets, mpaper, mBlind.ToString(), mSup.ToString(), mresit.ToString(), mblank.ToString(), scanDir, CreateJobDir.BiuldJobDir(cboexamType.Text, txtexamyear.Text, cboJob.Text, scanDIr),rrType};
            getRegistryValues.UpdateRegistry(@"software\necoscan", regKey, rValues);
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0;
            hidesettings(cboexamType.Text);
            
        }

        private void txtexamyear_TextChanged(object sender, EventArgs e)
        {
            //cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0; 
        }

        private void cboJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmdcontinue.Enabled = txtexamyear.Text.Length > 0 && cboexamType.Text.Length > 0 && cboJob.Text.Length > 0; 
        }
        private bool IsNummeric(string value, System.Globalization.NumberStyles NumberStyle)
        {
            int result;
            return int.TryParse(value, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chkblind_CheckedChanged(object sender, EventArgs e)
        {
            if (chkblind.Checked == true)
            {
                mBlind = true;
                ScanType = "Blind"   ;
            }
           
        }

        private void chkBlank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlank.Checked == true)
            {
                mblank = true;
                ScanType = "Blank";
            }
        }

        private void chksuplementry_CheckedChanged(object sender, EventArgs e)
        {
            if (chksuplementry.Checked == true)
            {
                mSup = true;
                ScanType = "Sup";
                //if (MessageBox.Show("Is this a fresh supplementry scanning", "Supplementry Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    mNewScan = true;
                //}
            }else
            {
                mSup = false;
                ScanType = "";
            }
           
        }

        private void chkresit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkresit.Checked == true)
            {
                mresit = true;
                ScanType = "Resit";
            }
        }

        private void optnormal_CheckedChanged(object sender, EventArgs e)
        {
            if (optnormal.Checked == true)
            {
                normal = true;
                ScanType = "Main";
               
            }
        }

        private void optA_CheckedChanged(object sender, EventArgs e)
        {
            if (optA.Checked == true)
            {
                normal = false;
                ScanType = "TypeA";

            }
        }

        private void optB_CheckedChanged(object sender, EventArgs e)
        {
            if (optB.Checked == true)
            {
                normal = false;
                ScanType = "TypeB";
            }
        }

        private void optC_CheckedChanged(object sender, EventArgs e)
        {
            if (optC.Checked == true)
            {
                normal = false;
                ScanType = "TypeC";

            }
        }

        private void optD_CheckedChanged(object sender, EventArgs e)
        {
            if (optD.Checked == true)
            {
                normal = false;
                ScanType = "TypeD";

            }
        }

        private void cmbscaner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

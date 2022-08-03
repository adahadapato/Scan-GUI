using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace scan
{
    public partial class frmnewscan : Form
    {
        WorkOnDefFile WrkNDef = new WorkOnDefFile();
        bool verify;
        string ComSubjCode, ComExamType ,ComSubject, ComState,ComExamYear ,ComScanDir, ComSosDir,ComCompanion,comJob,comPaper ;
        string comStateCode,comBatchNumber,comBlind;
        string ComDefFile,ComShortSubj;
        bool firstTime = true;
        bool logout;
        string comUserName;
        public frmnewscan()
        {
            InitializeComponent();
        }

        

        private void btncancel_Click(object sender, EventArgs e)
        {
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", true);
                    mICParams.SetValue("startBatch", false);
                    mICParams.SetValue("logout", true);
                    mICParams.SetValue("UID","Default");
                    break;

                }

            }
            mICParams.Close();

            QuiaApplication();
        }

        internal void QuiaApplication()
        {
            this.Dispose();
            Application.Exit();
        }

        private void frmnewscan_Load(object sender, EventArgs e)
        {
            UtilityClass.GetStates(cbostate);
            UtilityClass.getPaper(cbopaper);
            this.Text = this.Text + " (" + Environment.MachineName.ToUpper().Trim() + ")";
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", false);
                     foreach (string val in mICParams.GetValueNames())
                    {
                        if (val == "firstTime")
                        {
                            firstTime = Convert.ToBoolean(mICParams.GetValue("firstTime").ToString());
                            if (firstTime == false)
                            {
                                txtexam_year.Text = mICParams.GetValue("examYear").ToString();
                                txtexam_type.Text = mICParams.GetValue("examType").ToString().ToUpper();
                                cbostate.Text = mICParams.GetValue("state").ToString();
                                cbosubject.Text = mICParams.GetValue("subject").ToString();
                                ComSubject = mICParams.GetValue("subject").ToString();
                                ComShortSubj = mICParams.GetValue("shortsubj").ToString();
                                comUserName = mICParams.GetValue("UID").ToString();
                                comJob = mICParams.GetValue("Job").ToString ();
                                cbopaper.Text = mICParams.GetValue("paper").ToString ();
                                comPaper = mICParams.GetValue("paper").ToString();
                                logout = Convert.ToBoolean(mICParams.GetValue("logout"));
                                cbosubject.Refresh();
                                StoreVals();
                                ComSubjCode = UtilityClass.getSubjectCode(cbosubject.Text.Trim(), txtexam_type.Text.Substring(0, 4),comJob);
                                //UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);   
                                
                            }
                            else
                            {
                                comUserName = mICParams.GetValue("UID").ToString();
                                logout = Convert.ToBoolean(mICParams.GetValue("logout"));
                                txtexam_year.Text = mICParams.GetValue("examYear").ToString();
                                txtexam_type.Text = mICParams.GetValue("examType").ToString().ToUpper();
                                comJob = mICParams.GetValue("Job").ToString();
                                StoreVals();
                                ComSubjCode = UtilityClass.getSubjectCode(mICParams.GetValue("subject").ToString (),mICParams .GetValue("examType").ToString ().Substring(0, 4),comJob );   
                                

                            }
                            break;
                        }
                    }

                }

            }

            if (comJob == "Obj" ||(comJob =="Essay" && txtexam_type .Text .Trim ()=="BECE"))
            {
                cbopaper.Enabled = false;
            }
            else
            {
                cbopaper.Enabled = true;

            }

            if (txtexam_type.Text.Trim() == "NEEFUSSC" || txtexam_type.Text.Trim() == "NCEE")
            {
                cbostate.Enabled = false;
                cbopaper.Enabled = false;
                
            }

            if (logout == false)
            {
                this.Text = this.Text + " - " + comUserName;
            }
            mICParams.Close();
            
        }

        private void StoreVals()
        {
            cbosubject.Items.Clear();
            string cexam = txtexam_type.Text.Trim();
            switch(cexam)
            {
                case "SSCE NOV/DEC":
                    if (comJob == "Essay" )
                    {
                        ComSosDir = @"c:\novems" + txtexam_year.Text.Trim().Substring(2, 2);
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4),comJob);
                        ComScanDir = ComSosDir;//+ @"\" + ComState;
                        ComDefFile = "necoems";
                    }
                    if (comJob == "Obj")
                    {
                        ComSosDir = @"c:\novans" + txtexam_year.Text.Trim().Substring(2, 2);
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);
                        ComScanDir = ComSosDir + @"\" + ComState + comBlind;
                        ComDefFile = "sscescan";
                        //comJob = "Obj";
                    }
                    break;
                case "SSCE JUN/JUL":
                    if (comJob == "Essay" )
                    {
                        ComSosDir = @"c:\ems" + txtexam_year.Text.Trim();
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);
                        ComScanDir = ComSosDir;// +@"\" + ComState;
                        ComDefFile = "necoems";
                        //comJob = "Essay";
                    }
                    if (comJob == "Obj")
                    {
                        ComSosDir = @"c:\sscean" + txtexam_year.Text.Trim().Substring(2, 2);
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);
                        ComScanDir = ComSosDir + @"\" + ComState  + comBlind;
                        ComDefFile = "sscescan";
                        //comJob = "Obj";
                    }
                    break;
                case "BECE":
                    if (comJob == "Essay" )
                    {
                        ComSosDir = @"c:\beceems" + txtexam_year.Text.Trim().Substring(2, 2);
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);
                        ComScanDir = ComSosDir;// +@"\" + ComState;
                        ComDefFile = "necoems";
                        
                    }
                    if (comJob == "Obj")
                    {
                        ComSosDir = @"c:\beceans" + txtexam_year.Text.Trim().Substring(2, 2);
                        UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);
                        ComScanDir = ComSosDir + @"\" + ComState +  comBlind;
                        ComDefFile = "becescan";
                     }
                    break;
                case "NCEE":
                    ComSosDir = @"c:\nce" + txtexam_year.Text.Trim();
                    UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);  
                    ComScanDir = ComSosDir + @"\" + ComSubject;
                    ComDefFile = "ncescan"+ComSubject.Substring(6,1) ;
                    break;
                case "NEEFUSSC":
                    ComSosDir = @"c:\neef" + txtexam_year.Text.Trim().Substring(2, 2);
                    UtilityClass.getSubjects(cbosubject, txtexam_type.Text.Substring(0, 4), comJob);  
                    ComScanDir = ComSosDir + @"\" + ComSubject;
                    ComDefFile = "neefscan"+ComSubject.Substring(6,1);
                    //comJob = "Obj";
                    break;
            }
            ComCompanion = "sCompanion.companion";
        }

        private void cboexam_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbostate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComState = cbostate.Text.Trim();
            comStateCode = UtilityClass.getStateCode(ComState);   
        }

        private void cbosubject_SelectedIndexChanged(object sender, EventArgs e)
        {
           ComSubject = cbosubject.Text.Trim();
           ComShortSubj =UtilityClass.getShortSubject(cbosubject.Text.Trim(), txtexam_type.Text .Substring (0,4));
           ComSubjCode = UtilityClass.getSubjectCode(cbosubject.Text.Trim(), txtexam_type.Text.Substring(0, 4),comJob );
          
        }

        internal bool VerifyTextBoxEntries()
        {
            verify = true;
            try
            {
                if (string.IsNullOrEmpty(txtexam_type.Text))
                {
                    MessageBox.Show("Exam type cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                    
                }
                if (string.IsNullOrEmpty(txtexam_year.Text) && verify == true)
                {
                    MessageBox.Show("Exam year cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbosubject.Text) && verify == true)
                {
                    MessageBox.Show("Subject cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbostate.Text) && verify == true)
                {
                    MessageBox.Show("State cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbopaper.Text) && verify == true && comJob == "Essay" && txtexam_type.Text !="BECE")
                {
                    MessageBox.Show("Paper cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return verify;
        }

        private void SetScanning()
        {
            VerifyTextBoxEntries();
            try
            {
                if (verify == true)
                {

                    ComExamType = txtexam_type.Text.Trim();
                    ComSubject = cbosubject.Text.Trim();
                    ComState = cbostate.Text.Trim();
                    ComExamYear = txtexam_year.Text.Trim();
                    StoreVals();
                    ComShortSubj = UtilityClass.getShortSubject(ComSubject, ComExamType.Substring(0, 4));
                    ComSubjCode = UtilityClass.getSubjectCode(ComSubject, ComExamType.Substring(0, 4), comJob);
                    WrkNDef.CreateDir(ComScanDir, ComSosDir);
                    if (comJob == "Essay" && ComExamType.Substring(0, 4) == "SSCE")
                    {
                        string pap = UtilityClass.getPaperCode(ComSubjCode, comPaper);
                        comBatchNumber = ICreateBatchNumber.CreateBatchNumber(ComScanDir, pap, comStateCode, ComExamType, comJob);
                    }
                    else
                    {
                        comBatchNumber = ICreateBatchNumber.CreateBatchNumber(ComScanDir, ComSubjCode, comStateCode, ComExamType, comJob);
                    }

                    if (comBatchNumber != "000000.000")
                    {



                        if (ComExamType == "NEEFUSSC" || ComExamType == "NCEE")
                        {
                            ComShortSubj = ComSubject;
                        }

                        WrkNDef.ModifyDefFle(ComSosDir, ComDefFile, ComScanDir, ComCompanion, txtexam_year.Text,
                                             txtexam_type.Text, ComShortSubj, ComState, comUserName, comBatchNumber);
                        if (MessageBox.Show("Scanning Parameters Set Successfully\n "+
                                            "Do you want to continue ", "NECO SCAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                        {
                            RegistryKey mICParams = Registry.CurrentUser;
                            mICParams = mICParams.OpenSubKey("software", true);
                            foreach (string Keyname in mICParams.GetSubKeyNames())
                            {

                                if (Keyname == "necoscan")
                                {
                                    mICParams = mICParams.OpenSubKey("necoscan", true);
                                    mICParams.SetValue("startBatch", true);
                                    mICParams.SetValue("scanDir", ComSosDir);
                                    mICParams.SetValue("examYear", ComExamYear);
                                    mICParams.SetValue("examType", ComExamType);
                                    mICParams.SetValue("subject", ComSubject);
                                    mICParams.SetValue("state", ComState);
                                    mICParams.SetValue("firstTime", false);
                                    mICParams.SetValue("shortsubj", ComShortSubj);
                                    mICParams.SetValue("UID", comUserName);
                                    mICParams.SetValue("Logout", false);
                                    if (comJob == "Essay" && ComExamType.Substring(0, 4) == "SSCE")
                                    {
                                        mICParams.SetValue("paper", comPaper);
                                    }
                                    break;
                                }

                            }

                            mICParams = Registry.CurrentUser;
                            mICParams = mICParams.OpenSubKey(@"software\DRS\Sosinpw\Job", true);
                            mICParams.SetValue("LastDecodeLoaded", ComSosDir + @"\" + ComDefFile + ".sos");
                            mICParams.Close();
                            Process.Start(@"c:\program files\drs\skw\Sosinpw.exe");
                        }
                    }
                    else
                    {
                        QuiaApplication();
                    }

                    }
                    else
                    {
                        return;
                    }

                }
            
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "NECO SCAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Dispose();
            Application.Exit();
        }

        private void SetCrossCheck()
        {

        }

        private void SetDummy()
        {
          /*  try
                
            {
                ComExamType = txtexam_type.Text.Trim();
                ComSubject = cbosubject.Text.Trim();
                ComState = cbostate.Text.Trim();
                ComExamYear = txtexam_year.Text.Trim();
                StoreVals();
                ComShortSubj = UtilityClass.getShortSubject(ComSubject, ComExamType.Substring(0, 4));
                ComSubjCode = UtilityClass.getSubjectCode(ComSubject, ComExamType.Substring(0, 4));
                Process.Start(@"C:\projects\c#projects\Dummy\Dummy\bin\Debug\dummy.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "NECO SCAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Dispose();
            Application.Exit();*/
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (comJob == "Essay" || comJob == "Obj")
            {
                SetScanning();
            }
            if (comJob == "Dummy")
            {
                SetDummy();
            }
            
        }
        
        
        
        private void txtexam_type_TextChanged(object sender, EventArgs e)
        {
            //tSubjCode(cbosubject.Text.Trim()); 
        }

                      

        private void cbopaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPaper = cbopaper.Text.Trim();
        }

        private void mnuToolsStopScanning_Click(object sender, EventArgs e)
        {
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", true);
                    mICParams.SetValue ("Status","Stop");
                    //mICParams.SetValue("","");
                }
            }
            this.Dispose();
            Application.Exit();
        }

        private void chkblind_CheckedChanged(object sender, EventArgs e)
        {
            if (chkblind.Checked == true)
            {
                comBlind = @"\blind";
            }
            else
            {
                comBlind = "";
            }
        }
                       
    }
}

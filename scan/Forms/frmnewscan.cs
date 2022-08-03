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
using scan.Models;
using System.Threading.Tasks;
using SCRghelp.Infrastructure;
//using scan.ApiInfrastructure;
using scan.Classes;
using scan.Forms;
using scan.Data;

namespace scan
{
    public partial class frmnewscan : Form
    {
        RegistryHelperClass regHelper = new RegistryHelperClass();
        bool verify;
        string ComSubjCode, ComExamType ,ComSubject, ComState,ComExamYear ,ComScanDir, ComSosDir,ComCompanion,comJob,comPaper ;
        string comStateCode,comBatchNumber,comSheet;
        string ComDefFile,ComShortSubj,mSubjCode,ScanType;
        bool logout,IsBlind,IsSuplementary,IsResit, IsBlank;
        int AnswerSheet;
        string comUserName;
        
        List<string> _MissingFiles = new List<string>();
        

        private delegate void Function();
        public frmnewscan()
        {
            InitializeComponent();
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit scanning", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                QuiaApplication();
            else
                return;
        }

        internal void QuiaApplication()
        {
            QuitApplication.Quit();
            this.Dispose();
            Application.Exit();
        }
        private void SetDefault(Button myDefaultBtn)
        {
            AcceptButton = myDefaultBtn;
        }
        private async void frmnewscan_Load(object sender, EventArgs e)
        {
            
            btncancel.Enabled = btnok.Enabled = false;
            try
            {
                InitializeListView();

                BtnHouseKeeping.Enabled = false;
                SetDefault(btnok);
                AnswerSheet = (regHelper.ExamYear == "2000") ? 1 : 0;
                await FillComboBoxes.GetStates(cbostate);
                this.Text = this.Text + " (" + Environment.MachineName.ToUpper().Trim() + ")";// + " " + UtilityClass.ProgramVersion(); 
                txtexam_year.Text = regHelper.ExamYear;// getRegistryValues.GetRegistryValue("examYear");
                txtexam_type.Text = regHelper.ExamType;// getRegistryValues.GetRegistryValue("examType").ToString().ToUpper();
                //pictbece.Enabled = txtexam_type.Text.Contains("BECE");
                pictssce.Enabled = txtexam_type.Text.Contains("SSCE");
                cbostate.Text = regHelper.State;//  getRegistryValues.GetRegistryValue("state");

                ComSubject = regHelper.Subject;// getRegistryValues.GetRegistryValue("subject");
                                               //MessageBox.Show(ComSubject,"COM Subject");


                ComShortSubj = regHelper.ShortSubj;//  getRegistryValues.GetRegistryValue("shortsubj");

                //MessageBox.Show(ComShortSubj, "COM Short Subject");
                comUserName = regHelper.UID;// getRegistryValues.GetRegistryValue("UID");
                comJob = regHelper.Job;// getRegistryValues.GetRegistryValue("Job");
                cbopaper.Text = regHelper.Paper;// getRegistryValues.GetRegistryValue("paper");
                cbopaper.Refresh();
                comPaper = regHelper.Paper;// getRegistryValues.GetRegistryValue("paper");
                logout = regHelper.LogOut;// Convert.ToBoolean(getRegistryValues.GetRegistryValue("logout"));
                IsBlind = regHelper.IsBlind;// Convert.ToBoolean(getRegistryValues.GetRegistryValue("Blind"));
                IsSuplementary = regHelper.IsSuplementary;// Convert.ToBoolean(getRegistryValues.GetRegistryValue("Suplementary"));
                IsResit = regHelper.IsResit;// Convert.ToBoolean(getRegistryValues.GetRegistryValue("resit"));
                IsBlank = regHelper.IsBlank;// Convert.ToBoolean(getRegistryValues.GetRegistryValue("Blank"));


                StoreVals();
                cbosubject.Text = regHelper.Subject;// getRegistryValues.GetRegistryValue("subject");
                                                    //cbosubject.Refresh();
                SubjectModel current = (SubjectModel)cbosubject.SelectedValue;
                if (current != null)
                {
                    ComSubjCode = current.code;
                    mSubjCode = current.subj_code;


                    btnok.Enabled = true;
                    var p = current.paper;
                    foreach (var c in p)
                        cbopaper.Items.Add(c);

                    if (comJob == "Essay" && (txtexam_type.Text.Trim().Contains("SSCE") || txtexam_type.Text.Trim() == "BECE"))
                    {
                        cbopaper.Enabled = true;
                    }
                    if (comJob == "Obj" && txtexam_type.Text.Trim().Contains("SSCE"))
                    {
                        cbopaper.Enabled = false;
                        cbopaper.Text = "3";
                        cbopaper.Refresh();
                        comPaper = " ";
                    }
                    if (txtexam_type.Text.Trim() == "NEEFUSSC" || txtexam_type.Text.Trim() == "NCEE")
                    {
                        cbostate.Enabled = false;
                        cbopaper.Enabled = false;
                        comPaper = " ";

                    }

                    if (logout == false)
                    {
                        this.Text = this.Text + " - " + comUserName;
                    }

                    
                    cbopaper.Refresh();
                }

               
                lbldisplay.Text = await InventoryClass.GetTotalScanned();
                _MissingFiles = await InventoryClass.GetLocalInventory();
                BtnHouseKeeping.Enabled = Program.housekeeping;
                
                btncancel.Enabled = btnok.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private async void StoreVals()
        {
            try
            {
                cbosubject.Items.Clear();
                string cexam = txtexam_type.Text.Trim();
                await FillComboBoxes.getSubjects(cbosubject);
                string[] retVal = InitializeValues.StoreVals(cexam,  comJob, ComSubject, AnswerSheet, "");
                ComSosDir = regHelper.SosDir;// getRegistryValues.GetRegistryValue("sosDir");
                ComScanDir = regHelper.ScanDir;// getRegistryValues.GetRegistryValue("scandir");
                ComDefFile = retVal[0];
                ComCompanion = retVal[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Store Vals");
            }
        }

        private void cboexam_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbostate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComState = cbostate.Text.Trim();
            StateModel current = (StateModel)cbostate.SelectedValue;
            comStateCode = current.Code.Substring(1,2);// UtilityClass.getStateCode(ComState);  
            regHelper.StateCode = comStateCode;
        }

        private void cbosubject_SelectedIndexChanged(object sender, EventArgs e)
        {
           ComSubject = cbosubject.Text.Trim();
          
           cbopaper.Items.Clear();
            SubjectModel current = (SubjectModel)cbosubject.SelectedValue;
            ComShortSubj = current.subject;
            ComSubjCode = current.code;
            var p = current.paper;
            //cbopaper.DataSource = p;
            foreach (var s in p)
                cbopaper.Items.Add(s);

            cbopaper.Text = p[0].ToString();
            cbopaper.Refresh();

            regHelper.Subject = ComSubject;
            regHelper.Paper = cbopaper.Text;
            regHelper.ShortSubj = ComShortSubj;
            regHelper.SubjCode =  current.subj_code;
            mSubjCode = (regHelper.ExamType=="BECE" && regHelper.Job=="Obj")? current.subj_code+cbopaper.Text: current.subj_code;
            if (regHelper.ExamType == "BECE" && regHelper.Job == "Obj")
            {
                regHelper.SubjCode = current.code.Substring(0, 3) + cbopaper.Text;
            }
            btnok.Enabled = true;
        }

        internal bool VerifyTextBoxEntries()
        {
            verify = true;
            try
            {
                if (string.IsNullOrEmpty(txtexam_type.Text))
                {
                    MessageBox.Show("Examination type cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                    
                }
                if (string.IsNullOrEmpty(txtexam_year.Text) && verify == true)
                {
                    MessageBox.Show("Examination year cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbosubject.Text) && verify == true)
                {
                    MessageBox.Show("Subject cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbostate.Text) && verify == true && (txtexam_type.Text.Substring(0, 4) != "NCEE" && txtexam_type.Text.Substring(0, 4) != "NEEF"))
                {
                    MessageBox.Show("State cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbopaper.Text) && verify == true && comJob == "Essay" && txtexam_type.Text !="BECE")
                {
                    MessageBox.Show("Paper cannot be empty", "NECO Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    verify = false;
                }
                if (string.IsNullOrEmpty(cbopaper.Text) && verify == true && comJob == "Obj" && txtexam_type.Text == "BECE")
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void SetScanning()
        {
            //var UserName = getRegistryValues.GetRegistryValue("UID");
            //CreateOperators.CeateOperator(UserName);

            VerifyTextBoxEntries();
            try
            {
                if (verify == true)
                {
                    regHelper.AnswerSheet = AnswerSheet;
                    ComExamType = txtexam_type.Text.Trim();
                    ComSubject = cbosubject.Text.Trim();
                    ComState = cbostate.Text.Trim();
                    ComExamYear = txtexam_year.Text.Trim();
                    comPaper = cbopaper.Text.Trim();
                    //string[] retVal = InitializeValues.StoreVals(ComExamType, txtexam_year.Text, comJob, ComSubject, comSheet, AnswerSheet, "");
                    string[] retVal = InitializeValues.StoreVals(ComExamType, comJob, ComSubject,  AnswerSheet, "");
                    ComDefFile = retVal[0];
                    //ComCompanion = retVal[1];
                    SubjectModel current = (SubjectModel)cbosubject.SelectedValue;
                    //StoreVals();
                    ComShortSubj = current.subject;// ShortSubjects.getShortSubject(ComSubject, ComExamType.Substring(0, 4),comJob );
                    // SubjectCodes.getSubjCodes(ComSubject, comPaper,comJob, ComExamType.Substring(0, 4)  );
                    ScanType = $"{regHelper.ScanType}_{GetSystemName.SystemName()}";
                    if (ComExamType.Contains("NEEF") || ComExamType.Contains("NCE"))
                    {
                        ComScanDir = CreateJobDir.CreateDir(regHelper.ScanDir, "", ComSubject);
                        ComSubjCode = current.code;
                    }
                    else
                    {
                        ComSubjCode = current.code.Substring(0, 3) + cbopaper.Text;
                        if (mSubjCode == "30" && comPaper == "4")
                        {
                            mSubjCode = "31";
                        }
                       

                        //MessageBox.Show(cbopaper.Text);
                        regHelper.SubjCode = ComSubjCode;
                    }

                    //Generate batchnumber here from subjects + paper code + exam.
                     comBatchNumber = ICreateBatchNumber.CreateBatchNumber(ComSosDir, ComScanDir,  mSubjCode, comStateCode, comJob );
                    if (comBatchNumber != "000000.000")
                    {
                        var IsCreateJobDefFile = await CreateJobDefFile.ModifyDefFle(ComSosDir, ComDefFile, ComScanDir, ComCompanion,
                                              ComShortSubj, ComState, comUserName, comBatchNumber, ComSubjCode);

                       /* if (CreateJobDefFile.ModifyDefFle(ComSosDir, ComDefFile, ComScanDir, ComCompanion, 
                                              ComShortSubj, ComState, comUserName, comBatchNumber, ComSubjCode) == true)*/
                       if(IsCreateJobDefFile)
                        {

                            if (MessageBox.Show("Scanning Parameters Set Successfully\n " +
                                                "Do you want to continue ", "Scanning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string [] regKey={"startBatch","scanDir","examYear","examType","subject","state","firstTime","shortsubj","UID","Logout","subjcode","Blind","Suplementary"};
                                string[] rValues = { "true", ComSosDir + @"\" + ScanType, ComExamYear, ComExamType, ComSubject, ComState, "false", ComShortSubj, comUserName, "false", ComSubjCode, IsBlind.ToString(), IsSuplementary.ToString() };
                                getRegistryValues.UpdateRegistry(@"software\necoscan",regKey ,rValues );  
                                //regHelper.StartBatch = true;
                                //regHelper.Subject = ComSubject;
                                //regHelper.State = ComState;
                                //regHelper.ShortSubj = ComShortSubj;
                                //regHelper.SubjCode = ComSubjCode;
                               if ((comJob == "Essay" && ComExamType.Substring(0, 4) == "SSCE") || (comJob == "Obj" && ComExamType.Substring(0, 4) == "BECE"))
                               {
                                   //string [] pregKey={"paper"};
                                   //string [] prValues={comPaper};
                                   //getRegistryValues.UpdateRegistry(@"software\necoscan",pregKey ,prValues );
                                    regHelper.Paper = comPaper;
                               }
                                //MessageBox.Show("Got here so far");
                                //string[] dKey = { "LastDecodeLoaded" };
                                //string[] dValues = {ComSosDir + @"\" + ComDefFile + ".sos"};
                                //getRegistryValues.UpdateRegistry(@"software\DRS\Sosinpw\Job", dKey, dValues); 
                                regHelper.LastDecodeLoaded = $@"{ComSosDir}\{ComDefFile}.sos";
                               Process.Start(UtilityClass.InstallationPath()+@"drs\skw\Sosinpw.exe");
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
                else
                {
                   return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Scanning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Dispose();
            Application.Exit();
        }

        
        private void btnok_Click(object sender, EventArgs e)
        {
            if(Program.housekeeping)
            {
                MessageBox.Show("There is pending house keeping operation on this system\n" +
                        "Please carryout the necessary house keeiping to continue", "House keeping", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrWhiteSpace(regHelper.UID) || regHelper.UID.ToLower().Contains("default"))
            {
                MessageBox.Show("The system could not retrieve your user name\n"+
                        "Please login again to continue or call your supervisor", "Scanning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuiaApplication();
            }
            var msg = "Are you sure you want to continue with this exercise";
            if(MessageBox.Show(msg,"Scanning",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                QuiaApplication();

            //DependencyClass.GetCompanion();
            //DependencyClass.GetExportFilter();
            SetScanning();
        }
       
        private void cbopaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectModel current = (SubjectModel)cbosubject.SelectedValue;
            mSubjCode = (regHelper.ExamType=="BECE" && regHelper.Job=="Obj")? current.subj_code+cbopaper.Text: current.subj_code;
            if(regHelper.ExamType == "BECE" && regHelper.Job == "Obj")
            {
                regHelper.SubjCode = current.code.Substring(0, 3) + cbopaper.Text;
            }
            comPaper = cbopaper.Text;
            regHelper.Paper = comPaper;
        }

       

       

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
           // FillComboBoxes NetWorkClass.GetSubjects();
        }

        private void txtexam_year_TextChanged(object sender, EventArgs e)
        {

        }

        private async void BtnHouseKeeping_Click(object sender, EventArgs e)
        {
            var login = UtilityClass.ShowLogin("Supervisor Login");
            if (login == null)
            {
                MessageBox.Show("Please supply your login credentils to continue", "Supervisor Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(login.username) || string.IsNullOrWhiteSpace(login.password))
            {
                MessageBox.Show("Please supply your login credentials to continue", "Supervisor Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var PersonnelNo = login.username;
            var Password = login.password;

            var result = await Repository.SupervisorLogin(PersonnelNo, Password);
            if (!result) return;
            var frm = new HouseKeepingPage(_MissingFiles);
            frm.Show();
        }

        private void BtngetFiles_Click(object sender, EventArgs e)
        {
            //btnok.Enabled = btncancel.Enabled = BtngetFiles.Enabled = false;
            //BtnHouseKeeping.Enabled = false;
            

            //DependencyClass.CleanDir("Assemblies");
            //DependencyClass.CleanDir("Companion");
            //DependencyClass.GetCompanion();
            //DependencyClass.GetExportFilter();

            //btnok.Enabled = btncancel.Enabled = BtngetFiles.Enabled = true;
            //BtnHouseKeeping.Enabled = Program.housekeeping;
        }

        private void mnuToolsStopScanning_Click(object sender, EventArgs e)
        {
            
        }
        private void mnucreateUser_Click(object sender, EventArgs e)
        {
            
            
        }

       
        internal string[] LoadScanOption()
        {
            string[] sOptions = new string[2];
            bool[] ChkType = {IsSuplementary, IsBlind, IsResit, IsBlank};
            sOptions = getScanType.ScanOptions(ChkType);
            return sOptions;
        }

        private void mnutools_Click(object sender, EventArgs e)
        {

        }
        private void cbostate_MouseEnter(object sender, EventArgs e)
        {
            UtilityClass.DisplayToolTip(cbostate, "Click to select state");
        }
        private void cbosubject_MouseEnter(object sender, EventArgs e)
        {
             UtilityClass.DisplayToolTip(cbosubject, "Click to select subject");  
        }
       
        private void chkanswersheet_MouseEnter(object sender, EventArgs e)
        {
           /* UtilityClass.DisplayToolTip(chkoldsheet1, "Click to here to scan \n"+
                                                         "BECE Regular answer sheets...");*/
        }
        private void cbopaper_MouseEnter(object sender, EventArgs e)
        {
            UtilityClass.DisplayToolTip(cbopaper, "Click here to select paper..."); 
        }

        private void chkoldsheet_MouseEnter(object sender, EventArgs e)
        {
          //  UtilityClass.DisplayToolTip(chkoldsheet3, "Click to here to scan \n" + "SSCE Old answer sheets...");
        }

        private void txtfilename_TextChanged(object sender, EventArgs e)
        {
           /* if (txtfilename.Text.Length > 0)
            {
                string[] files = CountNumberOfFormsScanned.getFile(ComScanDir, txtfilename.Text.Trim(), today, wUser);
                //InitializeListView.FillListView(lstv,files);  
                lblfcount.Text = "Total of "+files.Length+" Files";
                if (files.Length > 0)
                {
                    gTot = CountNumberOfFormsScanned.TotalFormsScanned(ComScanDir, txtfilename.Text.Trim(), wUser, today);
                    lblcontent.Text = "No of Forms " + "0" +
                        " / " + gTot;
                }
                else
                {
                    gTot = 0;
                    lblcontent.Text = "No of Forms " + "0" +
                            " / " + gTot;
                }
            }
            else
            {
                lstv.Items.Clear();
                lblfcount.Text = "Total " ;
                lblcontent.Text = ""; 
            }*/
        }

       
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        async Task InitializeListView()
        {
            try
            {
                var result = await Repository.GetMyAllocation();
                if (result == null) return;
                var _FilesList = result.Data;
                
                if (_FilesList == null) return;
                if (_FilesList.Count == 0) return;

                LvFiles.Items.Clear();

                this.LvFiles.Columns.Add("State", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
                this.LvFiles.Columns.Add("Subject", 20 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
                this.LvFiles.Columns.Add("Schools", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
                this.LvFiles.Columns.Add("Registered", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
                this.LvFiles.Columns.Add("Scanned", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);

                foreach (var s in _FilesList)
                {

                    //var _state = s.State;
                    var _subject = s.Subject;
                    var _regcount = s.NumberOfCandidates;
                    var _scanned = s.NumberScanned;
                    var _schools = s.NumberOfSchools;

                    ListViewItem _ParentItem = new ListViewItem(s.State);
                    ListViewItem.ListViewSubItem _SubItem = new ListViewItem.ListViewSubItem(_ParentItem, _subject);
                    ListViewItem.ListViewSubItem _SubItem2 = new ListViewItem.ListViewSubItem(_ParentItem, _schools.ToString());
                    ListViewItem.ListViewSubItem _SubItem3 = new ListViewItem.ListViewSubItem(_ParentItem, _regcount.ToString());
                    ListViewItem.ListViewSubItem _SubItem4 = new ListViewItem.ListViewSubItem(_ParentItem, _scanned.ToString());
                    //ListViewItem.ListViewSubItem _SubItem5 = new ListViewItem.ListViewSubItem(_ParentItem, _scanned.ToString());

                    _ParentItem.SubItems.Add(_SubItem); //Associating these subitems to the parent item
                    _ParentItem.SubItems.Add(_SubItem2);
                    _ParentItem.SubItems.Add(_SubItem3);
                    _ParentItem.SubItems.Add(_SubItem4);
                    //_ParentItem.SubItems.Add(_SubItem5);
                    LvFiles.Items.Add(_ParentItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Progress");
            }
           await Task.CompletedTask;
        }
    }
}

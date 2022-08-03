using scan.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HttpService.ApiInfrastructure.Client;
using HttpService.ApiHelper.Client;
using HttpService.ApiHelper;
using HttpService.ApiInfrastructure;
using scan.Data;
using SCRghelp.Infrastructure;
using HttpService.ApiInfrastructure.ApiModels;

namespace scan.Forms
{
    public partial class HouseKeepingPage : Form
    {
        RegistryHelperClass _rHelper = new RegistryHelperClass();
        List<string> _FilesList = null;
        string NTSubject = "";
        string NTSCode = "";
        bool IsFileSelected = false;
        bool IsOperatorSelected = false;
        public HouseKeepingPage(List<string> FilesList)
        {
            InitializeComponent();
            _FilesList = FilesList;
        }

        private void lblfcount_Click(object sender, EventArgs e)
        {

        }

        private void LstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void InitializeListView()
        {
            LvFiles.Items.Clear();
            if (_FilesList == null) return;
            if (_FilesList.Count == 0) return;
            
            var subjects = await FillComboBoxes.getSubjects();
            

            this.LvFiles.Columns.Add("File", 25 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Owner", 25 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Records", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Subject", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Date", 15 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);

           
            foreach (var s in _FilesList)
            {
                var size = ScanFiles.GetScanFileSize(s);
                var owner = ScanFiles.GetScanFileOwner(s);
                var date = ScanFiles.GetScanFileCreationDate(s);
                var temp = ScanFiles.GetScanFileSubject(s);
                if (temp == null || temp.Length < 4) continue;
                string subj = "";
                if(_rHelper.Job == "Obj")
                {
                    NTSCode = temp;
                    subj = (_rHelper.ExamType == "BECE") ? subjects.Where(x => x.code.Substring(1, 2) == temp.Substring(1, 2)).Select(x => x.subject).FirstOrDefault() :
                         subjects.Where(x => x.code == temp).Select(x => x.subject).FirstOrDefault(); ;
                    NTSubject = subj;
                }

                if (_rHelper.Job == "Essay")
                {
                    NTSCode = temp;
                    subj =   subjects.Where(x => x.code == temp).Select(x => x.subject).FirstOrDefault(); 
                    NTSubject = subj;
                }


                ListViewItem _ParentItem = new ListViewItem(s);
                ListViewItem.ListViewSubItem _SubItem = new ListViewItem.ListViewSubItem(_ParentItem, owner);
                ListViewItem.ListViewSubItem _SubItem2 = new ListViewItem.ListViewSubItem(_ParentItem, size.ToString());
                ListViewItem.ListViewSubItem _SubItem3 = new ListViewItem.ListViewSubItem(_ParentItem, subj);
                ListViewItem.ListViewSubItem _SubItem4 = new ListViewItem.ListViewSubItem(_ParentItem, date);
                //ListViewItem.ListViewSubItem _SubItem5 = new ListViewItem.ListViewSubItem(_ParentItem, date);
                _ParentItem.SubItems.Add(_SubItem); //Associating these subitems to the parent item
                _ParentItem.SubItems.Add(_SubItem2);
                _ParentItem.SubItems.Add(_SubItem3);
                _ParentItem.SubItems.Add(_SubItem4);
               // _ParentItem.SubItems.Add(_SubItem5);
                LvFiles.Items.Add(_ParentItem);
            }
        }

        private void HouseKeepingPage_Load(object sender, EventArgs e)
        {
            InitializeListView();
            BtnHouseKeeping.Enabled = (IsFileSelected && IsOperatorSelected); 
            LblOwner.Text = "";
            LblStaffName.Text = "";
        }

        private void HouseKeepingPage_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblOwner.Text = "";
            if (LvFiles.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = LvFiles.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                LblOwner.Text = LvFiles.Items[intselectedindex].Text;
                IsFileSelected = LblOwner.Text.Trim().Length > 0;
            }
            BtnHouseKeeping.Enabled = (IsFileSelected && IsOperatorSelected);
        }

        private async void TxtPersonnelNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonnelNo.TextLength == 4)
            {
                var person = await Repository.GetStaffDetailsByNumber(TxtPersonnelNo.Text);
                if (person != null)
                {
                    BtnHouseKeeping.Enabled = true;
                    LblStaffName.Text = person.Data.name;
                    IsOperatorSelected = LblStaffName.Text.Trim().Length > 0;
                }
            }
            BtnHouseKeeping.Enabled = (IsFileSelected && IsOperatorSelected);
        }

        private async void BtnHouseKeeping_Click(object sender, EventArgs e)
        {
            var msg = $"Are you sure you want to save file {LblOwner.Text}\n" +
                $"for this operator {LblStaffName.Text} ";
            if (MessageBox.Show(msg, "Save to Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var FileName = LblOwner.Text.Trim();

            string ExamYear = _rHelper.ExamYear;
            var IsDiscard = FileName.Contains("Disc_");
            var Job = _rHelper.Job;
            var Exams = _rHelper.ExamType;
            string scanType;
            var Userid = TxtPersonnelNo.Text;
            var _file = System.IO.Path.GetFileName(FileName);
            var systemNo = _rHelper.DeviceId;
            var subject = NTSubject;
            //var paper = NTSubject.Substring(4, 1);
            string scanDir;
            if (IsDiscard)
            {
                var tempDir = _rHelper.SosDir;
                scanDir = tempDir.Substring(3, (tempDir.Length - 3));
                scanType = $"Disc_{systemNo}";
            }
            else
            {
                var tempDir = _rHelper.SosDir;
                scanDir = tempDir.Substring(3, (tempDir.Length - 3));
                scanType = $"{_rHelper.ScanType}_{systemNo}";
            }

            var scanData = ScanFiles.GetFileData(FileName);
            var Data = new ScanDataApiModel
            {
                ScanFile = _file,
                JobDir = scanDir,
                Responses = scanData,
                Job = Job,
                ExamType = (Exams == "SSCE") ? $"{Exams} {_rHelper.Examination}" : Exams,
                ScanType = scanType,
                SystemNo = systemNo,
                OperatorId = Userid,
                Subject = (Exams.Contains("NCEE")) ? $"Paper {subject}" : subject,
                ExamYear = ExamYear
            };

            var result = await Repository.SaveMissingScanFileToServer(Data);
            if (result!=null)
            {
                MessageBox.Show(result.message);
            }
            Referesh();
        }

        private async void Referesh()
        {
            this._FilesList = null;
            this._FilesList = await InventoryClass.GetLocalInventory();
            if(_FilesList==null || _FilesList.Count == 0)
            {
                Program.housekeeping = false;
            }
            InitializeListView();
            LblOwner.Text = "";
            LblStaffName.Text = "";
            TxtPersonnelNo.Text = "";
            BtnHouseKeeping.Enabled = false;
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            RegistryHelperClass _rHelper = new RegistryHelperClass();
            _rHelper.SupervisorApiKey = "";
            this.Close();
            this.Dispose();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Referesh();
        }

        private void BtnDalateFromSystem_Click(object sender, EventArgs e)
        {
            var msg = $"Are you sure you want to delete file {LblOwner.Text} from this computer";
            if (MessageBox.Show(msg, "Delete from System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            ScanFiles.DeleteLastEmptyScanFile("", LblOwner.Text.Trim());
            Referesh();
        }

        private async void BtnSearchByName_Click(object sender, EventArgs e)
        {
            var name = TxtSTaffName.Text;

            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var response = await client.GetStaffDetailsByName(name);

            if (response != null)
            {
                var person = response.Data.FirstOrDefault();
                LblStaffName.Text = $"[{person.personnelNo}] {person.name}";
            }
        }
    }
}

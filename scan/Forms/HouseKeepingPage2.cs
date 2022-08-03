//using scan.ApiInfrastructure;
using scan.Classes;
using SCRghelp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan.Forms
{
    public partial class HouseKeepingPage2 : Form
    {
        List<string> _FilesList = null;
        string NTSubject = "";
        string NTSCode = "";
        RegistryHelperClass regHelper = new RegistryHelperClass();
        public HouseKeepingPage2()
        {
            InitializeComponent();
            _FilesList = regHelper.InconsistentFiles.Split(',').ToList();
        }

        private void lblfcount_Click(object sender, EventArgs e)
        {

        }

        private void LstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void InitializeListView()
        {
            LvFiles.Items.Clear();
            
            if (_FilesList == null) return;
            if (_FilesList.Count == 0) return;
            
            var subjects = NetWorkClass.GetSubjects();
            BtnHouseKeeping.Enabled = true;
            this.LvFiles.Columns.Add("File", 25 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Owner", 25 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Records", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Code", 5 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Subject", 10 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);
            this.LvFiles.Columns.Add("Date", 15 * Convert.ToInt32(LvFiles.Font.SizeInPoints), HorizontalAlignment.Left);

           
            foreach (var s in _FilesList)
            {
                var size = ScanFiles.GetScanFileSize(s);
                var owner = ScanFiles.GetScanFileOwner(s);
                var date = ScanFiles.GetScanFileCreationDate(s);
                var temp = ScanFiles.GetScanFileSubject(s);
                NTSCode = temp;
                var subj = "";// subjects.Where(x => x.code == temp).Select(x=> x.subject).FirstOrDefault();
                NTSubject = subj;
                ListViewItem _ParentItem = new ListViewItem(s);
                ListViewItem.ListViewSubItem _SubItem = new ListViewItem.ListViewSubItem(_ParentItem, owner);
                ListViewItem.ListViewSubItem _SubItem2 = new ListViewItem.ListViewSubItem(_ParentItem, size.ToString());
                ListViewItem.ListViewSubItem _SubItem3 = new ListViewItem.ListViewSubItem(_ParentItem, temp);
                ListViewItem.ListViewSubItem _SubItem4 = new ListViewItem.ListViewSubItem(_ParentItem, subj);
                ListViewItem.ListViewSubItem _SubItem5 = new ListViewItem.ListViewSubItem(_ParentItem, date);

                //ListViewItem.ListViewSubItem _SubItem5 = new ListViewItem.ListViewSubItem(_ParentItem, date);
                _ParentItem.SubItems.Add(_SubItem); //Associating these subitems to the parent item
                _ParentItem.SubItems.Add(_SubItem2);
                _ParentItem.SubItems.Add(_SubItem3);
                _ParentItem.SubItems.Add(_SubItem4);
                _ParentItem.SubItems.Add(_SubItem5);
                LvFiles.Items.Add(_ParentItem);
            }
            
                    //ListViewItem listViewItem1 = new ListViewItem(_lvItems, -1, Color.Empty, Color.Empty, null);
            //ListViewItem listViewItem1 = new ListViewItem(new string[] { "Banana", "a", "b", "c" }, -1, Color.Empty, Color.Empty, null);
            /*ListViewItem listViewItem2 = new ListViewItem(new string[] { "Cherry", "v", "g", "t" }, -1, Color.Empty, Color.Empty, new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0))));
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "Apple", "h", "j", "n" }, -1, Color.Empty, Color.Empty, null);
            ListViewItem listViewItem4 = new ListViewItem(new string[] { "Pear", "y", "u", "i" }, -1, Color.Empty, Color.Empty, null);


            this.LvFiles.Items.AddRange(new ListViewItem[] {listViewItem1,
                listViewItem2,
                listViewItem3,
                listViewItem4});*/

            /*ListViewItem ParentItem = new ListViewItem("1"); //Parent item
            ListViewItem.ListViewSubItem SubFooItem = new ListViewItem.ListViewSubItem(ParentItem, "Foo");
            ParentItem.SubItems.Add(SubFooItem); //Associating these subitems to the parent item
            ParentItem.SubItems.Add(SubFooItem);
            ParentItem.SubItems.Add(SubFooItem);
            ParentItem.SubItems.Add(SubFooItem);
            LvFiles.Items.Add(ParentItem); //Adding the parent item to the listview control
            */
        }
        private void HouseKeepingPage_Load(object sender, EventArgs e)
        {
            InitializeListView();
            BtnHouseKeeping.Enabled =  false;
            
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
                TxtOldFileName.Text = LvFiles.Items[intselectedindex].Text;
                var subj = NTSCode.Substring(0,3);
                var systemNo = regHelper.DeviceId;
                TxtNewFileName.Text = $@"{subj}{systemNo}00{System.IO.Path.GetExtension(TxtOldFileName.Text)}";
                LblOwner.Text = $@"{System.IO.Path.GetDirectoryName(TxtOldFileName.Text)}\{TxtNewFileName.Text}" ;
            }
        }

        private void BtnHouseKeeping_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(LblOwner.Text);
            var msg = $"Are you sure you want to rename file {LblOwner.Text}\n" +
                $"to new name : {path}{TxtNewFileName.Text} ";
            if (MessageBox.Show(msg, "Save to Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var FileName = LblOwner.Text.Trim();
            if (System.IO.File.Exists(FileName))
            {
                MessageBox.Show($"file with name {FileName} already exist");
                return;
            }
            var result = ScanFiles.RenameScanFile(TxtOldFileName.Text, LblOwner.Text);
            MessageBox.Show(result);
            //NetWorkClass.SaveMissingScanFileToServer(FileName, TxtPersonnelNo.Text, NTSubject, NTSCode);
            Referesh();
        }

        private void Referesh()
        {
            this._FilesList = null;
            _FilesList = regHelper.InconsistentFiles.Split(',').ToList();
            if (_FilesList==null || _FilesList.Count == 0)
            {
                Program.housekeeping = false;
            }
            InitializeListView();
            LblOwner.Text = "";
            LblStaffName.Text = "";
            //TxtPersonnelNo.Text = "";
            BtnHouseKeeping.Enabled = false;
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            Program.SupervisorAccessToken = "";
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

        private void BtnSearchByName_Click(object sender, EventArgs e)
        {
            var name = TxtOldFileName.Text;
            var person = NetWorkClass.GetStaffDetailsEx(name.Trim());
            if (person != null)
            {
                //BtnHouseKeeping.Enabled = true;
                LblStaffName.Text = $"[{person.personnelNo}] {person.name}" ;
            }
        }

        private void TxtNewFileName_TextChanged(object sender, EventArgs e)
        {
            //LblOwner.Text = TxtNewFileName.Text;
            LblOwner.Text = $@"{System.IO.Path.GetDirectoryName(TxtOldFileName.Text)}\{TxtNewFileName.Text}";
        }
    }
}

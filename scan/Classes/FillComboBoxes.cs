using System;
using System.Collections.Generic;
using System.Windows.Forms;
using scan.Models;
using SCRghelp.Infrastructure;
using HttpService.ApiInfrastructure.Client;
using HttpService.ApiHelper.Client;
using HttpService.ApiHelper;
using HttpService.ApiInfrastructure;
using System.Threading.Tasks;
using System.Linq;

namespace scan
{
    static class FillComboBoxes
    {
        private static RegistryHelperClass _rHelper = new RegistryHelperClass();
        public static async Task<ComboBox> getSubjects(ComboBox cbo)
        {
            try
            {
                    ITokenContainer tokenContainer = new TokenContainer();
                    IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
                    INetworkClient client = new NetworkClient(apiClient);
                    string examType = _rHelper.ExamType;

                    if (_rHelper.Examination == "Internal")
                    {
                        examType = "SSCE";
                    }
                    if (_rHelper.Examination == "External")
                    {
                        examType = "NOV";
                    }
                    var result = (examType=="NCEE")? await client.GetSubjects(examType,  _rHelper.ExamYear) : await client.GetSubjects(examType, _rHelper.Job, _rHelper.ExamYear) ;
                    
                    if (result == null || result.Data.Count == 0)
                    {
                        MessageBox.Show("Unable to fetch subjects for scanning", "Fetc Subjects", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return cbo;
                    }
                    var Subjects = (from s in result.Data
                                    select new SubjectModel
                                    {
                                        code = s.code,
                                        subj_code =  s.subj_code,
                                        subject = s.subject,
                                        paper =s.paper,
                                        descript = s.descript,
                                        exam = s.exam
                                    }).ToList();
                    cbo.ValueMember = null;
                    cbo.DisplayMember = "descript";
                    cbo.DataSource = Subjects;
                    return cbo;
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,  "Fetc Subjects", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cbo;
        }

        public static async Task<List<SubjectModel>> getSubjects()
        {
            try
            {

                ITokenContainer tokenContainer = new TokenContainer();
                IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
                INetworkClient client = new NetworkClient(apiClient);

                string examType = _rHelper.ExamType;

                if (_rHelper.Examination == "Internal")
                {
                    examType = "SSCE";
                }
                if (_rHelper.Examination == "External")
                {
                    examType = "NOV";
                }
                var result = (examType=="NCEE")? await client.GetSubjects(examType, _rHelper.ExamYear) : await client.GetSubjects(examType, _rHelper.Job, _rHelper.ExamYear);

                if (result == null || result.Data.Count == 0)
                {
                    MessageBox.Show("Unable to fetch subjects for scanning", "Fetc Subjects", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var Subjects = (from s in result.Data
                                select new SubjectModel
                                {
                                    code = s.code,
                                    subj_code = s.subj_code,
                                    subject = s.subject,
                                    paper = s.paper,
                                    descript = s.descript,
                                    exam = s.exam
                                }).ToList();
                return Subjects;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public static async Task<ComboBox> GetStates(ComboBox cbo)
        {

            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var result = await client.GetStates();
            if (result == null || result.Data.Count == 0)
            {
                MessageBox.Show("Unable to fetch states for scanning", "Fetc States", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return cbo;
            }
            
            var states = (from r in result.Data
                         select new StateModel
                         {
                            Code = r.Code,
                            State = r.State
                         }).ToList();
            cbo.ValueMember = null;
            cbo.DisplayMember = "State";
            cbo.DataSource = states;
            return cbo;


        }

      
        /*public static ComboBox GetExamType(ComboBox cmb)
        {
            string[] exam = { "SSCE JUN/JUL", "SSCE NOV/DEC", "BECE", "NCEE", "NEEFUSSC", "Others" };
            foreach (string s in exam)
            {
                cmb.Items.Add(s);
            }
            return cmb;
        }

        public static ComboBox GetJobDescription(ComboBox cmb)
        {
            string[] job = { "Essay", "Obj" };
            foreach(string s in job)
            {
                cmb.Items.Add(s);
            }
            return cmb;
        }*/

        public static ComboBox GetScannerType(ComboBox cmb)
        {
            string[] scn = {"CD","PS" };
            foreach (string s in scn)
            {
                cmb.Items.Add(s);
            }
            return cmb;
        }

       
    }
}

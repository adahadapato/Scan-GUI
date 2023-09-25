using HttpService.ApiHelper;
using HttpService.ApiHelper.Client;
using HttpService.ApiInfrastructure;
using HttpService.ApiInfrastructure.ApiModels;
using HttpService.ApiInfrastructure.Client;
using HttpService.ApiInfrastructure.Responses;
using SCRghelp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan.Data
{
    public class Repository
    {
        static RegistryHelperClass _rHelper = new RegistryHelperClass();
        public static async Task<bool> SupervisorLogin(string PersonnelNo, string Password)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            ILoginClient client = new LoginClient(apiClient);
            var result = await client.Login(PersonnelNo, Password);
            if (result != null)
            {
                if (string.IsNullOrEmpty(result.access_token)) return false;
                _rHelper.SupervisorApiKey = result.access_token;
                return true;
            }
            return false;
        }

        public static async Task<(bool Issuccess, string Message)> ChangePWD(string PersonnelNo, string OldPassword, string NewPassword, string ConfrirmPassword)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            ILoginClient client = new LoginClient(apiClient);
            var result = await client.ChangePWD(PersonnelNo, OldPassword, NewPassword, ConfrirmPassword);
            if (result == null)
                return (false, "An error occured");
            else
                return (true, result?.message);
        }

        public static async Task<(bool Issuccess, bool IshangePWD, string Message)> Login(string PersonnelNo, string Password, string DeviceId)
        {
            bool IsLoginSucceeded = false;
            string message = "";
            bool IschgPWD = false;
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            ILoginClient client = new LoginClient(apiClient);
            var result = await client.Login(PersonnelNo, Password, DeviceId);
            if (result != null)
            {
                _rHelper.ApiToken = result.access_token;
                IschgPWD = result.IsChangePassword;
                IsLoginSucceeded = true;
                if (result.IsChangePassword)
                {
                    _rHelper.IsBlank = false;
                    _rHelper.IsBlind = result.isBlind;
                    _rHelper.IsResit = result.isResit;
                    _rHelper.IsSuplementary = result.isSuplementary;
                    _rHelper.Job = result.job;
                    _rHelper.OperatorId = result.personnelNo;
                    _rHelper.UID = result.name;
                    _rHelper.ScanType = result.scanType;
                    _rHelper.Examination = result.examType;
                    _rHelper.ExamType = result.examination;
                    _rHelper.ExamYear = result.examYear;
                    _rHelper.ExpectedSheets = result.expectedSheets;
                    _rHelper.LogOut = false;
                }
                else
                {
                    _rHelper.LogOut = true;
                    message = "There was a password reset on your account\n" +
                               "Please Change your password to continue scanning";
                }
                

                var exam = $"{_rHelper.ExamType} {_rHelper.Examination}";
                var sdir = CreateJobDir.BiuldJobDir(exam, _rHelper.ExamYear, _rHelper.Job, "");
                CreateJobDir.CreateDir(sdir);
                _rHelper.SosDir = sdir;
                var scDir = $@"{sdir}\{_rHelper.ScanType}_{_rHelper.DeviceId}";
                CreateJobDir.CreateDir(scDir);
                _rHelper.ScanDir = scDir;
            }
            
            return (IsLoginSucceeded, IschgPWD, message);
        }

        public static async Task<byte[]> GetFile(string fileType)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var result = await client.GetFile(fileType);
            return result;
        }
        public static async Task<byte[]> GetFile(string fileType, string job)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
                       var result = await client.GetFile(GetExamType, job, fileType);
            return result;
        }

        public static async Task<int> GetTotalScanned()
        {
            var totalScanned = 0;
           
                ITokenContainer tokenContainer = new TokenContainer();
                IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
                INetworkClient client = new NetworkClient(apiClient);
                var result = (GetExamType=="NCEE" || GetExamType == "GIFT") ? await client.GetTotalScan(GetExamType, _rHelper.OperatorId, _rHelper.ExamYear) 
                : await client.GetTotalScan(GetExamType, _rHelper.Job, _rHelper.OperatorId, _rHelper.ExamYear);
                if (result != null)
                {
                    if (result.Data == null)
                        totalScanned = 0;
                    else
                        totalScanned = result.Data.Total;
                }
            return totalScanned;
        }

        static string GetExamType
        {
            get
            {
                string examType = _rHelper.ExamType;

                if (_rHelper.Examination == "Internal")
                {
                    examType = "SSCE";
                }
                if (_rHelper.Examination == "External")
                {
                    examType = "NOV";
                }

                if (_rHelper.Examination == "GIFTED")
                {
                    examType = "GIFT";
                }
                return examType;
            }
        }

        public static async Task<ScanDataResult> SaveMissingScanFileToServer(ScanDataApiModel Data)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var result = await client.SaveMissingScanFileToServer(Data);
            return result;
        }
        public static async Task<StaffDetailsResponse> GetStaffDetailsByNumber(string PersonnelNo)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var person = await client.GetStaffDetailsByNumber(PersonnelNo);
            return person;
        }

        public static async Task<StaffDetailsResponseN> GetStaffDetailsByName(string StaffName)
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var person = await client.GetStaffDetailsByName(StaffName);
            return person;
        }
        public static async Task<InventoryResponse> GetServerInventory()
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var result = (GetExamType=="NCEE" || GetExamType == "GIFT") ? await client.GetInventory(GetExamType, _rHelper.ExamYear, _rHelper.DeviceId) 
                : await client.GetInventory(GetExamType, _rHelper.Job, _rHelper.ExamYear, _rHelper.DeviceId);
            return result;
        }


        public static async Task<AllocationResponse> GetMyAllocation()
        {
            ITokenContainer tokenContainer = new TokenContainer();
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            INetworkClient client = new NetworkClient(apiClient);
            var result = await client.GetMyAllovation(GetExamType, _rHelper.ExamYear);
            return result;
        }

        /* public static async Task<string> GetStaffDetailsByName(string Name)
         {
             bool IsLoginSucceeded = false;

             ITokenContainer tokenContainer = new TokenContainer();
             IApiClient apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
             INetworkClient client = new NetworkClient(apiClient);
             var person = await client.GetStaffDetailsByName(Name);
             if (person != null)
             {
                 Program.SupervisorAccessToken = result.access_token;
                 IsLoginSucceeded = true;
             }

             return IsLoginSucceeded;
         }*/
    }
}

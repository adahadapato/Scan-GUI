

namespace HttpService.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using Responses;
    using ApiModels;
    using System.Collections.Generic;
    using scan.HttpService.ApiInfrastructure.ApiModels;

    //using HttpService.ApiInfrastructure.ApiModels;

    public interface INetworkClient
    {
        Task<SubjectResponse> GetSubjects(string exam, string job, string year);
        Task<SubjectResponse> GetSubjects(string exam,  string year);
        Task<StateResponse> GetStates();
        Task<InventoryResponse> GetInventory(string exam, string job, string year, string system);
        Task<InventoryResponse> GetInventory(string exam, string year, string system);
        Task<StaffDetailsResponse> GetStaffDetailsByNumber(string PersonnelNo);
        Task<StaffDetailsResponseN> GetStaffDetailsByName(string Name);
        Task<ScanDataResult> SaveMissingScanFileToServer(ScanDataApiModel data);
        Task<TotalScanResponse> GetTotalScan(string exam, string job, string PersonnelNo, string year);
        Task<TotalScanResponse> GetTotalScan(string exam,  string PersonnelNo, string year);
        Task<byte[]> GetFile(string exam, string job, string file);
        Task<byte[]> GetFile(string file);
        Task<AllocationResponse> GetMyAllovation(string exam, string year);
    }
    public class NetworkClient: ClientBase, INetworkClient
    {
        private const string SubjectUri = "api/subjects";
        private const string StateUri = "api/states/all";
        private const string InventoryUri = "api/inventory";
        private const string StaffDetailsByNumberUri = "api/staff/getstaff";
        private const string StaffDetailsByNameUri = "api/staff/getstaffbyname";
        private const string GetTotalScannedUri = "api/scanning";
        private const string SaveScannedDataUri = "api/scanning";
        private const string GetMyAllocationUri = "api/archiving";
        public NetworkClient(IApiClient apiClient) 
            : base(apiClient)
        {
        }

        public async Task<SubjectResponse> GetSubjects(string exam, string job, string year)
        {
            var content = $"{SubjectUri}/{exam}/scanning/{job}/{year}";
            var result = await GetJsonDecodedContent<SubjectResponse, List<SubjectApiModel>>(content);
            return result;
        }

        public async Task<SubjectResponse> GetSubjects(string exam,  string year)
        {
            var content = $"{SubjectUri}/{exam}/scanning/{year}";
            var result = await GetJsonDecodedContent<SubjectResponse, List<SubjectApiModel>>(content);
            return result;
        }

        public async Task<byte[]> GetFile(string exam, string job, string file)
        {
            //http://192.168.1.2/ManagerApi/api/files/def/SSCE/Obj
            var content = $"api/files/{file}/{exam}/{job}";
            var result = await GetFileContent(content);
            return result;
        }

        public async Task<byte[]> GetFile(string file)
        {
            //api/files/scanning/dependency/SCompanion
            var content = $"api/files/scanning/dependency/{file}";
            var result = await GetFileContent(content);
            return result;
        }

        public async Task<InventoryResponse> GetInventory(string exam, string job, string year, string system)
        {
            var content = $"{InventoryUri}/{exam}/{job}/{year}/{system}";
            var result = await GetJsonDecodedContent<InventoryResponse, List<InventoryApiModel>>(content);
            return result;
        }

        public async Task<InventoryResponse> GetInventory(string exam,  string year, string system)
        {
            var content = $"{InventoryUri}/{exam}/{year}/{system}";
            var result = await GetJsonDecodedContent<InventoryResponse, List<InventoryApiModel>>(content);
            return result;
        }

        public async Task<TotalScanResponse> GetTotalScan(string exam, string job, string PersonnelNo, string year)
        {
            var content = $"{GetTotalScannedUri}/{exam}/mytotalscan/{PersonnelNo}/{job}/{year}";
            var result = await GetJsonDecodedContent<TotalScanResponse, TotalScanApiModel>(content);
            return result;
        }

        public async Task<TotalScanResponse> GetTotalScan(string exam,  string PersonnelNo, string year)
        {
            var content = $"{GetTotalScannedUri}/{exam}/mytotalscan/{PersonnelNo}/{year}";
            var result = await GetJsonDecodedContent<TotalScanResponse, TotalScanApiModel>(content);
            return result;
        }

        public async Task<StateResponse> GetStates()
        {
            var content = StateUri;
            var result = await GetJsonDecodedContent<StateResponse, List<StateApiModel>>(content);
            return result;
        }
        
        public async Task<StaffDetailsResponse> GetStaffDetailsByNumber(string PersonnelNo)
        {
            var content = $@"{StaffDetailsByNumberUri}/{PersonnelNo}";
            var result = await GetJsonDecodedContent<StaffDetailsResponse, StaffDetailsApiModel>(content, true);
            return result;
        }

        public async Task<StaffDetailsResponseN> GetStaffDetailsByName(string Name)
        {
            var content = $@"{StaffDetailsByNameUri}/{Name}";
            var result = await GetJsonDecodedContent<StaffDetailsResponseN, List<StaffDetailsApiModel>>(content, true);
            return result;
        }

        public async Task<ScanDataResult> SaveMissingScanFileToServer(ScanDataApiModel data)
        {
            var SaveDataUri = $@"{SaveScannedDataUri}/{data.ExamType.Substring(0,4)}/{data.Job}/save/ext";
            var dataResponse = await PostEncodedContentWithSimpleResponseEx<CreateScanDataResponse, ScanDataApiModel>(SaveDataUri, data);
            if (dataResponse != null)
            {
                var result = DecodeJsonToModel<ScanDataResult>(dataResponse.ResponseResult);
                return result;
            }
            return null;
        }

        public async Task<AllocationResponse> GetMyAllovation(string exam, string year)
        {
            var allocationUri = $@"{GetMyAllocationUri}/{exam}/myallocation/{year}";
            var result = await GetJsonDecodedContent<AllocationResponse, List<AllocationApiModel>>(allocationUri);
            return result;
        }
    }
}

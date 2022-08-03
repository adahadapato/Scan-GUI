using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpService.ApiInfrastructure.Responses
{
    using ApiHelper.Response;
    using ApiModels;
    using scan.HttpService.ApiInfrastructure.ApiModels;
    //using HttpService.ApiInfrastructure.ApiModels;
    using System.Collections.Generic;

    public class CreateSubjectResponse : ApiResponse<int>
    {
    }

    public class FileResponse : ApiResponse<FileApiModel>
    {
    }

    public class SubjectResponse : ApiResponse<List<SubjectApiModel>>
    {
    }

    public class StateResponse : ApiResponse<List<StateApiModel>>
    {
    }

    public class InventoryResponse : ApiResponse<List<InventoryApiModel>>
    {
    }

    public class StaffDetailsResponse : ApiResponse<StaffDetailsApiModel>
    {
    }

    public class StaffDetailsResponseN : ApiResponse<List<StaffDetailsApiModel>>
    {
    }

    public class TotalScanResponse : ApiResponse<TotalScanApiModel> { }

    public class ScanDataResponse : ApiResponse<ScanDataApiModel> { }

    public class CreateScanDataResponse : ApiResponse<int>
    {
    }

    public class AllocationResponse : ApiResponse<List<AllocationApiModel>> { }
}

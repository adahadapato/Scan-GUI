using HttpService.ApiHelper.Model;

namespace HttpService.ApiInfrastructure.ApiModels
{
    public class StaffDetailsApiModel : ApiModel
    {
        public string personnelNo { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
}

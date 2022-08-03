using HttpService.ApiHelper.Model;


namespace HttpService.ApiInfrastructure.ApiModels
{
    public class TotalScanApiModel : ApiModel
    {
        public string User { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
    }
}

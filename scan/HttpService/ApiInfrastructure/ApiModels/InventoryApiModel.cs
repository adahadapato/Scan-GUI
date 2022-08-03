using HttpService.ApiHelper.Model;


namespace HttpService.ApiInfrastructure.ApiModels
{
    public class InventoryApiModel : ApiModel
    {
        public string FileName { get; set; }
        public int Records { get; set; }
        public string SystemNo { get; set; }
        public bool IsDiscard { get; set; }
    }
}

using HttpService.ApiHelper.Model;
using System.Collections.Generic;

namespace HttpService.ApiInfrastructure.ApiModels
{
    public class ScanDataApiModel : ApiModel
    {
        public string ExamYear { get; set; }
        public string OperatorId { get; set; }
        public string ScanType { get; set; }
        public string ScanFile { get; set; }
        public string JobDir { get; set; }
        public string ExamType { get; set; }
        public string Job { get; set; }
        public string SystemNo { get; set; }
        public string Subject { get; set; }
        public List<string> Responses { get; set; }
    }

    public class ScanDataResult: ApiModel
    {
        public string message { get; set; }
    }
}

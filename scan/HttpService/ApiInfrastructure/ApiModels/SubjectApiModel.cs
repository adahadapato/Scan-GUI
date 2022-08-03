using HttpService.ApiHelper.Model;
using System.Collections.Generic;


namespace HttpService.ApiInfrastructure.ApiModels
{
    public class SubjectApiModel:ApiModel
    {
        public string subj_code { get; set; }
        public string code { get; set; }
        public string subject { get; set; }
        public string descript { get; set; }
        public List<string> paper { get; set; }
        public string exam { get; set; }
    }
}

using HttpService.ApiHelper.Model;
//using HttpService.Models;
using System.Collections.Generic;


namespace HttpService.ApiInfrastructure.ApiModels
{
    public class ChangePWDResult : ApiModel
    {
        public string message { get; set; }
    }
    public class ChangePWDApiModel:ApiModel
    {
        public string PersonnelNo { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoginApiModel:ApiModel
    {
        public string PersonnelNo { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
    }

    public class SupervisorResult:ApiModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public bool isAdmin { get; set; }
        public string personnelNo { get; set; }
        public string name { get; set; }
    }

    public class PersonResult:ApiModel
    {
        //public bool isAdmin { get; set; }
        public string personnelNo { get; set; }
        public string name { get; set; }
        public string examType { get; set; }
        public string examYear { get; set; }
        public string job { get; set; }
        public string scanType { get; set; }
        public bool isBlind { get; set; }
        public bool isResit { get; set; }
        public bool isSuplementary { get; set; }
        public int expectedSheets { get; set; }
        public string systemType { get; set; }
        public string examination { get; set; }
        public string access_token { get; set; }
        public bool IsChangePassword { get; set; }
    }
}

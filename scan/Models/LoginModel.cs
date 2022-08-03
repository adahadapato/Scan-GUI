using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scan.Models
{
    public class TokenRequest
    {
        public string PersonnelNo { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
    }

    public class ChangePWD
    {
        public string PersonnelNo { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class SupervisorLoginResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public bool isAdmin { get; set; }
        public string personnelNo { get; set; }
        public string name { get; set; }
    }

    public class LoginError
    {
        public string Message { get; set; }
    }
}

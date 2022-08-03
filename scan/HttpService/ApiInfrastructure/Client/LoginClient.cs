namespace HttpService.ApiInfrastructure.Client
{
   
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using Responses;
    using ApiModels;
    

    public interface ILoginClient
    {
        Task<PersonResult> Login(string Username, string Password, string DeviceId);
        Task<SupervisorResult> Login(string Username, string Password);
        Task<ChangePWDResult> ChangePWD(string Username, string OldPassword, string Password, string ConfirmPassword);
    }

   

    public class LoginClient : ClientBase, ILoginClient
    {
        private const string SupervisorTokenUri = "api/accounts/login";
        private const string ScanTokenUri = "api/accounts/scanning/login";
        private const string CnagePWDUri = "api/accounts/scanning/changepwd";

        public LoginClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<SupervisorResult> Login(string Username, string Password)
        {
            var apiModel = new LoginApiModel
            {
              PersonnelNo = Username,
              Password = Password
            };
            var loginResponse = await PostEncodedContentWithSimpleResponse<CreateLoginResponse, LoginApiModel>(SupervisorTokenUri, apiModel);
            if(loginResponse !=null)
            {
                if (loginResponse.StatusIsSuccessful)
                {
                    var loginResult = DecodeJsonToModel<SupervisorResult>(loginResponse.ResponseResult);
                    return loginResult;
                }
            }
            return null; 
        }


        public async Task<ChangePWDResult> ChangePWD(string Username, string OldPassword, string Password, string ConfirmPassword)
        {
            var apiModel = new ChangePWDApiModel
            {
                PersonnelNo = Username,
                OldPassword = OldPassword,
                NewPassword = Password,
                ConfirmPassword = ConfirmPassword
            };
            var changePWDResponse = await PostEncodedContentWithSimpleResponse<CreateChangePWDResponse, ChangePWDApiModel>(CnagePWDUri, apiModel);
            if (changePWDResponse != null)
            {
                if (changePWDResponse.StatusIsSuccessful)
                {
                    var loginResult = DecodeJsonToModel<ChangePWDResult>(changePWDResponse.ResponseResult);
                    return loginResult;
                }
            }
            return null;
        }

        public async Task<PersonResult> Login(string Username, string Password, string DeviceId)
        {
            var apiModel = new LoginApiModel
            {
               PersonnelNo = Username,
               Password = Password,
               DeviceId = DeviceId
            };
           
            var loginResponse = await PostEncodedContentWithSimpleResponse<CreateLoginResponse, LoginApiModel>(ScanTokenUri, apiModel);
            if (loginResponse != null)
            {
                if (loginResponse.StatusIsSuccessful)
                {
                    var loginResult = DecodeJsonToModel<PersonResult>(loginResponse.ResponseResult);
                    return loginResult;
                }
            }
            return null;
        }
    }
}
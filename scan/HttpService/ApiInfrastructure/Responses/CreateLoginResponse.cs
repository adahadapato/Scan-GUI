namespace HttpService.ApiInfrastructure.Responses
{
    using ApiHelper.Response;
    using ApiModels;
    public class CreateLoginResponse : ApiResponse<int>
    {
    }

    public class LoginResponse : ApiResponse<LoginApiModel>
    {
    }

    public class CreateChangePWDResponse : ApiResponse<int>
    {
    }
}
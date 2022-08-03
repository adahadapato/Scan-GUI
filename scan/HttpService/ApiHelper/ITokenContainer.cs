

namespace HttpService.ApiHelper
{
    public interface ITokenContainer
    {
        string ApiToken { get; set; }
        //string Origin { get; }
        //void CalculateExpiryDate();
        bool IsTokenExpired { get;}
        //void ForceTokenToExpire();
        string SupervisorToken { get; set; }
    }
}

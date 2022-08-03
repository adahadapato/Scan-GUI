
namespace HttpService.ApiInfrastructure
{
    using ApiHelper;
    using ApiHelper.Client;
    using Client;
    using SCRghelp;
    using SCRghelp.Infrastructure;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    public class TokenContainer : ITokenContainer
    {
        //IRegistryToken registryToken = new RegistryToken();
        
        ILoginClient loginClient;
        public TokenContainer()
        {
            IApiClient apiClient = new ApiClient(HttpClientInstance.Instance);
            loginClient = new LoginClient(apiClient);
        }
        RegistryHelperClass rh = new RegistryHelperClass();
        public string ApiToken
        {
            
            get
            {
                return rh.ApiToken ?? null;

            }
            set
            {
                rh.ApiToken = value;

            }
        }

        public string SupervisorToken
        {
            get
            {
                return rh.SupervisorApiKey ?? null;
            }
            set
            {
                rh.SupervisorApiKey = value;

            }
        }

        public bool IsTokenExpired
        {
            get
            {
                DateTime testDate = DateTime.Now;
                //string startDate = expiryDate.ToString("dd/MM/yyyy H:mm:ss tt", CultureInfo.InvariantCulture);
                string tempDate = rh.TokenExpiryDate.ToString();// registryToken.Getvalue("TokenExpiryDate");
                DateTime expiryDate = DateTime.ParseExact(tempDate, "dd/MM/yyyy H:mm:ss tt", CultureInfo.InvariantCulture);
                if (expiryDate > testDate)
                {
                    return false;
                }
                return true;
            }
        }

       /* public void CalculateExpiryDate()
        {
            using (RegistryHelperClass rh = new RegistryHelperClass())
            {
                DateTime tempDate = DateTime.Now;
                DateTime expiryDate = tempDate.AddHours(12);
                string startDate = expiryDate.ToString("dd/MM/yyyy H:mm:ss tt", CultureInfo.InvariantCulture);
                rh.TokenExpiryDate = startDate;// registryToken.Setvalue("TokenExpiryDate", startDate);
            }  
        }

        public void ForceTokenToExpire()
        {
            using (RegistryHelperClass rh = new RegistryHelperClass())
            {
                DateTime tempDate = DateTime.Now;
                DateTime expiryDate = tempDate;
                string startDate = expiryDate.ToString("dd/MM/yyyy H:mm:ss tt", CultureInfo.InvariantCulture);
                rh.TokenExpiryDate = startDate;// registryToken.Setvalue("TokenExpiryDate", startDate);
            }
        }*/
    }
}

namespace HttpService.ApiInfrastructure
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Creates a Singleton instance of HttpClient - note that this is for demo purposes only. 
    /// I would recommend that you use a Dependency Injection container such as Autofac for managing the lifecycle of your objects.
    /// If we used Autofac here there would be no need for this class.
    /// </summary>
    public class HttpClientInstance
    {
        
        private const string ManagerBaseUri = "http://10.0.1.31/ManagerApi/";

        public static HttpClient Instance
        {
            get { return new HttpClient { BaseAddress = new Uri(ManagerBaseUri) }; }
        }
    }
}
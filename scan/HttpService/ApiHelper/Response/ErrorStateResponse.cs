namespace HttpService.ApiHelper.Response
{
    using System.Collections.Generic;
    using System.Net;

    public class ErrorStateResponse
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ModelState { get; set; }
        public int status { get; set; }
    }
}
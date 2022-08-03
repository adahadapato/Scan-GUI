namespace HttpService.ApiHelper.Client
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System;
    using Model;
    using System.Windows.Forms;

    public interface IApiClient
    {
        Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> GetFormEncodedContentEx(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostFormEncodedContent<T>(string requestUri, T content);
        Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, bool withSupervisor = false);
        Task<HttpResponseMessage> PostFormEncodedContentWithExtraHeaders<T>(string requestUri, T content);
        Task<HttpResponseMessage> PostFormEncodedContentEx<T>(string requestUri, T content);
        //Task<HttpResponseMessage> GetFormEncodedContent(string requestUri);
        Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T : ApiModel;
        Task<HttpResponseMessage> PostJsonEncodedContentEx<T>(string requestUri, T content) where T : ApiModel;

        Task<HttpResponseMessage> PutFormEncodedContent<T>(string requestUri, T content);
        //Task<HttpResponseMessage> PostFormEncodedContent(string requestUri);
        Task<HttpResponseMessage> PostFormEncodedContentWithHeaders(string requestUri, params KeyValuePair<string, string>[] values);
        //Task<HttpResponseMessage> GetFormEncodedContent(string requestUri);
        //Task<HttpResponseMessage> GetFormEncodedContentWithExtraHeaders(string requestUri);
        //Task<HttpResponseMessage> FetchBiometricsApiKey<T>(string requestUri, T content);
        Task<HttpResponseMessage> GetFileFromServer(string requestUri);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;
        private readonly ITokenContainer tokenContainer;
        
        
            
        public ApiClient(HttpClient httpClient)//, ITokenContainer tokenContainer)
        {
            this.httpClient = httpClient;
            
        }

        public ApiClient(HttpClient httpClient, ITokenContainer tokenContainer)
        {
            this.httpClient = httpClient;
            this.tokenContainer = tokenContainer;
            
        }

       
        
        public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            try
            {
                using (var content = new FormUrlEncodedContent(values))
                {
                    AddToken();
                    var query = await content.ReadAsStringAsync();
                    var requestUriWithQuery = string.Concat(requestUri, "?", query);
                    var response = await httpClient.GetAsync(requestUriWithQuery);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                    MessageBox.Show("Request failed: " + response.ReasonPhrase,"Error");
                }
            }
            catch(Exception ex)
            {
              MessageBox.Show($"{ex.Message} : {ex.InnerException.Message}","Error");
            }
            return null;
        }

        public async Task<HttpResponseMessage> GetFormEncodedContentEx(string requestUri, params KeyValuePair<string, string>[] values)
        {
            try
            {
                using (var content = new FormUrlEncodedContent(values))
                {
                    AddToken();
                    var query = await content.ReadAsStringAsync();
                    var requestUriWithQuery = string.Concat(requestUri, "?", query);
                    var response = await httpClient.GetAsync(requestUriWithQuery);
                    if (response.IsSuccessStatusCode)
                    {
                        return response; 
                    }
                   MessageBox.Show("Request failed: " + response.ReasonPhrase,"Error");
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show($"{ex.Message} : {ex.InnerException.Message}","Error");
            }
            return null;
        }

        /*  public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri)
          {

                  AddToken();
                  //var query = await content.ReadAsStringAsync();
                  //var requestUriWithQuery = string.Concat(requestUri, "?", query);
                  var response = await httpClient.GetAsync(requestUri);
                  return response;

          }*/


        public async Task<HttpResponseMessage> PostFormEncodedContentWithHeaders(string requestUri, params KeyValuePair<string, string>[] values)
        {
            try
            {
                using (var content = new FormUrlEncodedContent(values))
                {
                    //AddHeaders();
                    var response = await httpClient.PostAsync(requestUri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                   MessageBox.Show("Request failed: " + response.ReasonPhrase,"Error");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"{ex.Message} : {ex.InnerException.Message}","Error");
            }
            return null;
        }

        public async Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            try
            {
                using (var content = new FormUrlEncodedContent(values))
                {
                    var response = await httpClient.PostAsync(requestUri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                   MessageBox.Show("Request failed: " + response.ReasonPhrase,"Error");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"{ex.Message} : {ex.InnerException.Message}","Error");
            }
            return null;
           
        }

        public async Task<HttpResponseMessage> PostFormEncodedContent<T>(string requestUri, T content,  params KeyValuePair<string, string>[] values)
        {
            try
            {
                using (var urlParams = new FormUrlEncodedContent(values))
                {
                    //var request =  QueryHelpers.AddQueryString(requestUri, urlParams);
                    var response = await httpClient.PostAsJsonAsync(requestUri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                   MessageBox.Show("Request failed: " + response.ReasonPhrase,"Error");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"{ex.Message} : {ex.InnerException.Message}","Error");
            }
            return null;

        }

        public async Task<HttpResponseMessage> PostFormEncodedContentWithExtraHeaders<T>(string requestUri, T content)
        {
            try
            {
                //AddHeaders();
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    await Task.Delay(3000);
                    return response;
                }
                else
                {
                   MessageBox.Show($"Request failed : {response.ReasonPhrase}","Error");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"Error");
            }
            await Task.Delay(3000);
            return null; 
        }



        public async Task<HttpResponseMessage> PostFormEncodedContent<T>(string requestUri, T content)
        {
            try
            {
                AddToken();
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
              MessageBox.Show("Request failed: " + response.ReasonPhrase.ToString(),"Error");
            }
            catch(Exception ex)
            {
              MessageBox.Show(ex.Message,"Error");
            }
            return null;
            
        }


        /*public async Task<HttpResponseMessage> FetchBiometricsApiKey<T>(string requestUri, T content)
        {
            AddBiometricsTokenHeaders();
            SafeGuiWpf.ShowInformation("Sending request to remote Server ...");
            var response = await httpClient.PostAsJsonAsync(requestUri, content);
            if (!response.IsSuccessStatusCode)
                SafeGuiWpf.ShowError("Request failed: " + response.ReasonPhrase.ToString());
            else
                SafeGuiWpf.ShowInformation("Request sent Successfully");
            return response;
        }*/

        public async Task<HttpResponseMessage> PutFormEncodedContent<T>(string requestUri, T content)
        {
            try
            {
                AddToken();
                var response = await httpClient.PutAsJsonAsync(requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
               MessageBox.Show("Request failed: " + response.ReasonPhrase.ToString(),"Error");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"Error");
            }
            return null;
           
        }
        public async Task<HttpResponseMessage> PostFormEncodedContentEx<T>(string requestUri, T content)
        {

            try
            {
                AddSupervisorToken();
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                MessageBox.Show("Request failed: " + response.ReasonPhrase.ToString(), "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            await Task.Delay(3000);
            return null;
          
        }




        /*public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri)
        {
            try
            {
                AddToken();
                SafeGuiWpf.ShowInformation("Sending request to remote Server ...");
                var response = await httpClient.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    SafeGuiWpf.ShowInformation("Request sent Successfully");
                    return response;
                }
                else
                {
                    SafeGuiWpf.ShowError("Request failed: " + response.ReasonPhrase.ToString());
                }
                   
            }
            catch(Exception e)
            {
                SafeGuiWpf.ShowError(e.Message);
            }
            await Task.Delay(3000);
            return null;
        }*/

        public async Task<HttpResponseMessage> GetFileFromServer(string requestUri)
        {
            try
            {
                //application/octet-stream");  

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                var response = await httpClient.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                MessageBox.Show($"Request failed: {response.ReasonPhrase}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            await Task.Delay(3000);
            return null;
        }

        public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, bool withSupervisor = false)
        {
            try
            {
                if (withSupervisor)
                    AddSupervisorToken();
                else
                    AddToken();
                var response = await httpClient.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
               MessageBox.Show($"Request failed: {response.ReasonPhrase}","Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            await Task.Delay(3000);
            return null;
        }

        public async Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T : ApiModel
        {
            try
            {
                AddToken();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }

       

        /*var parameters = new Dictionary<string, string> { { "param1", "1" }, { "param2", "2" } };
        var encodedContent = new FormUrlEncodedContent (parameters);

        var response = await HttpClient.PostAsync (url, encodedContent).ConfigureAwait (false);*/
        public async Task<HttpResponseMessage> PostJsonEncodedContentEx<T>(string requestUri, T content) where T : ApiModel
        {
            try
            {
                AddSupervisorToken();
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                /*if (response.IsSuccessStatusCode)
                {
                    return response;
                }*/
                //MessageBox.Show($"Request failed: {response.ReasonPhrase}", "Error");
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return null;
        }

        private void AddToken()
        {
            if(tokenContainer!=null)
            {
                if (tokenContainer.ApiToken != null)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenContainer.ApiToken.ToString());
                }
            }
        }

        private void AddSupervisorToken()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenContainer.SupervisorToken.ToString());
        }

       /* private void AddHeaders2()
        {
            using (RegistryHelperClass rh = new RegistryHelperClass())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenContainer.ApiToken.ToString());
                httpClient.DefaultRequestHeaders.Add("Origin", tokenContainer.Origin.ToString());
                httpClient.DefaultRequestHeaders.Add("username", rh.UserName.ToString());
            }
        }*/

       /* private void AddBiometricsApiKeyHeaders()
        {
            using (RegistryHelperClass rh = new RegistryHelperClass())
            {
                httpClient.DefaultRequestHeaders.Add("APIKey", tokenContainer.BiometricsApikey.ToString());
                httpClient.DefaultRequestHeaders.Add("ApplicationID", rh.ProductCode.ToString());
            }
        }*/

       /* private void AddBiometricsTokenHeaders()
        {
            httpClient.DefaultRequestHeaders.Add("APIKey", tokenContainer.BiometricsApiToken.ToString());
        }*/
    }
}
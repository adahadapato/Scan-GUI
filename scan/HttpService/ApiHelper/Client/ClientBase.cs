namespace HttpService.ApiHelper.Client
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using Response;
    using Model;
    using System;
    using System.Windows.Forms;

    public abstract class ClientBase
    {
        protected readonly IApiClient ApiClient;
        protected ClientBase(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        protected async Task<TResponse> GetJsonDecodedContent<TResponse, TContentResponse>(string uri,  params KeyValuePair<string, string>[] requestParameters) 
            where TResponse : ApiResponse<TContentResponse>, new()
        {
            using (var apiResponse = await ApiClient.GetFormEncodedContent(uri, requestParameters))
            {
                return await DecodeJsonResponse<TResponse, TContentResponse>(apiResponse);
            }
        }

        protected async Task<TResponse> GetJsonDecodedContent<TResponse, TContentResponse>(string uri, bool withSupervisor= false)
           where TResponse : ApiResponse<TContentResponse>, new()
        {
            using (var apiResponse = await ApiClient.GetFormEncodedContent(uri, withSupervisor))
            {

                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                    {
                        var result = await DecodeJsonResponse<TResponse, TContentResponse>(apiResponse);
                        return result;
                    }
                }
            }
            await Task.Delay(3000);
            return null;
        }

        protected async Task<byte[]> GetFileContent(string uri)
        {
            using (var apiResponse = await ApiClient.GetFileFromServer(uri))
            {

                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                    {
                        var result =  apiResponse.Content.ReadAsByteArrayAsync().Result;
                        return result;
                    }
                }
            }
            await Task.Delay(3000);
            return null;
        }


        /* protected async Task<TResponse> GetJsonDecodedContentWithExtraHeaders<TResponse, TContentResponse>(string uri)
           where TResponse : ApiResponse<TContentResponse>, new()
         {
             using (var apiResponse = await ApiClient.GetFormEncodedContentWithExtraHeaders(uri))
             {

                 if (apiResponse != null)
                 {
                     if (!apiResponse.IsSuccessStatusCode)
                     {
                       MessageBox.Show(apiResponse.ReasonPhrase);
                     }
                     else
                     {
                         var result = await DecodeJsonResponse<TResponse, TContentResponse>(apiResponse);
                         return result;
                     }
                 }
             }
             await Task.Delay(3000);
             return null;
         }*/

        /* protected async Task<TResponse> GetJsonDecodedContent<TResponse, TContentResponse>(string uri)
            where TResponse : ApiResponse<TContentResponse>, new()
         {
             using (var apiResponse = await ApiClient.GetFormEncodedContent(uri))
             {
                 return await DecodeJsonResponse<TResponse, TContentResponse>(apiResponse);
             }
         }*/
        protected async Task<TResponse> PostEncodedContentWithSimpleResponse<TResponse, TModel>(string url, TModel model)
            where TModel : ApiModel
            where TResponse : ApiResponse<int>, new()
        {
            using (var apiResponse = await ApiClient.PostJsonEncodedContent(url, model))
            {
                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                       var errJson= await DecodeContent<ErrorStateResponse>(apiResponse);
                        if(errJson!=null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                    {
                        return await DecodeJsonResponse<TResponse, int>(apiResponse);
                    } 
                }
            }
            return null;
        }


        protected async Task<TResponse> PostEncodedContentWithSimpleResponseEx<TResponse, TModel>(string url, TModel model)
          where TModel : ApiModel
          where TResponse : ApiResponse<int>, new()
        {
            using (var apiResponse = await ApiClient.PostJsonEncodedContentEx(url, model))
            {
                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                    {
                        return await DecodeJsonResponse<TResponse, int>(apiResponse);
                    }
                }
            }
            return null;
        }
        protected async Task<TResponse> PutEncodedContentWithSimpleResponse<TResponse, TModel>(string url, TModel model)
          where TModel : ApiModel
          where TResponse : ApiResponse<int>, new()
        {
            using (var apiResponse = await ApiClient.PutFormEncodedContent(url, model))
            {
                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                        return await DecodeJsonResponse<TResponse, int>(apiResponse);
                }
            }
            return null;
        }

        protected async Task<TResponse> PostContentWithSimpleResponse<TResponse, TModel>(string url, TModel model)
        where TModel : ApiModel
        where TResponse : ApiResponse<int>, new()
        {
            using (var apiResponse = await ApiClient.PostFormEncodedContent(url, model))
            {
                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                        return await DecodeJsonResponse<TResponse, int>(apiResponse);
                }

            }
            return null;
        }


        protected async Task<TResponse> PostContentWithSimpleResponsEx<TResponse, TModel>(string url, TModel model)
       where TModel : ApiModel
       where TResponse : ApiResponse<int>, new()
        {
            using (var apiResponse = await ApiClient.PostFormEncodedContentEx(url, model))
            {
                if (apiResponse != null)
                {
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        var errJson = await DecodeContent<ErrorStateResponse>(apiResponse);
                        if (errJson != null)
                        {
                            MessageBox.Show(errJson.Message.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await Task.Delay(3000);
                        }
                    }
                    else
                        return await DecodeJsonResponse<TResponse, int>(apiResponse);
                }

            }
            return null;
        }

        protected async Task<TResponse> PostEncodedContentWithSimpleResponse<TResponse,  TModel, TContentResponse>(string url, TModel model)
             where TModel : ApiModel
             where TResponse : ApiResponse<TContentResponse>, new()
        {
            using (var apiResponse = await ApiClient.PostJsonEncodedContent(url, model))
            {
                return await DecodeJsonResponse<TResponse, TContentResponse>(apiResponse);
            }
        }

      

        protected static async Task<TResponse> CreateJsonResponse<TResponse>(HttpResponseMessage response) where TResponse : ApiResponse, new()
        {
            var clientResponse = new TResponse
            {
                StatusIsSuccessful = response.IsSuccessStatusCode,
                ErrorState = response.IsSuccessStatusCode ? null : await DecodeContent<ErrorStateResponse>(response),
                ResponseCode = response.StatusCode
            };
            if (response.Content != null)
            {
                clientResponse.ResponseResult = await response.Content.ReadAsStringAsync();
            }
            return clientResponse;
        }

        protected static async Task<TContentResponse> DecodeContent<TContentResponse>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            return Json.Decode<TContentResponse>(result);
        }

        private static async Task<TResponse> DecodeJsonResponse<TResponse, TDecode>(HttpResponseMessage apiResponse) 
            where TResponse : ApiResponse<TDecode>, new()
        {
            try
            {
                var response = await CreateJsonResponse<TResponse>(apiResponse);
                response.Data = Json.Decode<TDecode>(response.ResponseResult);
                return response;
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            await Task.Delay(3000);
            return null;
        }


        protected static TDecode DecodeJsonToModel<TDecode>(string apiResponse) 
        {
            return  Json.Decode<TDecode>(apiResponse);
        }

        protected static async Task<TDecode> DecodeJsonToModelAsync<TDecode>(string apiResponse)
        {
            return await Task.Run(() =>
             {
                   return Json.Decode<TDecode>(apiResponse);
            });
        }
    }
}
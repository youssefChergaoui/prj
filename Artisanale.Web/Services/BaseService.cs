using Artisanale.Web.Models;
using Artisanale.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Artisanale.Web.Services
{
    public class BaseService : IBaseServices
    {
        public ResponseDto responseModel { get ; set ; }

        //aficher les resultat 
        public IHttpClientFactory httpClient { get; set ; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto(); 
            this.httpClient = httpClient;
            
        }



        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("ArtisanaleAPi");
                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");

                }
                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                        apiRequest.AccessToken);
                }

                //clear
                HttpResponseMessage apiResponse = null;

                switch (apiRequest.apitype)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                apiResponse = await client.SendAsync(message);
                //pbject generec ma3andhom ta dpour frl7ayat
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>
                    {
                        Convert.ToString(ex.Message)
                    },
                    IsSuccess = false,

                };

                var res=JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;

            }
        }


        public void Dispose()
        {
           GC.SuppressFinalize(true);
        }
    }
}

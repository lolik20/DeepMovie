using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeepAdmin
{
    public static class HttpService<TRequest, TResponse>
    {
        private static HttpClient _client;
        private readonly static string _apiUrl= "https://localhost:44342/";
        static HttpService()
        {
            _client = new HttpClient();

        }
        public static async Task<TResponse> Post(TRequest requestModel, string url)
        {
            var content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_apiUrl + url, content);
            var responseText = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(responseText);
            return result;
        }
    }
}

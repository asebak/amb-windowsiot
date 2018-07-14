using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Api
{
    public class Request: IRequest
    {
        private readonly AmbrosusSettings _settings;

        public Request(AmbrosusSettings settings)
        {
            _settings = settings;
        }

        public T GetRequest<T>(string path)
        {
            var client = new HttpClient {BaseAddress = new Uri(_settings.ApiEndpoint)};
            var response = client.GetAsync(path).Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T PostRequest<T>(string path, string body)
        {
            var client = new HttpClient {BaseAddress = new Uri(_settings.ApiEndpoint)};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var req = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            };
            req.Headers.Authorization = new AuthenticationHeaderValue("AMB", _settings.Secret);
            var res = client.SendAsync(req).Result;
            res.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result);
        }
    }
}

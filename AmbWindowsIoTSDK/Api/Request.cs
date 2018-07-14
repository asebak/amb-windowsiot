using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
            return (T)Convert.ChangeType("", typeof(T));
        }

        public T PostRequest<T>(string path, string body)
        {
            var client = new HttpClient {BaseAddress = new Uri(_settings.ApiEndpoint)};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.ConnectionClose = false;
            var req = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            };
            req.Headers.Authorization = new AuthenticationHeaderValue("AMB", _settings.Secret);
            var res = client.SendAsync(req).Result;
            return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result);
        }
    }
}

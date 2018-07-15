using System.Dynamic;
using Amb.Sdk.Model;
using Newtonsoft.Json;

namespace Amb.Sdk.Api
{
    public class Auth
    {
        private readonly IRequest _request;

        public Auth(IRequest request)
        {
            _request = request;
        }

        public string GetToken()
        {
            dynamic obj = new ExpandoObject();
            obj.validUntil = 1600000000;
            var response =  (TokenResponse) _request.PostRequest<TokenResponse>("token", JsonConvert.SerializeObject(obj));
            return response.Token;
        }
    }
}

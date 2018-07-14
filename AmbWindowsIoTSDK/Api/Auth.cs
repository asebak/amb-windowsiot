using System.Dynamic;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Api
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
            return _request.PostRequest<string>("token", JsonConvert.SerializeObject(obj));
        }
    }
}

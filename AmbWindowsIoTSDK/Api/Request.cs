using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return (T)Convert.ChangeType("", typeof(T));
        }
    }
}

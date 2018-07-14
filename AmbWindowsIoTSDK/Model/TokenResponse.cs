using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Model
{
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

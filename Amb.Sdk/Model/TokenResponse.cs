using Newtonsoft.Json;

namespace Amb.Sdk.Model
{
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

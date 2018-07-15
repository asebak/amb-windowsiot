using Newtonsoft.Json;

namespace Amb.Sdk.Model
{
    public class NodeInfo
    {

        [JsonProperty("commit")]
        public string Commit { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("nodeAddress")]
        public string NodeAddress { get; set; }
    }

}

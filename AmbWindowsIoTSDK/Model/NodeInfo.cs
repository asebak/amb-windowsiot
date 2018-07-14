using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Model
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

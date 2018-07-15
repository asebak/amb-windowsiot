using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amb.Sdk.Model.Event
{
    public class IdData
    {
        [JsonProperty("accessLevel")]
        public int AccessLevel { get; set; }

        [JsonProperty("assetId")]
        public string AssetId { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("dataHash")]
        public string DataHash { get; set; }
    }

    public class Datum
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
        //[JsonProperty("customField")] //todo fix this as it's a bunch of random fields
        //public string CustomField { get; set; }
    }

    public class Content
    {

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("idData")]
        public IdData IdData { get; set; }

        [JsonProperty("data")]
        public IList<Datum> Data { get; set; }
    }

    public class Event
    {

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public class EventList
    {

        [JsonProperty("results")]
        public IList<Event> Results { get; set; }

        [JsonProperty("resultCount")]
        public int ResultCount { get; set; }
    }
}

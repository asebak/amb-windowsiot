using System.Collections.Generic;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Model
{

    public class AssetList
    {

        [JsonProperty("results")]
        public IList<Asset> Results { get; set; }

        [JsonProperty("resultCount")]
        public int ResultCount { get; set; }
    }

    public class IdData
    {

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }
    }

    public class Content
    {

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("idData")]
        public IdData IdData { get; set; }
    }

    public class Metadata
    {

        [JsonProperty("bundleId")]
        public string BundleId { get; set; }

        [JsonProperty("bundleTransactionHash")]
        public string BundleTransactionHash { get; set; }
    }

    public class Asset
    {

        [JsonProperty("assetId")]
        public string AssetId { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }



}

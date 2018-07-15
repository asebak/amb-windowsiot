namespace Amb.Sdk.Model.Asset
{
    public class AssetOptions
    {
        public int? PerPage { get; set; }
        public int? Page { get; set; }
        public string CreatedBy { get; set; }
        public long? FromTimestamp { get; set; }
        public long? ToTimestamp { get; set; }
        public string Identifier { get; set; }
    }
}

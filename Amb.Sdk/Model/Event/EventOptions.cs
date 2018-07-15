namespace Amb.Sdk.Model.Event
{
    public class EventOptions
    {
        public string AssetId { get; set; }
        public long? FromTimestamp { get; set; }
        public long? ToTimestamp { get; set; }
        public int? PerPage { get; set; }
        public int? Page { get; set; }
        public string Data { get; set; }
        public string CreatedBy { get; set; }
    }
}

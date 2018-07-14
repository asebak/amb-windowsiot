namespace AmbWindowsIoTSDK.Model.Event
{
    public class EventOptions
    {
        public string AssetId { get; set; }
        public long? FromTimestamp { get; set; }
        public long? ToTimestamp { get; set; }
        public int? PerPage { get; set; }
        public string Data { get; set; }
    }
}

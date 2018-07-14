using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbWindowsIoTSDK.Model
{
    public class EventOptions
    {
        public string AssetId { get; set; }
        public long FromTimestamp { get; set; }
        public long ToTimestamp { get; set; }
        public int PerPage { get; set; }
        public string Data { get; set; }
    }
}

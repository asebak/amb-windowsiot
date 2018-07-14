using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbWindowsIoTSDK
{
    public class AmbrosusSettings
    {
        public string ApiEndpoint { get; set; } = "https://gateway-test.ambrosus.com";
        public string Address { get; set; }
        public string Secret { get; set; }

    }
}

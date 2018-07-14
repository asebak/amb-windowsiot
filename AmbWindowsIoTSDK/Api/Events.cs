using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbWindowsIoTSDK.Model;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Api
{
    public class Events
    {
        private readonly IRequest _request;

        public Events(IRequest request)
        {
            _request = request;
        }

        public Object GetEvents(EventOptions options)
        {
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage),
                new KeyValuePair<string, object>(nameof(options.AssetId).ToCamelCase(), options.AssetId),
                new KeyValuePair<string, object>(nameof(options.Data).ToCamelCase(), options.Data),
                new KeyValuePair<string, object>(nameof(options.FromTimestamp).ToCamelCase(), options.FromTimestamp),
                new KeyValuePair<string, object>(nameof(options.ToTimestamp).ToCamelCase(), options.ToTimestamp)
            });

            var events = _request.GetRequest<object>($"events{query}");
            return events;
        }


        public Object GeEventById(string eventId)
        {
            var eve = _request.GetRequest<Object>($"events/{eventId}");
            return eve;
        }

        public Asset CreateEvent(string assetId, Event eve)
        {
            return _request.PostRequest<Asset>($"assets/{assetId}/events", JsonConvert.SerializeObject(eve,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}
            ));
        }
    }
}

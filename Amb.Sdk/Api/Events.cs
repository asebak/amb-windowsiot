using System.Collections.Generic;
using Amb.Sdk.Model.Event;
using Newtonsoft.Json;

namespace Amb.Sdk.Api
{
    public class Events
    {
        private readonly IRequest _request;

        public Events(IRequest request)
        {
            _request = request;
        }

        public EventList GetEvents(EventOptions options)
        {
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage),
                new KeyValuePair<string, object>(nameof(options.AssetId).ToCamelCase(), options.AssetId),
                new KeyValuePair<string, object>(nameof(options.Data).ToCamelCase(), options.Data),
                new KeyValuePair<string, object>(nameof(options.FromTimestamp).ToCamelCase(), options.FromTimestamp),
                new KeyValuePair<string, object>(nameof(options.ToTimestamp).ToCamelCase(), options.ToTimestamp),
                new KeyValuePair<string, object>(nameof(options.CreatedBy).ToCamelCase(), options.CreatedBy),
                new KeyValuePair<string, object>(nameof(options.Page).ToCamelCase(), options.Page),

            });

            var events = _request.GetRequest<EventList>($"events{query}");
            return events;
        }


        public Event GetEventById(string eventId)
        {
            var eve = _request.GetRequest<Event>($"events/{eventId}");
            return eve;
        }

        public Event CreateEvent(string assetId, Event eve)
        {
            return _request.PostRequest<Event>($"assets/{assetId}/events", JsonConvert.SerializeObject(eve,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}
            ));
        }
    }
}

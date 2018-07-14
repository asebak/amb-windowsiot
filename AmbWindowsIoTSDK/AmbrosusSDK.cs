using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbWindowsIoTSDK.Api;
using AmbWindowsIoTSDK.Model;
using AmbWindowsIoTSDK.Model.Asset;
using AmbWindowsIoTSDK.Model.Event;
using AssetContent = AmbWindowsIoTSDK.Model.Asset.Content;
using EventContent = AmbWindowsIoTSDK.Model.Event.Content;
using AssetIdData = AmbWindowsIoTSDK.Model.Asset.IdData;
using EventIdData = AmbWindowsIoTSDK.Model.Event.IdData;

namespace AmbWindowsIoTSDK
{
    public class AmbrosusSdk
    {
        private readonly AmbrosusSettings _settings;
        private readonly Auth _auth;
        private readonly Assets _assets;
        private readonly Events _events;
        private readonly Node _node;

        public AmbrosusSdk(AmbrosusSettings settings)
        {
            _settings = settings;
            this._auth = new Auth(new Request(settings));
            this._assets = new Assets(new Request(settings));
            this._events = new Events(new Request(settings));
            this._node = new Node(new Request(settings));
        }

        public AssetList GetAssets(AssetOptions options)
        {
           return this._assets.GetAssets(options);
        }


        public Asset GetAssetById(string assetId)
        {
            return this._assets.GetAssetById(assetId);
        }

        public Asset CreateAsset()
        {
            var param = new Asset
            {
                Content = new AssetContent
                {
                    IdData = new AssetIdData
                    {
                        CreatedBy = _settings.Address,
                        SequenceNumber = 0,
                        Timestamp = (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                    }
                }
            };

            return this._assets.CreateAsset(param);
        }

        public Event GetEventById(string eventId)
        {
            return this._events.GetEventById(eventId);
        }


        public EventList GetEvents(EventOptions paramaters)
        {
            return this._events.GetEvents(paramaters);
        }



        public Event CreateEvent(string assetId, IList<Datum> eventData)
        {
            var param = new Event
            {
                Content = new EventContent
                {
                    IdData = new EventIdData
                    {
                        AssetId = assetId,
                        CreatedBy = _settings.Address,
                        AccessLevel = 0,
                        Timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                    }
                }

            };

            if (eventData != null && eventData.Count > 0)
            {
                param.Content.Data = eventData;
            }
            else
            {
                throw new ArgumentException("Data field is required.");
            }

            return this._events.CreateEvent(assetId, param);
        }

        public NodeInfo GetNodeInfo()
        {
            return _node.Information();
        }
 
    }
}

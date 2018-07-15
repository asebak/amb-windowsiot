using System;
using System.Collections.Generic;
using Amb.Sdk.Api;
using Amb.Sdk.Model;
using Amb.Sdk.Model.Asset;
using Amb.Sdk.Model.Event;
using AssetContent = Amb.Sdk.Model.Asset.Content;
using EventContent = Amb.Sdk.Model.Event.Content;
using AssetIdData = Amb.Sdk.Model.Asset.IdData;
using EventIdData = Amb.Sdk.Model.Event.IdData;

namespace Amb.Sdk
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

        public AmbrosusSettings Settings => _settings;

        public AssetList GetAssets(AssetOptions options)
        {
           return this._assets.GetAssets(options);
        }

        public Asset GetAssetById(string assetId)
        {
            if (string.IsNullOrEmpty(assetId))
            {
                throw new ArgumentException("assetId is required.");
            }
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
                        CreatedBy = Settings.Address,
                        SequenceNumber = 0,
                        Timestamp = (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                    }
                }
            };

            return this._assets.CreateAsset(param);
        }

        public Event GetEventById(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                throw new ArgumentException("eventId is required.");
            }

            return this._events.GetEventById(eventId);
        }


        public EventList GetEvents(EventOptions paramaters)
        {
            return this._events.GetEvents(paramaters);
        }



        public Event CreateEvent(string assetId, IList<Datum> eventData)
        {
            if (string.IsNullOrEmpty(assetId))
            {
                throw new ArgumentException("assetId is required.");
            }

            var param = new Event
            {
                Content = new EventContent
                {
                    IdData = new EventIdData
                    {
                        AssetId = assetId,
                        CreatedBy = Settings.Address,
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
                throw new ArgumentException("eventData is required.");
            }

            return this._events.CreateEvent(assetId, param);
        }

        public NodeInfo GetNodeInfo()
        {
            return _node.Information();
        }
 
    }
}

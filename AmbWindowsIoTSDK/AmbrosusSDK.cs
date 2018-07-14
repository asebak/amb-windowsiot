using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbWindowsIoTSDK.Api;
using AmbWindowsIoTSDK.Model;

namespace AmbWindowsIoTSDK
{
    public class AmbrosusSdk
    {
        private readonly AmbrosusSettings _settings;
        private readonly Auth _auth;
        private Assets _assets;
        private Events _events;

        public AmbrosusSdk(AmbrosusSettings settings)
        {
            _settings = settings;
            this._auth = new Auth(new Request(settings));
            this._assets = new Assets(new Request(settings));
            this._events = new Events(settings, this._auth);
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
                Content = new Content
                {
                    IdData = new IdData
                    {
                        CreatedBy = _settings.Address,
                        SequenceNumber = 0,
                        Timestamp = (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                    }
                }
            };

            return this._assets.CreateAsset(param);
        }

        public object GetEventById(string eventId)
        {
            throw new NotImplementedException();
        }


        public object GetEvents(EventOptions paramaters)
        {
            this._events
            throw new NotImplementedException();
        }



        public object CreateEvent(object asset, object eventData)
        {
            throw new NotImplementedException();
        }

        public object ParseEvents(object eventData)
        {
            throw new NotImplementedException();
        }

 
    }
}

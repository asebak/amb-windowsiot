using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbWindowsIoTSDK.Api;

namespace AmbWindowsIoTSDK
{
    public class AmbrosusSdk
    {
        private readonly Auth _auth;
        private Assets _assets;
        private Events _events;

        public AmbrosusSdk(AmbrosusSettings settings)
        {
            this._auth = new Auth(settings);
            this._assets = new Assets(settings, this._auth);
            this._events = new Events(settings, this._auth);
        }

        public object getAssetById(string assetId)
        {
            throw new NotImplementedException();
        }

        public object getEventById(string eventId)
        {
            throw new NotImplementedException();
        }

        public object getAssets(object paramaters)
        {
            throw new NotImplementedException();
        }

        public object getEvents(object paramaters)
        {
            throw new NotImplementedException();
        }

        public object createAsset(object asset)
        {
            throw new NotImplementedException();
        }

        public object createEvent(object asset, object eventData)
        {
            throw new NotImplementedException();
        }

        public object parseEvents(object eventData)
        {
            throw new NotImplementedException();
        }

 
    }
}

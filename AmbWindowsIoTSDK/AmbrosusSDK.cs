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
           this._auth = new Auth(new Request(settings));
           this._assets = new Assets(settings, this._auth);
           this._events = new Events(settings, this._auth);
        }

        public object GetAssets(object paramaters)
        {
            throw new NotImplementedException();
        }


        public object GetAssetById(string assetId)
        {
            throw new NotImplementedException();
        }

        public object GetEventById(string eventId)
        {
            throw new NotImplementedException();
        }


        public object GetEvents(object paramaters)
        {
            throw new NotImplementedException();
        }

        public object CreateAsset(object asset)
        {
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

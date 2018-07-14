using System;
using System.Collections.Generic;
using AmbWindowsIoTSDK.Model;
using AmbWindowsIoTSDK.Model.Asset;
using Newtonsoft.Json;

namespace AmbWindowsIoTSDK.Api
{
    public class Assets
    {
        private Request _request;

        public Assets(Request request)
        {
            this._request = request;
        }

        public AssetList GetAssets(AssetOptions options)
        {
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage)
            });

            var assets = _request.GetRequest<AssetList>($"assets{query}");
            return assets;
        }


        public Asset GetAssetById(string assetId)
        {
            var asset = _request.GetRequest<Asset>($"assets/{assetId}");
            return asset;
        }

        public Asset CreateAsset(Asset asset)
        {
            return _request.PostRequest<Asset>("assets", JsonConvert.SerializeObject(asset,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}
                ));
        }

    }
}

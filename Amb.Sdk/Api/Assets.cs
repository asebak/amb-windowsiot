using System.Collections.Generic;
using Amb.Sdk.Model.Asset;
using Newtonsoft.Json;

namespace Amb.Sdk.Api
{
    public class Assets
    {
        private readonly Request _request;

        public Assets(Request request)
        {
            this._request = request;
        }

        public AssetList GetAssets(AssetOptions options)
        {
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage),
                new KeyValuePair<string, object>(nameof(options.CreatedBy).ToCamelCase(), options.CreatedBy),
                new KeyValuePair<string, object>(nameof(options.Identifier).ToCamelCase(), options.Identifier),
                new KeyValuePair<string, object>(nameof(options.FromTimestamp).ToCamelCase(), options.FromTimestamp),
                new KeyValuePair<string, object>(nameof(options.ToTimestamp).ToCamelCase(), options.ToTimestamp),
                new KeyValuePair<string, object>(nameof(options.Page).ToCamelCase(), options.Page)

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
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}
            ));
        }

    }
}

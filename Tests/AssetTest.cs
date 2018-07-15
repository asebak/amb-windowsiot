using System;
using System.Collections.Generic;
using System.Text;
using Amb.Sdk;
using Amb.Sdk.Model.Asset;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AssetTest
    {
        string _assetId = "0x525466324f178cef08e25cf69cffde9f149129e4ceddfaa19767bc29705cef56";

        [TestMethod]
        public void TestGetAssetById()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var asset = sdk.GetAssetById(_assetId);
            Assert.IsNotNull(asset);
            Assert.IsTrue(asset.AssetId == _assetId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetAssetWithMissingId()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var asset = sdk.GetAssetById("");
        }


        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestGetAssetWithInvalidAssetId()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var asset = sdk.GetAssetById("0x34234232");

        }

        [TestMethod]
        public void TestGetAssetWithEmptyParamaters()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var assets = sdk.GetAssets(new AssetOptions
            {
                
            });
            Assert.IsTrue(assets.ResultCount > 1);
            Assert.IsTrue(assets.Results.Count > 1);
        }


        [TestMethod]
        public void TestGetAssetWithParamaters()
        {
            var createdBy = "0x9687a70513047dc6Ee966D69bD0C07FFb1102098";

            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var assets = sdk.GetAssets(new AssetOptions
            {
                PerPage = 10,
                CreatedBy = createdBy
            });
            Assert.IsTrue(assets.Results.Count == 10);
            foreach (var assetsResult in assets.Results)
            {
                Assert.IsTrue(assetsResult.Content.IdData.CreatedBy == createdBy);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestGetAssetWithInvalidParamaters()
        {
            var createdBy = "0x9687a70518";

            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var assets = sdk.GetAssets(new AssetOptions
            {
                PerPage = 10,
                CreatedBy = createdBy
            });
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestCreateAssetMissingKey()
        {
            var createdBy = "0x9687a70513047dc6Ee966D69bD0C07FFb1102098";

            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var assets = sdk.CreateAsset();
        }

    }
}

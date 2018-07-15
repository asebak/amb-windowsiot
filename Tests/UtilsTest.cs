using System.Collections.Generic;
using Amb.Sdk;
using Amb.Sdk.Model.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void TestLowercase()
        {
            EventOptions options;
            var camelCase = nameof(options.PerPage).ToCamelCase();
            Assert.IsTrue(camelCase == "perPage");
        }

        [TestMethod]
        public void TestValidQueryString()
        {
            EventOptions options = new EventOptions
            {
                PerPage = 5,
                AssetId = "0x55"
            };
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage),
                new KeyValuePair<string, object>(nameof(options.AssetId).ToCamelCase(), options.AssetId),
                new KeyValuePair<string, object>(nameof(options.Data).ToCamelCase(), options.Data),
                new KeyValuePair<string, object>(nameof(options.FromTimestamp).ToCamelCase(), options.FromTimestamp),
                new KeyValuePair<string, object>(nameof(options.ToTimestamp).ToCamelCase(), options.ToTimestamp)
            });

            Assert.IsTrue(query == $"?perPage={options.PerPage.Value}&assetId={options.AssetId}");
        }

        [TestMethod]
        public void TestEmptyQueryString()
        {
            EventOptions options = new EventOptions
            {
            };
            var query = Utils.BuildQueryString(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(options.PerPage).ToCamelCase(), options.PerPage),
                new KeyValuePair<string, object>(nameof(options.AssetId).ToCamelCase(), options.AssetId),
                new KeyValuePair<string, object>(nameof(options.Data).ToCamelCase(), options.Data),
                new KeyValuePair<string, object>(nameof(options.FromTimestamp).ToCamelCase(), options.FromTimestamp),
                new KeyValuePair<string, object>(nameof(options.ToTimestamp).ToCamelCase(), options.ToTimestamp)
            });

            Assert.IsTrue(query == "");
        }


    }
}

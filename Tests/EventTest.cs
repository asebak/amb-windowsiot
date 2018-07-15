using System;
using System.Collections.Generic;
using System.Text;
using Amb.Sdk;
using Amb.Sdk.Model.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Tests
{
    [TestClass]
    public class EventTest
    {
        string _eventId = "0x8663d7863dc5131d5ad6050d44ed625cd299b78d2ce289ffc95e63b1559c3f63";

        [TestMethod]
        public void TestGetEventById()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.GetEventById(_eventId);
            Assert.IsTrue(eve.EventId == _eventId);
            foreach (var datum in eve.Content.Data)
            {
                Assert.IsNotNull(datum.AdditionalData);
                foreach (var d in datum.AdditionalData)
                {
                    Assert.IsNotNull(d.Key);
                    Assert.IsNotNull(d.Value);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetEventByWithEmptyId()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.GetEventById("");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestGetEventWithInvalidId()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.GetEventById("0x34234232");

        }

        [TestMethod]
        public void TestGetEventWithDefaultParamters()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var events = sdk.GetEvents(new EventOptions());
            Assert.IsTrue(events.ResultCount > 1);
            Assert.IsTrue(events.Results.Count > 1);
        }

        [TestMethod]
        public void TestGetEventWithSpecificParamters()
        {
            var assetId = "0x525466324f178cef08e25cf69cffde9f149129e4ceddfaa19767bc29705cef56";
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var events = sdk.GetEvents(new EventOptions
            {
                PerPage = 5,
                AssetId = assetId
            });
            Assert.IsTrue(events.Results.Count == 5);
            foreach (var eventsResult in events.Results)
            {
                Assert.IsTrue(eventsResult.Content.IdData.AssetId == assetId);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestGetEventWithInvalidParamters()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.GetEvents(new EventOptions
            {
                CreatedBy = "0x32423",
                PerPage = 5,
                AssetId = "0x3432423",
                
            });
 
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateEventEmptyAssetId()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.CreateEvent("", new List<Datum>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateEventEmptyData()
        {
            var assetId = "0x525466324f178cef08e25cf69cffde9f149129e4ceddfaa19767bc29705cef56";
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.CreateEvent(assetId, new List<Datum>());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
        public void TestCreateEventInvalidSecret()
        {
            var assetId = "0x525466324f178cef08e25cf69cffde9f149129e4ceddfaa19767bc29705cef56";
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var eve = sdk.CreateEvent(assetId, new List<Datum>
            {
                new Datum
                {
                    Type = EventType.Temperature.Value,
                    AdditionalData = new Dictionary<string, JToken>
                    {
                        {"temperature", "15"}
                    }
                }
            });
        }

    }
}

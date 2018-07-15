using System;
using System.Collections.Generic;
using System.Text;
using Amb.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]

    public class SdkTest
    {
        [TestMethod]
        public void TestSdkInstantionation()
        {
            var settings = new AmbrosusSettings();
            var sdk = new AmbrosusSdk(settings);
            Assert.IsFalse(string.IsNullOrEmpty(sdk.Settings.ApiEndpoint));
            Assert.IsTrue(sdk.Settings.ApiEndpoint == settings.ApiEndpoint);
        }
    }
}

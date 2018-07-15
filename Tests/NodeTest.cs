using System;
using System.Collections.Generic;
using System.Text;
using Amb.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void TestNodeInformation()
        {
            var sdk = new AmbrosusSdk(new AmbrosusSettings());
            var nodeInfo = sdk.GetNodeInfo();
            Assert.IsFalse(string.IsNullOrEmpty(nodeInfo.NodeAddress));
            Assert.IsFalse(string.IsNullOrEmpty(nodeInfo.Version));
        }
    }
}

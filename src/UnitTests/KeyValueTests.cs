using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandyUtils;

namespace UnitTests
{
    [TestClass]
    public class KeyValueTests
    {
        [TestMethod]
        public void TestKeyValueNew()
        {
            var kv = KeyValue.New("a", 1);

            Assert.AreEqual(kv.Key, "a");
            Assert.AreEqual(kv.Value, 1);
        }
    }
}

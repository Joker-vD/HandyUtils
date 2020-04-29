using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HandyUtils;
using System.Collections.Specialized;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class EnumerableUtilsTests
    {
        [TestMethod]
        public void TestToDictionary()
        {
            var dict = new KeyValuePair<string, int>[]
            {
                KeyValue.New("a", 1),
                KeyValue.New("b", 2),
            }.ToDictionary();

            Assert.IsTrue(dict.Count == 2);
            Assert.IsTrue(dict["a"] == 1);
            Assert.IsTrue(dict["b"] == 2);
        }

        [TestMethod]
        public void TestToItemsString_EmptySequence()
        {
            var expected = "";
            var actual = new string[] { }.ToItemsString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToItemsString_SingletonSequence()
        {
            var expected = "1";
            var actual = new string[] { "1" }.ToItemsString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToItemsString_LongSequence()
        {
            var expected = "1, 2";
            var actual = new string[] { "1", "2" }.ToItemsString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToPrefixedItemsString_EmptySequence()
        {
            var expected = "test";
            var actual = new string[] { }.ToPrefixedItemsString("test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToPrefixedItemsString_SingletonSequence()
        {
            var expected = "test, 1";
            var actual = new string[] { "1" }.ToPrefixedItemsString("test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToPrefixedItemsString_LongSequence()
        {
            var expected = "test, 1, 2";
            var actual = new string[] { "1", "2" }.ToPrefixedItemsString("test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAssignFrom()
        {
            var dict = new StringDictionary();
            dict.Add("z", "42");

            dict.AssignFrom(new Dictionary<string, string>
            {
                ["a"] = "1",
                ["b"] = "2",
            });

            Assert.IsTrue(dict.Count == 2);
            Assert.IsTrue(dict["a"] == "1");
            Assert.IsTrue(dict["b"] == "2");
        }

        [TestMethod]
        public void TestSingleton()
        {
            var singleton = EnumerableUtils.Singleton("test").ToList();

            Assert.AreEqual(1, singleton.Count);
            Assert.AreEqual("test", singleton[0]);
        }
    }
}

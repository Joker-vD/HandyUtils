using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandyUtils;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TypeUtilsTests
    {
        [TestMethod]
        public void TestListIntImplementsIList()
        {
            Type resultType;
            Assert.IsTrue(TypeUtils.ImplementsGenericInterface(typeof(List<int>), typeof(IList<>), out resultType));
            Assert.AreEqual(typeof(IList<int>), resultType);
        }

        [TestMethod]
        public void TestDictionaryDoesntImplementIList()
        {
            Type resultType;
            Assert.IsFalse(TypeUtils.ImplementsGenericInterface(typeof(Dictionary<int, string>), typeof(IList<>), out resultType));
            Assert.AreEqual(null, resultType);
        }

        [TestMethod]
        public void TestUnderlyingListTypeOfListInt()
        {
            Assert.AreEqual(typeof(int), TypeUtils.GetUnderlyingListItemType(typeof(List<int>)));
        }

        [TestMethod]
        public void TestUnderlyingListTypeOfIList()
        {
            Assert.AreEqual(typeof(int), TypeUtils.GetUnderlyingListItemType(typeof(IList<int>)));
        }
    }
}

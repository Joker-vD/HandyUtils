using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using HandyUtils;

namespace UnitTests
{
    [TestClass]
    public class HashUtilsTests
    {
        void ForAllInts(Action<int> action)
        {
            for (int i = int.MinValue; i < int.MaxValue; ++i)
            {
                action(i);
            }
            action(int.MaxValue);
        }

        [Ignore]
        [TestMethod]
        public void TestCombiningZeroWithOthers()
        {
            ForAllInts(num => { Assert.AreEqual(num, HashUtils.Combine(0, num)); });
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandyUtils;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ForEachUtilsTests
    {
        [TestMethod]
        public void TestForEach()
        {
            var list = new List<string> { "a", "b", "c" };
            var sb = new StringBuilder();

            list.ForEach((item, index) =>
            {
                sb.AppendFormat("{0}:{1},", index, item);
            });

            var actual = sb.ToString();
            Assert.AreEqual("0:a,1:b,2:c,", actual);
        }
    }
}

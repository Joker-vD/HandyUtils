using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandyUtils;

namespace UnitTests
{
    [TestClass]
    public class CharUtilsTests
    {
        [TestMethod]
        public void TestEscapeChar()
        {
            Assert.AreEqual(@"\n", '\n'.Escape());
            Assert.AreEqual(@"\r", '\r'.Escape());
            Assert.AreEqual(@"\t", '\t'.Escape());
            Assert.AreEqual(@"\ ", ' '.Escape());
            Assert.AreEqual(@"\0", '\0'.Escape());
            Assert.AreEqual(@"\\", '\\'.Escape());
            Assert.AreEqual(@"\'", '\''.Escape());
            Assert.AreEqual(@"\" + '"', '\"'.Escape());
            Assert.AreEqual("a", 'a'.Escape());
            Assert.AreEqual("0", '0'.Escape());
        }

        [TestMethod]
        public void TestUnescapeChar()
        {
            Assert.AreEqual('\n', @"\n".UnescapeChar());
            Assert.AreEqual('\r', @"\r".UnescapeChar());
            Assert.AreEqual('\t', @"\t".UnescapeChar());
            Assert.AreEqual(' ', @"\ ".UnescapeChar());
            Assert.AreEqual('\0', @"\0".UnescapeChar());
            Assert.AreEqual('\\', @"\\".UnescapeChar());
            Assert.AreEqual('\'', @"\'".UnescapeChar());
            Assert.AreEqual('\"', (@"\" + '"').UnescapeChar());
            Assert.AreEqual('a', "a".UnescapeChar());
            Assert.AreEqual('0', "0".UnescapeChar());
        }
    }
}

using HandyUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class StringUtilsTests
    {
        [TestMethod]
        public void TestFormatWith()
        {
            Assert.AreEqual("Test: a, b", "{0}: {1}, {2}".FormatWith("Test", "a", "b"));
        }

        [TestMethod]
        public void TestIsUpperLower()
        {
            Assert.IsTrue('A'.IsUpper());
            Assert.IsFalse('A'.IsLower());

            Assert.IsTrue('a'.IsLower());
            Assert.IsFalse('a'.IsUpper());
        }

        [TestMethod]
        public void TestToLowerToUpper()
        {
            Assert.AreEqual('I', 'i'.ToUpperInvariant());
            Assert.AreEqual('i', 'I'.ToLowerInvariant());
        }

        [TestMethod]
        public void TestDecapitalizeFirstLetter_EmptyString()
        {
            Assert.AreEqual("", "".DecapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestDecapitalizeFirstLetter_AlreadyLowerCase()
        {
            Assert.AreEqual("camelCase", "camelCase".DecapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestDecapitalizeFirstLetter()
        {
            Assert.AreEqual("uPPER", "UPPER".DecapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter_EmptyString()
        {
            Assert.AreEqual("", "".CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter_AlreadyUpperCase()
        {
            Assert.AreEqual("PascalCase", "pascalCase".CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter()
        {
            Assert.AreEqual("Lower", "lower".CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestTruncateMiddle_ExactlyOneAndOne()
        {
            Assert.AreEqual("a...z", "abcd...xyz".TruncateMiddle(5));
        }

        [TestMethod]
        public void TestTruncateMiddle_TrailerIsOneLonger()
        {
            Assert.AreEqual("a...yz", "abcd...xyz".TruncateMiddle(6));
        }

        [TestMethod]
        public void TestTruncateMiddle_NoTruncationNeeded()
        {
            Assert.AreEqual("test", "test".TruncateMiddle(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTruncateMiddle_ChecksLengths()
        {
            "test".TruncateMiddle(3);
        }

        [TestMethod]
        public void Test_AppendLines()
        {
            var sb = new StringBuilder();
            var sb1 = sb.AppendLines(Enumerable.Repeat("test", 2));

            Assert.AreSame(sb, sb1);
            Assert.AreEqual("test{0}test{0}".FormatWith(Environment.NewLine), sb.ToString());
        }
    }
}

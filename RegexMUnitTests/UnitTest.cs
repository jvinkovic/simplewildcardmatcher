using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexM;

namespace RegexMUnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void NoSpecialCharSameLength()
        {
            Assert.IsTrue(Program.CheckMatch("aasdasdbc", "aasdasdbc"));
            Assert.IsFalse(Program.CheckMatch("aasdasmbc", "aasdasdbc"));
        }

        [TestMethod]
        public void Test1SpecialChar1()
        {
            Assert.IsFalse(Program.CheckMatch("fas", "a*"));
        }

        [TestMethod]
        public void Test1SpecialChar2()
        {
            Assert.IsTrue(Program.CheckMatch("abcd", "a*d"));
        }

        [TestMethod]
        public void Test1SpecialChar3()
        {
            Assert.IsTrue(Program.CheckMatch("abcd", "a*"));
        }

        [TestMethod]
        public void Test1SpecialChar4()
        {
            Assert.IsTrue(Program.CheckMatch("adadad", "a*d"));
        }

        [TestMethod]
        public void Test1SpecialChar5()
        {
            Assert.IsTrue(Program.CheckMatch("ad", "a*d"));
        }

        [TestMethod]
        public void Test1SpecialChar6()
        {
            Assert.IsTrue(Program.CheckMatch("adagds", "a*ds"));
        }

        [TestMethod]
        public void Test2SpecialChars1()
        {
            Assert.IsFalse(Program.CheckMatch("fasf", "a*f*"));
        }

        [TestMethod]
        public void Test2SpecialChars2()
        {
            Assert.IsFalse(Program.CheckMatch("adadad", "a*d*s"));
        }

        [TestMethod]
        public void Test2SpecialChars3()
        {
            Assert.IsFalse(Program.CheckMatch("adadads", "a*i*s"));
        }

        [TestMethod]
        public void Test2SpecialChars4()
        {
            Assert.IsTrue(Program.CheckMatch("asfa", "a*f*"));
        }

        [TestMethod]
        public void Test3SpecialCharsOnEnd()
        {
            Assert.IsTrue(Program.CheckMatch("afastala", "af***"));
        }

        [TestMethod]
        public void Test2SpecialChars5()
        {
            Assert.IsTrue(Program.CheckMatch("fasffasf", "f*f*f"));
        }

        [TestMethod]
        public void Test2SpecialChars6()
        {
            Assert.IsTrue(Program.CheckMatch("adadad", "a*d*"));
        }

        [TestMethod]
        public void Test2SpecialChars7()
        {
            Assert.IsTrue(Program.CheckMatch("adadads", "a*d*s"));
        }

        [TestMethod]
        public void NoSpecialCharDifferentLength()
        {
            Assert.IsFalse(Program.CheckMatch("abc", "abcd"));
            Assert.IsFalse(Program.CheckMatch("absd", "abc"));
        }

        [TestMethod]
        public void NullStrTest()
        {
            Assert.IsFalse(Program.CheckMatch(null, "a*"));
        }

        [TestMethod]
        public void NullPatternTest()
        {
            Assert.IsFalse(Program.CheckMatch("fas", null));
        }

        [TestMethod]
        public void BothNull()
        {
            Assert.IsTrue(Program.CheckMatch(null, null));
        }

        [TestMethod]
        public void ManyStars1()
        {
            Assert.IsTrue(Program.CheckMatch("adadaadaads", "a*a*a*s"));
        }

        [TestMethod]
        public void ManyStars2()
        {
            Assert.IsTrue(Program.CheckMatch("adadaadaads", "a*a*a*s"));
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스를생성할수있다()
        {
            var wordwwapper = new WordWrapper();
        }

        [TestMethod]
        public void 크기가작은한단어()
        {
            Assert.AreEqual("test", new WordWrapper().Wrap("test", 7));
        }

        [TestMethod]
        public void 크기가작은두단어()
        {
            Assert.AreEqual("hello--world", new WordWrapper().Wrap("hello world", 7));
        }

        [TestMethod]
        public void 크기가작은여러단어()
        {
            Assert.AreEqual("a lot of--words for--a single--line", new WordWrapper().Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void coloumn크기와같은단어가포함된여러단어()
        {
            Assert.AreEqual("this--is a--test", new WordWrapper().Wrap("this is a test", 4));
        }

        [TestMethod]
        public void coloumn크기보다큰단어가스페이스뒤에포함된두단어()
        {
            Assert.AreEqual("a long--word", new WordWrapper().Wrap("a longword", 6));
        }

        [TestMethod]
        public void coloumn크기보다큰단어가한단어()
        {
            Assert.AreEqual("areall--ylongw--ord", new WordWrapper().Wrap("areallylongword", 6));
        }

        [DataRow("word", "word", 6)]
        [DataRow("word", "word", 5)]
        [DataRow("word", "word", 4)]
        [DataRow("wor--d", "word", 3)]
        [DataRow("word--word", "word word", 4)]
        [DataRow("word--word", "word word", 5)]
        [DataRow("word--word", "word word", 7)]
        [DataRow("word word--word", "word word word", 10)]
        [DataRow("word word--word", "word word word", 12)]
        [DataRow("word--word--word", "word word word", 5)]
        [DataRow("a lot of--words", "a lot of words", 10)]
        [DataRow("a lot of--words for--a single", "a lot of words for a single", 10)]
        [DataTestMethod]
        public void 더많은단어(string Expected, string Given, int Length)
        {
            Assert.AreEqual(Expected, new WordWrapper().Wrap(Given, Length));
        }

        [DataRow("a[--a]aa", "a[ a]aa", 4)]
        [DataTestMethod]
        public void 인터넷(string Expected, string Given, int Length)
        {
            Assert.AreEqual(Expected, new WordWrapper().Wrap(Given, Length));
        }
    }
}

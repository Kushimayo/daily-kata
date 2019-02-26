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
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void 크기가_작은_한단어()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", new WordWrapper().Wrap("test", 7));
        }

        [TestMethod]
        public void 크기가_작은_두단어()
        {
            Assert.AreEqual("hello--world", new WordWrapper().Wrap("hello world", 7));
        }

        [TestMethod]
        public void 크기가_작은_여러단어()
        {
            Assert.AreEqual("a lot of--words for--a single--line", new WordWrapper().Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void col_size와_같은_크기가포함된_여러단어()
        {
            Assert.AreEqual("this--is a--test", new WordWrapper().Wrap("this is a test", 4));
        }

        [TestMethod]
        public void 스페이스이후_col_size_보다_크기가_큰_단어()
        {
            Assert.AreEqual("a long--word", new WordWrapper().Wrap("a longword", 6));
        }

        [TestMethod]
        public void col_size_보다_크기가_큰_한단어()
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
        [DataRow("a[[--a]aa", "a[[ a]aa", 4)]
        [DataTestMethod]
        public void 인터넷_실패케이스(string Expected, string Given, int Length)
        {
            Assert.AreEqual(Expected, new WordWrapper().Wrap(Given, Length));
        }
    }
}

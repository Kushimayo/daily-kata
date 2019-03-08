using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스를_생성할수있다()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void 크기가작은_한단어()
        {
            Assert.AreEqual("test", new WordWrapper().Wrap("test", 7));
        }

        [TestMethod]
        public void 크기가작은_두단어()
        {
            Assert.AreEqual("hello--world", new WordWrapper().Wrap("hello world", 7));
        }

        [TestMethod]
        public void 크기가작은_여러단어()
        {
            Assert.AreEqual("a lot of--words for--a single--line", new WordWrapper().Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void 크기가같은단어가_포함된_여러단어()
        {
            Assert.AreEqual("this--is a--test", new WordWrapper().Wrap("this is a test", 4));
        }

        [TestMethod]
        public void 스페이스뒤에크기가_큰_단어()
        {
            Assert.AreEqual("a long--word", new WordWrapper().Wrap("a longword", 6));
        }

        [TestMethod]
        public void 크기가_큰_한단어()
        {
            Assert.AreEqual("areall--ylongw--ord", new WordWrapper().Wrap("areallylongword", 6));
        }
    }
}

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
        public void col_크기보다작은한단어()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("test", wordWrapper.Wrap("test", 7));
        }

        [TestMethod]
        public void col_크기보다작은두단어()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("hello--world", wordWrapper.Wrap("hello world", 7));
        }

        [TestMethod]
        public void col_크기보다작은여러단어()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void col_크기와_같은단어포함()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("this--is a--test", wordWrapper.Wrap("this is a test", 4));
        }

        [TestMethod]
        public void col_크기보다큰단어가_스페이스뒤에_포함된_두단어()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("a long--word", wordWrapper.Wrap("a longword", 6));
        }

        [TestMethod]
        public void col_크기보다큰한단어()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("areall--ylongw--ord", wordWrapper.Wrap("areallylongword", 6));
        }
    }
}

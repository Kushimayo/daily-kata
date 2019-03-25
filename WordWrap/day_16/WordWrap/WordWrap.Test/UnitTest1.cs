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
            WordWrapper wordWrapper = new WordWrapper();
        }
        [TestMethod]
        public void 줄바꿈필요없는짧은단어()
        {
            Assert.AreEqual("test", new WordWrapper().Wrap("test", 7));
        }

        [TestMethod]
        public void 짧은두단어_스페이스단위로_Wrap()
        {
            Assert.AreEqual("hello--world", new WordWrapper().Wrap("hello world", 7));
        }

        [TestMethod]
        public void 짧은여러단어_스페이스단위로_Wrap()
        {
            Assert.AreEqual("a lot of--words for--a single--line", new WordWrapper().Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void limit와크기동일한단어_스페이스단위로_Wrap()
        {
            Assert.AreEqual("this--is a--test", new WordWrapper().Wrap("this is a test", 4));
        }

        [TestMethod]
        public void 스페이스뒤에_limit보다긴단어_단어중간에_Wrap()
        {
            Assert.AreEqual("a long--word", new WordWrapper().Wrap("a longword", 6));
        }

        [TestMethod]
        public void limit보다긴_한단어()
        {
            Assert.AreEqual("areall--ylongw--ord", new WordWrapper().Wrap("areallylongword", 6));
        }
    }
}

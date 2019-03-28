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
        public void 짧은단어는Wrap하지않아도된다()
        {
            Assert.AreEqual("test", new WordWrapper().Wrap("test", 7));
        }

        [TestMethod]
        public void 스페이스뒤에단어가_limit보다짧다면_스페이스를기준으로Wrap이된다()
        {
            Assert.AreEqual("Hello--World", new WordWrapper().Wrap("Hello World", 7));
        }

        [TestMethod]
        public void limit보다_짧은여러단어도_스페이스기준으로Wrap이된다()
        {
            Assert.AreEqual("a lot of--words for--a single--line", new WordWrapper().Wrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void limit길이와같은단어도_스페이스기준으로Wrap이된다()
        {
            Assert.AreEqual("this--is a--test", new WordWrapper().Wrap("this is a test", 4));
        }

        [TestMethod]
        public void limit길이보다긴단어가_스페이스뒤에있다면_limit기준으로Wrap이된다()
        {
            Assert.AreEqual("a long--word", new WordWrapper().Wrap("a longword", 6));
        }

        [TestMethod]
        public void limit길이보다긴한단어는_limit기준으로Wrap이된다()
        {
            Assert.AreEqual("areall--ylongw--ord", new WordWrapper().Wrap("areallylongword", 6));
        }
    }
}

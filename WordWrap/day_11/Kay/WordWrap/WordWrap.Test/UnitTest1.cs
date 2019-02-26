using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스생성()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void 크기가작은한단어()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.Wrap("test", 7));
        }

        [TestMethod]
        public void 크기가큰한단어()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("areall--ylongw--ord", wordWrapper.Wrap("areallylongword", 6));
        }
    }
}

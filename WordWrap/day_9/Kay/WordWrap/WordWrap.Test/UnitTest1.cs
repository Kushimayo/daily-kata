using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordWrapper인스턴스를_생성할수있다()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void col_크기가충분하면_주어진스트링이그대로반환된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void col_크기보다작은_두개의단어일경우_스페이스를기준으로Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void col_크기보다작은_여러개의단어일경우_스페이스를기준으로Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void col_크기와_동일한_크기의단어도Wrap이되며스페이스가제거된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

        [TestMethod]
        public void 스페이스이후_뒤의단어가_col_크기보다크다면_단어중간에서Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a long--word", wordWrapper.doWrap("a longword", 6));
        }

        [TestMethod]
        public void 한단어가_col_크기보다크다면_단어가Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("areall--ylongw--ord", wordWrapper.doWrap("areallylongword", 6));
        }
    }
}

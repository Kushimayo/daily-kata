using System;
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
        public void Coloumn_크기가_충분하다면_Wrap없이_string이리턴된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void 두개의_단어_중_두번째에_Coloumn이걸쳐있고_두번째단어가_Coloumn_크기보다작다면_space로_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void 여러단어의_긴단어라도_space를_기점으로_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void 한단어의크기가_Coloumn크기가같더라도_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

        [TestMethod]
        public void 두개의_단어중_두번째에_Coloumn이걸쳐있고_두번째단어가_Coloumn_크기보다_크다면_두번째단어에서Wrap_된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a long--word", wordWrapper.doWrap("a longword", 6));
        }

        [TestMethod]
        public void 하나의단어가_Coloumn크기보다크다면_단어가Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("areall--ylongw--ord", wordWrapper.doWrap("areallylongword", 6));
        }
    }
}

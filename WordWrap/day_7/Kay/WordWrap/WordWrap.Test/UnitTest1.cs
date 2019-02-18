using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordWrapper_인스턴스를_생성할수있다()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void Coloumn_size가충분하다면_Wrap되지않는다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void Wrod가_긴경우_두개의단어는_space_로_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void Wrod가_한줄로긴경우_여러단어는_coloumn크기에따라_space_로_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void 한_단어가_coloumn크기와같을때도_Wrap이_정상동작한다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

        [TestMethod]
        public void 스페이스이후한_단어가_coloumn크기보다클때단어중간이_Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a long--word", wordWrapper.doWrap("a longword", 6));
        }

        [TestMethod]
        public void 한단어가_Colomn크기보다크면_단어가Wrap된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("areall--ylongw--ord", wordWrapper.doWrap("areallylongword", 6));
        }
    }
}

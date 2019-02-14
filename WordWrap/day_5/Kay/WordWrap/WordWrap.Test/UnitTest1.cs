using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordWrapper의_인스턴스를_생성할수있다()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void Coloumn크기가_word보다클때에는_doWrap시_word가_반환된다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void 두개의단어중_두번째단어보다_coloumn크기가작다면_두번째단어는_Wrap되어야한다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void 한줄에많은단어가있는상태로_Wrap_되어야한다()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void 이건_테스트_문제_()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

    }
}

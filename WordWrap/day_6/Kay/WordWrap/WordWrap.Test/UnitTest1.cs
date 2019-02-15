using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordWrapper클래스_인스턴스를_생성할수있다()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void 가로행크기가_충분하다면_Word_Wrap하지_않는다()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void Wrap이필요한경우_스페이스_포함_뒤에_단어는_coloumn_size보다작다면_스페이스를_기준으로_Wrap한다()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void 한줄에_coloumn_size보다작은단어가_많이_포함되어있어도_Wrap되어야한다()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void 한단어의크기가_coloumn_size와같다면_해당단어끝에서_Wrap_되어야한다()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

        [TestMethod]
        public void 한단어의크기가_coloumn_size_보다클때_앞에스페이스바가있더라도_단어중간을_Wrap한다()
        {
            var wordWrapper = new WordWrapper();

            Assert.AreEqual("a long--word", wordWrapper.doWrap("a longword", 6));
        }
    }
}

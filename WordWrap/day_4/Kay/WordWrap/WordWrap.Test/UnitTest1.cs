using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Create_WordWrapper_Instance()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void doWrap_return_given_string_if_string_short_then_coloumn_size()
        {
            var wordWrapper = new WordWrapper();
            string actualString = wordWrapper.doWrap("test", 7);

            Assert.IsTrue(actualString.Equals("test"));
        }

        [TestMethod]
        public void if_string_longger_then_coloumn_size_word_shoud_Wrap_two_word_with_space()
        {
            var wordWrapper = new WordWrapper();
            string actualString = wordWrapper.doWrap("hello world", 7);

            Assert.IsTrue(actualString.Equals("hello--world"));
        }

        [TestMethod]
        public void 한줄에_스페이스가_많이포함된_긴문장을_Wrap_할수있다()
        {
            var wordWrapper = new WordWrapper();
            string actualString = wordWrapper.doWrap("a lot of words for a single line", 10);

            Assert.IsTrue(actualString.Equals("a lot of--words for--a single--line"));
        }
    }
}

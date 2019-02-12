using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Create_WordWrap_Instance()
        {
            var wordWrap = new WordWrapper();
        }

        [TestMethod]
        public void input_empty_string_doWrap_Method_return_empty_string()
        {
            var wordWrap = new WordWrapper();
            string result = wordWrap.doWrap("", 5);
            Assert.IsTrue(result.Equals(""));
        }

        [TestMethod]
        public void input_one_less_word_then_col_size_return_input_word()
        {
            var wordWrap = new WordWrapper();
            string given_word = "test";
            string result = wordWrap.doWrap(given_word, 7);
            Assert.IsTrue(result.Equals(given_word));
        }

        [TestMethod]
        public void input_two_word_longger_col_size_return_wordwrap_word()
        {
            var wordWrap = new WordWrapper();
            string expect_word = "hello--world";
            string result = wordWrap.doWrap("hello world", 7);
            Assert.IsTrue(result.Equals(expect_word));
        }
    }
}

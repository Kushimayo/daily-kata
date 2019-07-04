using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReqularExpression.Test
{
    [TestClass]
    public class UnitTest1
    {
        private REMatcher matcher;
        [TestInitialize]
        public void Initialize()
        {
            matcher = new REMatcher();
        }

        [TestMethod]
        public void aa_not_match_with_a()
        {
            Assert.IsFalse(matcher.IsMatch("aa", "a"));
        }

        [TestMethod]
        public void aa_match_with_a_star()
        {
            Assert.IsTrue(matcher.IsMatch("aa", "a*"));
        }

        [TestMethod]
        public void ab_matched_point_with_star()
        {
            Assert.AreEqual(true, matcher.IsMatch("ab", ".*"));
        }

        [TestMethod]
        public void p_with_star_can_not_exist()
        {
            Assert.AreEqual(true, matcher.IsMatch("aab", "c*a*b"));
        }

        [TestMethod]
        public void Example_5()
        {
            Assert.AreEqual(false, matcher.IsMatch("mississippi", "mis*is*p*."));
        }

        [TestMethod]
        public void Example_5_true_condition()
        {
            Assert.AreEqual(true, matcher.IsMatch("mississippi", "mis*is*ip*."));
        }

        [TestMethod]
        public void pattern_is_too_long()
        {
            Assert.AreEqual(false, matcher.IsMatch("aabbcc", "a*b*c*d"));
        }

        [TestMethod]
        public void empty_string()
        {
            Assert.AreEqual(true, matcher.IsMatch("", ".*"));
        }

        [TestMethod]
        public void same_string_with_pattern()
        {
            Assert.AreEqual(true, matcher.IsMatch("aaa", "a*a"));
        }

        [TestMethod]
        public void extra()
        {
            Assert.AreEqual(false, matcher.IsMatch("abcd", "d*"));
        }

        [TestMethod]
        public void extra2()
        {
            Assert.AreEqual(true, matcher.IsMatch("ab", ".*.."));
        }

        [TestMethod]
        public void extra3()
        {
            Assert.AreEqual(true, matcher.IsMatch("ab", ".*..c*"));
        }

        [TestMethod]
        public void extra4()
        {
            Assert.AreEqual(true, matcher.IsMatch("aasdfasdfasdfasdfas", "aasdf.*asdf.*asdf.*asdf.*s"));
        }
    }
}

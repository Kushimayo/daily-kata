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
        public void aa_not_match_with_just_a()
        {
            Assert.AreEqual(false, matcher.IsMatch("aa", "a"));
        }

        [TestMethod]
        public void aa_matched_a_string_with_star()
        {
            Assert.AreEqual(true, matcher.IsMatch("aa", "a*"));
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
    }
}

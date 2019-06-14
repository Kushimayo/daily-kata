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
            Assert.AreEqual(false, matcher.isMatch("aa", "a"));
        }

        [TestMethod]
        public void aa_matched_with_a_with_star()
        {
            Assert.AreEqual(true, matcher.isMatch("aa", "a*"));
        }
    }
}

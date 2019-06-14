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
        public void aa_not_match_with_patern_just_a()
        {
            Assert.AreEqual(false, matcher.IsMatch("aa", "a"));
        }
    }
}

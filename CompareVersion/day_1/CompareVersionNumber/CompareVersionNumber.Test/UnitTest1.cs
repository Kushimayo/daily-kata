using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompareVersionNumber.Test
{
    [TestClass]
    public class UnitTest1
    {
        private VersionManager vManager;
        [TestInitialize]
        public void Initialize()
        {
            vManager = new VersionManager();
        }

        [TestMethod]
        public void 한자리숫자의버전을비교할수있다_동일()
        {
            Assert.AreEqual(0, vManager.CompareVersion("1", "1"));
        }

        [TestMethod]
        public void 한자리숫자의버전을비교할수있다_왼쪽큼()
        {
            Assert.AreEqual(1, vManager.CompareVersion("2", "1"));
        }

        [TestMethod]
        public void 한자리숫자의버전을비교할수있다_오른쪽큼()
        {
            Assert.AreEqual(-1, vManager.CompareVersion("1", "2"));
        }

        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(-1, vManager.CompareVersion("0.1", "1.1"));
        }
    }
}

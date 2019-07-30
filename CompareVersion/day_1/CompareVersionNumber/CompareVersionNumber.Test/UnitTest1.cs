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
        public void ���ڸ������ǹ��������Ҽ��ִ�_����()
        {
            Assert.AreEqual(0, vManager.CompareVersion("1", "1"));
        }

        [TestMethod]
        public void ���ڸ������ǹ��������Ҽ��ִ�_����ŭ()
        {
            Assert.AreEqual(1, vManager.CompareVersion("2", "1"));
        }

        [TestMethod]
        public void ���ڸ������ǹ��������Ҽ��ִ�_������ŭ()
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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompareVersion.Test
{
    [TestClass]
    public class UnitTest1
    {
        private VersionManager vm;
        [TestInitialize]
        public void Initialize()
        {
            vm = new VersionManager();
        }

        [TestMethod]
        [DataRow("1", "2", -1, DisplayName = "���ڸ���������")]
        [DataRow("2", "1", 1, DisplayName = "���ڸ���������2")]
        [DataRow("1", "1", 0, DisplayName = "���ڸ���������3")]
        [DataRow("1.0", "1.1", -1, DisplayName = "���ڸ���������")]
        [DataRow("1.1", "1.0", 1, DisplayName = "���ڸ���������2")]
        [DataRow("1.0", "1.0", 0, DisplayName = "���ڸ���������3")]
        [DataRow("1.0.0", "1.1", -1, DisplayName = "�ٸ��ڸ���������")]
        [DataRow("7.5.2.3", "7.5.4", -1, DisplayName = "�ٸ��ڸ���������2")]
        [DataRow("1.0.0", "1.01", -1, DisplayName = "�ٸ��ڸ���������3")]
        [DataRow("1.01", "1.001", 0, DisplayName = "�ٸ��ڸ���������4")]
        [DataRow("1.0.0", "1.0.0.0", 0, DisplayName = "�ٸ��ڸ���������4")]
        public void TestMethod1(string version1, string version2, int expected)
        {
            Assert.AreEqual(expected, vm.CompareVersion(version1, version2));
        }
    }
}

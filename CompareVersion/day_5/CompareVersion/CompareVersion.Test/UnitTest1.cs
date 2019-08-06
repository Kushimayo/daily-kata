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
        [DataRow("1.0", "1.1", -1, DisplayName = "�ڿ���ū���ڸ�")]
        [DataRow("1.1", "1.0", 1, DisplayName = "�ڿ����������ڸ�")]
        [DataRow("1.0", "1.0", 0, DisplayName = "�������ڸ�")]
        [DataRow("1.0.1", "1", 1, DisplayName = "�ڸ������ٸ�����")]
        [DataRow("7.5.2.3", "7.5.3", -1, DisplayName = "�ڸ������ٸ�����2")]
        [DataRow("1.01", "1.1", 0, DisplayName = "�Ѱ����ߺ�")]
        [DataRow("1.01", "1.001", 0, DisplayName = "�Ѱ����ߺ�2")]
        [DataRow("1.0.0", "1.0.0.0", 0, DisplayName = "�ڸ������ٸ����Ϲ���")]
        public void TestSet(string version1, string version2, int expected)
        {
            Assert.AreEqual(expected, vm.CompareVersion(version1, version2));
        }
    }
}

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
        [DataRow("1.0", "1.1", -1, DisplayName = "뒤에가큰두자리")]
        [DataRow("1.1", "1.0", 1, DisplayName = "뒤에가작은두자리")]
        [DataRow("1.0", "1.0", 0, DisplayName = "같은두자리")]
        [DataRow("1.0.1", "1", 1, DisplayName = "자리수가다른버전")]
        [DataRow("7.5.2.3", "7.5.3", -1, DisplayName = "자리수가다른버전2")]
        [DataRow("1.01", "1.1", 0, DisplayName = "한곳이중복")]
        [DataRow("1.01", "1.001", 0, DisplayName = "한곳이중복2")]
        [DataRow("1.0.0", "1.0.0.0", 0, DisplayName = "자리수가다른동일버전")]
        public void TestSet(string version1, string version2, int expected)
        {
            Assert.AreEqual(expected, vm.CompareVersion(version1, version2));
        }
    }
}

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
        [DataRow("1", "2", -1, DisplayName = "한자리수버전비교")]
        [DataRow("2", "1", 1, DisplayName = "한자리수버전비교2")]
        [DataRow("1", "1", 0, DisplayName = "한자리수버전비교3")]
        [DataRow("1.0", "1.1", -1, DisplayName = "두자리수버전비교")]
        [DataRow("1.1", "1.0", 1, DisplayName = "두자리수버전비교2")]
        [DataRow("1.0", "1.0", 0, DisplayName = "두자리수버전비교3")]
        [DataRow("1.0.0", "1.1", -1, DisplayName = "다른자리수버전비교")]
        [DataRow("7.5.2.3", "7.5.4", -1, DisplayName = "다른자리수버전비교2")]
        [DataRow("1.0.0", "1.01", -1, DisplayName = "다른자리수버전비교3")]
        [DataRow("1.01", "1.001", 0, DisplayName = "다른자리수버전비교4")]
        [DataRow("1.0.0", "1.0.0.0", 0, DisplayName = "다른자리수버전비교4")]
        public void TestMethod1(string version1, string version2, int expected)
        {
            Assert.AreEqual(expected, vm.CompareVersion(version1, version2));
        }
    }
}

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
        public void Example1()
        {
            Assert.AreEqual(-1, vm.CompareVersion("0.1", "1.1"));
        }
        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(1, vm.CompareVersion("1.0.1", "1"));
        }
        [TestMethod]
        public void Example3()
        {
            Assert.AreEqual(-1, vm.CompareVersion("7.5.2.4", "7.5.3"));
        }
        [TestMethod]
        public void Example4()
        {
            Assert.AreEqual(0, vm.CompareVersion("1.01", "1.001"));
        }
        [TestMethod]
        public void Example5()
        {
            Assert.AreEqual(0, vm.CompareVersion("1.0", "1.0.0"));
        }
    }
}

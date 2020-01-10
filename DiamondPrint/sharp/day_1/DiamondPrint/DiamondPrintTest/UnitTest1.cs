using DiamondPrint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondPrintTest
{
    [TestClass]
    public class UnitTest1
    {
        Solution sol;
        
        [TestInitialize]
        public void Initialize()
        {
            sol = new Solution();
        }

        [TestMethod]
        public void Test_GetDepth()
        {
            char given = 'C';
            Assert.AreEqual(2, sol.GetDepth(given));
        }

        [TestMethod]
        public void Test_GetDepth2()
        {
            char given = 'c';
            Assert.AreEqual(2, sol.GetDepth(given));
        }

        [TestMethod]
        public void Step2Diamond()
        {
            char given = 'b';
            string expect = " A\n" +
                            "B B\n" +
                            " A";
            string actual = sol.GetDiamondString(given);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Step3Diamond()
        {
            char given = 'C';
            string expect = "  A\n" +
                            " B B\n" +
                            "C   C\n" +
                            " B B\n" +
                            "  A";
            string actual = sol.GetDiamondString(given);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Step4Diamond()
        {
            char given = 'D';
            string expect = "   A\n" +
                            "  B B\n" +
                            " C   C\n" +
                            "D     D\n" +
                            " C   C\n" +
                            "  B B\n" +
                            "   A";
            string actual = sol.GetDiamondString(given);
            Assert.AreEqual(expect, actual);
        }
    }
}

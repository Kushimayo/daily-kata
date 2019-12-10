using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxAreaOfIsland.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스생성()
        {
            Area area = new Area();
        }

        [TestMethod]
        public void 모두0일경우0()
        {
            Area area = new Area();
            int[][] grid = new int[1][];
            grid[0] = new int[] { 0, 0, 0, 0 };
            Assert.AreEqual(0, area.MaxAreaOfIsland(grid));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegionsCut.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void create_instance()
        {
            Regions regions = new Regions();
        }

        [TestMethod]
        public void get_Region_size_with_1()
        {
            Regions regions = new Regions();
            string[] grid = new string[1];
            grid[0] = " ";
            Assert.AreEqual(1, regions.RegionsBySlashes(grid));
        }

        [TestMethod]
        public void get_Region_size_with_2()
        {
            Regions regions = new Regions();
            string[] grid = new string[1];
            grid[0] = "\\";
            Assert.AreEqual(2, regions.RegionsBySlashes(grid));
        }

        [TestMethod]
        public void get_Region_size_with_3()
        {
            Regions regions = new Regions();
            string[] grid = new string[1];
            grid[0] = "/";
            Assert.AreEqual(2, regions.RegionsBySlashes(grid));
        }

        [TestMethod]
        public void example_5()
        {
            Regions regions = new Regions();
            string[] grid = new string[2];
            grid[0] = "//";
            grid[1] = "/ ";
            Assert.AreEqual(3, regions.RegionsBySlashes(grid));
        }
    }
}

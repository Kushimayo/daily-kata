using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalancedTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Solution solution;

        [TestInitialize]
        public void Initialize()
        {
            solution = new Solution();
        }

        [TestMethod]
        public void nullTree()
        {
            TreeNode root = null;
            Assert.AreEqual(true, solution.IsBalanced(root));
        }
    }
}

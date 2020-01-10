using InvertBTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvertBtree.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Solution sol;
        [TestInitialize]
        public void Initialzie()
        {
            sol = new Solution();
        }

        [TestMethod]
        public void nullTree()
        {
            TreeNode root = null;
            Assert.AreEqual(null, sol.InvertTree(root));
        }

        [TestMethod]
        public void oneTree()
        {
            TreeNode root = new TreeNode(1);
            TreeNode actual = sol.InvertTree(root);
            Assert.AreEqual(1, actual.val);
        }

        [TestMethod]
        public void twoTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            TreeNode actual = sol.InvertTree(root);
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.right.val);
            Assert.AreEqual(3, actual.left.val);
        }
    }
}

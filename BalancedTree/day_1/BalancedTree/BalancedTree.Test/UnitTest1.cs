using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalancedTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        private BinaryTree bTree;
        [TestInitialize]
        public void Initialize()
        {
            bTree = new BinaryTree();
        }

        [TestMethod]
        public void nullTree()
        {
            TreeNode root = null;
            bool result = bTree.IsBalanced(root);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void BalancedTree()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            Assert.AreEqual(true, bTree.IsBalanced(root));
        }

        [TestMethod]
        public void BalancedTree2()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(3);
            root.left.left.left = new TreeNode(4);
            root.left.left.right = new TreeNode(4);
            root.left.right.left = new TreeNode(4);
            root.left.right.right = new TreeNode(4);
            root.right.left.left = new TreeNode(4);
            root.right.left.right = new TreeNode(4);
            root.left.left.left.left = new TreeNode(5);
            root.left.left.left.right = new TreeNode(5);


            Assert.AreEqual(true, bTree.IsBalanced(root));
        }
    }
}

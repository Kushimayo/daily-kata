using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxDepthTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateInstance()
        {
            BinaryTree bTree = new BinaryTree();
        }

        [TestMethod]
        public void EmptyTreeReturn_0()
        {
            BinaryTree bTree = new BinaryTree();
            Assert.AreEqual(0, bTree.MaxDepth(null));
        }

        [TestMethod]
        public void onlyrootTree_return_1()
        {
            TreeNode root = new TreeNode(1);
            root.left = null;
            root.right = null;
            BinaryTree bTree = new BinaryTree();
            Assert.AreEqual(1, bTree.MaxDepth(root));
        }

        [TestMethod]
        public void example()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.left.left = null;
            root.left.right = null;
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            root.right.left.left = null;
            root.right.left.right = null;
            root.right.right.left = null;
            root.right.right.right = null;

            BinaryTree bTree = new BinaryTree();
            Assert.AreEqual(3, bTree.MaxDepth(root));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncreasingTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void create_instance()
        {
            BinaryTree bTree = new BinaryTree();
        }

        [TestMethod]
        public void noNode_return_noNode()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = null;

            Assert.AreEqual(null, bTree.IncreasingBST(root));
        }

        [TestMethod]
        public void oneNode_return_oneNode()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = new TreeNode(1);
            root.left = null;
            root.right = null;

            TreeNode actualNode = bTree.IncreasingBST(root);
            Assert.AreEqual(root.val, actualNode.val);
            Assert.AreEqual(root.left, actualNode.left);
            Assert.AreEqual(root.right, actualNode.right);
        }

        [TestMethod]
        public void three_return_onerightNode()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(1);
            root.left.left = null;
            root.left.right = null;
            root.right.left = null;
            root.right.right = null;

            TreeNode actualNode = bTree.IncreasingBST(root);
            Assert.AreEqual(2, actualNode.val);
            Assert.AreEqual(null, actualNode.left);
            Assert.AreEqual(4, actualNode.right.val);
            Assert.AreEqual(null, actualNode.right.left);
            Assert.AreEqual(1, actualNode.right.right.val);
        }

        [TestMethod]
        public void four_return_onerightNode()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = new TreeNode(4);
            root.left = null;
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(1);
            root.right.right = new TreeNode(3);
            root.right.left.left = null;
            root.right.left.right = null;
            root.right.right.left = null;
            root.right.right.right = null;

            TreeNode actualNode = bTree.IncreasingBST(root);
            Assert.AreEqual(4, actualNode.val);
            Assert.AreEqual(null, actualNode.left);
            Assert.AreEqual(1, actualNode.right.val);
            Assert.AreEqual(null, actualNode.right.left);
            Assert.AreEqual(2, actualNode.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.left);
            Assert.AreEqual(3, actualNode.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.left);
        }

        [TestMethod]
        public void four_return_onerightNode_2()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(5);
            root.right.left = null;
            root.right.right = null;
            root.left.left.left = null;
            root.left.left.right = null;
            root.left.right.left = null;
            root.left.right.right = null;

            TreeNode actualNode = bTree.IncreasingBST(root);
            Assert.AreEqual(3, actualNode.val);
            Assert.AreEqual(null, actualNode.left);
            Assert.AreEqual(2, actualNode.right.val);
            Assert.AreEqual(null, actualNode.right.left);
            Assert.AreEqual(5, actualNode.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.left);
            Assert.AreEqual(4, actualNode.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.left);
            Assert.AreEqual(1, actualNode.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.left);
        }

        [TestMethod]
        public void example()
        {
            BinaryTree bTree = new BinaryTree();
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.left = null;
            root.right.right = new TreeNode(8);
            root.left.left.left = new TreeNode(1);
            root.left.left.right = null;
            root.right.right.left = new TreeNode(7);
            root.right.right.right = new TreeNode(9);
            root.left.left.left.left = null;
            root.left.left.left.right = null;
            root.right.right.left.left = null;
            root.right.right.left.right = null;
            root.right.right.right.left = null;
            root.right.right.right.right = null;

            TreeNode actualNode = bTree.IncreasingBST(root);
            Assert.AreEqual(1, actualNode.val);
            Assert.AreEqual(null, actualNode.left);
            Assert.AreEqual(2, actualNode.right.val);
            Assert.AreEqual(null, actualNode.right.left);
            Assert.AreEqual(3, actualNode.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.left);
            Assert.AreEqual(4, actualNode.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.left);
            Assert.AreEqual(5, actualNode.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.left);
            Assert.AreEqual(6, actualNode.right.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.right.left);
            Assert.AreEqual(7, actualNode.right.right.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.right.right.left);
            Assert.AreEqual(8, actualNode.right.right.right.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.right.right.right.left);
            Assert.AreEqual(9, actualNode.right.right.right.right.right.right.right.right.val);
            Assert.AreEqual(null, actualNode.right.right.right.right.right.right.right.right.left);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxBinaryTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스를_만들수있다()
        {
            BinaryTree bTree = new BinaryTree();
        }

        [TestMethod]
        public void TreeNode인스턴스를_만들수있다()
        {
            TreeNode node = new TreeNode(3);
            Assert.AreEqual(3, node.val);
        }

        [TestMethod]
        public void 한개의숫자를넣었을때_BinaryTree가_return된다()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
        }

        [TestMethod]
        public void 두개의숫자를넣었을때_큰숫자의BinaryTree가_return된다()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
        }

        [TestMethod]
        public void 세개의숫자를넣었을때_큰숫자의BinaryTree가_return된다()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = {7, 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(7, node.val);
        }

        [TestMethod]
        public void 두개의숫자를넣었을때_큰숫자의BinaryTree가_return된다2()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
            Assert.AreEqual(3, node.left.val);
        }

        [TestMethod]
        public void 인터넷문제()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 3, 2, 1, 6, 0, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(6, node.val);
            Assert.AreEqual(3, node.left.val);
            Assert.AreEqual(2, node.left.right.val);
            Assert.AreEqual(1, node.left.right.right.val);
            Assert.AreEqual(5, node.right.val);
            Assert.AreEqual(0, node.right.left.val);
        }
    }
}

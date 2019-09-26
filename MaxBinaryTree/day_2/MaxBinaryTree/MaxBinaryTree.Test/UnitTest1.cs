using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxBinaryTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void �ν��Ͻ���_������ִ�()
        {
            BinaryTree bTree = new BinaryTree();
        }

        [TestMethod]
        public void TreeNode�ν��Ͻ���_������ִ�()
        {
            TreeNode node = new TreeNode(3);
            Assert.AreEqual(3, node.val);
        }

        [TestMethod]
        public void �Ѱ��Ǽ��ڸ��־�����_BinaryTree��_return�ȴ�()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
        }

        [TestMethod]
        public void �ΰ��Ǽ��ڸ��־�����_ū������BinaryTree��_return�ȴ�()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
        }

        [TestMethod]
        public void �����Ǽ��ڸ��־�����_ū������BinaryTree��_return�ȴ�()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = {7, 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(7, node.val);
        }

        [TestMethod]
        public void �ΰ��Ǽ��ڸ��־�����_ū������BinaryTree��_return�ȴ�2()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 3, 5 };
            TreeNode node = bTree.ConstructMaximumBinaryTree(nums);
            Assert.AreEqual(5, node.val);
            Assert.AreEqual(3, node.left.val);
        }

        [TestMethod]
        public void ���ͳݹ���()
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

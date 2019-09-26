using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxBinaryTree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void �ν��Ͻ�_�����Ҽ��ִ�()
        {
            BinaryTree bTree = new BinaryTree();
        }

        [TestMethod]
        public void array��_����ū������_�ε�����_���Ҽ��ִ�()
        {
            BinaryTree bTree = new BinaryTree();
            int[] nums = { 1, 2, 3 };
            int index = bTree.GetMaximumNumberIndex(0, nums.Length, nums);
            Assert.AreEqual(2, index);
            Assert.AreEqual(3, nums[index]);
        }

        [TestMethod]
        public void TreeNode�ν��Ͻ�_�����Ҽ��ִ�()
        {
            TreeNode node = new TreeNode(4);
            Assert.AreEqual(4, node.val);
        }

        [TestMethod]
        public void Maximum_binary_tree���������ִ�()
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

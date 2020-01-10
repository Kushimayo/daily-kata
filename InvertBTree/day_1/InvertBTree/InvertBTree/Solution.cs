using System;

namespace InvertBTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public Solution()
        {
        }

        public TreeNode InvertTree(TreeNode root)
        {
            return InvertTreeNode(root);
        }

        private TreeNode InvertTreeNode(TreeNode node)
        {
            if (node == null)
                return null;

            TreeNode rootNode = new TreeNode(node.val);
            rootNode.right = InvertTreeNode(node.left);
            rootNode.left = InvertTreeNode(node.right);

            return rootNode;
        }
    }
}
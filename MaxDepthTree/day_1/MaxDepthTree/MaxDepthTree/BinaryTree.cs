using System;

namespace MaxDepthTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class BinaryTree
    {
        public BinaryTree()
        {
        }

        public int MaxDepth(TreeNode root)
        {
            return SearchMaxDepth(root);
        }
        
        private int SearchMaxDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            int rightNode = SearchMaxDepth(node.right);
            int leftNode = SearchMaxDepth(node.left);

            return 1 + (rightNode > leftNode ? rightNode : leftNode);
        }
    }
}
using System;

namespace BalancedTree
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
        public bool IsBalanced(TreeNode root)
        {
            int max;
            return SearchTree(root, out max);
        }

        private bool SearchTree(TreeNode node, out int MaxDepth)
        {
            if (node == null)
            {
                MaxDepth = 0;
                return true;
            }

            int leftDepth = 0;
            int rightDepth = 0;
            bool leftResult = SearchTree(node.left, out leftDepth);
            bool rightResult = SearchTree(node.right, out rightDepth);

            int MaxDepthOfNode = leftDepth > rightDepth ? leftDepth : rightDepth;
            MaxDepth = MaxDepthOfNode++;

            return leftResult && rightResult &&
                ((leftDepth > rightDepth) ? ((leftDepth - rightDepth) < 2) : (rightDepth - leftDepth) < 2);
        }
    }
}
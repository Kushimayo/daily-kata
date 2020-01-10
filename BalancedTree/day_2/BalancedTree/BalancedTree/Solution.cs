namespace BalancedTree
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

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            return false;
        }
    }
}
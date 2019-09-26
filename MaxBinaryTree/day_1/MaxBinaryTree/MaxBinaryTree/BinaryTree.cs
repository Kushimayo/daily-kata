using System;

namespace MaxBinaryTree
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

        public int GetMaximumNumberIndex(int start, int endindex, int[] nums)
        {
            int maxNum = -1;
            int index = -1;
            for (int i = start; i < endindex; i++)
            {
                if(maxNum < nums[i])
                {
                    maxNum = nums[i];
                    index = i;
                }
            }

            return index;
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTreeWithRange(0, nums.Length, nums);
        }
        
        private TreeNode ConstructMaximumBinaryTreeWithRange(int startindex, int endindex, int[] nums)
        {
            if (startindex == endindex)
                return null;
            int maxindex = GetMaximumNumberIndex(startindex, endindex, nums);
            TreeNode root = new TreeNode(nums[maxindex]);
            root.left = ConstructMaximumBinaryTreeWithRange(startindex, maxindex, nums);
            root.right = ConstructMaximumBinaryTreeWithRange(maxindex + 1, endindex, nums);

            return root;
        }
    }
}
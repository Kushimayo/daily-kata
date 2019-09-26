using System;

namespace MaxBinaryTree
{
    public class BinaryTree
    {
        public BinaryTree()
        {
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTreeWithIndex(0, nums.Length, nums);
        }

        public TreeNode ConstructMaximumBinaryTreeWithIndex(int start, int end, int[] nums)
        {
            if (start == end)
                return null;
            int maxIndex = GetMaximumNumberIndex(start, end, nums);
            TreeNode node = new TreeNode(nums[maxIndex]);
            node.left = ConstructMaximumBinaryTreeWithIndex(start, maxIndex, nums);
            node.right = ConstructMaximumBinaryTreeWithIndex(maxIndex+1, end, nums);

            return node;
        }

        public int GetMaximumNumberIndex(int start, int end, int[] nums)
        {
            int maxnumIndex = start;
            for (int i = start; i < end; i++)
            {
                if (nums[maxnumIndex] < nums[i])
                {
                    maxnumIndex = i;
                }
            }

            return maxnumIndex;
        }
    }
}
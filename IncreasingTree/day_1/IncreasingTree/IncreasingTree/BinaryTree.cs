using System;
using System.Collections;

namespace IncreasingTree
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

        //public TreeNode IncreasingBST(TreeNode root)
        //{
        //    ArrayList list = new ArrayList();
        //    TreeValueToList(root, list);
        //    list.Sort();

        //    return CreateTreeNode(list);
        //}
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null)
                return null;

            return  reOrderTree(root);            
        }

        private TreeNode reOrderTree(TreeNode node)
        {
            TreeNode newNode = new TreeNode(node.val);

            if (node.right != null)
            {
                TreeNode rightNode = reOrderTree(node.right);
                newNode.right = rightNode;
            }

            if (node.left != null)
            {
                TreeNode leftNode = reOrderTree(node.left);
                TreeNode endRight = leftNode;
                while(endRight.right != null)
                {
                    endRight = endRight.right;
                }
                endRight.left = null;
                endRight.right = newNode;
                newNode = leftNode;
            }

            return newNode;
        }

        private TreeNode CreateTreeNode(ArrayList list)
        {
            if (list.Count < 1)
                return null;

            TreeNode root = new TreeNode((int)list[0]);
            TreeNode prev = root;
            for (int i = 1; i < list.Count; i++)
            {
                TreeNode node = new TreeNode((int)list[i]);
                prev.left = null;
                prev.right = node;
                prev = node;
            }

            return root;
        }

        private void TreeValueToList(TreeNode node, ArrayList list)
        {
            if (node == null)
                return;
            list.Add(node.val);
            TreeValueToList(node.left, list);
            TreeValueToList(node.right, list);
        }
    }
}
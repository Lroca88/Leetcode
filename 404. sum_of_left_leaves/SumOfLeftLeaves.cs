/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class SumLeftLeaves {

    private int GetSum(TreeNode node, bool isLeftNode) {
        if (node == null) return 0;
        if (isLeftNode && node.right == null && node.left == null) 
            return node.val;
        return GetSum(node.left, true) + GetSum(node.right, false);
        
    }
    
    public int SumOfLeftLeaves(TreeNode root) {
        return GetSum(root, false);
    }

/**
 * Definition for a binary tree node.
 */
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

/**

Find the sum of all left leaves in a given binary tree.

Example:

    3
   / \
  9  20
    /  \
   15   7

There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.

*/
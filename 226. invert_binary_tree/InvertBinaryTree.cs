

public class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return root;
        TreeNode left = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);
        var temp = left;
        root.left = root.right;
        root.right = temp;
        return root;
    }

    // Definition for a binary tree node.
    public class ITreeNode
    {
        public int val;
        public ITreeNode left;
        public ITreeNode right;
        public ITreeNode(int val = 0, ITreeNode left = null, ITreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

/**

Invert a binary tree.

Example:

Input:

     4
   /   \
  2     7
 / \   / \
1   3 6   9


Output:

     4
   /   \
  7     2
 / \   / \
9   6 3   1


Trivia:
This problem was inspired by this original tweet by Max Howell:

Google: 90% of our engineers use the software you wrote (Homebrew), but you can’t invert a binary tree on a whiteboard so f*** off.

*/
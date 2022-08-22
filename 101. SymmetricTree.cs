using System.Collections.Generic;

public class Solution {
    private bool IsSymmetric(TreeNode a, TreeNode b) {
        if (a == null && b == null) return true;
        if (a == null || b == null && a != b) return false;
        return a.val == b.val && IsSymmetric(a.left, b.right) && IsSymmetric(a.right, b.left);
    }
    
    public bool IsSymmetric(TreeNode root) {
        if (root != null)
            return IsSymmetric(root.left, root.right);
        return true;
    }

    //---------- Iterative Solution ---------------//
    public bool IsSymmetricIterative(TreeNode root) {
        if (root == null) return true;
        
        Stack<TreeNode> s = new Stack<TreeNode>();
        s.Push(root.left);
        s.Push(root.right);
        
        
        while(s.Count > 0) {
            TreeNode b = s.Pop();
            TreeNode a = s.Pop();
            if (a != null && b != null && a.val == b.val) {
                s.Push(a.left);
                s.Push(b.right);
                s.Push(a.right);
                s.Push(b.left);
                continue;
            }
            
            if (a == null && b == null) continue;
            
            return false;
        }
        
        return true;
    }
}

/**

Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
 

But the following [1,2,2,null,3,null,3] is not:

    1
   / \
  2   2
   \   \
   3    3
 

Follow up: Solve it both recursively and iteratively.

*/
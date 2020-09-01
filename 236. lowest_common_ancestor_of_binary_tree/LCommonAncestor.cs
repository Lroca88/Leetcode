using System.Collections.Generic;

class LCommonAncestor {
    HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
    bool found = false;
    TreeNode commonAncestor = null;
    
    private void FindCommon(TreeNode root, TreeNode q) {
        if (root == q) {
            found = true;
            if (ancestors.Contains(root)) commonAncestor = root;
        }
        
        if (root == null || found) return;
             
        FindCommon(root.left, q);
        FindCommon(root.right, q);
        
        if (found && commonAncestor == null && ancestors.Contains(root)) commonAncestor = root;
    }
    
    private void FindAncestors(TreeNode root, TreeNode p) {
        if (root == p) {
            found = true;
            ancestors.Add(root);
        }
        if (root == null || found) return;
        
        FindAncestors(root.left, p);
        FindAncestors(root.right, p);
        
        if (found) ancestors.Add(root);
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        FindAncestors(root, p);
        found = false;
        FindCommon(root, q);
        return commonAncestor;
    }
}


/**

Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

Given the following binary tree:  root = [3,5,1,6,2,0,8,null,null,7,4]


 

Example 1:

Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.
Example 2:

Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
 

Note:

All of the nodes' values will be unique.
p and q are different and both values will exist in the binary tree.

*/
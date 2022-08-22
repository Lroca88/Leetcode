
using System;
using System.Collections.Generic;
/*
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
public class MaxDepthTree
{
    public int MaxDepth(TreeNode root)
    {
        return MaxDepthDFS(root);
    }

    // Dept First Search (Recursive)
    public int MaxDepthDFS(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var maxLeft = MaxDepthDFS(root.left) + 1;
        var maxRight = MaxDepthDFS(root.right) + 1;

        return Math.Max(maxLeft, maxRight);
    }

    // Breadth First Search
    public int MaxDepthBFS(TreeNode root)
    {
        var nodeQ = new Queue<TreeNode>();
        var maxDepth = 0;

        if (root == null)
        {
            return 0;
        }

        nodeQ.Enqueue(root);
        nodeQ.Enqueue(null);

        while (nodeQ.Count > 0)
        {
            var node = nodeQ.Dequeue();
            if (node == null)
            {
                maxDepth++;
                if (nodeQ.Count > 0)
                {
                    nodeQ.Enqueue(null);
                }
            }
            else
            {
                if (node.left != null)
                {
                    nodeQ.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nodeQ.Enqueue(node.right);
                }
            }
        }

        return maxDepth;
    }
}
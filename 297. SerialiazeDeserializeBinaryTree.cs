
using System;
using System.Collections.Generic;
using System.Text;
/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/
public class Codec {
StringBuilder sb = new StringBuilder("[");
    Queue<TreeNode> nodes;
    
    private void addNode(TreeNode node) {
        if (node != null) {
            sb.Append($",{node.val}");
            nodes.Enqueue(node);
        } else {
             sb.Append($",null");
        }
    }
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        nodes = new Queue<TreeNode>();
        TreeNode node;
        
        if (root != null) {
            nodes.Enqueue(root);
            sb.Append($"{root.val}");
        }
            
        while(nodes.Count > 0) {
            node = nodes.Dequeue();
            if (node != null) {
                addNode(node.left);
                addNode(node.right);
            }
        }
        
        sb.Append("]");
        return sb.ToString();
    }
    
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "[]") return null;
        data = data.Substring(1, data.Length - 2);
        string[] items = data.Split(',');
        TreeNode root = new TreeNode(Int32.Parse(items[0]));
        nodes = new Queue<TreeNode>();
        nodes.Enqueue(root);
        int i = 1;
        while (i < items.Length) {
            TreeNode node = nodes.Dequeue();
            string left = items[i];
            i++;
            string right = i < items.Length ? items[i] : "null";
            
            if (left != "null") {
                node.left = new TreeNode(Int32.Parse(left));
                nodes.Enqueue(node.left);
            }
            
            if (right != "null") {
                node.right = new TreeNode(Int32.Parse(right));
                nodes.Enqueue(node.right);
            }
            i++;
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));


/*

Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

Example: 

You may serialize the following tree:

    1
   / \
  2   3
     / \
    4   5

as "[1,2,3,null,null,4,5]"
Clarification: The above format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.

Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.



*/
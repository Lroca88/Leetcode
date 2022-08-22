using System;
using System.Text;

public class Codec2 {

    StringBuilder sb = new StringBuilder("[");
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
            if (sb.Length > 1) return sb.Append(",null").ToString();
            else return sb.Append("]").ToString();
        }
        if (sb.Length == 1) sb.Append($"{root.val}");
        else sb.Append($",{root.val}");

        serialize(root.left);
        serialize(root.right);
        return sb.ToString() + "]";
    }
    
    string data;
    private TreeNode deserialize(TreeNode node) {
       if (String.IsNullOrEmpty(data)) return node;
        int index = data.IndexOf(',');
        int pos = index != -1 ? index : data.Length - 1;
        string nodeStr = data.Substring(0, pos);
        data  = data.Remove(0, pos + 1);
        if (nodeStr == "null") return null;
        
        node = new TreeNode(Int32.Parse(nodeStr));
        node.left = deserialize(node.left);
        node.right = deserialize(node.right);
        return node;
    }
    
    
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "[]") return null;
        this.data = data.Remove(0,1);
        return deserialize((TreeNode) null);
    }
}


/*

Same problem as 297. I got a faster solution in 297 with a BFS instead of DFS.

Serialization is the process of converting a data structure or object into a sequence of bits so 
that it can be stored in a file or memory buffer, or transmitted across a network connection link 
to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on 
how your serialization/deserialization algorithm should work. You just need to ensure that a binary
search tree can be serialized to a string and this string can be deserialized to the original tree structure.

The encoded string should be as compact as possible.

Note: Do not use class member/global/static variables to store states. Your serialize and 
deserialize algorithms should be stateless.

*/
using System;
using System.Collections.Generic;
using System.Linq;

/**
 * Definition for a binary tree node.
 */
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class VerticalOrderTraversal {
    Dictionary<int, Node> dict;
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        dict = new Dictionary<int, Node>();
        List<Node> nodes = new List<Node>();
        IList<IList<int>> res = new List<IList<int>>();
        InOrder(root, 0, 0);
        foreach(var val in dict.Values) {
            val.numbers.Sort((t1, t2) => {
                if (t2.Item1 != t1.Item1) {
                    return t2.Item1.CompareTo(t1.Item1);
                }
                return t1.Item2.CompareTo(t2.Item2);
            });
            nodes.Add(val);
        }
        nodes.Sort((val1, val2) => val1.x.CompareTo(val2.x));
        foreach(var l in nodes) {  
            res.Add(l.numbers.Select(t => t.Item2).ToList());
        }
        return res;
    }

    public void InOrder(TreeNode root, int x, int y) {
        if (root == null) return;

        InOrder(root.left, x - 1, y - 1);
        
        if (dict.ContainsKey(x)) {
            dict[x].numbers.Add(Tuple.Create(y, root.val));
        } else {
            dict[x] = new Node(x, y, root.val);
        }
        
        InOrder(root.right, x + 1, y - 1);
    }

    private class Node
    {
        public int x { get; set; }
        public List<Tuple<int, int>> numbers { get; set; }

        public Node(int x = int.MaxValue, int y = int.MaxValue, int val = int.MaxValue) {
            this.x = x;
            numbers = new List<Tuple<int, int>> { Tuple.Create(y, val) };
        }
    }
}

/**
Given a binary tree, return the vertical order traversal of its nodes values.

For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).

Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, we report the values of the nodes in order from top to bottom (decreasing Y coordinates).

If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.

Return an list of non-empty reports in order of X coordinate.  Every report will have a list of values of nodes.

 

Example 1:



Input: [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
Explanation: 
Without loss of generality, we can assume the root node is at position (0, 0):
Then, the node with value 9 occurs at position (-1, -1);
The nodes with values 3 and 15 occur at positions (0, 0) and (0, -2);
The node with value 20 occurs at position (1, -1);
The node with value 7 occurs at position (2, -2).
Example 2:



Input: [1,2,3,4,5,6,7]
Output: [[4],[2],[1,5,6],[3],[7]]
Explanation: 
The node with value 5 and the node with value 6 have the same position according to the given scheme.
However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.
 

Note:

The tree will have between 1 and 1000 nodes.
Each node's value will be between 0 and 1000.
*/
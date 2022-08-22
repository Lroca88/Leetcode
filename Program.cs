using System;
using System.Collections.Generic;
using listNode = MergeTwoSortedLists.ListNode;
namespace leetcode
{
    class Program
    {
        static void Main(string[] args) {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            MaxDepthTree maxDeepTree = new MaxDepthTree();
            maxDeepTree.MaxDepth(tree);
        }
    }
}




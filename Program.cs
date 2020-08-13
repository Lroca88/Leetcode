using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            FindAllDuplicates f = new FindAllDuplicates();

            
            VerticalOrderTraversal v = new VerticalOrderTraversal();
            TreeNode root = new TreeNode(0);
            root.left = new TreeNode(5);
            root.left.left = new TreeNode(9);
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(2);
            root.right.left.right = new TreeNode(3);
            root.right.left.right.left = new TreeNode(4);
            root.right.left.right.right = new TreeNode(8);
            root.right.left.right.left.left = new TreeNode(6);
            root.right.left.right.left.left.left = new TreeNode(7);
            var res = v.VerticalTraversal(root);
            Console.WriteLine(res);
        }
    }
}

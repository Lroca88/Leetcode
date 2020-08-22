using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            PalindromeLinkedList pll = new PalindromeLinkedList();
            PNode head = pll.BuildLinkedList(new int[] {1,3,2,2,1});
            bool res = pll.IsPalindrome(head);
            
            
            Console.WriteLine(res);
=======
            ReorderLinkedList r = new ReorderLinkedList();
            var ll = r.CreateLinkedList(new int[]{1,2,3,4});
            r.ReorderList(ll); 
            Console.WriteLine(ll);
>>>>>>> 3d64e1d51200df35d85c10524aec0dc528586d1b
        }
    }
}

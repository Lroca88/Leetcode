using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            PalindromeLinkedList pll = new PalindromeLinkedList();
            PNode head = pll.BuildLinkedList(new int[] {1,3,2,2,1});
            bool res = pll.IsPalindrome(head);
            
            
            Console.WriteLine(res);
        }
    }
}

using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            ReorderLinkedList r = new ReorderLinkedList();
            var ll = r.CreateLinkedList(new int[]{1,2,3,4});
            r.ReorderList(ll); 
            Console.WriteLine(ll);
        }
    }
}

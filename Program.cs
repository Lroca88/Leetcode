using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            FindAllDuplicates f = new FindAllDuplicates();

            
            VerticalOrderTraversal v = new VerticalOrderTraversal();

            var res = f.FindDuplicates(new int[] {4,3,2,7,8,2,3,1});
            Console.WriteLine(res);
        }
    }
}

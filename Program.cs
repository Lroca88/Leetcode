using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Sum3 sum = new Sum3();
            
            Console.WriteLine(sum.ThreeSum(new int[]{-1,0,1,2,-1,-4}));
        }
    }
}

using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            LongestConsecutiveS l = new LongestConsecutiveS();
            
            Console.WriteLine(l.LongestConsecutive(new int[]{4,0,-4,-2,2,5,2,0,-8,-8,-8,-8,-1,7,4,5,5,-4,6,6,-3}));
        }
    }
}

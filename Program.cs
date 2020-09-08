using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            MedianSortedArrays ma = new MedianSortedArrays();
            
            Console.WriteLine(ma.FindMedianSortedArrays(new int[]{2}, new int[]{}));
        }
    }
}

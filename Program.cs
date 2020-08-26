using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {

            contest203 c = new contest203();
            var ll = c.FindLatestStep(new int[]{3,5,1,2,4}, 1);
            Console.WriteLine(ll);
        }
    }
}

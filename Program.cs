using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            MedianFinder mf = new MedianFinder();
            mf.AddNum(1);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(2);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(3);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(4);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(5);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(6);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(7);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(8);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(9);
            Console.WriteLine(mf.FindMedian());
            mf.AddNum(10);
            Console.WriteLine(mf.FindMedian());
        }
    }
}

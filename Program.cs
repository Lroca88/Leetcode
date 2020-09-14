using System;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            CheapestFlights cp = new CheapestFlights();
            var flights = new int[][] {
                new int[] {0,1,2},
                new int[] {0,2,5},
                new int[] {1,2,2},
                new int[] {2,3,1},
                new int[] {2,4,4},
                new int[] {3,4,1},
            };
            int ans = cp.FindCheapestPrice(5, flights, 0, 4, 3);
            Console.WriteLine(ans);
            
        }
    }
}


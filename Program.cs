using System;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args) {
            MaxNumRequests max = new MaxNumRequests();
            Console.WriteLine(max.MaximumRequests(
               2,
               new int[][] {
                   new int[] {1,1},
                   new int[] {1,0},
                   new int[] {0,1},
                   new int[] {0,0},
                   new int[] {0,0},
                   new int[] {0,1},
                   new int[] {0,1},
                   new int[] {1,0},
                   new int[] {1,0},
                   new int[] {1,1},
                   new int[] {0,0},
                   new int[] {1,0}
               }
            ));
        }
    }
}




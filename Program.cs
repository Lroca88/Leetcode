using System;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args) {
           MaxNumOfVisiblePoints max = new MaxNumOfVisiblePoints();
           max.VisiblePoints(
               new List<IList<int>> {
                   new List<int> {2,2},
                   new List<int> {-2,10},
                   new List<int> {-2,-2},
                   new List<int> {2,-2},
                   new List<int> {1,1}
               },
               90,
               new List<int> {0,0}
           );
        }
    }
}




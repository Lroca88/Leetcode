using System;
using System.Collections.Generic;

public class PSquares {
    public int NumSquares(int n) {
        List<int> squares = new List<int>();
        int[] best = new int[n+1];
        
        for(var i = 1; i <= (int) Math.Sqrt(n); i++)
            squares.Add(i*i);
        
        for(var i = 1; i <= n; i++)
            best[i] = int.MaxValue;
        
        foreach(var sq in squares) {
            for(var i = sq; i <= n; i++) {
                best[i] = Math.Min(best[i], best[i - sq] + 1);
            }        
        }
        
        return best[n];
    }
}


/**

Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Example 1:

Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.

Example 2:

Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.

*/





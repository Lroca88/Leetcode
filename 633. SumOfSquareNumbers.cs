using System;

public class SumOfSquares {
    public bool JudgeSquareSum(int c) {
        int max = (int) Math.Sqrt(c);
        for(var i = 1; i <= max; i++){
            int a = i * i;
            int b = (int) Math.Sqrt(c - a);
            if (a + b * b == c) return true;
        }
        return false;
    }
}


/**

Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.

Example 1:

Input: 5
Output: True
Explanation: 1 * 1 + 2 * 2 = 5
 

Example 2:

Input: 3
Output: False

*/
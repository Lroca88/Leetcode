using System;
using System.Collections.Generic;
public class NumberWithEqualDigitSum {
    public int solution(int[] A) {
        Dictionary<int, int> number = new Dictionary<int, int>();
        int sum = 0;
        int sol = -1;
        for (var i = 0; i < A.Length; i++) {
            sum = GetSum(A[i]);
            if (number.ContainsKey(sum)) {
                sol = Math.Max(sol, A[i] + number[sum]);
                if (A[i] > number[sum]) number[sum] = A[i];
            } else {
                number[sum] = A[i];
            }
        }
        return sol;
    }

    private int GetSum(int num) {
        int res = 0;
        while (num != 0) {
            res += num % 10;
            num = num / 10;
        }
        return res;
    }
}


/*

Write a function:
    class Solution { public int solution(int[] A); }
that, given an array A consisting of N integers, returns the maximum sum of two numbers 
whose digits add up to an equal sum. If there are no two numbers whose digits add up to
an equal sum, the function should return -1.

Examples:
1. Given A = [51,71,17,42], the function should return 93. There are two pairs of numbers
whose digits add up to an equal sum: (51,42) and (17,71). The first pair sums up to 93.

2. Given A = [42, 33, 60], the function should return 102. The digits of all numbers in A
add up to the same sum, and choosing to add 42 and 60 gives the result 102.

3. Given A = [51,32,43], the function should return -1. Since all numbers in A have digits
that add up to different, unique sums.

Write an efficient algorithm for the following assumptions:
- N is an integer within the range [1..200,000]
- each element of the array A is an integer within the range [1..1,000,000,000].

*/

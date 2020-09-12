using System;

public class MaxLengthOfSubarray {
    public int FindLength(int[] A, int[] B) {
        int a = A.Length;
        int b = B.Length;
        int[][] best = new int[a][];
        int length = 0;
        
        for (var i = 0; i < A.Length; i++) {
            best[i] = new int[b];
            for (var j = 0; j < B.Length; j++) {
                if (A[i] == B[j]) {
                    int prev = i == 0 || j == 0 ? 0 : best[i - 1][j - 1];
                    best[i][j] = prev + 1;
                    length = Math.Max(length, best[i][j]);
                }
                    
            }
        }
        
        return length;
    }
}

/*

 0 1 2 3 4
[1 2 3 2 1]
[3 2 1 4 7]
          
 0 1 2 3 4
[0 0 1 0 0]0   Best[i][j] = Best[i - 1][j - 1] + 1;
[0 1 0 0 0]1   Max = 3
[1 0 0 0 0]2
[0 2 0 0 0]3
[0 0 3 0 0]4
     
-----------------------------------------------------------

 0 1 2 3 4
[1 2 3 2 1]
[1 2 1 2 3]
          
 0 1 2 3 4   
[1 0 1 0 0]0  Best[i][j] = Best[i - 1][j - 1] + 1;
[0 2 0 2 0]1  Max = 3
[0 0 0 0 3]2
[0 1 0 1 0]3
[1 0 2 0 0]4

*/

/**

Given two integer arrays A and B, return the maximum length of an subarray that appears in both arrays.

Example 1:

Input:
A: [1,2,3,2,1]
B: [3,2,1,4,7]
Output: 3
Explanation: 
The repeated subarray with maximum length is [3, 2, 1].
 

Note:

1 <= len(A), len(B) <= 1000
0 <= A[i], B[i] < 100

*/
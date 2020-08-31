using System;

public class StoneGame5 {
    int[][] stoneMat;
    int[] stoneSum; 
    int n;

    public void BuildMatrix(int[] stoneValue) {
        for(int i = 0; i < n; i++)
            stoneMat[i][i] = stoneValue[i];
        
        for(int i = 2; i <= n; i++) {                       // Size of subarray
            for(int start = 0; start <=  n - i; start++) {  // Moving the subarray over the original array
                int end = start + i - 1;                    // Getting index of last element of subarray
                for (int k = start; k < end; k++) {
                    int leftSum = stoneSum[k + 1] - stoneSum[start];
                    int rightSum = stoneSum[end + 1] - stoneSum[k + 1];
                    int max = leftSum + rightSum;
                    
                    if (leftSum < rightSum) {               // Getting smallest subarray
                        max += stoneMat[start][k];                
                    } else if (leftSum > rightSum) {
                        max += stoneMat[k+1][end];  
                    } else {                                // If we get here subarrays have same sum
                        max += Math.Max(stoneMat[start][k], stoneMat[k+1][end]);
                    }

                    stoneMat[start][end] = Math.Max(stoneMat[start][end], max);
                }
            }
        }

    }

    public int StoneGameV(int[] stoneValue) {
        n = stoneValue.Length;
        stoneMat = new int[n][];
        stoneSum = new int[n + 1];
        
        for (int i = 0; i < n; i++) {
            stoneMat[i] = new int[n];
            stoneSum[i+1] = stoneSum[i] + stoneValue[i];
        }

        BuildMatrix(stoneValue);
        int gameMax = stoneMat[0][n-1] - stoneSum[n];
        return gameMax;
    }
}

/**
     0   1   2   3   4
    [7,  2,  2,  2,  2]
[0,  7,  9,  11, 13, 15]
 0   1   2   3   4   5

There are several stones arranged in a row, and each stone has an associated value which is an integer given in the array stoneValue.

In each round of the game, Alice divides the row into two non-empty rows (i.e. left row and right row), then Bob calculates the value
of each row which is the sum of the values of all the stones in this row. Bob throws away the row which has the maximum value, and 
Alice's score increases by the value of the remaining row. If the value of the two rows are equal, Bob lets Alice decide which row
will be thrown away. The next round starts with the remaining row.

The game ends when there is only one stone remaining. Alice's is initially zero.

Return the maximum score that Alice can obtain.

 

Example 1:

Input: stoneValue = [6,2,3,4,5,5]
Output: 18
Explanation: In the first round, Alice divides the row to [6,2,3], [4,5,5]. The left row has the value 11 and the right row has value 14.
Bob throws away the right row and Alice's score is now 11.
In the second round Alice divides the row to [6], [2,3]. This time Bob throws away the left row and Alice's score becomes 16 (11 + 5).
The last round Alice has only one choice to divide the row which is [2], [3]. Bob throws away the right row and Alice's score is now
18 (16 + 2). The game ends because only one stone is remaining in the row.


Example 2:

Input: stoneValue = [7,7,7,7,7,7,7]
Output: 28
Example 3:

Input: stoneValue = [4]
Output: 0
 

Constraints:

1 <= stoneValue.length <= 500
1 <= stoneValue[i] <= 10^6

*/
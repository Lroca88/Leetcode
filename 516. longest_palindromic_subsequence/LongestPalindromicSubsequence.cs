using System;

public class LongestPalindromicSubsequence {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        int[][] dp = new int[n][];
        
        for (var i = 0; i < n; i++) {
            dp[i] = new int[n];
            dp[i][i] = 1;
            if (i + 1 < n) dp[i][i+1] = s[i] == s[i+1] ? 2 : 1;
        }
        
        for (var k = 3; k <= n; k++) {
            for (var i = 0; i <= n - k; i++) {
                int j = i + k - 1;
                dp[i][j] = s[i] == s[j] ? dp[i+1][j-1] + 2 : Math.Max(dp[i][j-1], dp[i+1][j]);
            }
        }
        
        return dp[0][n-1];
    }
}

/*

 01234
"bbbab"

For palindromes of length 1 and 2 => base cases
     
  0 1 2 3 4      dp[i][i] = 1
0[1 2 0 0 0]     dp[i][i+1] = s[i] == s[i+1] ? 2 : 1
1[0 1 2 0 0]     If is "aa" the length is 2, if is "ab" length is 1 either a or b.
2[0 0 1 1 0]
3[0 0 0 1 1]
4[0 0 0 0 1]


For palindromes of length 3
     
  0 1 2 3 4      dp[i][j] = s[i] == s[j] ? dp[i+1][j-1] + 2 : max(dp[i][j-1], dp[i+1][j])
0[1 2 3 0 0]     If I can make a palindrome I use the best solution inside + 2 additional chars (edges)
1[0 1 2 2 0]     If the edges aren't the same, the best solution would be either from the starting point
2[0 0 1 1 3]     [i, j - 1] or from [i + 1, j] you have both beforehand.
3[0 0 0 1 1]
4[0 0 0 0 1]


For palindromes of length 4
     
  0 1 2 3 4      dp[i][j] = s[i] == s[j] ? dp[i+1][j-1] + 2 : max(dp[i][j-1], dp[i+1][j])
0[1 2 3 3 0]     
1[0 1 2 2 3]
2[0 0 1 1 3]
3[0 0 0 1 1]
4[0 0 0 0 1]


For palindromes of length 5
     
  0 1 2 3 4      dp[i][j] = s[i] == s[j] ? dp[i+1][j-1] + 2 : max(dp[i][j-1], dp[i+1][j])
0[1 2 3 3 4]     
1[0 1 2 2 3]
2[0 0 1 1 3]
3[0 0 0 1 1]
4[0 0 0 0 1]


*/


/*

Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.

Example 1:
Input:

"bbbab"
Output:
4
One possible longest palindromic subsequence is "bbbb".
 

Example 2:
Input:

"cbbd"
Output:
2
One possible longest palindromic subsequence is "bb".
 

Constraints:

1 <= s.length <= 1000
s consists only of lowercase English letters.

*/
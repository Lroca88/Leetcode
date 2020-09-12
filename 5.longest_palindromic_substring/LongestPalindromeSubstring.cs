using System.Collections.Generic;

public class LongestPalindromeSubstring {
    public int getMaxPal(string s, int left, int right) {
        while(left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        return right - left - 1;
    }
    
    public string LongestPalindrome(string s) {
        int max = 0, index = 0; 
        int current = 0;
        for(var i = 0; i < s.Length; i++) {
            current = getMaxPal(s, i, i);
            if (current > max) {
              max = current;
              index = i - max / 2;  
            }
            
            current = getMaxPal(s, i, i+1);
            if (current > max) {
                max = current;
                index = i + 1 - max / 2;
            }
        }   
        return s.Substring(index, max);
    }
}

/*
    Approach: Expand around center, there are two ways "aa" or "aba".
    Time Complexity: O(N^2)
    Space Complexity: O(1)
*/


/*

Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example 1:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.


Example 2:
Input: "cbbd"
Output: "bb"

*/

using System.Collections.Generic;

public class Solution {
    private Dictionary<char, int> chars = new Dictionary<char, int>();
    
    public int LongestPalindrome(string s) {
        int total = 0;
        for(int i = 0; i < s.Length; i++) {
            if (chars.ContainsKey(s[i]))
                chars[s[i]]++;
            else
                chars[s[i]] = 1;
        }
        
        foreach(char key in chars.Keys) {
            if (chars[key] % 2 == 0) {
                total += chars[key];
            } else {
                total += chars[key] - 1;
            }
        }

        // If there is at least one character with
        // odd count the total will be less than lenght of s.
        if (total < s.Length) total++;
        
        return total;
    }
}

/**
Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

This is case sensitive, for example "Aa" is not considered a palindrome here.

Note:
Assume the length of given string will not exceed 1,010.

Example:

Input:
"abccccdd"

Output:
7

Explanation:
One longest palindrome that can be built is "dccaccd", whose length is 7.
*/
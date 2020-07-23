using System;
using System.Collections.Generic;

namespace leetcode
{
    class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s) {
            int windowLeft = 0;                                             // Window left side
            int max = 0;                                                    
            Dictionary<char, int> character = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++) {
                if (character.ContainsKey(s[i])) {                          // If character is in the dictionary
                    var oldIndex = character[s[i]];
                    if (windowLeft < oldIndex + 1) {                        // If character is inside the subsequence
                        windowLeft = oldIndex + 1;                          // Gather a new subsequence starting right next to oldIndex                    
                    }
                }
                var total = i - windowLeft + 1;                             // Getting actual lenght of subsequence
                character[s[i]] = i;                                        // Updating or adding index of character
                if (max < total) max = total;                               // Getting max subsequence
            }
            return max;
        }
    }
}

/*
3. Longest Substring Without Repeating Characters
Given a string, find the length of the longest substring without repeating characters.

Example 1:

Input: "abcabcbb"
Output: 3 
Explanation: The answer is "abc", with the length of 3. 
Example 2:

Input: "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3. 
             Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/
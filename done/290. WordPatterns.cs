using System.Collections.Generic;
using System.Text;

class WordPatterns {
    public bool WordPattern(string pattern, string str) {
        string[] letter = new string[26];
        Dictionary<string, char> word = new Dictionary<string, char>();
        int k = -1;

        for(var i = 0; i < pattern.Length; i++) {
            k++;
            StringBuilder sb = new StringBuilder();
            while (k < str.Length && str[k] != ' ') {
                sb.Append(str[k]);
                k++;
            }
            int index = pattern[i] - 'a';
            string subStr = sb.ToString();

            if (string.IsNullOrEmpty(letter[index]) && !word.ContainsKey(subStr)) {
                letter[index] = subStr;
                word[subStr] = pattern[i];
                continue;
            }
            
            if (letter[index] != subStr) return false;

            if (word.ContainsKey(subStr) && word[subStr] != pattern[i]) return false;
        }

        return k == str.Length;
    }
}


/*

Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

Example 1:

Input: pattern = "abba", str = "dog cat cat dog"
Output: true
Example 2:

Input:pattern = "abba", str = "dog cat cat fish"
Output: false
Example 3:

Input: pattern = "aaaa", str = "dog cat cat dog"
Output: false
Example 4:

Input: pattern = "abba", str = "dog dog dog dog"
Output: false
Notes:
You may assume pattern contains only lowercase letters, and str contains lowercase letters that may be separated by a single space.

*/
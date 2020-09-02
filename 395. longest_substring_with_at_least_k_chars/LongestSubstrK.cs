using System;
using System.Collections.Generic;

public class LongestSubstrK {
    
    private int max = 0;
    
    private int FindSubstr(string s, int k, int ini, int end) {
        int interval = end - ini;
        if (interval < k) return 0;
        
        Dictionary<char, int> chars = new Dictionary<char, int>();
        for(var i = ini; i < end; i++) {
            if (chars.ContainsKey(s[i])) 
                chars[s[i]]++;
            else
                chars[s[i]] = 1;
        }
        
        for(var i = ini; i < end; i++) {
            if (chars[s[i]] < k) {
                if (i < end -1 && s[i] == s[i + 1]) continue;
                int left = FindSubstr(s, k, ini, i);
                int right = FindSubstr(s, k, i + 1, end); 
                return max = Math.Max(max, Math.Max(left, right));
            }    
        }
        
        return interval;
    }
    
    public int LongestSubstring(string s, int k) {
        return FindSubstr(s, k, 0, s.Length);
    }
}

/**

Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Example 1:

Input:
s = "aaabb", k = 3

Output:
3

The longest substring is "aaa", as 'a' is repeated 3 times.
Example 2:

Input:
s = "ababbc", k = 2

Output:
5

The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.


Solution by me:

aacbaddeeb  k = 2
1- Find the deal breakers in the array. {c = 1} 
2- Divide the string getting out the deal breakers. aa and baddeeb
3- Do the same, if there is no deal breaker, return the lenght of the string.
4- Bactrack => compare Max with the result of splitting the string.
    

aacbaddeeb  k = 2
1- Divides in
aa max = 2
baddeeb  DB: {a}
2- Divide:
b return 0 because is less than k
ddeeb DB:{b}
3- Divide:
ddee max = 4
b return 0

*/
    
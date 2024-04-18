public class RepeatedSubstring {
    public bool RepeatedSubstringPattern(string s) {
        string ss = s + s;
        return ss.IndexOf(s, 1, ss.Length - 2) != -1 ? true : false;
    }
}

/*
Second Solution: Double the original string and remove first and last characters,
then look for the original string within it.
Time Complexity: O(N)
Space Complexity: O(N)  => ss

Example:

s = "ababab"
ss =  "bababababa"

ss still contains s, thus there is a repeated pattern in the original string.

Explanation:
s = "abcabcabc"
     | || || |
      m  m  m

s = m + m + m => n * m  In this case n = 3.

Before removing the first and last chars from ss:
s = "abcabcabcabcabcabc"
     | || || |  ...
      m  m  m
ss =  2n * m

After removing first and last chars from ss:
s = "bcabcabcabcabcab"
       | || || || | 
        m  m  m  m

ss = (2n-2) * m   Because we are affecting the first and last m
              ⬆️
              ⬆  
But look we still have at least n * m inside ss when n > 1 (Which makes sense because n = 1 is not a valid case). 

*/


/*  
First Solution: Find divisors of the string total length
Complexity: ?
public bool RepeatedSubstringPattern(string s) {
    int n = s.Length;
    bool[] used = new bool[26];
    int letters = 0;
    bool sol = false;
    
    if (n == 1) return false;
    
    for(var i = 0; i < n; i++) {
        int index = s[i] - 'a'; 
        if (!used[index]) {
            letters++;
            used[index] = true;
        }
    }
    
    List<int> divisors = new List<int>();
    for(var i = 1; i <= (int)Math.Sqrt(n); i++) {
        if (n % i == 0) {
            if (i >= letters)
                divisors.Add(i);
            int j = n / i;
            if (j >= letters && j < n)
                divisors.Add(j);
        }
    }
    
    
    for(var i = 0; i < divisors.Count; i++) {
        if (sol) return true;
        sol = true;
        for(var j = divisors[i]; j < n; j++) {
            if (s[j] != s[j % divisors[i]]) {
                sol = false;
                break;
            }
        }
    }
    
    return sol;
}

*/



/*

Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

 

Example 1:

Input: "abab"
Output: True
Explanation: It's the substring "ab" twice.
Example 2:

Input: "aba"
Output: False
Example 3:

Input: "abcabcabcabc"
Output: True
Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)

*/
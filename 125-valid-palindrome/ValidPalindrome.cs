using System;

public class ValidPalindrome {
    public bool IsPalindrome(string s) {
        int init = 0;
        int end = s.Length - 1;
        bool palindrome = true;
        while(init < end) {
            if (!Char.IsLetterOrDigit(s[init])) {
                init++;
                continue;
            }
            if (!Char.IsLetterOrDigit(s[end])) {
                end--;
                continue;
            }
            if (Char.ToLower(s[init]) != Char.ToLower(s[end])) {
                palindrome = false;
                break;
            }
            init++;
            end--;
        }
        return palindrome;
    }
}

/**

Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Note: For the purpose of this problem, we define empty string as valid palindrome.

Example 1:

Input: "A man, a plan, a canal: Panama"
Output: true
Example 2:

Input: "race a car"
Output: false
 

Constraints:

s consists only of printable ASCII characters.

*/
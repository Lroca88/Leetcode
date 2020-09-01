public class ValidPalindrome2 {
    private bool ValidPalindrome(string s, int left, int right, bool fix) {
       while (left < right && s[left] == s[right]) {
           left++;
           right--;
       }
       if (left >= right) return true;
       if (!fix)
           return ValidPalindrome(s, left+1, right, true) || ValidPalindrome(s, left, right-1, true);
       return false; 
    }
    
    
    public bool ValidPalindrome(string s) {
        return ValidPalindrome(s, 0, s.Length - 1, false);
    }
}


/**

Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.

Example 1:
Input: "aba"
Output: True

Example 2:
Input: "abca"
Output: True
Explanation: You could delete the character 'c'.

Note:
The string will only contain lowercase characters a-z. The maximum length of the string is 50000.

*/
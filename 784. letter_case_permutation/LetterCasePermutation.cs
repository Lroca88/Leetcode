using System;
using System.Collections.Generic;
using System.Text;

public class LetterCasePermutate {
    List<string> solutions = new List<string>();
    StringBuilder sb = new StringBuilder();
    
    public IList<string> LetterCasePermutation(string S) {
        Permutate(S);
        return solutions;
    }
    
    public void Permutate(string s) {
        if (sb.Length == s.Length) {
            solutions.Add(sb.ToString());
            return;
        }
        
        if (Char.IsDigit(s[sb.Length])) {
            sb.Append(s[sb.Length]);
            Permutate(s);
            sb.Length--;
        } else {
            sb.Append(Char.ToLower(s[sb.Length]));
            Permutate(s);
            sb.Length--;
            sb.Append(Char.ToUpper(s[sb.Length]));
            Permutate(s);
            sb.Length--;
        }
    }
    
}

/*
  Time Complexity: O(2^N * N)     2^N permutations when all chars are letters and N to print every single string from the string builder. 
  Space Complexity: O(2^N * N)    All the permutations stored in the solutions list
*/


/*

Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.

Return a list of all possible strings we could create. You can return the output in any order.

 

Example 1:

Input: S = "a1b2"
Output: ["a1b2","a1B2","A1b2","A1B2"]
Example 2:

Input: S = "3z4"
Output: ["3z4","3Z4"]
Example 3:

Input: S = "12345"
Output: ["12345"]
Example 4:

Input: S = "0"
Output: ["0"]
 

Constraints:

S will be a string with length between 1 and 12.
S will consist only of letters or digits.

*/
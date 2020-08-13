using System;

public class ExcelSheet {
    public int TitleToNumber(string s) {
        int charNum;
        int column = 0;
        int sLen = s.Length;
        for(int i = 0; i < sLen; i++) {
            charNum = s[i] - 'A' + 1;
            column += charNum * (int)Math.Pow(26, sLen-i-1);
        }
        return column;
    }
}

/**
Given a column title as appear in an Excel sheet, return its corresponding column number.

For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
    ...

Example 1:
Input: "A"
Output: 1

Example 2:
Input: "AB"
Output: 28

Example 3:
Input: "ZY"
Output: 701
 

Constraints:

1 <= s.length <= 7
s consists only of uppercase English letters.
s is between "A" and "FXSHRXW".

*/

/**
Solution:
For a case my alphabet contains only ABC:
A - 1    
B - 2
C - 3
AA - 4      1*3^1 + 1*3^0 = 4
AB - 5      1*3^1 + 2*3^0 = 5
AC - 6      1*3^1 + 3*3^0 = 6
BA - 7      2*3^1 + 1*3^0 = 7 
BB - 8      2*3^1 + 2*3^0 = 8
BC - 9      2*3^1 + 3*3^0 = 9
CA - 10     3*3^1 + 1*3^0 = 10 
CB - 11     3*3^1 + 2*3^0 = 11
CC - 12     3*3^1 + 3*3^0 = 12
AAA - 13    1*3^2 + 1*3^1 + 1*3^0 = 13
**/
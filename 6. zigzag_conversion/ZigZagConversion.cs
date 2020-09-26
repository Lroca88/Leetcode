using System.Text;

public class ZigZagConversion {
    public string Convert(string s, int numRows) {
        StringBuilder sBuilder = new StringBuilder();
        
        if (numRows == 1) return s;  // Capturing edge case where incrementPerrow1 becomes 0
        
        int incrementPerRow1 = 2 * numRows - 2;
        for (int row = 1; row <= numRows; row++) {
            int index = row - 1;
            int incrementPerRow2 = 2 * (numRows - row);
            while(index < s.Length) {
                sBuilder.Append(s[index]);
                int secondIndex = index + incrementPerRow2;
                bool isInString = secondIndex < s.Length;
                if (row > 1 && row < numRows && isInString) {
                     sBuilder.Append(s[secondIndex]);
                }
                
                index += incrementPerRow1;
            }
        }
        
        return sBuilder.ToString();
    }
}


/**

Time Complexity: O(N)    => Every char is touched exactly once 
Space Complexity: O(N)   => The Stringbuilder

For 3:
1st Row: s[i + 2n - 2]     
2nd Row: s[i + 2n - 2]  && s[i + 2*(n-row)]    ex: i = 2 row = 2   2 + 2 = 4  Let's call 2*(n-row) => incrementPerRow
3th Row: s[i + 2n - 2]

0  1  2  3  4  5  6  7  8  9  10 11 12 13     
P  A  Y  P  A  L  I  S  H  I  R  I  N  G
    
P   A   H   N
A P L S I I G
Y   I   R   
    
    
For 4:
1st Row: s[i + 2n - 2]                                                    
2nd Row: s[i + 2n - 2]  && s[i + 2*(n-row)]    ex: i = 1 row = 2   1 + 4 = 5  
3rd Row: s[i + 2n - 2]  && s[i + 2*(n-row)]    ex: i = 2 row = 3   2 + 2  = 4 
4th Row: s[i + 2n - 2]

0  1  2  3  4  5  6  7  8  9  10 11 12 13     
P  A  Y  P  A  L  I  S  H  I  R  I  N  G


P     I    N
A   L S  I G   Here I realized that to get from A in the 2nd row to L in the same row, we have to increment index four times. => i + 4
Y A   H R      Here I realized that to get from Y in the 3rd row to A in the same row, we have to increment index two times. => i + 2 
P     I


For 5:
1st Row: s[n + n/2]                                                    
2nd Row: s[n + n/2]  && s[i + 2*(n-row)]    ex: i = 1 row = 2   1 + 4 = 5  
3rd Row: s[n + n/2]  && s[i + 2*(n-row)]    ex: i = 2 row = 3   2 + 2  = 4 
4th Row: s[n + n/2]


0  1  2  3  4  5  6  7  8  9  10 11 12 13     
P  A  Y  P  A  L  I  S  H  I  R  I  N  G

                                                                                     
P       H     Here I realized that for first and last row, the amount of chars between first and second letter in the same row are N + N - 2
A     S I 
Y   I   R
P L     I G
A       N


**/
/*

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:

P     I    N
A   L S  I G
Y A   H R
P     I

*/
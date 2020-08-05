/**
 *  1- You can check if the number is a power of two first
       n & n-1 = 0.
       0 -> 0000      5 -> 0101
       1 -> 0001      6 -> 0110          
       2 -> 0010      7 -> 0111
       3 -> 0011      8 -> 1000
       4 -> 0100      9 -> 1001

       Therefore:
       2 & 1 = 0    5 & 4 = 4   8 & 7 = 0
       3 & 2 = 2    6 & 5 = 4   9 & 8 = 8
       4 & 3 = 0    7 & 6 = 6
       
       
 *  2- Now knowing that every 3 consecutive numbers must be divisible by 3
       we can say that 2^n - 1, 2^n, 2^n + 1 must contain a divisible number by 3.
       2^n can't be the number because is power of 2.
       Therefore 2^n - 1 or 2^n + 1 must be divisible by 3. If we multiply them the result must be divisible by 3 as well.
       (2^n - 1)(2^n + 1) = 2^2n - 1 = 4^n-1
       Look: If we substract 1 to a power of 4, we obtain a number divisble by 3.
       Then: The power of 4, awlays, has to be divisible by 3 when we substract 1. 
 */

public class Power4 {
        
    public bool IsPowerOfFour(int num) {
        return num > 0 && (num & (num-1)) == 0 && (num-1) % 3 == 0;   
    }
}


/**
Given an integer (signed 32 bits), write a function to check whether it is a power of 4.

Example 1:

Input: 16
Output: true
Example 2:

Input: 5
Output: false

Follow up: Could you solve it without loops/recursion?
*/
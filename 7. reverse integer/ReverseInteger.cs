using System;

public class ReverseInteger
{
    private const int MinValue = Int32.MinValue;       // -2,147,483,648  => Look the last digit is 8 (it means -2,147,483,649 is first out of range)
    private const int MaxValue = Int32.MaxValue;       // 2,147,483,647   => Look the last digit is 7 (it means 2,147,483,648 is first out of range)
    private const int MinDivided10 = MinValue / 10;
    private const int MaxDivided10 = MaxValue / 10;

    public int Reverse(int x)
    {
        int reverse = 0;
        int pop;
        while (x != 0)
        {
            pop = x % 10;
            x /= 10;
            if (reverse > MaxDivided10) return 0;
            if (reverse < MinDivided10) return 0;
            if (reverse == MaxDivided10 && pop > 7) return 0;
            if (reverse == MinDivided10 && pop < -8) return 0;
            reverse = reverse * 10 + pop;
        }

        return reverse;
    }
}


/*
Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
Example 4:

Input: x = 0
Output: 0
 

Constraints:

-231 <= x <= 231 - 1
 
*/
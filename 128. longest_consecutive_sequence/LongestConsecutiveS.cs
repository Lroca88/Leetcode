using System;
using System.Collections.Generic;

public class LongestConsecutiveS {
    public int LongestConsecutive(int[] nums) {
        Dictionary<int,int> numbers = new Dictionary<int,int>();
        int max = 0;
        int left, right;
        foreach(var num in nums) {
            if (numbers.ContainsKey(num)) continue;
            numbers.TryGetValue(num - 1, out left);
            numbers.TryGetValue(num + 1, out right);
            
            int sum = left + right + 1;
            numbers[num] = sum;
            numbers[num - left] = sum;
            numbers[num + right] = sum;
            max = Math.Max(sum, max);
        }
        return max;
    }
}

/*

Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

Your algorithm should run in O(n) complexity.

Example:

Input: [100, 4, 200, 1, 3, 2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Solution: 

The important detail here is thet you need to keep the left and right edges updated, the middle doesn't matter.


*/
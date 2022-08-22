using System;
using System.Collections.Generic;
public class TwoNumberSum {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> index = new Dictionary<int, int>();
        for(var i= 0; i< nums.Length; i++) {
            var desiredNumber = target - nums[i];
            if(index.ContainsKey(desiredNumber)) {
                return new int[] {index[desiredNumber], i};
            }
            index[nums[i]] = i;
        }
        return null;
    }
}


/**

Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].

*/
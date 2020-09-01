using System;
using System.Collections.Generic;

public class Sum3 {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<IList<int>> solution = new List<IList<int>>();
        if (nums.Length < 3) return solution;
        Array.Sort(nums);
        
        for(var i = 0; i < nums.Length - 2; i++) {
            if (i > 0 && nums[i] == nums[i-1]) continue;
            
            int left = i + 1;
            int right = nums.Length - 1;
            
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0) {
                    solution.Add(new int[3]{nums[i], nums[left++], nums[right--]});
                    while (left < right && nums[left] == nums[left-1]) left++;
                    while (right > left && nums[right] == nums[right+1]) right--;
                } else if (sum < 0) {
                    left++;
                } else {
                    right--;
                }
            }
        }
        
        return solution;
    }
}
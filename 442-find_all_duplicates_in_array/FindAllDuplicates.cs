using System.Collections.Generic;

public class FindAllDuplicates {
    public IList<int> FindDuplicates(int[] nums) {
        List<int> duplicates = new List<int>();
        int index = 0;
        int temp = 0;
        int pos;
        while (index < nums.Length) {
            if (nums[index] == index + 1 || nums[index] == 0) {
                index++;
                continue;
            }
            
            pos = nums[index] - 1;

            if (nums[index] == nums[pos]) {
                duplicates.Add(nums[index]);
                nums[index] = 0;
            } else {
                temp = nums[pos];
                nums[pos] = nums[index];
                nums[index] = temp;
            }
            
        }

        return duplicates;
    }
}


/**

Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements that appear twice in this array.

Could you do it without extra space and in O(n) runtime?

Example:

Input:
[4,3,2,7,8,2,3,1]

Output:
[2,3]

*/
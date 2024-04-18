using System;

public class MedianSortedArrays {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        
        if (len1 > len2) // Making sure we have the smallest array in nums1
            return FindMedianSortedArrays(nums2, nums1); 

        int start = 0;
        int end = len1;

        while (start <= end) {
            int partition1 = (start + end) / 2;
            int partition2 = (len1 + len2 + 1) / 2 - partition1;

            int maxLeft1 = partition1 == 0 ? int.MinValue : nums1[partition1 - 1];
            int minRight1 = partition1 == len1 ? int.MaxValue : nums1[partition1];

            int maxLeft2 = partition2 == 0 ? int.MinValue : nums2[partition2 - 1];
            int minRight2 = partition2 == len2 ? int.MaxValue : nums2[partition2];

            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {
                int sol = Math.Max(maxLeft1, maxLeft2);
                if ((len1 + len2) % 2 == 1) return (double) sol;
                sol = sol + Math.Min(minRight1, minRight2);
                return (double)(sol) / 2; 
            }

            if (maxLeft1 > minRight2) // We need to move to the left in the binary search
                end = partition1 - 1;
            else                      // We need to move to the right, because maxLeft2 > minRigth1 
                start = partition1 + 1; 
        }

        throw new ArgumentException(); // We get here only if the arrays are not sorted, which is an argument exception
    }
}

/*
Time Complexity: O(logN) Where N is the minimum between Arr1 and Arr2.
Space Complexity: O(1) No extra array needed, only few int variables.

Let's use binary search for partitioning the smallest array, the second array will need to be partiotioned in a way that
the same amount of elements are in each side and all elements from left are smaller than right.

P1 = (start + end) / 2  => Binary Search
P2 = (Length1 + Length2 + 1) / 2 - Problem1

At this point we need to check if maximum element from left partition in Arr1 is smaller than the minimum element from Arr2 in right partition
We also need to check if minimum element from rigth partition in Arr1 is bigger than the maximum element from Arr2 in left parition.

Example 1:
Arr1 = [1 2 3 7 12]
Arr2 = [4 5 8 9 11 13]

Solution: [1 2 3 4 5 7 8 9 11 12 13]  => 7 / 2 = 3.5
--------------------------------------------------------------------------------------------
start = 0
end = 5
P1 = (start + end) / 2 = 2 Elements in the left side
P2 = (A + B + 1) / 2 - P1 = 4 Elements on left side.

Left Side  |  Rigth side
1 2        |  3 7 12                
4 5 8 9    |  11 13 

2 <= 11 First condition met.
9 <= 3 Second condition failed. (It means we have to move to the rigth in the binary search).
--------------------------------------------------------------------------------------------
start = P1 + 1 = 3
end = 5
P1 = (start + end) / 2 = 3
P2 = (A + B + 1) / 2 - P1 = 3

Left Side  |  Rigth side
1 2 3      |  7 12                
4 5 8      |  9 11 13 

3 <= 9 First condition met.
8 <= 7 Second condition failed. (It means we have to move to the rigth in the binary search).
--------------------------------------------------------------------------------------------
start = P1 + 1 = 4
end = 5
P1 = (start + end) / 2 = 4
P2 = (A + B + 1) / 2 - P1 = 2

Left Side  |  Rigth side
1 2 3 7    |  12                
4 5        |  8 9 11 13 

7 <= 8  First condition met.
5 <= 12 Second condition met

Since the total number of elements is odd, in this case 11. We just need to get the largest 
element between Arr1 and Arr2 in the left side, 7 > 5. Therefore is 7.

If the total number of elements is even, then we need bigger element from the Left side and
the smaller element from the right side.
--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------

Example 2:
Arr1 = [14 16 17 18]
Arr2 = [4 5 8 9 11 13]

Solution: [4 5 8 9 11 13 14 16 17 18]  => (11 + 13) / 2 = 12
--------------------------------------------------------------------------------------------
start = 0
end = 4
P1 = 2
P2 = 3

Left Side  |  Rigth side
14 16      |  17 18                
4 5 8      |  9 11 13 

16 <= 9 First condition failed  (It means we have to move to the left in the binary search).
8 <= 17 Second condition meet

--------------------------------------------------------------------------------------------
start = 0
end = 1
P1 = 0
P2 = 5

Left Side  |  Rigth side
           |  14 16 17 18               
4 5 8 9 11 |  13 

16 <= 9 First condition failed  (It means we have to move to the left in the binary search).
8 <= 17 Second condition meet

There is 0 elements in the left side for Arr1 => We consider a -Infinity for the empty parition.

-Inf <= 13 First condition met
  11 <= 14 Second condition met

*/


/*

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

Follow up: The overall run time complexity should be O(log (m+n)).

 

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.


Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Example 3:
Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000

Example 4:
Input: nums1 = [], nums2 = [1]
Output: 1.00000

Example 5:
Input: nums1 = [2], nums2 = []
Output: 2.00000
 

Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-10^6 <= nums1[i], nums2[i] <= 10^6

*/
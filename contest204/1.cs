using System;

public class Pattern {
    public int GetMaxLen(int[] nums) {
        int lastZero = -1;
        int neg = 0;
        int firstNeg = 0;
        int lastNeg = 0;
        int max = 0;
        int current = 0;
        for(int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) {
                current = 0;
                if (neg % 2 == 0) {
                    current = i - lastZero - 1;
                } else {
                    int current1 = Math.Max(firstNeg - lastZero - 1, i - firstNeg - 1);
                    int current2 = Math.Max(lastNeg - lastZero - 1, i - lastNeg - 1);
                    current = Math.Max(current1, current2);
                }
                max = Math.Max(current, max);
                lastZero = i;
                neg = 0;
            } else if (nums[i] < 0) {
                if (neg == 0) {
                    firstNeg = i;
                    lastNeg = i;
                } else {
                    lastNeg = i;
                }
                neg++;
            }
        }

        if (neg % 2 == 0) {
            current = nums.Length - lastZero - 1;
            
        } else {
            int current1 = Math.Max(firstNeg - lastZero - 1, nums.Length - firstNeg - 1);
            int current2 = Math.Max(lastNeg - lastZero - 1, nums.Length - lastNeg - 1);
            current = Math.Max(current1, current2);
        }
        max = Math.Max(current, max);
        return max;
    }
}
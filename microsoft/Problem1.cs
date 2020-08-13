using System;
using System.Collections.Generic;
public class Problem1 {
    public int solution(int[] A) {
        Dictionary<int, int> number = new Dictionary<int, int>();
        int sum = 0;
        int sol = -1;
        for (var i = 0; i < A.Length; i++) {
            sum = GetSum(A[i]);
            if (number.ContainsKey(sum)) {
                sol = Math.Max(sol, A[i] + number[sum]);
                if (A[i] > number[sum]) number[sum] = A[i];
            } else {
                number[sum] = A[i];
            }
        }
        return sol;
    }

    private int GetSum(int num) {
        int res = 0;
        while (num != 0) {
            res += num % 10;
            num = num / 10;
        }
        return res;
    }
}

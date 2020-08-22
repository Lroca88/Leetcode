public class SortArrayByP {
    public int[] SortArrayByParity(int[] A) {
        int[] sol = new int[A.Length];
        int init = 0, end = A.Length - 1;
        foreach(var num in A) {
            if (num % 2 == 0) {
                sol[init] = num;
                init++;
            } else {
                sol[end] = num;
                end--;
            }
        }
        return sol;
    }
}


/**
Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.

You may return any answer array that satisfies this condition.

 

Example 1:

Input: [3,1,2,4]
Output: [2,4,3,1]
The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
 

Note:

1 <= A.length <= 5000
0 <= A[i] <= 5000
*/
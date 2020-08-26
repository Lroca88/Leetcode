using System;
using System.Collections.Generic;

public class contest203 {
    char[] binary;

    private bool findSubstring(int m, int totalBitsOne) {
        int subStr = 0;
        foreach(var ch in binary) {
            if (totalBitsOne < m) break;
            if (ch == '1') subStr++;
            else {
                if (subStr == m) return true;
                totalBitsOne -= subStr;
                subStr = 0;
            }
        }
        return subStr == m;
    }
    
    public int FindLatestStep(int[] arr, int m) {
        int[] length = 
        binary = new char[arr.Length];
        int latest = -1;
        int totalBitsOne = 0;
        for(int i = 0; i < arr.Length; i++) {
            binary[arr[i] - 1] = '1';
            totalBitsOne = i + 1;
            if (totalBitsOne >= m && findSubstring(m, totalBitsOne)) latest = i + 1;
        }

        return latest;
    }
}

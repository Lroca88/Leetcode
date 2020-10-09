using System;
using System.Collections.Generic;

public class MaxNumRequests {
    int maxRequests;
    int[][] requests;
    int[] buildingBalance;

    public int MaximumRequests(int n, int[][] requests) {
        this.requests = requests;
        buildingBalance = new int[n];
        maxRequests = 0;
        GetMaxRequests(0,0);
        return maxRequests;
    }

    private void GetMaxRequests(int reqIndex, int reqAddressed) {
        if(reqIndex == requests.Length) {
            if (buildingBalanceIsZero())
                maxRequests = Math.Max(reqAddressed, maxRequests);
            return;
        }

        buildingBalance[requests[reqIndex][0]]--;
        buildingBalance[requests[reqIndex][1]]++;
        GetMaxRequests(reqIndex + 1, reqAddressed + 1);
        buildingBalance[requests[reqIndex][0]]++;
        buildingBalance[requests[reqIndex][1]]--;
        GetMaxRequests(reqIndex + 1, reqAddressed);
    }

    private bool buildingBalanceIsZero() {
        for(var k = 0; k < buildingBalance.Length; k++) {
            if (buildingBalance[k] != 0) return false;
        }
        return true;
    }
}



using System;

public class ReverseInteger {
    public int Reverse(int x) {
        long sol = 0;
        int sign = 1;
        int overflowPos = (int) Math.Pow(2, 31) - 1;
        int overflowNeg = (int) (-1 * Math.Pow(2, 31));
        
        if (x < 0) {
            sign = -1;
            x = -x;
        }

        while(x > 0) {
            sol = sol * 10 + x % 10;
            x = x / 10;    
        }

        sol = sign * sol;

        if (sol > overflowPos || sol < overflowNeg) return 0;
        
        return (int) sol;
    }
}
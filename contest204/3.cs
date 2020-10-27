using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SmallestStr {
    public string FindLexSmallestString(string s, int a, int b) {
        string smallest = s;
        int smallestInt = Int32.Parse(s);
        HashSet<string> numbers = new HashSet<string>();
        numbers.Add(smallest);
        
        bool done = false;
        int rotateTimes = s.Length;

        while(!done) {
            s = add(s, a);
            if (!numbers.Contains(s)) {
                numbers.Add(s);
                var num = Int32.Parse(s);
                if (num < smallestInt) {
                    smallestInt = num;
                    smallest = s;
                }
                continue;
            }
            
            foreach(var numStr in numbers.ToList()) {
                s = rotate(numStr, b);
                if (!numbers.Contains(s)) {
                    numbers.Add(s);
                    var num = Int32.Parse(s);
                    if (num < smallestInt) {
                        smallestInt = num;
                        smallest = s;
                    }
                }
            }
            

            rotateTimes--;
            if (rotateTimes == 0) done = true;
        }
        
        return smallest;
    }
    
    private string add(string s, int a) {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++) {
            if (i % 2  != 0) {
                int digit = (s[i] - '0' + a) % 10;
                sb.Append(digit);
            } else {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
    
    private string rotate(string s, int n) {
        StringBuilder sb = new StringBuilder();
        int length = s.Length;
        for(int i = n; i < n + length; i++) {
            sb.Append(s[i % length]);
        }
        return sb.ToString();
    }
}
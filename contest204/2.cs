using System;

public class SplitTwoStrMakePal {
    public bool CheckPalindromeFormation(string a, string b) {
        if (isPalindrome(a) || isPalindrome(b)) return true;
        if (checkCommonIndex(a, b)) return true;
        if (checkCommonIndex(reverse(a), reverse(b))) return true;
        return false;
    }
    
    private bool isPalindrome(string s) {
        int ini = 0;
        int fin = s.Length - 1;
        while(ini < fin) {
            if (s[ini] != s[fin]) return false;
            ini++;
            fin--;
        }
        return true;
    }
    
    public static string reverse(string s) {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
    
    private bool checkCommonIndex(string a, string b) {
        int aLen = a.Length;
        int bLen = b.Length;
        int idxA = 0;
        int idxB = bLen - 1;
        
        while(idxA < idxB) {
            if (a[idxA] != b[idxB]) {
                string subStrA = a.Substring(idxA, idxB - idxA + 1);
                string subStrB = b.Substring(idxA, idxB - idxA + 1);
                return isPalindrome(subStrA) || isPalindrome(subStrB);
            }
            idxA++;
            idxB--;
        }
        
        return true;
    }
}
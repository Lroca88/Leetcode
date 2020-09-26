using System;
using System.Collections.Generic;
using System.Linq;

public class SubsequencesOfString {

    private HashSet<string> subsequences = new HashSet<string>();

    public void FindAllSubsequences(string s) {
        PrintAllSubsequences(s, "");
        foreach (var seq in subsequences) {
            Console.WriteLine(seq);
        }
    }

    private void PrintAllSubsequences(string s, string subsequence)
    {
        if (s.Length == 0) {
            subsequences.Add(subsequence);
            return;
        }

        // Adding 1 character to the subsequnce
        PrintAllSubsequences(s.Substring(1), subsequence + s[0]);
        
        // Dont add any character to the subsequnce
        PrintAllSubsequences(s.Substring(1), subsequence);
    }
}

/*
 Time Complexity: O(2^N * N)   2^N From picking or not a char from s, N from printing the string.
 Space Complexity: O(N^2)      Because I have at most N calls in the callstack storing 2 strings (s and subsequence) of at most N characters
*/
using System.Collections.Generic;
using System.Text;

public class NumberMatchingSubseq {
    public int NumMatchingSubseq(string S, string[] words) {
        int response = 0;
        Dictionary<char, Queue<StringBuilder>> wordsByChar = new Dictionary<char, Queue<StringBuilder>>();
        foreach (var word in words) {
            if (!wordsByChar.ContainsKey(word[0])) 
                wordsByChar[word[0]] = new Queue<StringBuilder>();
            wordsByChar[word[0]].Enqueue(new StringBuilder(word));
        }
        
        foreach(char ch in S) {
            if (!wordsByChar.ContainsKey(ch)) continue;
            Queue<StringBuilder> currentQ = wordsByChar[ch];
            int total = currentQ.Count; 
            for (var i = 0; i < total; i++) {
                StringBuilder currentWord = currentQ.Dequeue();
                currentWord = currentWord.Remove(0,1);    // Improve with String Builder
                if (currentWord.Length > 0) {
                    if (!wordsByChar.ContainsKey(currentWord[0]))
                        wordsByChar[currentWord[0]] = new Queue<StringBuilder>();
                    wordsByChar[currentWord[0]].Enqueue(currentWord);
                } else {
                    response++;
                }
            }
        }
        
        return response;
    }
}

                
/*

Time Complexity: O(N * M)  Where N is the length of the string and M is the number of words
Space Complexity: O(M * L) Because I'm going to have up to M words stored in different queues and L is in the range of [1, 50]

The approach here is having the words in buckets (Queues) and while iterating over the big string,
I get the buckets of the words that start with S[i] and delete from those words that character, 
after that if the new word is not an empty string, I place the word in a new bucket according to initial
letter of the new word.
*/

/*
Given string S and a dictionary of words words, find the number of words[i] that is a subsequence of S.

Example :
Input: 
S = "abcde"
words = ["a", "bb", "acd", "ace"]
Output: 3
Explanation: There are three words in words that are a subsequence of S: "a", "acd", "ace".
Note:

All words in words and S will only consists of lowercase letters.
The length of S will be in the range of [1, 50000].
The length of words will be in the range of [1, 5000].
The length of words[i] will be in the range of [1, 50].
*/

using System.Collections.Generic;

public class WordDictionary {

    private TryNode tryHead, pointer;

    /** Initialize your data structure here. */
    public WordDictionary() {
        tryHead = new TryNode();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        pointer = tryHead;
        foreach(char c in word) {
            if (!pointer.children.ContainsKey(c)) {
                TryNode child = new TryNode(c);
                pointer.children[c] = child;
            }
            pointer = pointer.children[c];
        }
        pointer.isCompleteWord = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return HasPathDFS(tryHead, word, 0);
    }

    private bool HasPathDFS(TryNode node, string word, int index) {
        // If it gets to the end of the word
        if (index == word.Length) {
           return node.isCompleteWord;
        }

        // If the children contains the char I'm looking for, get one level deep
        if (node.children.ContainsKey(word[index]) && HasPathDFS(node.children[word[index]], word, index + 1)) {
            return true;
        }

        // In case the word contains '.' it means we can use any child as the next step
        if (word[index] == '.') {
            foreach(TryNode child in node.children.Values) {
                if (HasPathDFS(child, word, index + 1)) {
                    return true;
                }
            }
        }

        // If we get to this point, there is no path
        return false;
    }
}

public class TryNode {
    private char ch;
    public bool isCompleteWord { get; set; }
    public Dictionary<char, TryNode> children { get; set; }

    public TryNode(char c = '*') {
        ch = c; // This is not necessary but it gives me a better debugging experience
        children = new Dictionary<char, TryNode>();
        isCompleteWord = false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */


/*
Design a data structure that supports the following two operations:

void addWord(word)
bool search(word)
search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.

Example:

addWord("bad")
addWord("dad")
addWord("mad")
search("pad") -> false
search("bad") -> true
search(".ad") -> true
search("b..") -> true

Note:
You may assume that all words are consist of lowercase letters a-z.
*/
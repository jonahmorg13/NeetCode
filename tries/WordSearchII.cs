var sol = new Solution();

var res = sol.FindWords(new char[][] {
  new char[] {'a','b','c','d'},
  new char[] {'s','a','a','t'},
  new char[] {'a','c','k','e'},
  new char[] {'a','c','d','n'}
}, new string[] {"bat","cat","back","backend","stack"});
return 0;
public class Solution {
    private class TrieNode
    {
        public TrieNode[] children;
        public bool isWord;

        public TrieNode()
        {
            children = new TrieNode[26];
            isWord = false;
        }
    }

    private void AddWord(TrieNode root, string word)
    {
        if(root == null) return;

        var currNode = root;
        foreach(var c in word)
        {
            var idx = (int)c - 97;
            if(currNode.children[idx] == null)
            {
                currNode.children[idx] = new TrieNode();
            }
            currNode = currNode.children[idx];
        }
        currNode.isWord = true;        
    }

    public List<string> FindWords(char[][] board, string[] words) {
        var trieRoot = new TrieNode();
        foreach(var word in words)
            AddWord(trieRoot, word);

        var res = new List<string>();

        // make the words into a trie.
        // for each col and row combo. 
        // do a depth first search and use the trie to see if we have a match
        
        // how fast?
        // id assume
        // word_amount * max_word_length + board_length * board_width * dfs


        return res;
    }
}

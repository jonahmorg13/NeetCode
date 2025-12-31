using System.Security.Cryptography.X509Certificates;

WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("day");
wordDictionary.AddWord("bay");
wordDictionary.AddWord("may");
wordDictionary.Search("say"); // return false
wordDictionary.Search("day"); // return true
wordDictionary.Search(".ay"); // return true
wordDictionary.Search("b.."); 
return 0;

public class WordDictionary {
    private class TrieNode
    {
        public Dictionary<char, TrieNode> children;
        public bool isEndOfWord;
        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
        }
    }
    private TrieNode root;
    public WordDictionary() {
        this.root = new TrieNode();
    }
    
    public void AddWord(string word) {
        int idx = 0;
        var currNode = this.root;
        while(idx < word.Length)
        {
            if(!currNode.children.ContainsKey(word[idx]))
                currNode.children[word[idx]] = new TrieNode();

            currNode = currNode.children[word[idx]];
            idx++;
        }
        currNode.isEndOfWord = true;
    }
    
    public bool Search(string word) {
        return RecursiveSearch(word, this.root, 0);
    }

    private bool RecursiveSearch(string word, TrieNode currNode, int start)
    {
        int idx = start;
        while(idx < word.Length)
        {
            if(word[idx] == '.')
            {
                foreach(var node in currNode.children)
                    if(RecursiveSearch(word, node.Value, idx + 1))
                        return true;

                return false;
            }

            if(!currNode.children.ContainsKey(word[idx]))
            {
                return false;
            }
            currNode = currNode.children[word[idx]];
            idx++;
        }
        return currNode.isEndOfWord;
    }
}

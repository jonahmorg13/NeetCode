#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res = sol.WordBreak("neetcode", ["neet", "code"]);

var resTwo = sol.WordBreak("aaaaaaa", ["aaaa", "aaa"]);
Debug.Assert(res == true);
Debug.Assert(resTwo == true);

public class Solution
{
    // come back and figure this out.
    // i wonder if it can be solved the same way as coin change?
    // how does that coin change algorithm actually work?
    public bool WordBreak(string s, List<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        int maxLen = 0;
        foreach(var word in wordDict)
            maxLen = Math.Max(maxLen, word.Length);

        return dfs(s, 0, wordDict, maxLen, wordSet);
    }

    private bool dfs(string s, int start, List<string> wordDict, int maxLen, HashSet<string> wordSet)
    {
        if(start >= s.Length) return true;

        int end = start;
        while(end < s.Length)
        {
            var currStr = s.Substring(start, end - start + 1);
            if(currStr.Length > maxLen)
                return false;

            if(wordDict.Contains(currStr))
                if(dfs(s, end + 1, wordDict, maxLen, wordSet) == true)
                    return true;

            end++;
        }

        return false;
    }
}
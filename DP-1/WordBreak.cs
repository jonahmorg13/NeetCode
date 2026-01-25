#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var resThree = sol.WordBreak("catsincars", ["cats","cat","sin","in","car"]);
var resTwo = sol.WordBreak("aaaaaaa", ["aaaa", "aaa"]);
var res = sol.WordBreak("neetcode", ["neet", "code"]);

Debug.Assert(resThree == false);
Debug.Assert(resTwo == true);
Debug.Assert(res == true);

public class Solution
{
    // come back and figure this out.
    // i wonder if it can be solved the same way as coin change?
    // how does that coin change algorithm actually work?
    public bool WordBreak(string s, List<string> wordDict)
    {
        var cache = new Dictionary<string, bool>();
        return dfs(s, wordDict, cache);
    }

    private bool dfs(string s, List<string> wordDict, Dictionary<string, bool> cache)
    {
        if(s.Length <= 0) return true;
        if(cache.ContainsKey(s)) return cache[s];

        var res = false;
        foreach(var word in wordDict)
        {
            var currStrIdx = s.IndexOf(word);
            if(currStrIdx == 0)
            {
                var newStr = s.Substring(word.Length);
                if(res == false)
                    res = dfs(newStr, wordDict, cache);
            }
        }

        cache[s] = res;
        return res;
    }
}
#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res = sol.WordBreak("neetcode", ["neet", "code"]);
var resThree = sol.WordBreak("catsincars", ["cats","cat","sin","in","car"]);
var resTwo = sol.WordBreak("aaaaaaa", ["aaaa", "aaa"]);

Debug.Assert(resThree == false);
Debug.Assert(resTwo == true);
Debug.Assert(res == true);

public class Solution
{
    public bool WordBreak(string s, List<string> wordDict)
    {
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;

        for(int i = 1; i <= s.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                if(dp[j] && wordDict.Contains(s.Substring(j, i -j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}
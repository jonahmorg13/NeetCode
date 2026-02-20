using System.Diagnostics;

var sol = new Solution();
var res = sol.Partition("aab");
Debug.Assert(res.Count == 2);
Console.WriteLine(res.ToString());

public class Solution {

    public List<List<string>> Partition(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] &&
                                    (i + 1 > (i + l - 2) ||
                                    dp[i + 1, i + l - 2]));
            }
        }

        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        Dfs(0, s, part, res, dp);
        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res, bool[,] dp) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) {
                part.Add(s.Substring(i, j - i + 1));
                Dfs(j + 1, s, part, res, dp);
                part.RemoveAt(part.Count - 1);
            }
        }
    }
}
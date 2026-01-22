using System.Diagnostics;

var sol = new Solution();

var res2 = sol.CountSubstrings("aaaaa");
var res3 = sol.CountSubstrings("a");
var res4 = sol.CountSubstrings("aa");
Debug.Assert(res2 == 15);
Debug.Assert(res3 == 1);
Debug.Assert(res4 == 3);

public class Solution {
    public int CountSubstrings(string s) {
        if(String.IsNullOrWhiteSpace(s)) return 0;

        var res = 0;
        int n = s.Length;
        bool[,] cache = new bool[n, n];

        for(int i = n - 1; i >= 0; i--)
        {
            for(int j = i; j < n; j++)
            {
                if(s[i] == s[j] && (j - i <= 2 || cache[i + 1, j - 1] == true))
                {
                    cache[i, j] = true;
                    res++;
                }
            }
        }

        return res;
    }
}

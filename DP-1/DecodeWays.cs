using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

var sol = new Solution();
var res = sol.NumDecodings("12");
Debug.Assert(res == 2);

public class Solution {
    public int NumDecodings(string s)
    {
        int Dfs(int i)
        {
            if(i == s.Length) return 1;
            if(s[i] == '0') return 0;

            int res = Dfs(i + 1);
            if(i < s.Length - 1)
            {
                if(s[i] == '1' ||
                (s[i] == '2' && s[i + 1] < '7'))
                {
                    res += Dfs(i + 2);
                }
            }
            return res;
        }
        
        return Dfs(0);
    }
}
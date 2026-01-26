using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

var sol = new Solution();
var res = sol.CountBits(4);
Debug.Assert(res.SequenceEqual([0,1,1,2,1]));
public class Solution
{
    public int[] CountBits(int n)
    {
        int[] res = new int[n + 1];
        for(int i = 0; i <= n; i++)
        {
            var currNum = i;
            var currRes = 0;
            while(currNum > 0)
            {
                if((currNum & 1) == 1) currRes++;
                currNum = currNum >> 1;
            }
            res[i] = currRes;
        }
        return res;
    }
}
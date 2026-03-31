using System.Diagnostics;

var sol = new Solution();
var res = sol.PartitionLabels("xyxxyzbzbbisl");
Debug.Assert(res.SequenceEqual([5,5,1,1,1]));
return 0;

public class Solution
{
    public List<int> PartitionLabels(string s)
    {
        var lastIndex = new int[26];
        for(int i = 0; i < s.Length; i++)
            lastIndex[s[i] - 'a'] = i;

        var res = new List<int>();
        int start = 0, end = 0;
        for(int i = 0; i < s.Length; i++)
        {
            end = Math.Max(end, lastIndex[s[i] - 'a']);
            if(i == end)
            {
                res.Add(end - start + 1);
                start = i + 1;
            }
        }

        return res;
    }
}
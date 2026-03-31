using System.Diagnostics;

var sol = new Solution();
var res = sol.PartitionLabels("xyxxyzbzbbisl");
Debug.Assert(res.SequenceEqual([5,5,1,1,1]));
return 0;

public class Solution
{
    public List<int> PartitionLabels(string s)
    {
        var firstAppearances = new Dictionary<char, int>();
        var intervals = new List<(int, int)>();

        for(int i = 0; i < s.Length; i++)
        {
            var currChar = s[i];
            if(!firstAppearances.ContainsKey(currChar))
            {
                firstAppearances[currChar] = i;
                intervals.Add((i, i));
                continue;        
            }

            // we have a first appearance. lets update our intervals!
            var charFirstIndex = firstAppearances[currChar];
            while(i > intervals[intervals.Count - 1].Item2 && charFirstIndex < intervals[intervals.Count  - 1].Item1)
                intervals.RemoveAt(intervals.Count - 1);
            intervals[intervals.Count - 1] = (intervals[intervals.Count - 1].Item1, i);
        }

        var res = new List<int>();
        for(int i = 0; i < intervals.Count; i++)
            res.Add(intervals[i].Item2 - intervals[i].Item1 + 1);
        return res;
    }
}
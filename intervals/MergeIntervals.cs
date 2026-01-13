var sol = new Solution();
var res = sol.Merge([[1,3],[1,5],[6,7]]);
var res2 = sol.Merge([[1,4],[0,0]]);
return 0;

public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals.Length <= 1) return intervals;

        Array.Sort(intervals, Comparer<int[]>.Create((x,y) => x[0].CompareTo(y[0])));

        var res = new List<int[]>();
        for(int i = 1; i < intervals.Length; i++)
        {
            if(intervals[i - 1][1] < intervals[i][0])
                res.Add(intervals[i - 1]);
            else
            {
                intervals[i][0] = Math.Min(intervals[i][0], intervals[i - 1][0]);
                intervals[i][1] = Math.Max(intervals[i][1], intervals[i - 1][1]);
            }
        }

        res.Add(intervals[intervals.Length - 1]);
        return res.ToArray();
    }
}
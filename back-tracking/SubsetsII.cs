using System.Diagnostics.CodeAnalysis;

var sol = new Solution();
var res = sol.SubsetsWithDup([1,2,1]);
return 0;

public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        var sol = new List<List<int>>();
        var currSeq = new List<int>();
        dfs(nums, 0, currSeq, sol);
        return sol;
    }

    private void dfs(int[] nums, int i, List<int> currSeq, List<List<int>> sol)
    {
        // handle duplicates here
        var seq = currSeq.OrderBy(x => x);
        var found = false;
        foreach(var s in sol)
        {
            if(seq.SequenceEqual(s))
            {
                found = true;
            }
        }
        if(!found) sol.Add(new List<int>(seq.OrderBy(x => x)));

        if(i >= nums.Length)
        {
            return;
        }

        currSeq.Add(nums[i]);
        dfs(nums, i + 1, currSeq, sol);
        currSeq.RemoveAt(currSeq.Count - 1);
        dfs(nums, i + 1, currSeq, sol);
    }

}

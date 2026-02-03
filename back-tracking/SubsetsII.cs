using System.Diagnostics.CodeAnalysis;

var sol = new Solution();
var res = sol.SubsetsWithDup([1,2,1]);
return 0;

public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        var sol = new List<List<int>>();
        var currSeq = new List<int>();
        Array.Sort(nums);
        dfs(nums, 0, currSeq, sol);
        return sol;
    }

    private void dfs(int[] nums, int i, List<int> currSeq, List<List<int>> sol)
    {
        if(i >= nums.Length)
        {
            sol.Add(new List<int>(currSeq));
            return;
        }

        currSeq.Add(nums[i]);
        dfs(nums, i + 1, currSeq, sol);
        currSeq.RemoveAt(currSeq.Count - 1);

        // this is how we handle duplicates
        while(i + 1 < nums.Length && nums[i] == nums[i + 1])
            i++;

        dfs(nums, i + 1, currSeq, sol);
    }

}

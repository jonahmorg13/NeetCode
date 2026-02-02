using System.Diagnostics;

var sol = new Solution();
var res = sol.Permute([1,2,3]);
List<List<int>> expected = [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]];
Debug.Assert(expected.Count == res.Count);
for(int i = 0; i < res.Count; i++)
{
    Debug.Assert(expected[i].SequenceEqual(res[i]));
}

public class Solution {
    public List<List<int>> Permute(int[] nums)
    {
        var sol = new List<List<int>>();
        var currSeq = new List<int>();
        dfs(nums.ToList(), currSeq, sol, nums.Length);
        return sol;
    }

    private void dfs(List<int> nums, List<int> currSeq, List<List<int>> sol, int sollen)
    {
        if(currSeq.Count == sollen)
        {
            sol.Add(new List<int>(currSeq));
            return;
        }

        for(int i = 0; i < nums.Count; i++)
        {
            currSeq.Add(nums[i]);
            var nextNums = new List<int>(nums);
            nextNums.RemoveAt(i);
            dfs(nextNums, currSeq, sol, sollen);
            currSeq.RemoveAt(currSeq.Count - 1);
        }
    }
}

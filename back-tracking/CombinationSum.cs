#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res = sol.CombinationSum([2,5,6,9], 9);
Console.WriteLine(res);

public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var res = new List<List<int>>();
        var currSol = new List<int>();
        dfs(nums, target, 0, 0, res, currSol);
        return res;
    }

    public void dfs(int[] nums, int target, int i, int currSum, List<List<int>> res, List<int> currSol)
    {
        if(currSum > target || i >= nums.Length)
        {
            if(currSum == target)
            {
                var newSol = new List<int>(currSol);
                res.Add(newSol);
            }
            return;
        }
        if(currSum == target)
        {
            var newSol = new List<int>(currSol);
            res.Add(newSol);
            return;
        }

        currSol.Add(nums[i]);
        currSum += nums[i];
        dfs(nums, target, i, currSum, res, currSol);
        currSol.RemoveAt(currSol.Count - 1);
        currSum -= nums[i];
        dfs(nums, target, i + 1, currSum, res, currSol);
    }
}

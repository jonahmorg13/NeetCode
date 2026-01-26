using System.Diagnostics;

var sol = new Solution();
var res = sol.CanPartition([1,2,3,4]);
Debug.Assert(res == true);

public class Solution {
    public bool CanPartition(int[] nums)
    {
        return dfs(nums, 0, 0, 0);
    }

    //todo: do this as an iterative bottom up approach instead of a top down approach
    private bool dfs(int[] nums, int i, int leftSum, int rightSum)
    {
        if(i >= nums.Length)
            return leftSum == rightSum;

        var left = dfs(nums, i + 1, leftSum + nums[i], rightSum);
        var right = dfs(nums, i + 1, leftSum, rightSum + nums[i]);
        return left || right;
    }
}

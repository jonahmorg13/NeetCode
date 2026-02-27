using System.Diagnostics;

var sol = new Solution();
var res  = sol.CanJump([1,2,0,1,0]);
Debug.Assert(res == true);
res = sol.CanJump([1,2,1,0,1]);
Debug.Assert(res == false);

public class Solution {
    public bool CanJump(int[] nums) {
        return recursiveJumpGame(nums, 0);        
    }

    private bool recursiveJumpGame(int[] nums, int i)
    {
        if(i >= nums.Length - 1)
            return true;

        int currNum = nums[i];
        if(currNum == 0)
            return false;

        for(int j = currNum; j >= 1; j--)
            if(recursiveJumpGame(nums, i + j)) return true;

        return false;
    }
}

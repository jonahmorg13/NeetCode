using System.Diagnostics;

var sol = new Solution();
var res  = sol.CanJump([1,2,0,1,0]);
Debug.Assert(res == true);
res = sol.CanJump([1,2,1,0,1]);
Debug.Assert(res == false);

public class Solution {
    public bool CanJump(int[] nums)
    {
        int goal = nums.Length - 1;

        for(int i = nums.Length - 2; i >= 0; i--)
            if(i + nums[i] >= goal)
                goal = i;

        return goal == 0;
    }
}

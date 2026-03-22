#:property PublishAot=false

using System.Diagnostics;

var sol = new Solution();
var res = sol.MaxSubArray([2,-3,4,-2,2,1,-1,4]);
Debug.Assert(res == 8);

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int maxSub = nums[0];
        int currSum = 0;

        foreach(var num in nums)
        {
            if(currSum < 0)
                currSum = 0;
            currSum += num;
            maxSub = Math.Max(maxSub, currSum);
        }

        return maxSub;
    }
}
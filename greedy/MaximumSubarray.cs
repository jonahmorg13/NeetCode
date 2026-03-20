#:property PublishAot=false

using System.Diagnostics;

var sol = new Solution();
var res = sol.MaxSubArray([2,-3,4,-2,2,1,-1,4]);
Debug.Assert(res == 8);

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int res = Int32.MinValue;
        for(int i = 0; i < nums.Length; i++)
        {
            var currSubArray = 0;
            for(int j = i; j < nums.Length; j++)
            {
                currSubArray += nums[j];
                res = Math.Max(res, currSubArray);
            }
        }
        return res;
    }
}
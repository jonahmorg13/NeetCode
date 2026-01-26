using System.Diagnostics;

var sol = new Solution();
var res = sol.MaxProduct([1,2,-3,4]);
var res2 = sol.MaxProduct([-2,-1]);
var res3 = sol.MaxProduct([10,0,5,6,0,10]);
Debug.Assert(res == 4);
Debug.Assert(res2 == 2);
Debug.Assert(res3 == 30);

public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int res = nums[0];
        for(int i = 0; i < nums.Length; i++)
        {
            int currProduct = nums[i];
            res = Math.Max(res, nums[i]);
            for(int j = i + 1; j < nums.Length; j++)
            {
                currProduct *= nums[j];
                res = Math.Max(res, currProduct);
            }
        }
        return res;
    }    
}
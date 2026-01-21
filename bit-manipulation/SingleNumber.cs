using System.Diagnostics;

var sol = new Solution();
var res = sol.SingleNumber([3,2,3]);
Debug.Assert(res == 2);
res = sol.SingleNumber([7,6,6,7,8]);
Debug.Assert(res == 8);

public class Solution {
    public int SingleNumber(int[] nums) {
        int res = 0;
        for(int i = 0; i < nums.Length; i++) 
            res ^= nums[i];
        return res;
    }
}

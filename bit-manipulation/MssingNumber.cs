using System.Diagnostics;

var sol = new Solution();
var res = sol.MissingNumber([1,2,3]);
Debug.Assert(res == 0);

public class Solution {
    public int MissingNumber(int[] nums) {
        var n = nums.Length;
        int res = n;
        for(int i = 0; i < nums.Length; i++)
            res ^= i ^ nums[i];
        return res;
    }
}

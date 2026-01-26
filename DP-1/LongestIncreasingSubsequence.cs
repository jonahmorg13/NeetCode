#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res2 = sol.LengthOfLIS([0,1,0,3,2,3]);
Debug.Assert(res2 == 4);

var res = sol.LengthOfLIS([9,1,4,2,3,3,7]);
Debug.Assert(res == 4);

public class Solution {
    public int LengthOfLIS(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return 1;

        int res = 1;

        var idx_amount = new Dictionary<int, Tuple<int, int>>();
        idx_amount[nums.Length - 1] = new Tuple<int, int>(nums[nums.Length - 1], 1);
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            int curr_max_len = 1;
            for(int j = i + 1; j < nums.Length; j++)
            {
                var (min_needed, amt)= idx_amount[j];
                if(nums[i] < min_needed)
                {
                    curr_max_len = Math.Max(curr_max_len, amt + 1);
                    idx_amount[i] = new Tuple<int, int>(nums[i], curr_max_len);
                }
                else
                    idx_amount[i]= new Tuple<int, int>(nums[i], curr_max_len);
            }
            res = Math.Max(res, idx_amount[i].Item2);
        }        

        return res;
    }
}

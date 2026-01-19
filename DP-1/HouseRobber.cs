using System.Diagnostics;

var sol = new Solution();
var res1 = sol.Rob([1,1,3,3]);
var res2 = sol.Rob([2,9,8,3,6]);
Debug.Assert(res1 == 4);
Debug.Assert(res2 == 16);
public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length <= 0) return 0;
        else if (nums.Length == 1) return nums[0];
        else if(nums.Length == 2) return Math.Max(nums[0], nums[1]);

        Span<int> cache = stackalloc int[nums.Length];
        cache[nums.Length - 1] = nums[nums.Length - 1];
        cache[nums.Length - 2] = nums[nums.Length - 2];
        for(int i = nums.Length - 3; i >= 0; i--)
        {
            cache[i] = Math.Max(nums[i] + cache[i + 2], cache[i + 1]);
        }

        return cache[0];
    }
}

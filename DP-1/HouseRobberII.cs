using System.Diagnostics;

var sol = new Solution();
var res = sol.Rob([3,4,3]);
Debug.Assert(res == 4);

public class Solution {
    public int Rob(int[] nums)
    {
        if(nums.Length <= 0) return 0;
        else if (nums.Length == 1) return nums[0];
        else if(nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int[] first = new int[nums.Length - 1];
        int[] copy = new int[nums.Length - 1];
        Array.Copy(nums, 0, first, 0, nums.Length - 1);
        Array.Copy(nums, 1, copy, 0, nums.Length - 1);
        return Math.Max(InternalRob(first), InternalRob(copy));
    }

    private int InternalRob(int[] nums) {
        if(nums.Length <= 0) return 0;
        else if (nums.Length == 1) return nums[0];
        else if(nums.Length == 2) return Math.Max(nums[0], nums[1]);

        Span<int> cache = stackalloc int[nums.Length];
        cache[nums.Length - 1] = nums[nums.Length - 1];
        cache[nums.Length - 2] = Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);
        for(int i = nums.Length - 3; i >= 0; i--)
        {
            cache[i] = Math.Max(nums[i] + cache[i + 2], cache[i + 1]);
        }

        return cache[0];
    } 
}

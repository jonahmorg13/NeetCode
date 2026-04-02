using System.Diagnostics;

var sol = new Solution();
var res = sol.Jump([2,3,0,1,4]);
Debug.Assert(res == 2);

public class Solution {
    public int Jump(int[] nums) {
        var length = nums.Length;
        if(length <= 1) return 0;
        nums[length - 1] = 0;
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            var minJmps = int.MaxValue;
            var currJumpAmt = nums[i];
            int j = i + 1;
            int count = 1;
            while(j < nums.Length && count <= currJumpAmt)
            {
                if(nums[j] != -1)
                    minJmps = Math.Min(minJmps, nums[j]);

                j++;
                count++;
            }
            if(j >= nums.Length) nums[i] = 1;
            else if(minJmps == int.MaxValue)
            {
                nums[i] = -1;
            }
            else
            {
                nums[i] = minJmps + 1;
            }
        }
        return nums[0];
    }
}

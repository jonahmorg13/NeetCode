using System.Data;
using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.MaxSlidingWindow([1,2,1,0,4,2,6], 3).SequenceEqual([2,2,4,4,6]));
return 0;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var queue = new PriorityQueue<(int val, int idx), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var res = new List<int>();

        var numsCount = nums.Count();
        for(int i = 0; i < numsCount; i++)
        {
            queue.Enqueue((nums[i], i), nums[i]);
            if(i >= k - 1)
            {
                while(queue.Peek().idx <= i - k)
                {
                    queue.Dequeue();
                }
                res.Add(queue.Peek().val);
            }

        }

        return res.ToArray();
    }
}

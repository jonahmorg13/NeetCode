using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

var sol = new Solution();
var res = sol.MinCostClimbingStairs([1,2,1,2,1,1,1]);
var resTwo = sol.MinCostClimbingStairs([1,2,3]);

var resThree = sol.MinCostClimbingStairs([1,100,1,1,1,100,1,1,100,1]);
Debug.Assert(res == 4);
Debug.Assert(resTwo == 2);
Debug.Assert(resThree == 6);

// ok now we need to memoize this
public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        if(n <= 0) return 0;
        else if(n <= 1) return cost[0];
        else if(n <= 2) return Math.Min(cost[0], cost[1]);

        Span<int> cache = stackalloc int[n];

        cache[0] = cost[0];
        cache[1] = cost[1];
        for(int i = 2; i < n; i++)
            cache[i] = Math.Min(cache[i - 2], cache[i - 1]) + cost[i];

        return Math.Min(cache[n - 1], cache[n - 2]);
    }
}

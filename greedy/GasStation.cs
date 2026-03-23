using System.Diagnostics;

var sol = new Solution();
var res = sol.CanCompleteCircuit([1,2,3,4], [2,2,4,1]);
Debug.Assert(res == 3);

public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        if(gas.Sum() < cost.Sum()) return -1;
        var res = 0;
        var total = 0;
        for(int i = 0; i < gas.Length; i++)
        {
            var diff = gas[i] - cost[i];
            total += diff;
            if(total < 0)
            {
                total = 0;
                res = i + 1;
            }
        }
        return res;        
    }
}

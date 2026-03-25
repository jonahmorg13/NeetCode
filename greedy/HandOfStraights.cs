using System.Diagnostics;
using System.Text.RegularExpressions;

var sol = new Solution();
var res = sol.IsNStraightHand([1,2,4,2,3,5,3,4], 4);
Debug.Assert(res == true);

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0) return false;

        var count = new Dictionary<int, int>();
        foreach(var num in hand)
            count[num] = count.GetValueOrDefault(num, 0) + 1;

        Array.Sort(hand);
        foreach(var num in hand)
        {
            if(count[num] > 0)
            {
                for(int i = num; i < num + groupSize; i++)
                {
                    if(!count.ContainsKey(i) || count[i] == 0)
                    {
                        return false;
                    }
                    count[i]--;
                }
            }
        }
        return true;
    }
}

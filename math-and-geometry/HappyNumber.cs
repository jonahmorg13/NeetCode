using System.Diagnostics;

var sol = new Solution();

var res = sol.IsHappy(100);
Debug.Assert(res == true);

res = sol.IsHappy(101);
Debug.Assert(res == false);

public class Solution {
    public bool IsHappy(int n) {
        var seen = new HashSet<int>();
        var currNum = n;
        while(currNum != 1)
        {
            int currAns = 0;
            while(currNum > 0)
            {
                currAns += (int)Math.Pow(currNum % 10, 2);
                currNum /= 10;
            }
            currNum = currAns;
            if(currAns == 1) return true;
            if(seen.Contains(currAns)) return false;
            seen.Add(currAns);
        }
        return true;
    }
}

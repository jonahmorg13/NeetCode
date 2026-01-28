using System.Diagnostics;

var sol = new Solution();
var res = sol.GetSum(1, 1);

Debug.Assert(res is 2);
Debug.Assert(sol.GetSum(1, -1) == 0);
Debug.Assert(sol.GetSum(1, -2) == -1);

public class Solution {
    public int GetSum(int a, int b) {
        while (b != 0) {
            int carry = (a & b) << 1;
            a ^= b;
            b = carry;
        }
        return a;
    }
}
using System.Diagnostics;

var sol = new Solution();
var res = sol.MyPow(2.0, 5);
Debug.Assert(res == 32.0);
Debug.Assert(sol.MyPow(2.0, -2) == 0.25);
Debug.Assert(sol.MyPow(2.0, 0) == 1.0);

public class Solution {
    public double MyPow(double x, int n) {
        double res = x;
        if(n == 0) return 1;
        var amt = Math.Abs(n);
        for(int i = 1; i < amt; i++)
            res = res * x;
        if(n < 0) res = 1 / res;
        return res;
    }
}

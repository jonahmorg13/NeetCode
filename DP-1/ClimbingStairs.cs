#:property PublishAot=false
using System.Diagnostics;
using System.Runtime.CompilerServices;

var sol = new Solution();
var res = sol.ClimbStairs(2);
var resTwo = sol.ClimbStairs(3);
Debug.Assert(res == 2);
Debug.Assert(resTwo == 3);

// ok so this passes the test cases. but how do i make it so it's using 
// memoization?
public class Solution {
    public int ClimbStairs(int n) {     
        if(n <= 2) return n;
        Span<int> cache = stackalloc int[n + 1]; 
        cache[1] = 1;
        cache[2] = 2;
        for(int i = 3; i <= n; i++)
            cache[i] = cache[i - 1] + cache[i - 2];

        return cache[n];
    }
}

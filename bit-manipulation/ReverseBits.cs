using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

var sol = new Solution();
var res = sol.ReverseBits(21);
Console.WriteLine(Convert.ToString(res, 2));
return 0;

public class Solution {
    public uint ReverseBits(uint n) {
        uint res = 0;
        uint currBit = (uint)1 << 31;

        for(int i = 0; i < 32; i++)
        {
            if((n & 1) == 1) res += currBit;
            n = n >> 1;
            currBit = currBit >> 1;
        }        

        return res;
    }
}

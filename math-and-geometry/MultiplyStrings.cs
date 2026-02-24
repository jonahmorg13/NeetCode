using System.Diagnostics;
using System.Text;

var sol = new Solution();
var res = sol.Multiply("003", "04");
Debug.Assert(res == "12");
res = sol.Multiply("123", "456");
Debug.Assert(res == "56088");
res = sol.Multiply("0", "0");
Debug.Assert(res == "0");

public class Solution {
    public string Multiply(string num1, string num2) {
        if(num1 == "0" || num2 == "0")
            return "0";

        int[] res = new int[num1.Length + num2.Length];
        num1 = new string(num1.Reverse().ToArray());
        num2 = new string(num2.Reverse().ToArray());
        for(int i1 = 0; i1 < num1.Length; i1++)
        {
            for(int i2 = 0; i2 < num2.Length; i2++)
            {
                int digit = (num1[i1] - '0') * (num2[i2] - '0');
                res[i1 + i2] += digit;
                res[i1 + i2 + 1] += res[i1 + i2] / 10;
                res[i1 + i2] %= 10;
            }
        }

        Array.Reverse(res);
        int beg = 0;
        while(beg < res.Length && res[beg] == 0)
        {
            beg++;
        }

        string[] result = res.Skip(beg).Select(x => x.ToString()).ToArray();
        return string.Join("", result);
    }
}

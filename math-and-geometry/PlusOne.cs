using System.Diagnostics;

var sol = new Solution();
var res = sol.PlusOne([9,9,9]);
Debug.Assert(res.SequenceEqual([1,0,0,0]));

res = sol.PlusOne([1,2,3,4]);
Debug.Assert(res.SequenceEqual([1,2,3,5]));

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        var res = new List<int>(digits);
        int i = digits.Length - 1;
        bool addOne = true;
        while(i >= 0 && addOne)
        {
            var newNum = res[i] + 1;
            if(newNum == 10)
                newNum = 0;
            else
                addOne = false;
            res[i] = newNum;
            i--;
        }
        if(addOne)
        {
            res.Insert(0, 1);
        }
        return res.ToArray();
    }
}
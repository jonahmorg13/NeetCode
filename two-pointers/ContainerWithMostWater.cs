using System.Diagnostics;

int MaxArea(int[] heights)
{
    var l = 0;
    var r = heights.Length - 1;
    var res = -1;

    while(l < r)
    {
        res = Math.Max(res, Math.Min(heights[l],heights[r]) * (r-l));
        if(heights[l] > heights[r])
        {
            r--;
        }
        else
        {
            l++;
        }
    }

    return res;
}

Debug.Assert(MaxArea([1,7,2,5,4,7,3,6]) == 36);
Debug.Assert(MaxArea([2,2,2]) == 4);
Debug.Assert(MaxArea([1,7,2,5,12,3,500,500,7,8,4,7,3,6]) == 500);

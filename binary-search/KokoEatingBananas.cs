using System.Diagnostics;

int MinEatingSpeed(int[] piles, int h)
{
    Array.Sort(piles);

    var left = 1;
    var right = piles[piles.Length - 1];

    var min = Int32.MaxValue;
    while(left <= right)
    {
        var rate = left + (right - left) / 2;
        var totalHours = 0;
        // instead of simulating hour by hour, we can just calculate the amount of hours it would take to eat
        // from each pile and have that be a running sum
        for(int i = 0; i < piles.Length; i++)
        {
            totalHours += (piles[i] + rate - 1) / rate;
        }
        // we have successfully eaten all of the bananas
        if(totalHours <= h)
        {
            right = rate - 1;
            min = Math.Min(min, rate);
        }
        else if(totalHours > h)
        {
            left = rate + 1;
        }
    }

    return min;
}

Debug.Assert(MinEatingSpeed([1,4,3,2], 9) == 2);
Debug.Assert(MinEatingSpeed([25, 10, 23, 4], 4) == 25);
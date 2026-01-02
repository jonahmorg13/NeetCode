Console.WriteLine("hello!");
var sol = new Solution();
Console.WriteLine(sol.MaxProfit([10,1,5,6,7,1]));
return 0;

public class Solution {
    public int MaxProfit(int[] prices) {
        //we could use two pointers. one that iterates through all of the days.
        // the second one would be current lowest point so we can get a new max
        int lowest = 0;
        int res = 0;
        int size = prices.Count();
        for(int i = 1; i < size; i++)
        {
            int currDiff = prices[i] - prices[lowest];

            if(prices[i] < prices[lowest])
                lowest = i;
            
            res = Math.Max(res, currDiff);
        }

        return res;
    }
}

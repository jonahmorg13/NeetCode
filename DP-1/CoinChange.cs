
using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.CoinChange([1], 0) == 0);
Debug.Assert(sol.CoinChange([2], 3) == -1);
Debug.Assert(sol.CoinChange([1,2,5], 11) == 3);

var res = sol.CoinChange([2], 4);
Debug.Assert(res == 2);

public class Solution {

    private void coin_dfs(int[] coins, int amount, int i, int currSum, int currCoinCount, ref int res)
    {
        if(i >= coins.Length || currSum > amount) return;

        int amt_coins_to_fit_amount = (amount - currSum) / coins[i];

        for(int j = 0; j < amt_coins_to_fit_amount; j++)
        {
            currSum += coins[i];
            currCoinCount += 1;

            if(currSum == amount)
                res = res == -1 ? currCoinCount : Math.Min(res, currCoinCount);

            coin_dfs(coins, amount, i + 1, currSum, currCoinCount, ref res);
        }
        currSum -= amt_coins_to_fit_amount * coins[i];
        currCoinCount -= amt_coins_to_fit_amount;
        coin_dfs(coins, amount, i + 1, currSum, currCoinCount, ref res);
    }

    public int CoinChange(int[] coins, int amount) {
        if(amount == 0) return 0 ;
        int res = -1;
        coin_dfs(coins, amount, 0, 0, 0, ref res);
        return res;
    }
}

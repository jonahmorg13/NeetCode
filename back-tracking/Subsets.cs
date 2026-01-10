public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        var res = new List<List<int>>();
        var sol = new List<int>();
        dfs(nums, 0, res, sol);
        return res;        
    }

    private void dfs(int[] nums, int i, List<List<int>> res, List<int> sol)
    {
        if(i >= nums.Length)
        {
            res.Add(new List<int>(sol));
            return;
        }

        sol.Add(nums[i]);
        dfs(nums, i + 1, res, sol);
        sol.RemoveAt(sol.Count - 1);
        dfs(nums, i + 1, res, sol);
    }
}

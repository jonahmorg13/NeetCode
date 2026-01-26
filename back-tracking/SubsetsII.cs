using System.Diagnostics.CodeAnalysis;

var sol = new Solution();
var res = sol.SubsetsWithDup([1,2,1]);
return 0;

public class Solution {
    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null || y == null) return false;
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<int> obj)
        {
            if (obj == null) return 0;
            int hash = 17;
            foreach (var item in obj)
            {
                hash = hash * 31 + item.GetHashCode();
            }
            return hash;
        }
    }

    public List<List<int>> SubsetsWithDup(int[] nums) {
        var sets = new HashSet<List<int>>(new ListComparer());
        var subset = new List<int>();
        dfs(nums, 0, subset, ref sets);
        return sets.ToList();
    }

    private void dfs(int[] nums, int i, List<int> subset, ref HashSet<List<int>> sets)
    {
        var newSubset = new List<int>(subset);
        if(!sets.Contains(newSubset))
            sets.Add(newSubset);

        if(i >= nums.Length)
            return;

        newSubset.Add(nums[i]);
        dfs(nums, i + 1, newSubset, ref sets);
        dfs(nums, i + 2, newSubset, ref sets);
    }
}

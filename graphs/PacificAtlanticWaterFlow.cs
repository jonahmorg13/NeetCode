using System.Diagnostics;

var sol = new Solution();
var res = sol.PacificAtlantic([
  [4,2,7,3,4],
  [7,4,6,4,7],
  [6,3,5,3,6]
]);

Debug.Assert(res.Count == 8);

public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int rows = heights.Length;
        int cols = heights[0].Length;

        var atlantic = new HashSet<(int, int)>();
        var pacific = new HashSet<(int, int)>();

        for(int r = 0; r < rows; r++)
        {
            Dfs(heights, r, cols - 1, atlantic, Int32.MinValue);
            Dfs(heights, r, 0, pacific, Int32.MinValue);
        }

        for(int c = 0; c < cols; c++)
        {
            Dfs(heights, 0, c, pacific, Int32.MinValue);
            Dfs(heights, rows - 1, c, atlantic, Int32.MinValue);
        }

        var res = new List<List<int>>();
        atlantic.IntersectWith(pacific);
        foreach(var (r, c) in atlantic)
            res.Add([r, c]);
        return res;
    }

    private void Dfs(int[][] heights, int r, int c, HashSet<(int, int)> visited, int prevHeight)
    {
        if(r < 0 || c < 0 || r >= heights.Length || c >= heights[0].Length)
            return;
        if(heights[r][c] < prevHeight)
            return;
        if(visited.Contains((r, c)))
            return;

        visited.Add((r, c));
        Dfs(heights, r - 1, c, visited, heights[r][c]);
        Dfs(heights, r + 1, c, visited, heights[r][c]);
        Dfs(heights, r, c - 1, visited, heights[r][c]);
        Dfs(heights, r, c + 1, visited, heights[r][c]);
    }
}

using System.Diagnostics;

var sol = new Solution();
int[][] grid = [
    [2147483647,-1,0,2147483647],
    [2147483647,2147483647,2147483647,-1],
    [2147483647,-1,2147483647,-1],
    [0,-1,2147483647,2147483647]
];

int[][] expected = [
    [3,-1,0,1],
    [2,2,1,-1],
    [1,-1,2,-1],
    [0,-1,3,4]
];

sol.islandsAndTreasure(grid);
Debug.Assert(sol.AreEqual(grid, expected));

public class Solution
{
    private const int INF = 2147483647;

    public void islandsAndTreasure(int[][] grid)
    {
        var currDist = 0;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                DFS(i, j, currDist, grid);
            }
        }
    }

    private void DFS(int i, int j, int currDist, int[][] grid)
    {
        // water cells cant be traversed.
        if(grid[i][j] == -1) return;
        if(grid[i][j] != 0 && currDist == 0) return;
        if(currDist != 0 && grid[i][j] == 0) return;
        if(currDist != 0 && grid[i][j] <= currDist) return;
        
        int[] left = new int[]{i, j - 1};
        int[] right = new int[]{i, j + 1};
        int[] up = new int[]{i - 1, j};
        int[] down = new int[]{i + 1, j};

        grid[i][j] = currDist;
        currDist++;

        if(left[1] >= 0) DFS(left[0], left[1], currDist, grid);
        if(right[1] < grid[i].Length) DFS(right[0], right[1], currDist, grid);
        if(up[0] >= 0) DFS(up[0], up[1], currDist, grid);
        if(down[0] < grid.Length) DFS(down[0], down[1], currDist, grid);
    }


  public bool AreEqual(int[][] a, int[][] b)
  {
      if (a.Length != b.Length) return false;
      for (int i = 0; i < a.Length; i++)
      {
          if (!a[i].SequenceEqual(b[i])) return false;
      }
      return true;
  }
}

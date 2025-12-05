using System.Diagnostics;

var sol = new Solution();

Debug.Assert(sol.NumIslands([
    ['0','1','1','1','0'],
    ['0','1','0','1','0'],
    ['1','1','0','0','0'],
    ['0','0','0','0','0']
  ]) == 1);

Debug.Assert(sol.NumIslands([
    ['1','1','0','0','1'],
    ['1','1','0','0','1'],
    ['0','0','1','0','0'],
    ['0','0','0','1','1']
  ]) == 4);

public class Solution {
    private class NumIslandsSolver
    {
        private char[][] grid;
        private HashSet<Tuple<int,int>> visited;

        public NumIslandsSolver(char[][] grid)
        {
            this.grid = grid;
            this.visited = new HashSet<Tuple<int, int>>();
        }

        public int SolveIsland()
        {
            var numIslands = 0;

            for(int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] != '1') continue;

                    var currLoc = new Tuple<int,int>(j, i);
                    if(visited.Contains(currLoc)) continue; 

                    // we are at a new location that hasn't been hit before.
                    // we have a new island to add to our visited list. 
                    DFS_MarkIslandAsVisited(currLoc);
                    numIslands++;
                }
            }

            return numIslands;
        }

        private void DFS_MarkIslandAsVisited(Tuple<int,int> pos)
        {
            if(visited.Contains(pos) || grid[pos.Item2][pos.Item1] == '0') return;
            visited.Add(pos);

            var left = new Tuple<int,int>(pos.Item1 - 1, pos.Item2);
            var right = new Tuple<int,int>(pos.Item1 + 1, pos.Item2);
            var up = new Tuple<int,int>(pos.Item1, pos.Item2 - 1);
            var down = new Tuple<int,int>(pos.Item1, pos.Item2 + 1);

            if(left.Item1 >= 0) DFS_MarkIslandAsVisited(left);
            if(right.Item1 < this.grid[right.Item2].Length) DFS_MarkIslandAsVisited(right);
            if(up.Item2 >= 0) DFS_MarkIslandAsVisited(up);
            if(down.Item2 < this.grid.Length) DFS_MarkIslandAsVisited(down);

            return;
        }
    }
    public int NumIslands(char[][] grid)
    {
        var solver = new NumIslandsSolver(grid);
        return solver.SolveIsland();
    }
}

var sol = new Solution();
var res = sol.OrangesRotting([[1,1,0],[0,1,1],[0,1,2]]);
res = sol.OrangesRotting([[1,0,1],[0,2,0],[1,0,1]]);

return 0;

public class Solution
{
    public int OrangesRotting(int[][] grid) 
    {
        int yLen = grid.Length;
        int xLen = grid[0].Length;

        var queue = new Queue<(int, int)>();
        int fresh = 0;

        int minutes = 0;
        int[][] dirs = [[-1,0], [1,0], [0,-1],[0,1]];

        for(int y = 0; y < yLen; y++)
        {
            for(int x = 0; x < xLen; x++)
            {
                if(grid[y][x] == 1) fresh++;
                else if(grid[y][x] == 2) queue.Enqueue((x, y));
            }
        }

        while(queue.Count > 0 && fresh > 0)
        {
            int size = queue.Count;
            for(int i = 0; i < size; i++)
            {
                var (currX, currY) = queue.Dequeue();
                foreach(var d in dirs)
                {
                    int nr = currX + d[0], nc = currY + d[1];
                    if(nr < 0 || nc < 0 || nr >= xLen || nc >= yLen || grid[nc][nr] != 1) continue;
                    grid[nc][nr] = 2;
                    fresh--;
                    queue.Enqueue((nr, nc));

                }
            }
            minutes++;
        }

        return fresh == 0 ? minutes : -1;
    }
}
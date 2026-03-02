SurroundedRegionsTests.Run();

public class Solution
{
    public void Solve(char[][] board)
    {
        // loop through each x and y position until we find a char 'O'
        // when we find that 'O', we will start a dfs!
        // inside this dfs, we will keep track if we've hit a border or that has an 'O'. 
        // if we do, then we know we can't remove any of the O's seen, we must do an early return
        // we will need to keep a visited hashset to short circuit the dfs
        // after a dfs, if we didnt hit a 'O' on the border, then we know we can change each of those positions!
        int y_amt = board.Length;
        int x_amt = board[0].Length;
        for(int y = 0; y < y_amt; y++) {
            for(int x = 0; x < x_amt; x++) {
                // <int, int> -> x, y
                if(board[y][x] == 'X') continue;
                var surroundedTileLocations = new HashSet<Tuple<int, int>>();
                var visited = new HashSet<Tuple<int, int>>();
                if(dfs(board, x, y, surroundedTileLocations, x_amt, y_amt, visited)) {
                    // go through each surrounded tile location and change it
                    foreach(var tile in surroundedTileLocations)
                        board[tile.Item2][tile.Item1] = 'X';
                }
            }
        }
    }

    private bool dfs(char[][] board, int currX, int currY, HashSet<Tuple<int,int>> tiles, int sizeX, int sizeY, HashSet<Tuple<int,int>> visited) {
        var currLoc = new Tuple<int, int>(currX, currY);
        if(visited.Contains(currLoc)) return true;
        visited.Add(currLoc);

        // base case 1
        if(currX == sizeX - 1 || currX == 0 || currY == sizeY - 1 || currY == 0) {
            if(board[currY][currX] == 'O') return false;
            tiles.Add(currLoc);
            return true;
        }

        // base case 2
        if(board[currY][currX] == 'X') return true;
        tiles.Add(currLoc);

        // we must do the four directions here
        if(!dfs(board, currX - 1, currY, tiles, sizeX, sizeY, visited)) return false;
        if(!dfs(board, currX + 1, currY, tiles, sizeX, sizeY, visited)) return false;
        if(!dfs(board, currX, currY - 1, tiles, sizeX, sizeY, visited)) return false;
        if(!dfs(board, currX, currY + 1, tiles, sizeX, sizeY, visited)) return false;

        return true;
    }

}

public class SurroundedRegionsTests
{
    public static void Run()
    {
        var sol = new Solution();

        char[][] board = new char[][]
        {
            new char[] { 'X', 'X', 'X', 'X' },
            new char[] { 'X', 'O', 'O', 'X' },
            new char[] { 'X', 'O', 'O', 'X' },
            new char[] { 'X', 'X', 'X', 'O' }
        };

        char[][] expected = new char[][]
        {
            new char[] { 'X', 'X', 'X', 'X' },
            new char[] { 'X', 'X', 'X', 'X' },
            new char[] { 'X', 'X', 'X', 'X' },
            new char[] { 'X', 'X', 'X', 'O' }
        };

        sol.Solve(board);

        for (int i = 0; i < board.Length; i++)
            for (int j = 0; j < board[i].Length; j++)
                System.Diagnostics.Debug.Assert(
                    board[i][j] == expected[i][j],
                    $"Mismatch at [{i}][{j}]: expected '{expected[i][j]}' but got '{board[i][j]}'"
                );
    }
}
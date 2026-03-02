SurroundedRegionsTests.Run();

public class Solution
{
    public void Solve(char[][] board)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++)
        {
            if (board[r][0] == 'O') Dfs(board, r, 0, rows, cols);
            if (board[r][cols - 1] == 'O') Dfs(board, r, cols - 1, rows, cols);
        }
        for (int c = 0; c < cols; c++)
        {
            if (board[0][c] == 'O') Dfs(board, 0, c, rows, cols);
            if (board[rows - 1][c] == 'O') Dfs(board, rows - 1, c, rows, cols);
        }

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (board[r][c] == 'O') board[r][c] = 'X';
                else if (board[r][c] == 'S') board[r][c] = 'O';
    }

    private void Dfs(char[][] board, int r, int c, int rows, int cols)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols || board[r][c] != 'O') return;
        board[r][c] = 'S';
        Dfs(board, r + 1, c, rows, cols);
        Dfs(board, r - 1, c, rows, cols);
        Dfs(board, r, c + 1, rows, cols);
        Dfs(board, r, c - 1, rows, cols);
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
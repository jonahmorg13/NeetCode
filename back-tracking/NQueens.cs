#:property PublishAot=false
public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        var sol = new List<List<string>>();
        var cols = new HashSet<int>();
        var diag1 = new HashSet<int>(); // row - col (top-left to bottom-right)
        var diag2 = new HashSet<int>(); // row + col (top-right to bottom-left)
        var board = new char[n][];
        for (int i = 0; i < n; i++)
            board[i] = new string('.', n).ToCharArray();

        dfs(0, n, board, sol, cols, diag1, diag2);
        return sol;
    }

    private void dfs(int row, int n, char[][] board, List<List<string>> sol,
                     HashSet<int> cols, HashSet<int> diag1, HashSet<int> diag2)
    {
        if (row == n)
        {
            sol.Add(board.Select(r => new string(r)).ToList());
            return;
        }
        for (int col = 0; col < n; col++)
        {
            if (cols.Contains(col) || diag1.Contains(row - col) || diag2.Contains(row + col))
                continue;

            board[row][col] = 'Q';
            cols.Add(col); diag1.Add(row - col); diag2.Add(row + col);

            dfs(row + 1, n, board, sol, cols, diag1, diag2);

            board[row][col] = '.';
            cols.Remove(col); diag1.Remove(row - col); diag2.Remove(row + col);
        }
    }
}
#:property PublishAot=false
var sol = new Solution();
var res = sol.SolveNQueens(4);

return 0;

public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        var board = new char[n][];
        for (int i = 0; i < n; i++)
            board[i] = new string('.', n).ToCharArray();
        var sol = new List<List<string>>();
        dfs(0, n, board, sol);
        return sol;
    }

    private void dfs(int row, int n, char[][] board, List<List<string>> sol)
    {
        if (row == n)
        {
            sol.Add(board.Select(r => new string(r)).ToList());
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (CanPlaceQueen(n, col, row, board))
            {
                board[row][col] = 'Q';
                dfs(row + 1, n, board, sol);
                board[row][col] = '.';
            }
        }
    }
    private bool CanPlaceQueen(int n, int x, int y, char[][] board)
    {
        if(board[y].Contains('Q')) return false;
        if(board.Any(row => row[x] == 'Q')) return false;

        // top left
        int curr_x = x - 1;
        int curr_y = y - 1;
        while(curr_x >= 0 && curr_y >= 0)
        {
            if(board[curr_y][curr_x] == 'Q') return false;
            curr_y--;
            curr_x--;
        }

        // top right
        curr_x = x + 1;
        curr_y = y - 1;
        while(curr_x < n && curr_y >= 0)
        {
            if(board[curr_y][curr_x] == 'Q') return false;
            curr_y--;
            curr_x++;
        }

        // top right
        curr_x = x - 1;
        curr_y = y + 1;
        while(curr_x >= 0 && curr_y < n)
        {
            if(board[curr_y][curr_x] == 'Q') return false;
            curr_y++;
            curr_x--;
        }

        // top right
        curr_x = x + 1;
        curr_y = y + 1;
        while(curr_x < n && curr_y < n)
        {
            if(board[curr_y][curr_x] == 'Q') return false;
            curr_y++;
            curr_x++;
        }

        return true;
    }
}
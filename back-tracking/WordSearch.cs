using System.Diagnostics;

var sol = new Solution();
char[][] board = new char[][] {
    new char[] { 'A', 'B', 'C', 'D' },
    new char[] { 'S', 'A', 'A', 'T' },
    new char[] { 'A', 'C', 'A', 'E' }
};
var res = sol.Exist(board, "CAT");
Debug.Assert(res == true);

board = new char[][] {
    new char[] { 'A', 'B', 'C', 'E' },
    new char[] { 'S', 'F', 'C', 'S' },
    new char[] { 'A', 'D', 'E', 'E' }
};
res = sol.Exist(board, "ABCB");
Debug.Assert(res == false);


public class Solution {
    public bool Exist(char[][] board, string word) {
        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                var visited = new HashSet<Tuple<int,int>>();
                if(dfs(board, new Tuple<int,int>(j, i), word, 0, visited)) return true;
            }
        }
        return false;
    }

    private bool dfs(char[][]board, Tuple<int, int> curr_loc, string word, int str_idx, HashSet<Tuple<int,int>> visited) {
        if(board[curr_loc.Item2][curr_loc.Item1] != word[str_idx]) return false;
        str_idx++;

        if(str_idx >= word.Length) {
            return true;
        }

        visited.Add(curr_loc);

        var left = curr_loc.Item1 - 1 >= 0 ? new Tuple<int, int>(curr_loc.Item1 - 1, curr_loc.Item2) : null;
        var right = curr_loc.Item1 + 1 < board[0].Length ? new Tuple<int, int>(curr_loc.Item1 + 1, curr_loc.Item2) : null;
        var up = curr_loc.Item2 - 1 >= 0 ? new Tuple<int, int>(curr_loc.Item1, curr_loc.Item2 - 1) : null;
        var down = curr_loc.Item2 + 1 < board.Length ? new Tuple<int, int>(curr_loc.Item1, curr_loc.Item2 + 1): null;

        if(left != null && !visited.Contains(left))  {
            if(dfs(board, left, word, str_idx, visited)) return true;
        }
        if(right != null && !visited.Contains(right)) {
            if(dfs(board, right, word, str_idx, visited)) return true;
        }
        if(up != null && !visited.Contains(up)) { 
            if(dfs(board, up, word, str_idx, visited)) return true;
        }
        if(down != null && !visited.Contains(down)) {
            if(dfs(board, down, word, str_idx, visited)) return true;
        }

        visited.Remove(curr_loc);

        return false;
    }
}

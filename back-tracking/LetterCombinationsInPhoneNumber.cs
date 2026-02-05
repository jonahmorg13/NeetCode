using System.Diagnostics;
using System.Text;

var sol = new Solution();
var res = sol.LetterCombinations("34");
Debug.Assert(res.Count == 9);
List<string> expected = ["dg","dh","di","eg","eh","ei","fg","fh","fi"];
for(int i = 0; i < res.Count; i++)
{
    Debug.Assert(res[i].SequenceEqual(expected[i]));
}

public class Solution {
    private Dictionary<char, string> digitsToChars = new Dictionary<char, string>
    {
        {'1', ""},
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"},
        {'0', "+"},
    };

    public List<string> LetterCombinations(string digits) {
        var sol = new List<string>();
        if(string.IsNullOrWhiteSpace(digits)) return sol;
        var currStr = new StringBuilder();
        dfs(digits, 0, currStr, sol);
        return sol;
    }

    private void dfs(string digits, int i, StringBuilder currStr, List<string> sol)
    {
        if(i == digits.Length)
        {
            sol.Add(currStr.ToString());
            return;
        }

        var currDigit = digits[i];
        var currChars = digitsToChars[currDigit];
        for(int j = 0; j < currChars.Length; j++)
        {
            currStr.Append(currChars[j]);
            dfs(digits, i + 1, currStr, sol);
            currStr.Length--;
        }
    }
}

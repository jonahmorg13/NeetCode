using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.EvalRPN(["1", "2", "+", "3", "*", "4", "-"]) == 5);

public class Solution
{
    private Dictionary<string, Func<int, int, int>> operations = new()
    {
        {"+", (a, b) => a + b},
        {"-", (a, b) => a - b},
        {"*", (a, b) => a * b},
        {"/", (a, b) => a / b},
    };

    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<string>();

        foreach(var token in tokens)
        {
            if (operations.ContainsKey(token))
            {
                // do i need to deal with error handling in this? is it apart of the constraints?
                var second = stack.Pop();
                var first = stack.Pop();
                stack.Push(operations[token](int.Parse(first), int.Parse(second)).ToString());
            }
            else
            {
                stack.Push(token);
            }
        }
        return int.Parse(stack.Pop());
    }
}

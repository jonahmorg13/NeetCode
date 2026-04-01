public class Solution
{
    public bool CheckValidString(string s)
    {
        var leftParenStack = new Stack<int>();
        var asteriskStack = new Stack<int>();

        for(int i = 0; i < s.Length; i++)
        {
            var currChar = s[i];
            if(currChar == '(')
                leftParenStack.Push(i);
            else if(currChar == ')')
            {
                if(leftParenStack.Count == 0 && asteriskStack.Count == 0) return false;
                if(leftParenStack.Count > 0)
                {
                    leftParenStack.Pop();
                }
                else
                {
                    asteriskStack.Pop();
                }
            }
            else if(currChar == '*')
                asteriskStack.Push(i);
            else
                return false;
        }

        while(leftParenStack.Count > 0 && asteriskStack.Count > 0)
            if(leftParenStack.Pop() > asteriskStack.Pop()) return false;

        return leftParenStack.Count == 0;
    }
}
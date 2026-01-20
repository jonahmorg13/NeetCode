using System.Diagnostics;

var sol = new Solution();
var res = sol.LongestPalindrome("ababd");
Debug.Assert(res == "aba");

public class Solution {
    private bool IsPalindrome(string s, int start, int end)
    {
        while(start < end)
        {
            if(s[start] != s[end]) return false;
            start++;
            end--;
        }
        return true;
    }

    private void TestIsPalindrome()
    {
        Debug.Assert(IsPalindrome("racecar", 0, 6) == true, "Failed: 'racecar' should be true");
        Debug.Assert(IsPalindrome("noon", 0, 3) == true, "Failed: 'noon' should be true");
        Debug.Assert(IsPalindrome("apple", 0, 4) == false, "Failed: 'apple' should be false");
        Debug.Assert(IsPalindrome("radars", 1, 3) == true, "Failed: Substring 'ada' should be true");
        Debug.Assert(IsPalindrome("a", 0, 0) == true, "Failed: Single char should be true");
        Debug.Assert(IsPalindrome("ab", 0, 0) == true, "Failed: Range of 0 length should be true");
        Debug.Assert(IsPalindrome("Aba", 0, 2) == false, "Failed: 'Aba' should be false due to case");
        Debug.Assert(IsPalindrome("abcbca", 0, 5) == false, "Failed: 'abcbca' should be false");
        Console.WriteLine("All tests passed!");
    }

    public string LongestPalindrome(string s) {
        if(String.IsNullOrWhiteSpace(s)) return string.Empty;

        int n = s.Length;
        bool[,] cache = new bool[n, n];

        int maxLength = 1;
        int maxLengthStart = 0;
        for(int i = n - 1; i >= 0; i--)
        {
            for(int j = i + 1; j < n; j++)
            {
                if(s[i] == s[j] && (j - i <= 2 || cache[i + 1, j - 1] == true))
                {
                    cache[i, j] = true;
                    if(j - i + 1 > maxLength)
                    {
                        maxLength = j - i + 1;
                        maxLengthStart = i;
                    }
                }
            }
        }

        return s.Substring(maxLengthStart, maxLength);
    }
}

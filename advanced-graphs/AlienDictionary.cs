using System.Text;

var sol = new Solution();
Console.WriteLine(sol.foreignDictionary(["abc","bcd","cde"]));

public class Solution
{
    public string foreignDictionary(string[] words)
    {
        // Track ALL unique characters (not just those involved in edges)
        var edges = new Dictionary<char, HashSet<char>>();
        foreach(var word in words)
            foreach(var ch in word)
                if(!edges.ContainsKey(ch))
                    edges[ch] = new HashSet<char>();

        int[] inDegrees = new int[26];

        for(int first = 0, second = 1; second < words.Length; first++, second++)
        {
            var leftWord = words[first];
            var rightWord = words[second];

            int ptr = 0;
            while(ptr < leftWord.Length && ptr < rightWord.Length && leftWord[ptr] == rightWord[ptr])
                ptr++;

            // If rightWord is a prefix of leftWord, ordering is invalid
            if(ptr == rightWord.Length && leftWord.Length > rightWord.Length)
                return "";

            // If leftWord is a prefix of rightWord, no edge to add
            if(ptr == leftWord.Length)
                continue;

            var leftChar = leftWord[ptr];
            var rightChar = rightWord[ptr];

            // HashSet prevents duplicate edges from inflating in-degrees
            if(!edges[leftChar].Contains(rightChar))
            {
                edges[leftChar].Add(rightChar);
                inDegrees[alphaToNum(rightChar)]++;
            }
        }

        // Max-heap so we pick the largest char first among ties
        var pq = new PriorityQueue<char, char>(Comparer<char>.Create((a, b) => b.CompareTo(a)));
        foreach(var (key, val) in edges)
            if(inDegrees[alphaToNum(key)] == 0)
                pq.Enqueue(key, key);

        var stringBuilder = new StringBuilder();
        while(pq.Count > 0)
        {
            var currNode = pq.Dequeue();
            stringBuilder.Append(currNode);

            foreach(var neighbor in edges[currNode])
            {
                inDegrees[alphaToNum(neighbor)]--;
                if(inDegrees[alphaToNum(neighbor)] == 0)
                    pq.Enqueue(neighbor, neighbor);
            }
        }

        // If not all characters made it into the result, there's a cycle
        if(stringBuilder.Length != edges.Count)
            return "";

        return stringBuilder.ToString();
    }

    private int alphaToNum(char ch)
    {
        return (int)ch - 97;
    }
}
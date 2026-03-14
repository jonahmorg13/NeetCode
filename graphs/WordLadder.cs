#:property PublishAot=false

using System.Diagnostics;

var sol = new Solution();
var res = sol.LadderLength("cat", "sag", ["bat","bag","sag","dag","dot"]);
Debug.Assert(res == 4);

public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var visited = new HashSet<string>();
        var currWord = beginWord;

        var wordsToVisit = new Queue<string>();
        for(int i = 0; i < wordList.Count; i++)
        {
            var newWord = wordList[i];
            int amountDiff = 0;
            for(int j = 0; j < newWord.Length; j++)
            {
                if(currWord[j] != newWord[j])
                {
                    amountDiff++;
                    if(amountDiff > 1) break;
                }
            }
            if(amountDiff == 1) wordsToVisit.Enqueue(newWord);
        }

        // i think we would like to keep track of solutions, but we want the best one so
        // we'll have to go through every 
        var res = 1;
        while((currWord != endWord) && wordsToVisit.Count > 0)
        {
            int amountOfWordsToVisit = wordsToVisit.Count;
            for(int i = 0; i < amountOfWordsToVisit; i++)
            {
                currWord = wordsToVisit.Dequeue();
                if(visited.Contains(currWord)) continue;
                visited.Add(currWord);

                if(currWord == endWord)
                    return res + 1;

                for(int j = 0; j < wordList.Count; j++)
                {
                    var newWord = wordList[j];
                    int amountDiff = 0;
                    for(int k = 0; k < newWord.Length; k++)
                    {
                        if(currWord[k] != newWord[k])
                        {
                            amountDiff++;
                            if(amountDiff > 1) break;
                        }
                    }
                    if(amountDiff == 1) wordsToVisit.Enqueue(newWord);
                }
            }

            res++;
        }

        return 0;
    }
}

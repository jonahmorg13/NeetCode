using System.Diagnostics;

var sol = new Solution();
var res = sol.CountComponents(5, [[0,1],[1,2],[3,4]]);
Debug.Assert(res == 2);
res = sol.CountComponents(5, [[0,1],[0,2],[1,2],[2,3],[2,4]]);
Debug.Assert(res == 1);

res = sol.CountComponents(4,[[2,3],[1,2],[1,3]]);
Debug.Assert(res == 2);

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        // edge case where we only have one node
        if(n == 1 && edges.Length == 0) return 1;

        var edgeDict = new Dictionary<int, List<int>>();
        int i;
        for(i = 0; i < edges.Length; i++)
        {
            int start = edges[i][0];
            int end = edges[i][1];
            if(!edgeDict.ContainsKey(start))
                edgeDict[start] = new List<int>();
            if(!edgeDict.ContainsKey(end))
                edgeDict[end] = new List<int>();

            edgeDict[start].Add(end);
            edgeDict[end].Add(start);
        }

        // main function, run a dfs on it!
        var visitedAmts = new int[n];
        i = 0;
        int res = 0;
        while(true)
        {
            res++;
            dfs(-1, i, visitedAmts, edgeDict);
            int j;
            for(j = 0; j < visitedAmts.Length && visitedAmts[j] != 0; j++) {}
            if(j >= visitedAmts.Length)
                break;
            if(j == i)
                i++;
            else 
                i = j;
        }
        
        return res;
    }

    private bool dfs(int srcNode, int currNode, int[] visitedAmts, Dictionary<int, List<int>> edgeDict)
    {
        // if we've visited this node more than once, we know we have a cycle!
        if(srcNode != -1 && (visitedAmts[currNode] + 1) > 1)
            return false;
        visitedAmts[currNode]++;

        // loop through the other edges besides the one we came from!
        if(!edgeDict.ContainsKey(currNode))
            return true;
        var nodesToCheck = edgeDict[currNode];
        for(int i = 0; i < nodesToCheck.Count; i++)
            if(srcNode != nodesToCheck[i])
                dfs(currNode, nodesToCheck[i], visitedAmts, edgeDict);

        return true;
    }
}

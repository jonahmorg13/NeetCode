var sol = new Solution();
var res = sol.ValidTree(5, [[0,1], [0,2], [0,3], [1,4]]);
res = sol.ValidTree(1, [[0,0]]);

public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        //edge case if there's one node
        if(n == 1 && edges.Length == 0) return true;
        // we could do a map for each node n.  
        // for ex. say we havevar res = sol.ValidTree(5, [[0,1], [0,2], [0,3], [1,4]]);
        // then we could map 0 -> [1,2,3]
        // and               1 -> [4],
        // etc. and etc.
        // then, starging from any node (we'll just do the first) we could do a dfs
        // or a bfs on the graph and if we encounter a node that's visited twice,
        // then we return false,
        // else, we return true
        
        // lets start by creating our ds
        var edgeDict = new Dictionary<int, List<int>>();
        for(int i = 0; i < edges.Length; i++)
        {
            int start = edges[i][0];
            int end = edges[i][1];
            if(start == end) return false;
            if(!edgeDict.ContainsKey(start))
                edgeDict[start] = new List<int>();
            if(!edgeDict.ContainsKey(end))
                edgeDict[end] = new List<int>();

            edgeDict[start].Add(end);
            edgeDict[end].Add(start);
        }

        // OK, we have our ds built out. lets run a dfs on it!
        // we need a visited amt for each of our nodes
        // i think we need to check that all of the nodes are connected...
        var visitedAmts = new int[n];
        if(!dfs(-1, 0, visitedAmts, edgeDict))
            return false;
        
        for(int i = 0; i < visitedAmts.Length; i++)
            if(visitedAmts[i] < 1) return false;

        return true;
    }

    private bool dfs(int srcNode, int currNode, int[] visitedAmts, Dictionary<int, List<int>> edgeDict)
    {
        if(srcNode != -1 && (visitedAmts[currNode] + 1) > 1)
            return false;
        visitedAmts[currNode]++;

        var nodesToCheck = edgeDict[currNode];
        for(int i = 0; i < nodesToCheck.Count; i++)
        {
            if(srcNode != nodesToCheck[i])
            {
                if(!dfs(currNode, nodesToCheck[i], visitedAmts, edgeDict)) return false;
            }
        }

        return true;
    }
}

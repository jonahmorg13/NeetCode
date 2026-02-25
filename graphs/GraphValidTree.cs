var sol = new Solution();
var res = sol.ValidTree(5, [[0,1], [0,2], [0,3], [1,4]]);
res = sol.ValidTree(1, [[0,0]]);

public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // edge case where we only have one node
        if(n == 1 && edges.Length == 0) return true;

        var edgeDict = new Dictionary<int, List<int>>();
        for(int i = 0; i < edges.Length; i++)
        {
            int start = edges[i][0];
            int end = edges[i][1];
            // if we have a node that points at itself
            if(start == end) return false;
            if(!edgeDict.ContainsKey(start))
                edgeDict[start] = new List<int>();
            if(!edgeDict.ContainsKey(end))
                edgeDict[end] = new List<int>();

            edgeDict[start].Add(end);
            edgeDict[end].Add(start);
        }

        // main function, run a dfs on it!
        var visitedAmts = new int[n];
        if(!dfs(-1, 0, visitedAmts, edgeDict))
            return false;
        
        // if we didnt visit a node, it's not a valid tree
        for(int i = 0; i < visitedAmts.Length; i++)
            if(visitedAmts[i] < 1) return false;

        return true;
    }

    private bool dfs(int srcNode, int currNode, int[] visitedAmts, Dictionary<int, List<int>> edgeDict)
    {
        // if we've visited this node more than once, we know we have a cycle!
        if(srcNode != -1 && (visitedAmts[currNode] + 1) > 1)
            return false;
        visitedAmts[currNode]++;

        // loop through the other edges besides the one we came from!
        var nodesToCheck = edgeDict[currNode];
        for(int i = 0; i < nodesToCheck.Count; i++)
            if(srcNode != nodesToCheck[i])
                if(!dfs(currNode, nodesToCheck[i], visitedAmts, edgeDict)) return false;

        return true;
    }
}

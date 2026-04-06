using System.Diagnostics;

var sol = new Solution();
// [src, dst, weight]
// undirected so they go in both dirs!
var res = sol.Dijkstras(7, [[1,2,3], [1,3,2], [2,3,2], [2,4,1], [2,5,4], [3,4,3], [3,6,5], [3,7,6], [6,7,2], [4,7,2], [5,7,1]], 7, 1);
Debug.Assert(res.SequenceEqual([7,4,2,1]));
public class Solution
{
    public List<int> Dijkstras(int n, int[][] edges, int src, int dest)
    {
        // create the edges. each int is mapped to it's destination with it's weight
        var dictEdges = new Dictionary<int, List<(int, int)>>();
        for(int i = 0; i < edges.Length; i++)
        {
            var s = edges[i][0];
            var d = edges[i][1];
            var w = edges[i][2];
            if(!dictEdges.ContainsKey(s))
                dictEdges[s] = new List<(int, int)>();
            if(!dictEdges.ContainsKey(d)) 
                dictEdges[d] = new List<(int, int)>();
            dictEdges[s].Add((d, w));
            dictEdges[d].Add((s, w));
        }

        var dist = new int[n + 1];
        var visited = new bool[n + 1];
        var prev = new int[n + 1];
        for(int i = 0; i <= n; i++)
            dist[i] = int.MaxValue;

        dist[src] = 0;
        var queue = new PriorityQueue<int, int>();
        queue.Enqueue(src, 0);

        while(queue.TryDequeue(out var currNode, out var distance))
        {
            if(visited[currNode]) continue;
            visited[currNode] = true;
            var edgesToCheck = dictEdges[currNode];
            for(int i = 0; i < edgesToCheck.Count; i++)
            {
                var (dst, w) = edgesToCheck[i];
                if(dist[currNode] + w < dist[dst])
                {
                    dist[dst] = dist[currNode] + w;
                    prev[dst] = currNode;
                    queue.Enqueue(dst, dist[currNode] + w);
                }
            }
        }

        var path = new Stack<int>();
        var curr = dest;
        while(curr != src)
        {
            path.Push(curr);
            curr = prev[curr];
        }
        path.Push(src);
        return path.ToList();
    }
}
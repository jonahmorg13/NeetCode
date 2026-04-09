using System.Diagnostics;

var sol = new Solution();
var res = sol.NetworkDelayTime([[1,2,1],[2,3,1],[1,4,4],[3,4,1]], 4, 1);
Debug.Assert(res == 3);

res = sol.NetworkDelayTime([[1,2,1],[2,3,1]], 3, 2);
Debug.Assert(res == -1);

public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        // we need to make our graph
        // int1 = node, List<(int, int)> a list of destinations associated with their time
        var edges = new Dictionary<int, List<(int, int)>>();
        for(int i = 0; i < times.Length; i++)
        {
            var src = times[i][0];
            var dst = times[i][1];
            var time = times[i][2];
            if(!edges.ContainsKey(src))
                edges[src] = new List<(int, int)>();
            edges[src].Add((dst, time));
        }

        //make sure to properly index in the near future!
        var distances = new int[n];
        var visited = new bool[n];
        for(int i = 0; i < distances.Length; i++)
            distances[i] = Int32.MaxValue;
        distances[k - 1] = 0;

        var q = new PriorityQueue<int, int>();
        q.Enqueue(k, 0);
        while(q.TryDequeue(out var node, out var time))
        {
            if(visited[node - 1]) continue;
            visited[node - 1] = true;

            if(!edges.ContainsKey(node)) continue;
            var nodeEdges = edges[node];
            for(int i = 0; i < nodeEdges.Count; i++)
            {
                var nextNode = nodeEdges[i].Item1;
                var timeToNextNode = nodeEdges[i].Item2;
                // if the time plus the next time to the next node is less than the currently saved dist
                if(time + timeToNextNode < distances[nextNode - 1])
                {
                    //enqueue, update
                    distances[nextNode - 1] = time + timeToNextNode;
                    q.Enqueue(nextNode, time + timeToNextNode);
                }
            }
        }

        int res = Int32.MinValue;
        for(int i = 0; i < distances.Length; i++)
        {
            if(distances[i] == Int32.MaxValue) return -1;
            res = Math.Max(res, distances[i]);
        }

        return res;
    }
}
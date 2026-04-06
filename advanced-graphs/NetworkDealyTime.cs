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
        var edges = new Dictionary<int, PriorityQueue<int, int>>();
        for(int i = 0; i < times.Length; i++)
        {
            var src = times[i][0];
            var dst = times[i][1];
            var time = times[i][2];
            if(!edges.ContainsKey(src))
                edges[src] = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            edges[src].Enqueue(dst, time);
        }
        var visited = new HashSet<int>();
        var queue = new Queue<(int, int)>();
        queue.Enqueue((k, 0));
        var res = 0;
        while(queue.Count > 0)
        {
            var (currNode, currTime) = queue.Dequeue();
            if(!edges.ContainsKey(currNode)) continue;
            var currEdges = edges[currNode];
            var amtCurrEdges = currEdges.Count;
            for(int i = 0; i < amtCurrEdges; i++)
            {
                currEdges.TryDequeue(out var next, out int time);
                if(visited.Contains(next)) continue;
                res += time;
                visited.Add(next);
                queue.Enqueue((next, currTime + time));
            }
        }
        return res;
    }
}
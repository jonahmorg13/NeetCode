using System.Diagnostics;

var sol = new Solution();
var res = sol.FindCheapestPrice(4, [[0,1,200],[1,2,100],[1,3,300],[2,3,100]], 0 ,3, 1);
Debug.Assert(res == 500);
res = sol.FindCheapestPrice(5, [[1,2,10],[2,0,7],[1,3,8],[4,0,10],[3,4,2],[4,2,10],[0,3,3],[3,1,6],[2,4,5]], 0, 4, 1);
Debug.Assert(res == 5);
public class Solution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var edges = new Dictionary<int, List<(int, int)>>();
        for(int i = 0; i < flights.Length; i++)
        {
            var s = flights[i][0];
            var d = flights[i][1];
            var price = flights[i][2];
            if(!edges.ContainsKey(s))
                edges[s] = new List<(int, int)>();
            edges[s].Add((d, price));
        }
        var distances = new Dictionary<(int, int), int>();
        distances[(src, 0)] = 0;
        var q = new PriorityQueue<(int, int, int), int>();
        q.Enqueue((src, 0, 0), 0);
        while(q.TryDequeue(out var val, out var _))
        {
            var currNode = val.Item1;
            var currKStops = val.Item2;
            var currPrice = val.Item3;
            if(currNode == dst) return currPrice;
            if(currKStops > k) continue;
            if(!edges.ContainsKey(currNode)) continue;
            var currEdges = edges[currNode];
            for(int i = 0; i < currEdges.Count; i++)
            {
                var priceToNextNode = currEdges[i].Item2;
                var nextNode = currEdges[i].Item1;
                var newPrice = currPrice + priceToNextNode;
                var newStops = currKStops + 1;
                var key = (nextNode, newStops);
                if(!distances.ContainsKey(key) || newPrice < distances[key])
                {
                    distances[key] = newPrice;
                    q.Enqueue((nextNode, newStops, newPrice), newPrice);
                }
            }
        }
        return -1;
    }
}
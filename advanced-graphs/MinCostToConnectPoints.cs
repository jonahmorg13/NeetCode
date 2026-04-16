using System.Diagnostics;

var sol = new Solution();
var res = sol.MinCostConnectPoints([[0,0],[2,2],[3,3],[2,4],[4,2]]);
Debug.Assert(res == 10);

public class Solution
{
    private record Point
    {
        public int x {get; set;}
        public int y {get; set;}

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    private int ManhattanDistance(int x1, int x2, int y1, int y2)
    {
        return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
    }

    public int MinCostConnectPoints(int[][] points)
    {
        var edges = new Dictionary<Point, List<(Point, int)>>();
        for(int i = 0; i < points.Length - 1; i++)
        {
            for(int j = i + 1; j < points.Length; j++)
            {
                var p1 = new Point(points[i][0], points[i][1]);
                var p2 = new Point(points[j][0], points[j][1]);
                if(!edges.ContainsKey(p1))
                    edges[p1] = new List<(Point, int)>();
                if(!edges.ContainsKey(p2))
                    edges[p2] = new List<(Point, int)>();


                var distance = ManhattanDistance(p2.x, p1.x, p2.y, p1.y);
                edges[p1].Add((p2, distance));
                edges[p2].Add((p1, distance));
            }
        }

        var visited = new HashSet<Point>();
        var distances = new Dictionary<Point, int>();

        for(int i = 0; i < points.Length; i++)
        {
            var currPoint = new Point(points[i][0], points[i][1]);
            distances[currPoint] = Int32.MaxValue;
        }
        var src = new Point(points[0][0], points[0][1]);
        distances[src] = 0;
        var minDist = 0;

        // point = nodes to visit, priority will be based on min manhattan distance
        var q = new PriorityQueue<Point, int>();
        q.Enqueue(src, 0);
        while(q.TryDequeue(out var point, out var distance))
        {
            if(visited.Contains(point)) continue;
            visited.Add(point);
            minDist += distance;

            if(!edges.ContainsKey(point)) continue;
            var currEdges = edges[point];
            for(int i = 0; i < currEdges.Count; i++)
            {
                var destination = currEdges[i].Item1;
                var destDistance = currEdges[i].Item2;
                if(!visited.Contains(destination) && destDistance < distances[destination])
                {
                    // we need to save the current total distance somehow
                    q.Enqueue(destination, destDistance);
                    distances[destination] = destDistance;
                }
            }
        }

        return minDist;
    }
}
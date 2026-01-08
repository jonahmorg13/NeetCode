using System.Diagnostics;
using System.Drawing;

var sol = new Solution();
var res = sol.KClosest([[0,2],[2,2]], 1);
Debug.Assert(res[0].SequenceEqual([0,2]));

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // put the points into a heap based on minimum distance
        var heap = new PriorityQueue<List<int>,double>();
        foreach(var point in points)
        {
            var x = point[0];
            var y = point[1];
            // dist: sqrt(x^2 + y^2)
            var dist = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            heap.Enqueue(new List<int>{x, y}, dist);
        }

        var res = new int[k][];
        for(int i = 0; i < k; i++)
        {
            var point = heap.Dequeue();
            res[i] = new int[2];
            res[i][0] = point[0];
            res[i][1] = point[1];
        }

        return res;
    }
}

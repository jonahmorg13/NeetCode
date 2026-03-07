#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res = sol.FindOrder(3, [[1,0]]);
return 0;

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // we can use kahns algorithm. which is bfs based 
        // 1. compute the in degree for every node
        var edges = new Dictionary<int, List<int>>();
        var inDegrees = new int[numCourses];
        foreach(var pair in prerequisites)
        {
            // create the edge
            var src = pair[1];
            var dst = pair[0];
            if(!edges.ContainsKey(src))
                edges[src] = new List<int>();
            edges[src].Add(dst);

            // add the in degree
            inDegrees[dst]++;
        }

        // 2. add all nodes with in degree 0 to a queue
        var q = new Queue<int>();
        for(int i = 0; i < inDegrees.Length; i++)
            if(inDegrees[i] == 0) 
                q.Enqueue(i);

        // 3. while queue is not empty
        //    do what my obsidian note says
        var res = new List<int>();
        while(q.Count > 0)
        {
            var node = q.Dequeue();
            res.Add(node);

            if(!edges.ContainsKey(node))
                continue;

            var neighbors = edges[node];
            for(int i = 0; i < neighbors.Count; i++)
            {
                inDegrees[neighbors[i]]--;
                if(inDegrees[neighbors[i]] == 0)
                    q.Enqueue(neighbors[i]);
            }
        }

        if(res.Count != numCourses) return [];
        return res.ToArray();        
    }
}

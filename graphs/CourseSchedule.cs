using System.Diagnostics;

var sol = new Solution();
var res = sol.CanFinish(2, [[0,1]]);
Debug.Assert(res == true);
res = sol.CanFinish(2, [[0,1], [1,0]]);
Debug.Assert(res == false);

public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // we can use kahns algorithm. which is bfs based 
        // 1. compute the in degree for every node
        var edges = new Dictionary<int, List<int>>();
        var inDegrees = new int[numCourses];
        foreach(var pair in prerequisites)
        {
            // create the edge
            var src = pair[0];
            var dst = pair[1];
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
        var res = 0;
        while(q.Count > 0)
        {
            var node = q.Dequeue();
            res++;

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

        return res == numCourses;        
    }
}

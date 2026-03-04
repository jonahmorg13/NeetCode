var sol = new Solution();
var res = sol.FindRedundantConnection([[1,2],[1,3],[3,4],[2,4]]);

public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        var parent = new int[n + 1];
        var rank   = new int[n + 1];
        for (int i = 0; i <= n; i++) parent[i] = i;

        foreach (var edge in edges)
        {
            if (!Union(parent, rank, edge[0], edge[1]))
                return edge;
        }

        return new int[2];
    }

    private int Find(int[] parent, int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent, parent[x]);
        return parent[x];
    }

    private bool Union(int[] parent, int[] rank, int x, int y)
    {
        int px = Find(parent, x);
        int py = Find(parent, y);
        if (px == py) return false; // already connected → redundant edge

        if (rank[px] < rank[py])      parent[px] = py;
        else if (rank[px] > rank[py]) parent[py] = px;
        else { parent[py] = px; rank[px]++; }

        return true;
    }
}

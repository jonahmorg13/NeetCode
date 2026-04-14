using System.Diagnostics;

var cs = new CountSquares();
cs.Add([1, 1]);
cs.Add([2, 2]);
cs.Add([1, 2]);
Debug.Assert(cs.Count([2, 1]) == 1); // equal 1 in the future
Debug.Assert(cs.Count([3, 3]) == 0); // equal 0 in the future
cs.Add([2, 2]);
Debug.Assert(cs.Count([2, 1]) == 2); // equal 2 in the future

public class CountSquares
{
    private Dictionary<(int, int), int> pointDict;
    public CountSquares()
    {
        // (x, y) -> count of amount at that point, make sure to check if key exists first!
        pointDict = new Dictionary<(int, int), int>();
    }

    public void Add(int[] point)
    {
        var (x, y) = (point[0], point[1]);
        if(!pointDict.ContainsKey((x, y)))
            pointDict[(x, y)] = 1;
        else 
            pointDict[(x, y)]++;
    }

    public int Count(int[] point)
    {
        var res = 0;
        foreach(var (p, count) in pointDict)
        {
            // skip over non diagonal points
            if(Math.Abs(p.Item1 - point[0]) != Math.Abs(p.Item2 - point[1])) continue;
            if(p.Item1 == point[0] && p.Item2 == point[1]) continue;

            // find the two other points
            var p2 = (point[0], p.Item2);
            var p3 = (p.Item1, point[1]);
            if(!pointDict.ContainsKey(p2) || !pointDict.ContainsKey(p3)) continue;

            // add the counts of all four points
            res += pointDict[p] * pointDict[p2] * pointDict[p3];
        }
        return res;
    }
}
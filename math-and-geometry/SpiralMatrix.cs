using System.Diagnostics;

var sol = new Solution();
var res = sol.SpiralOrder([[1,2],[3,4]]);
Debug.Assert(res.SequenceEqual([1,2,4,3]));
res = sol.SpiralOrder([[1,2,3],[4,5,6],[7,8,9]]);

public class Solution
{
    private int[] direction {get; set;}
    private void updateDirection()
    {
        if(direction.SequenceEqual([1, 0]))
            direction = [0,1];
        else if(direction.SequenceEqual([0,1]))
            direction = [-1, 0];
        else if(direction.SequenceEqual([-1,0]))
            direction = [0, -1];
        else if(direction.SequenceEqual([0, -1]))
            direction = [1,0];
    }
    public List<int> SpiralOrder(int[][] matrix)
    {
        direction = [1,0];

        int minX = 0, minY = 0;
        int maxX = matrix[0].Length;
        int maxY = matrix.Length;

        var res = new List<int>();
        int[] currLoc = [0,0];
        int amtItems = maxX * maxY;
        int count = 0;


        while(count < amtItems)
        {
            res.Add(matrix[currLoc[1]][currLoc[0]]);
            count++;

            int[] nextLoc = [currLoc[0] + direction[0], currLoc[1] + direction[1]];
            if(minX > nextLoc[0] || nextLoc[0] >= maxX || minY > nextLoc[1] || nextLoc[1] >= maxY)
            {
                if(direction.SequenceEqual([1, 0]))
                    minY += 1;   
                else if(direction.SequenceEqual([0, 1]))
                    maxX -= 1;   
                else if(direction.SequenceEqual([-1, 0]))
                    maxY -= 1;   
                else if(direction.SequenceEqual([0, -1]))
                    minX += 1;   
                updateDirection();
            }
            currLoc[0] += direction[0];
            currLoc[1] += direction[1];
        }

        return res;
    }
}
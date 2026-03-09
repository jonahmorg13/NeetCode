var sol = new Solution();
int[][] matrix = new int[3][];
matrix[0] = [1,2,3];
matrix[1] = [4,0,5];
matrix[2] = [6,7,8];

sol.SetZeroes(matrix);

public class Solution {
    public void SetZeroes(int[][] matrix) {
        // create two hashsets for where zeroes exist in rows and cols
        // loop through each location and if a zero is in that hashmap. set it to zero
        var zeroCols = new HashSet<int>();
        var zeroRows = new HashSet<int>();
        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix[0].Length; j++)
            {
                if(matrix[i][j] == 0)
                {
                    zeroCols.Add(j);
                    zeroRows.Add(i);
                }
            }
        }

        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix[0].Length; j++)
            {
                if(zeroCols.Contains(j) || zeroRows.Contains(i)) matrix[i][j] = 0;
            }
        }

    }
}

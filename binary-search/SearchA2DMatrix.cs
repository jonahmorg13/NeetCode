using System.Diagnostics;

bool SearchMatrix(int[][] matrix, int target)
{
    var top = 0;
    var bottom = matrix.Length - 1;

    while(top <= bottom)
    {
        var mid = ((bottom - top) / 2) + top;
        var firstCol = matrix[mid][0];
        var lastCol = matrix[mid][matrix[mid].Length - 1];

        if(target < firstCol)
        {
            bottom = mid - 1;
        }
        else if(target > lastCol)
        {
            top = mid + 1;
        }
        else
        {
            //we're in the row! we need to do an inner binary search
            var left = 0;
            var right = matrix[mid].Length - 1;
            while(left <= right)
            {
                var colMid = ((right - left) / 2) + left;
                if(matrix[mid][colMid] < target)
                {
                    left = colMid + 1;
                }
                else if(matrix[mid][colMid] > target)
                {
                    right = colMid - 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }

    //binary search based on the row
    //binary search based on the column
    return false;
}

Debug.Assert(SearchMatrix([[1,2,4,8],[10,11,12,13],[14,20,30,40]], 10));
Debug.Assert(!SearchMatrix([[1,2,4,8],[10,11,12,13],[14,20,30,40]], 15));
Debug.Assert(SearchMatrix([[1,3,5,7],[10,11,16,20],[23,30,34,60]], 3));
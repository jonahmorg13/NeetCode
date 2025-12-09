using System.Diagnostics;

int LargestRectangleArea(int[] heights)
{
    var max = 0;
    var stack = new Stack<Tuple<int, int>>();
    for(int i = 0; i < heights.Length; i++)
    {
        if(stack.Count() <= 0)
        {
            stack.Push(new Tuple<int,int>(i, heights[i]));
            continue;
        }

        if(heights[i] >= stack.Peek().Item2)
        {
            stack.Push(new Tuple<int,int>(i, heights[i]));
            continue;
        }

        var startIdx = i;
        while(stack.Count() > 0 && stack.Peek().Item2 > heights[i])
        {
            var idxHeight = stack.Pop();
            max = Math.Max(max, idxHeight.Item2 * (i - idxHeight.Item1));
            //important! we need to make sure to save the correct starting index from here on out
            startIdx = idxHeight.Item1;
        }

        stack.Push(new Tuple<int,int>(startIdx, heights[i]));
    }

    while(stack.Count() > 0)
    {
        var idxHeight = stack.Pop();
        max = Math.Max(max, idxHeight.Item2 * ((heights.Length) - idxHeight.Item1));
    }

    return max;
}

Debug.Assert(LargestRectangleArea([7,1,7,2,2,4]) == 8);
Debug.Assert(LargestRectangleArea([1,3,7]) == 7);
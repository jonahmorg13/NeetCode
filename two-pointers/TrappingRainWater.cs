using System.Diagnostics;

int Trap(int[] height)
{
    var prefixMaxs = new int[height.Length];
    var suffixMaxs = new int[height.Length];
    var resHeights = new int[height.Length];

    var currMaxPrefix = 0;
    for(int i = 0; i < height.Length; i++)
    {
        currMaxPrefix = Math.Max(currMaxPrefix, height[i]);
        prefixMaxs[i] = currMaxPrefix;
    }


    var currMaxSuffix = 0;
    for(int i = height.Length - 1; i >= 0; i--)
    {
        currMaxSuffix = Math.Max(currMaxSuffix, height[i]);
        suffixMaxs[i] = currMaxSuffix;
    }

    for(int i = 1; i < height.Length - 1; i++)
    {
        //how to calc curr res height?
        resHeights[i] = Math.Max(Math.Min(prefixMaxs[i - 1], suffixMaxs[i + 1]) - height[i], 0);
        //like dat :)
    }
    
    return Enumerable.Sum(resHeights);
}

Debug.Assert(Trap([0,2,0,3,1,0,1,3,2,1]) == 9);
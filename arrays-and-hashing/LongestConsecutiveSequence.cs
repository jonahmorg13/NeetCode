using System.Diagnostics;

int LongestConsecutive(int[] nums)
{
    var numIdxDict = new Dictionary<int, int>();
    var maxSequence = 0;

    for(int i = 0; i < nums.Length; i++)
    {
        numIdxDict[nums[i]] = i; 
    }

    for(int i = 0; i < nums.Length; i++)
    {
        var currNum = nums[i];
        var count = 1;
        while(numIdxDict.TryGetValue(currNum - 1, out int idx))
        {
            count++;
            currNum = nums[idx];
        }
        maxSequence = Math.Max(maxSequence, count);
    }

    return maxSequence;
}

Debug.Assert(LongestConsecutive([2,20,4,10,3,4,5]) == 4);
Debug.Assert(LongestConsecutive([0,3,2,5,4,6,1,1]) == 7);

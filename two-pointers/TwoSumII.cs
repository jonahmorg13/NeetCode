using System.Diagnostics;

int[] TwoSum(int[] numbers, int target)
{
    var ptrOne = 0;
    var ptrTwo = numbers.Count() - 1;

    while(ptrOne != ptrTwo)
    {
        var currSum = numbers[ptrOne] + numbers[ptrTwo];
        if(target == currSum)
        {
            return new int[2]{ptrOne + 1, ptrTwo + 1};
        }

        if(currSum < target)
        {
            ptrOne++;
        }
        else
        {
            ptrTwo--;
        }
    }

    return new int[2]{-1, -1};
}

Debug.Assert(TwoSum([1,2,3,4], 3).SequenceEqual([1,2]));
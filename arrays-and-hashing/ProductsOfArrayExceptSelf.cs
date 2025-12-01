using System.Diagnostics;

int[] ProductExceptSelf(int[] nums)
{
    var output = new int[nums.Length];
    var prefix = new int[nums.Length];
    var suffix = new int[nums.Length];

    for(int i = 0; i < nums.Length; i++)
    {
        if(i == 0)
        {
            prefix[i] = nums[i];
        }
        else
        {
            prefix[i] = nums[i] * prefix[i-1];
        }
    }

    var lastIdx = nums.Length - 1;
    for(int i = lastIdx; i >= 0; i--)
    {
        if(i == lastIdx)
        {
            suffix[lastIdx] = nums[lastIdx];
        }
        else
        {
            suffix[i] = nums[i] * suffix[i+1];
        }
    }

    for(int i = 0; i < nums.Length; i++)
    {
        if(i == 0)
        {
            output[i] = suffix[i + 1];
        }
        else if(i == lastIdx)
        {
            output[i] = prefix[i-1];
        }
        else
        {
            output[i] = prefix[i-1] * suffix[i+1];
        }
    }

    return output;
}

Debug.Assert(ProductExceptSelf([1,2,4,6]).SequenceEqual([48,24,12,8]));
Debug.Assert(ProductExceptSelf([-1,0,1,2,3]).SequenceEqual([0,-6,0,0,0]));
using System.Diagnostics;

bool hasDuplicate(int[] nums)
{
    var numSet = new HashSet<int>();
    foreach(var num in nums)
    {
        if(numSet.Contains(num))
        {
            return true;
        }
        numSet.Add(num);
    }
    return false;
}

Debug.Assert(hasDuplicate([1, 2, 2, 3]) == true);
Debug.Assert(hasDuplicate([]) == false);
Debug.Assert(hasDuplicate([1, 2, 3]) == false);
Debug.Assert(hasDuplicate([-1, -1, 2, 3]) == true);
Debug.Assert(hasDuplicate([-1, -1, 2, 3, 3]) == true);

using System.Diagnostics;

List<List<int>> ThreeSum(int[] nums)
{
    Array.Sort(nums);
    var res = new List<List<int>>();

    for(int i = 0; i < nums.Length - 1; i++)
    {
        if(nums[i] > 0) break;
        if(i > 0 && nums[i] == nums[i - 1]) continue;

        var l = i + 1;
        var r = nums.Length - 1;
        while(l < r)
        {
            var sum = nums[i] + nums[l] + nums[r];
            if(sum > 0)
            {
                r--;
            }
            else if(sum < 0)
            {
                l++;
            }
            else
            {
                res.Add(new List<int>{nums[i],nums[l],nums[r]});
                l++;
                r--;
                while(l < r && nums[l] == nums[l - 1])
                {
                    l++;
                }
            }
        }
    }

    return res;
}

var list = ThreeSum([-1,0,1,2,-1,-4]);
var expected = new List<List<int>>{
    new List<int>{-1,-1,2},
    new List<int>{-1,0,1}
};
Debug.Assert(testLists(list, expected));


var listTwo = ThreeSum([0,0,0]);
var expectedTwo = new List<List<int>>{
    new List<int>{0, 0, 0}
};
Debug.Assert(testLists(listTwo, expectedTwo));

bool testLists(List<List<int>> listOne, List<List<int>> listTwo)
{
    if(listOne.Count() != listTwo.Count()) return false;

    for(int i = 0; i < listOne.Count(); i++)
    {
        if(!listOne[i].SequenceEqual(listTwo[i])) return false;
    }

    return true;
}
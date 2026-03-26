var sol = new Solution();
var res = sol.MergeTriplets([[15,9,8],[2,4,4],[2,6,1],[10,9,4],[10,4,1],[2,12,11],[1,4,2],[15,1,14],[6,2,9],[4,5,11]], [10,9,9]);

public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        bool firstOK = false;
        bool secondOK = false;
        bool thirdOK = false;

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < triplets.Length; j++)
            {
                // exact match means we can short circuit with 'true'.
                if(triplets[j][0] == target[0] && triplets[j][1] == target[1] && triplets[j][2] == target[2])
                    return true;

                if(i == 0 && triplets[j][0] == target[0] && triplets[j][1] <= target[1] && triplets[j][2] <= target[2])
                {
                    firstOK = true;
                    break;
                }
                if(i == 1 && triplets[j][0] <= target[0] && triplets[j][1] == target[1] && triplets[j][2] <= target[2])
                {
                    secondOK = true;
                    break;
                }
                if(i == 2 && triplets[j][0] <= target[0] && triplets[j][1] <= target[1] && triplets[j][2] == target[2])
                {
                    thirdOK = true;
                    break;
                }
            }
        }
        return firstOK && secondOK && thirdOK; 
    }
}

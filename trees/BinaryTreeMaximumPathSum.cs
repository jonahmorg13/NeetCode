#:property PublishAot=false
var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
var sol = new Solution();
var test = sol.MaxPathSum(root);
return 0;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public int MaxPathSum(TreeNode root) {
        var q = new Queue<TreeNode>();
        var stack = new Stack<TreeNode>();
        var map = new Dictionary<TreeNode, int>();
        var res = Int32.MinValue;

        if(root == null) return 0;

        q.Enqueue(root);
        stack.Push(root);

        while(q.Count > 0)
        {
            var amount = q.Count;
            for(int i = 0; i < amount; i++)
            {
                var node = q.Dequeue();
                if(node.left != null)
                {
                    q.Enqueue(node.left);
                    stack.Push(node.left);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                    stack.Push(node.right);
                }
            }
        }

        while(stack.Count > 0)
        {
            var curr = stack.Pop();
            var leftVal = 0;
            var rightVal = 0;

            if(curr.left != null && map.ContainsKey(curr.left))
            {
                leftVal = map[curr.left];
            }
            if(curr.right != null && map.ContainsKey(curr.right))
            {
                rightVal = map[curr.right];
            }

            var sumOne = curr.val;
            var sumTwo = curr.val + leftVal;
            var sumThree = curr.val + rightVal;
            var sumFour = curr.val + leftVal + rightVal;
            var valForMap = Math.Max(sumOne, sumTwo);
            valForMap = Math.Max(valForMap, sumThree);
            res = Math.Max(res, valForMap);
            res = Math.Max(res, Math.Max(valForMap, sumFour));

            map[curr] = valForMap;
        }

        return res;
    }
}

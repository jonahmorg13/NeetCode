// https://www.youtube.com/watch?v=Wcv0600V5q4
// https://www.youtube.com/watch?v=EPMql3dljqU

public class Solution {

    public List<List<int>> LevelOrder(TreeNode root) {
        var res = new List<List<int>>();
        var queue = new Queue<TreeNode>();

        if(root == null) return res;       
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var level = new List<int>();
            var amount = queue.Count;
            for(int i = 0; i < amount; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            res.Add(level);
        }
        return res;
    }
}

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
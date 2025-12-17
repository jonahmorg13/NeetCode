public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    // can do this many ways! recursivly using DFS. or using a queue BFS.
    // could we use a stack and DFS?
    // yes, you can store a tuple of the node itself associated with it's calcualted depth
    // would be useful if we needed to know the depth of each node :0

    // public int MaxDepth(TreeNode root)
    // {
    //     var depth = DFS(root);
    //     return depth;
    // }

    // private int DFS(TreeNode node)
    // {
    //     if(node == null) return 0;
    //     var left = DFS(node.left);
    //     var right = DFS(node.right);
    //     return 1 + Math.Max(left, right);
    // }

    public int MaxDepth(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        if(root != null)
            q.Enqueue(root);

        int level = 0;
        while(q.Count > 0)
        {
            int size = q.Count;
            for(int i = 0; i < size; i++)
            {
                TreeNode node = q.Dequeue();
                if(node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            level++;
        }
        return level;
    }
}
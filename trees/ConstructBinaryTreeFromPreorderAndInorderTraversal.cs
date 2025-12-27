#:property PublishAot=false
var sol = new Solution();
var test = sol.BuildTree([1,2,3,4], [2,1,3,4]);
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return DFS(preorder, inorder, 0, preorder.Length - 1, 0, preorder.Length - 1);
    }

    private TreeNode DFS(int[] preorder, int[] inorder, int start, int end, int inorderStart, int inorderEnd)
    {
        // edge case for if the tree is empty
        if(start > end) return null;

        // edge case for if the tree will only have one node
        var root = new TreeNode(preorder[start]);

        // we have a tree with at least one child
        // get the size of the left tree
        var i = inorderStart;
        var leftSize = 0;
        while(inorder[i] != preorder[start])
        {
            i++;
            leftSize++;
        }

        // ok, now lets recursively call our solution for both the left and the right node.
        root.left = DFS(preorder, inorder, start + 1, start + leftSize, inorderStart, inorderStart + leftSize - 1);
        root.right = DFS(preorder, inorder, start + leftSize + 1, end, inorderStart + leftSize + 1, inorderEnd);

        return root;
    }
}
 
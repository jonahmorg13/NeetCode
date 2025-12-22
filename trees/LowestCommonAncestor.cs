
// Create the tree from the image:
//         5
//        / \
//       3   8
//      / \ / \
//     1  4 7  9
//      \
//       2

using System.Diagnostics;

TreeNode root = new TreeNode(5);
root.left = new TreeNode(3);
root.right = new TreeNode(8);
root.left.left = new TreeNode(1);
root.left.right = new TreeNode(4);
root.left.left.right = new TreeNode(2);
root.right.left = new TreeNode(7);
root.right.right = new TreeNode(9);

Debug.Assert(LowestCommonAncestor(root, root.left.left.right, root.left) == root.left);

TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    var pStack = BSTPath(root, p);
    var qStack = BSTPath(root, q);

    while(pStack.Count != qStack.Count) {
        if(pStack.Count > qStack.Count) {
            pStack.Pop();
        }
        else {
            qStack.Pop();
        }
    }

    while(pStack.Peek().val != qStack.Peek().val) 
    {
        pStack.Pop();
        qStack.Pop();
    }

    return pStack.Peek();
}

Stack<TreeNode> BSTPath(TreeNode root, TreeNode p) {
    var stack = new Stack<TreeNode>();

    var currNode = root;
    while(currNode != null)
    {
        stack.Push(currNode);
        if(currNode.val == p.val)
            break;

        if(p.val < currNode.val)
            currNode = currNode.left;
        else 
            currNode = currNode.right;
    }
    return stack;
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

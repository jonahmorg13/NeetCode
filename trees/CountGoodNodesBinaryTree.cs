using System;
using System.Collections.Generic;

var root = new TreeNode(2,
    new TreeNode(1,
        new TreeNode(3),
        null
    ),
    new TreeNode(1,
        new TreeNode(1),
        new TreeNode(5)
    )
);

var sol = new Solution();
Console.WriteLine(sol.GoodNodes(root));

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
    public int GoodNodes(TreeNode root) {
        // we need to do a dfs, and the current node must be greater than or equal to the max value on the current
        // path downwards
        // for this example, we will use a stack
        if(root == null) return 0;
        var res = 0;

        var stack = new Stack<Tuple<TreeNode, int>>();
        stack.Push(new Tuple<TreeNode,int>(root, root.val));

        while(stack.Count > 0)
        {
            var (node, heightToBeat) = stack.Pop();
            if(node.val >= heightToBeat) res++;
            var newHeight = node.val >= heightToBeat ? node.val : heightToBeat;
            if(node.left != null)
            {
                stack.Push(new Tuple<TreeNode,int>(node.left, newHeight));
            }
            if(node.right != null)
            {
                stack.Push(new Tuple<TreeNode,int>(node.right, newHeight));
            }
        }

        return res;
    }
}

using System.Diagnostics;

TreeNode InvertTree(TreeNode node)
{
    if(node == null) return null;

    var temp = node.left;
    node.left = node.right;
    node.right = temp;

    InvertTree(node.left);
    InvertTree(node.right);

    return node;
}

var four = new TreeNode(4);
var five = new TreeNode(5);
var six = new TreeNode(6);
var seven = new TreeNode(7);


var two = new TreeNode(2, four, five);
var three = new TreeNode(3, six, seven);

var one = new TreeNode(1, two, three);

var inverted = InvertTree(one);
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

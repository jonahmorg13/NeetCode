using System.Diagnostics;

var three = new TreeNode(3);
var two = new TreeNode(2);
var one = new TreeNode(1, two, three);


var threeTwo = new TreeNode(3);
var twoTwo = new TreeNode(2);
var oneTwo = new TreeNode(1, twoTwo, threeTwo);

Debug.Assert(IsSameTree(one, oneTwo));

// Root tree: 1 -> (2 -> (4, 5), 3)
var four = new TreeNode(4);
var five = new TreeNode(5);
var rootTwo = new TreeNode(2, four, five);
var rootThree = new TreeNode(3);
var root = new TreeNode(1, rootTwo, rootThree);

// Subroot tree: 2 -> (4, 5)
var subFour = new TreeNode(4);
var subFive = new TreeNode(5);
var subRoot = new TreeNode(2, subFour, subFive);

Debug.Assert(IsSubTree(root, subRoot));

// Root tree with extra node: 1 -> (2 -> (4 -> 6, 5), 3)
var six2 = new TreeNode(6);
var four2 = new TreeNode(4, six2, null);
var five2 = new TreeNode(5);
var rootTwo2 = new TreeNode(2, four2, five2);
var rootThree2 = new TreeNode(3);
var root2 = new TreeNode(1, rootTwo2, rootThree2);

// Subroot tree: 2 -> (4, 5) - should NOT match because root2's 4 has child 6
var subFour2 = new TreeNode(4);
var subFive2 = new TreeNode(5);
var subRoot2 = new TreeNode(2, subFour2, subFive2);

Debug.Assert(!IsSubTree(root2, subRoot2));

bool IsSubTree(TreeNode root, TreeNode subRoot)
{
    if(root == null && subRoot == null) return true;
    if(root == null || root == null) return false;

    var stack = new Stack<TreeNode>();
    stack.Push(root);

    while(stack.Count > 0) {
        var currNode = stack.Pop();
        if(IsSameTree(currNode, subRoot)) return true;

        if(currNode.left != null)
            stack.Push(currNode.left);
        if(currNode.right != null)
            stack.Push(currNode.right);

    }

    return false;
}

bool IsSameTree(TreeNode p, TreeNode q)
{
    // edge cases for nulls
    if(p == null && q == null) return true;
    if(p == null || q == null) return false;

    // put the roots into the queue since they both exist
    var queue = new Queue<Tuple<TreeNode, TreeNode>>();
    queue.Enqueue(new Tuple<TreeNode, TreeNode>(p, q));

    while(queue.Count > 0)
    {
        var treeLevelAmount = queue.Count;
        for(int i = 0; i < treeLevelAmount; i++)
        {
            var (leftNode, rightNode) = queue.Dequeue();
            if(leftNode.val != rightNode.val) return false;
            
            if(leftNode.left != null && rightNode.left != null)
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(leftNode.left, rightNode.left));
            else if(leftNode.left != null || rightNode.left != null)
                return false;

            if(leftNode.right != null && rightNode.right != null)
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(leftNode.right, rightNode.right));
            else if(leftNode.right != null || rightNode.right != null)
                return false;
        }
    }

    return true;
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
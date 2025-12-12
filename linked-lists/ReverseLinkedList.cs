using System.Diagnostics;

var sol = new Solution();

var three = new ListNode(3);
var two = new ListNode(2, three);
var one = new ListNode(1, two);

var reversed = sol.ReverseList(one);
return 0;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

 
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        var currNode = head;
        while(currNode != null)
        {
            var next = currNode.next;
            currNode.next = prev;
            prev = currNode;
            currNode = next;
        }
        return prev;
    }
}

var six = new ListNode(6);
var five = new ListNode(5, six);
var four = new ListNode(4, five);
var three = new ListNode(3, four);
var two = new ListNode(2, three);
var one = new ListNode(1, two);
var zero = new ListNode(0, one);

var sol = new Solution();
var reordered = sol.ReorderList(zero);

return 0;

public class Solution {
    public void ReorderList(ListNode head) {
        
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

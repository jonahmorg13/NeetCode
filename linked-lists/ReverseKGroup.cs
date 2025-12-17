using System.Diagnostics;

var five = new ListNode(5);
var four = new ListNode(4, five);
var three = new ListNode(3, four);
var two = new ListNode(2, three);
var one = new ListNode(1, two);

var reversed = ReverseKGroup(one, 3);
return 0;

ListNode ReverseKGroup(ListNode head, int k)
{
    if(head == null) return null;
    if(head.next == null) return head;

    ListNode dummy =  new ListNode(-1);
    var currPtr = head;
    var currHead = currPtr;
    var tail = dummy;

    while(currPtr != null)
    {
        // we need to point the tail of the last list to the head of the new list
        int i = 0;
        while(i < k - 1 && currHead.next != null)
        {
            i++;
            currHead = currHead.next;
        }

        // determine if we need to do an early return
        if(currHead.next == null && i < k - 1)
        {
            tail.next = currPtr;
            break;
        }
        
        tail.next = currHead;
        currHead = currHead.next;

        tail = currPtr;
        ListNode prev = null;

        // time to reverse the sublist
        while(currPtr != currHead)
        {
            var next = currPtr.next;
            currPtr.next = prev;
            prev = currPtr;
            currPtr = next;
        }
    }

    return dummy.next;
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

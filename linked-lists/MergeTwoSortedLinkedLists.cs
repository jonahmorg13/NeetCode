using System.Diagnostics;

var sol = new Solution();

var three = new ListNode(3);
var two = new ListNode(2, three);
var one = new ListNode(1, two);


var threeTwo = new ListNode(3);
var twoTwo = new ListNode(2, threeTwo);
var oneTwo = new ListNode(1, twoTwo);

var merged = sol.MergeTwoLists(one, oneTwo);
return 0;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if(list1 == null) return list2;
        if(list2 == null) return list1;

        ListNode head = null;
        var nextOne = list1;
        var nextTwo = list2;

        if(list1.val < list2.val)
        {
            head = list1;
            nextOne = list1.next;
        }
        else
        {
            head = list2;
            nextTwo = list2.next;
        }
        var retNode = head;

        while(nextOne != null && nextTwo != null)
        {
            if(nextOne.val < nextTwo.val)
            {
                var next = nextOne;
                nextOne = nextOne.next;
                head.next = next;
            }
            else
            {
                var next = nextTwo;
                nextTwo = nextTwo.next;
                head.next = next;
            }
            head = head.next;
        }

        if(nextOne != null)
        {
            head.next = nextOne;
        }
        else
        {
            head.next = nextTwo;
        }

        return retNode;
    }
}
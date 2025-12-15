
var three = new ListNode(9);
var two = new ListNode(9, three);
var one = new ListNode(9, two);

var sldf = new ListNode(9);
var sldf2 = new ListNode(9, sldf);
var sldf23 = new ListNode(9, sldf2);
var nine = new ListNode(9);
var five = new ListNode(9, nine);
var four = new ListNode(9, five);

var newNumbers = AddTwoNumbers(one, four);
return 0;

ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    var l1Ptr = l1;
    var l2Ptr = l2;

    var newList = new ListNode(-1);
    var newListPtr = newList;
    var remainder = 0;
    while(l1Ptr != null && l2Ptr != null)
    {
        var currVal = l1Ptr.val + l2Ptr.val + remainder;
        var mod10 = (currVal) % 10;
        if(currVal >= 10)
        {
            remainder = currVal / 10;
            currVal = mod10;
        }
        else
        {
            remainder = 0;
        }
        var newNode = new ListNode(currVal);

        newListPtr.next = newNode;
        newListPtr = newListPtr.next;

        l1Ptr = l1Ptr.next;
        l2Ptr = l2Ptr.next;
    }

    while(l1Ptr != null)
    {
        var currVal = l1Ptr.val + remainder;
        var mod10 = (currVal) % 10;
        if(currVal >= 10)
        {
            remainder = currVal / 10;
            currVal = mod10;
        }
        else
        {
            remainder = 0;
        }
        var newNode = new ListNode(currVal);

        newListPtr.next = newNode;
        newListPtr = newListPtr.next;

        l1Ptr = l1Ptr.next;
    }


    while(l2Ptr != null)
    {
        var currVal = l2Ptr.val + remainder;
        var mod10 = (currVal) % 10;
        if(currVal >= 10)
        {
            remainder = currVal / 10;
            currVal = mod10;
        }
        else
        {
            remainder = 0;
        }
        var newNode = new ListNode(currVal);

        newListPtr.next = newNode;
        newListPtr = newListPtr.next;

        l2Ptr = l2Ptr.next;
    }

    if(remainder != 0)
    {
        var newNode = new ListNode(remainder);
        newListPtr.next = newNode;
    }

    return newList.next;
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
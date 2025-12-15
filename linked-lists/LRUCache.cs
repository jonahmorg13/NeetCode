LRUCache lRUCache = new LRUCache(2);
lRUCache.Put(1, 10);  // cache: {1=10}
var getOneOne = lRUCache.Get(1);      // return 10
lRUCache.Put(2, 20);  // cache: {1=10, 2=20}
lRUCache.Put(3, 30);  // cache: {2=20, 3=30}, key=1 was evicted
var getTwo = lRUCache.Get(2);      // returns 20 
var getOne = lRUCache.Get(1); 

return 0;

public class LRUCache {
    private class Node
    {
        public int key {get; set;}
        public int val {get; set;}
        public Node? next;
        public Node? prev;
        public Node(int key, int val)
        {
            this.key = key;
            this.val = val;
            next = null;
            prev = null;
        }
    }

    private class DoublyLinkedList
    {
        public Node head;
        public Node tail;
        public int capacity;
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            capacity = 0;
        }
    }

    private Dictionary<int, Node> map;
    private DoublyLinkedList list;
    private int maxCapacity;

    public LRUCache(int capacity) {
        map = new Dictionary<int, Node>(); 
        list = new DoublyLinkedList();
        maxCapacity = capacity;
    }
    
    public int Get(int key) {
        if(map.ContainsKey(key))
        {
            var node = map[key];
            UpdateCacheKeyValue(key, node.val);
            return node.val;
        }
        else
            return -1;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key))
            UpdateCacheKeyValue(key, value);
        else
            InsertCacheKeyValue(key, value);
    }

    private void UpdateCacheKeyValue(int key, int value)
    {
        var currNode = map[key];
        currNode.val = value;

        // if it's already the tail, no need to move
        if(currNode == list.tail)
            return;

        // point the prev node at the next node
        var prev = currNode.prev;
        var next = currNode.next;
        if(prev != null)
        {
            prev.next = next;
        }
        else
        {
            // currNode is the head
            list.head = next;
        }
        
        if(next != null)
        {
            next.prev = prev;
        }

        // make currNode the tail node
        var currTail = list.tail;
        currTail.next = currNode;
        currNode.prev = currTail;
        currNode.next = null;

        list.tail = currNode;
    }

    private void InsertCacheKeyValue(int key, int value)
    {
        var newNode = new Node(key, value);
        map[key] = newNode;            

        // it's empty
        if(list.capacity <= 0)
        {
            list.head = newNode;
            list.tail = newNode;
            list.capacity++;
            return;
        }

        list.tail.next = newNode;
        newNode.prev = list.tail;
        list.tail = newNode;

        // it's at the max capacity
        if(list.capacity >= maxCapacity)
        {
            map.Remove(list.head.key);

            // move the head pointer
            var newHead = list.head.next;
            list.head.next = null;
            list.head = newHead;
            if(list.head != null)
                list.head.prev = null;

            list.capacity--;
        }

        list.capacity++;
    }
}
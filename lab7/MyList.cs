using System;
using System.Collections;
using System.Text;

public class MyList<T> where T : IComparable, IEnumerable<T>
{

    private class MyListNode : IComparable<T>
    {
        public T Data { get; set; }
        public MyListNode? Next { get; set; }

        public MyListNode(T data, MyTreeNode? next = null)
        {
            this.Data = data;
            this.Next = next;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


    }




    private MyListNode? head = null;

    public MyList()
    {
        head = null;
    }

    public void pushBack(T value)
    {
        if (head == null)
        {
            head = new MyListNode(value);
            return;
        }

        var cur = head;
        for(; cur.Next != null; cur = cur.Next);
        cur.Next = new MyListNode(value);

    }

    public void pushFront(T value)
    {
        var newHead = new MyListNode(value, this.head);
        this.head = newHead;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for(var cur = head; cur != null; cur = cur.Next)
        {
            sb.AppendLine(cur.Data.ToString());
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var node = this.head; node != null; node = node.Next)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void print()
    {
        Console.WriteLine(this.ToString());
    }

    public void printReversed()
    {
        reverse();
        print();
        reverse();
    }

    public void reverse()
    {
        var cur = this.head;
        var next;
        var prev;

        if(cur == null || cur.Next == null)
        {
            return;
        }

        next = cur.Next;
        cur.Next = null;
        while(next.Next != null)
        {
            prev = cur;
            cur = next;
            next = cur.Next;

            cur.Next = prev;

        }

        next.Next = cur;
        head = next;

    }







}
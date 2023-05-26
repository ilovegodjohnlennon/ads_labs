using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MyList<T> : IEnumerable<T> where T : IComparable
{

    private class MyListNode : IComparable<T>
    {
        public T Data { get; set; }
        public MyListNode? Next { get; set; }
        public MyListNode? Prev {get; set;}

        public MyListNode(T data, MyListNode? next = null, MyListNode? prev = null)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


    }




    private MyListNode? head = null;
    private MyListNode? tail = null;

    public MyList()
    {
        head = null;
        tail = null;
    }

    public void pushBack(T value)
    {
        if (head == null)
        {
            head = new MyListNode(value);
            tail = head;
            return;
        }

        tail.Next = new MyListNode(value, null, tail);
        tail = tail.Next;

    }

    public void pushFront(T value)
    {
        if(head == null)
        {
            head = new MyListNode(value, null, null);
            tail = head;
            return;
        }

        var newHead = new MyListNode(value, this.head, null);
        this.head.Prev = newHead;
        this.head = newHead;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (var cur = head; cur != null; cur = cur.Next)
        {
            sb.AppendLine(cur.Data.ToString());
        }

        return sb.ToString();
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
        for(var cur = tail; cur != null; cur = cur.Prev)
        {
            Console.WriteLine(cur.Data);
        }
    }


    public bool containsValue(T value)
    {
        for (var cur = head; cur != null; cur = cur.Next)
        {
            if (value.CompareTo(cur.Data) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public T at(int index)
    {
        return nodeAt(index).Data;
    }

    private MyListNode nodeAt(int index)
    {
        var cur = head;
        if (cur == null)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = 0; i < index; i++)
        {
            cur = cur.Next;
            if (cur == null)
            {
                throw new IndexOutOfRangeException();
            }
        }

        return cur;
    }

    public int size()
    {
        int res = 0;

        for (var cur = head; cur != null; cur = cur.Next) res++;

        return res;
    }


    public void insertBefore(int index, T value)
    {
        if (index == 0)
        {
            pushFront(value);
            return;
        }


        MyListNode cur = nodeAt(index - 1);

        if(cur.Next == null)
        {
            throw new IndexOutOfRangeException("Cannot insert before non-existent element!");
        }

        var newNode = new MyListNode(value, cur.Next, cur);
        cur.Next = newNode;
        newNode.Next.Prev = newNode;


    }

    public void insertAfter(int index, T value)
    {
        var cur = nodeAt(index);

        if(cur.Next == null)
        {
            pushBack(value);
            return;
        }

        var newNode = new MyListNode(value, cur.Next, cur);
        cur.Next = newNode;
        newNode.Next.Prev = newNode;
    }

    public void removeFront()
    {
        if (head == null)
        {
            throw new Exception("Cannot remove from empty list!");
        }

        if(head.Next == null)
        {
            head = null;
            tail = null;
            return;
        }

        var tmp = head.Next;
        head.Next = null;
        head = tmp;
        head.Prev = null;
    }

    public void removeBack()
    {
        if (head == null)
        {
            throw new Exception("Cannot remove from empty list!");
        }

        if(tail.Prev == null)
        {
            head = null;
            tail = null;
            return;
        }

        var tmp = tail.Prev;
        tail.Prev = null;
        tail = tmp;
        tail.Next = null;
    }

    public void removeBefore(int index)
    {
        if (index < 1)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 1)
        {
            removeFront();
            return;
        }

        removeAfter(index - 2);
    }

    public void removeAfter(int index)
    {
        var cur = nodeAt(index);

        if (cur.Next == null)
        {
            return;
        }
        if(cur.Next == tail)
        {
            removeBack();
            return;
        }

        var next = cur.Next;
        cur.Next = next.Next;
        cur.Next.Prev = cur;
        next.Next = null;
        next.Prev = null;
    }







}
using System.Collections;
using System.Text;

public class MyQueue<T>: IEnumerable<T>
{
    private MyQueueNode<T>? head;
    private MyQueueNode<T>? tail;

    public MyQueue()
    {
        head = null;
        tail = null;
    }

    public void enqueue(T data)
    {
        MyQueueNode<T> newNode = new MyQueueNode<T>(data);

        if(this.tail != null)
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail = newNode;
            this.head = newNode;
        }
    }

    public T dequeue()
    {
        MyQueueNode<T> ret;

        if(head == null)
        {
            throw new NullReferenceException("Queue is empty!");
        }

        if(head.Next == null)
        {
            ret = this.head;

            this.head = null;
            this.tail = null;

            return ret.Data;
        }

        ret = this.head;

        this.head = this.head.Next;
        ret.Next = null;

        return ret.Data;

    }

    public T peek()
    {
        if(this.head == null)
        {
            throw new NullReferenceException("Queue is empty!");
        }

        return this.head.Data;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        for(var cur = this.head; cur != null; cur = cur.Next)
        {
            sb.AppendLine(cur.Data.ToString());
        }


        return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var p = this.head; p != null; p = p.Next)
        {
            yield return p.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
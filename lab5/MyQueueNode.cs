

public class MyQueueNode<T>
{
    public T Data { set; get; }
    public MyQueueNode<T>? Next { get; set; }

    public MyQueueNode(T data, MyQueueNode<T>? next = null)
    {
        this.Data = data;
        this.Next = next;
    }

    public void invalidate()
    {
        this.Next = null;
    }

}
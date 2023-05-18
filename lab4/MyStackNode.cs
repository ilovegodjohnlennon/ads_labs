

public class MyStackNode<T>
{
    public T Data { set; get;}
    public MyStackNode<T>? Next {get; set;}
    
    public MyStackNode(T data, MyStackNode<T>? next = null)
    {
        this.Data = data;
        this.Next = next;
    }

    public void invalidate()
    {
        this.Next = null;
    }

}
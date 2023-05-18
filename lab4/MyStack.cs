

using System.Collections;

public class MyStack<T>: IEnumerable<T>
{
    private MyStackNode<T>? top;

    public MyStack()
    {
        top = null;
    }


    public void push(T data)
    {
        var prevTop = this.top;

        this.top = new MyStackNode<T>(data, prevTop);
    }

    public T peek()
    {
        if(this.top == null)
        {
            throw new NullReferenceException("Stack is empty!");
        }

        return this.top.Data;
    }

    public void clear()
    {
        while(this.top != null)
        {
            pop();
        }
    }

    public bool empty()
    {
        return this.top == null;
    }

    public T pop()
    {
        if(this.top == null)
        {
            throw new NullReferenceException("Stack is empty!");
        }

        var popped = this.top;
        this.top = popped.Next;
        popped.Next = null;
        return popped.Data;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(var node = this.top; node != null; node = node.Next)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public static void randomFill(MyStack<int> stack, int size, int range_min = -1000, int range_max = 1000)
    {
        var rand = new Random();

        stack.clear();
        for(int i = 0; i < size; i++)
        {
            stack.push(rand.Next(range_min, range_max));
        }

    }

    public static void swap(MyStack<T> a, MyStack<T> b)
    {
        var tmp = a.top;

        a.top = b.top;
        b.top = tmp;
    }
}
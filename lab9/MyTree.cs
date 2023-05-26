using System;
using System.Collections;

public class MyTree<T> where T: IComparable
{

    private class MyTreeNode : IComparable<T>
    {
        public T Data { get; set; }
        public MyTreeNode? Left { get; set; }
        public MyTreeNode? Right { get; set; }

        public MyTreeNode(T data, MyTreeNode? left = null, MyTreeNode? right = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public void invalidate()
        {
            this.Left = null;
            this.Right = null;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


    }




    private MyTreeNode? root = null;

    public MyTree()
    {
        root = null;
    }

    public void addNode(T value)
    {
        if(root == null)
        {
            root = new MyTreeNode(value);
            return;
        }

        var cur = this.root;
        while(true)
        {
            if(value.CompareTo(cur.Data) > 0)
            {
                if(cur.Right == null)
                {
                    cur.Right = new MyTreeNode(value);
                    return;
                }

                cur = cur.Right;
                continue;
            }

            if(cur.Left == null)
            {
                cur.Left = new MyTreeNode(value);
                return;
            }

            cur = cur.Left;
            continue;
        }
    }

    public void print()
    {
        printSubtree(root, 0);
    }

    private readonly static int maxPrintDepth = 8;
    private void printSubtree(MyTreeNode? node, int depth)
    {
        if(node == null || depth > maxPrintDepth)
        {
            return;
        }

        for(int i = 0; i < depth; i++) Console.Write("  ");
        Console.WriteLine(node.Data);

        printSubtree(node.Left, depth + 1);
        printSubtree(node.Right, depth + 1);
    }


    public int minLeafDistance()
    {
        return -1;
    }

    public int maxLeafDistance()
    {
        int res = -1;
        maxLeafDistanceHelper(root, ref res);
        return res;
    }

    // returns max depth of leaf
    private int maxLeafDistanceHelper(MyTreeNode? node, ref int res)
    {
        if(node == null)
        {
            return -1;
        }

        if(node.Left == null && node.Right == null)
        {
            return 0;
        }

        int max_depth_left = maxLeafDistanceHelper(node.Left, ref res);
        int max_depth_right = maxLeafDistanceHelper(node.Right, ref res);

        if(node.Left == null)
        {
            return max_depth_right + 1;
        }

        if(node.Right == null)
        {
            return max_depth_left + 1;
        }

        res = Math.Max(res, max_depth_left + max_depth_right + 2);
        return Math.Max(max_depth_left, max_depth_right) + 1;

    }




}
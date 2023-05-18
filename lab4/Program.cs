using System;
using System.Numerics;

namespace Lab3
{

    public class Program
    {

        public static void Main()
        {
            ConsoleKeyInfo K;
            MyStack<int> stack = new MyStack<int>();
            int tmp;

            do
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("1 - fill stack");
                Console.WriteLine("2 - sort stack");
                Console.WriteLine("3 - compare sum of positive elements to sum of negative elements");
                Console.WriteLine("4 - print stack");
                Console.WriteLine("ESC - quit\n\n");

                K = Console.ReadKey();
                switch(K.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Please input size of stack!");
                        try
                        {
                            tmp = readInt();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Could not parse input");
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        MyStack<int>.randomFill(stack, tmp);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D2:
                        sort(stack);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D3:
                        var res = sum(stack);
                        if(res > 0)
                        {
                            Console.WriteLine("Sum of positive elements is greater than sum of negative elements!");
                        }
                        else if(res < 0)
                        {
                            Console.WriteLine("Sum of negative elements is greater than the sum of positive elements");
                        }
                        else
                        {
                            Console.WriteLine("Sums of positive and negative elements are equal");
                        }
                        break;
                        
                    case ConsoleKey.D4:
                        printIntStack(stack);
                        break;
                        


                    default:
                     break;
                }

                System.Threading.Thread.Sleep(1000);
            }
            while(K.Key != ConsoleKey.Escape);
        }


        public static BigInteger sum(MyStack<int> stack)
        {
            BigInteger res = 0;

            foreach(var x in stack) res += x;

            return res;
        }

        public static void sort(MyStack<int> stack)
        {
            int tmp;
            MyStack<int> aux = new MyStack<int>();

            while(!stack.empty())
            {
                tmp = stack.pop();
                while(!aux.empty() && aux.peek() < tmp)
                {
                    stack.push(aux.pop());
                }
                aux.push(tmp);
            }

            MyStack<int>.swap(stack, aux);
        }

        public static int readInt()
        {
            String? line;
            int res;

            line = Console.ReadLine();

            if(line == null)
            {
                throw new Exception("Received ctrl-d");
            }

            res = Int32.Parse(line);

            return res;
        }

        public static void printIntStack(MyStack<int> stack)
        {
            foreach(var x in stack)
            {
                Console.WriteLine(x);
            }
        }

    }


}

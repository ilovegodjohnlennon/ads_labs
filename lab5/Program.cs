using System;
using System.Numerics;

namespace Lab5
{

    public class Program
    {

        public static void Main()
        {
            ConsoleKeyInfo K;
            MyQueue<int> que = new MyQueue<int>();
            int tmp;

            do
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("1 - fill queue");
                Console.WriteLine("2 - sort queue");
                Console.WriteLine("3 - move evens to beginning, odds to end of queue");
                Console.WriteLine("4 - print queue");
                Console.WriteLine("ESC - quit\n\n");

                K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Please input size of queue!");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not parse input");
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        randomFill(que, tmp);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D2:
                        sort(que);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D3:
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine(que.ToString());
                        break;



                    default:
                        break;
                }

                System.Threading.Thread.Sleep(1000);
            }
            while (K.Key != ConsoleKey.Escape);
        }



        public static void sort(MyQueue<int> que)
        {
            
        }

        public static void randomFill(MyQueue<int> que, int N)
        {
            Random rand = new Random();
            for(int i = 0; i < N; i++)
            {
                que.enqueue(rand.Next(-1000, 1000));
            }

        }

        public static int readInt()
        {
            String? line;
            int res;

            line = Console.ReadLine();

            if (line == null)
            {
                throw new Exception("Received ctrl-d");
            }

            res = Int32.Parse(line);

            return res;
        }


    }


}

using System;
using System.Numerics;

namespace Lab9
{

    public class Program
    {

        public static void Main()
        {
            ConsoleKeyInfo K;
            MyTree<int> tree = new MyTree<int>();
            int tmp;

            do
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("1 - add node");
                Console.WriteLine("2 - print tree");
                Console.WriteLine("3 - delete node");
                Console.WriteLine("4 - find min and max path between leaves");
                Console.WriteLine("5 - add a child to each leaf");
                Console.WriteLine("ESC - quit\n\n");

                K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Please input value of new node");
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
                        tree.addNode(tmp);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D2:
                        tree.print();
                        break;
                    case ConsoleKey.D3:
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("Max dist between leaves: {0}", tree.maxLeafDistance());
                        break;



                    default:
                        break;
                }

                System.Threading.Thread.Sleep(1000);
            }
            while (K.Key != ConsoleKey.Escape);
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

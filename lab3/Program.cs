using System;
using System.Diagnostics;

namespace Program
{
    public class ArraysLab
    {

        public static void Main()
        {
            ConsoleKeyInfo K;
            int tmp;
            int res;
            Stopwatch stopwatch;

            MyArray arr = new MyArray();

            do
            {
                //Console.Clear();
                Console.Write("\n\n\n\n\n\n\n\n\n");

                Console.WriteLine("1 - fill array");
                Console.WriteLine("2 - print whole array");
                Console.WriteLine("3 - print first 100 elements");
                Console.WriteLine("4 - sort array (insert)");
                Console.WriteLine("5 - sort array (quick)");
                Console.WriteLine("6 - check if array is sorted");
                Console.WriteLine("7 - binary search");
                Console.WriteLine("8 - interpolation search");
                Console.WriteLine("ESC - quit\n\n");

                K = Console.ReadKey();
                Console.WriteLine();
                switch (K.Key)
                {
                    case System.ConsoleKey.D1:
                        Console.WriteLine("Pls input the size of the array!!");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not read input!");
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        arr.populate(tmp);
                        Console.WriteLine("    done");
                        break;
                    case System.ConsoleKey.D2:
                        arr.print();
                        break;
                    case System.ConsoleKey.D3:
                        arr.print(100);
                        break;
                    case System.ConsoleKey.D4:
                        stopwatch = Stopwatch.StartNew();
                        arr.insertSort();
                        stopwatch.Stop();
                        Console.WriteLine("   done -- elapsed: {0}", stopwatch.Elapsed);
                        break;
                    case System.ConsoleKey.D5:
                        stopwatch = Stopwatch.StartNew();
                        arr.qSort();
                        stopwatch.Stop();
                        Console.WriteLine("   done -- elapsed: {0}", stopwatch.Elapsed);
                        break;
                    case System.ConsoleKey.D6:
                        arr.checkSorted();
                        break;

                    case System.ConsoleKey.D7:
                        Console.WriteLine("Pls enter value to search!");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Could not read input!");
                            break;
                        }
                        res = arr.binarySearch(tmp);
                        if(res < 0)
                        {
                            Console.WriteLine("Could not find value :(");
                            break;
                        }
                        Console.WriteLine("Found value at index: {0}", res);
                        break;
                    case System.ConsoleKey.D8:
                        Console.WriteLine("Pls enter value to search!");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not read input!");
                            break;
                        }
                        res = arr.lerpSearch(tmp);
                        if (res < 0)
                        {
                            Console.WriteLine("Could not find value :(");
                            break;
                        }
                        Console.WriteLine("Found value at index: {0}", res);
                        break;


                    default:
                        break;

                }

                System.Threading.Thread.Sleep(2000);
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

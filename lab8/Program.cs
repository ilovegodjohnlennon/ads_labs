using System;
using System.Numerics;

namespace Lab7
{

    public class Program
    {

        public static void Main()
        {
            ConsoleKeyInfo K;
            MyList<int> list = new MyList<int>();
            int tmp;
            int val;

            do
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("1 - push front");
                Console.WriteLine("2 - push back");
                Console.WriteLine("3 - print list");
                Console.WriteLine("4 - print reversed");
                Console.WriteLine("5 - check if list contains value");
                Console.WriteLine("6 - find value by index");
                Console.WriteLine("7 - insert before index");
                Console.WriteLine("8 - insert after index");
                Console.WriteLine("9 - remove front");
                Console.WriteLine("0 - remove back");
                Console.WriteLine("a - remove before index");
                Console.WriteLine("b - remove after index\n");

                Console.WriteLine("m - insert into middle (only if length is even)");
                Console.WriteLine("x - find max element of the list");
                Console.WriteLine("ESC - quit\n\n");

                K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Please input value of new element!");
                        Console.Write(">>> ");
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
                        list.pushFront(tmp);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Please input value of new element!");
                        Console.Write(">>> ");
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
                        list.pushBack(tmp);
                        Console.WriteLine("    done!");
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("\n");
                        list.print();
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("\n");
                        list.printReversed();
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Pls input value to find:");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine(e.ToString());
                            break;
                        }

                        Console.WriteLine("Result: {0}", list.containsValue(tmp).ToString());
                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine("Pls input index: ");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine(e.ToString());
                            break;
                        }

                        try
                        {
                            Console.WriteLine("Value: {0}", list.at(tmp).ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid index!");
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        break;

                    case ConsoleKey.D7:
                        try
                        {
                            Console.WriteLine("Enter index: ");
                            Console.Write(">>> ");
                            tmp = readInt();
                            Console.WriteLine("Enter value: ");
                            Console.Write(">>> ");
                            val = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error input!");
                            break;
                        }

                        try
                        {
                            list.insertBefore(tmp, val);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
                        break;
                    case ConsoleKey.D8:
                        try
                        {
                            Console.WriteLine("Enter index: ");
                            Console.Write(">>> ");
                            tmp = readInt();
                            Console.WriteLine("Enter value: ");
                            Console.Write(">>> ");
                            val = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error input!");
                            break;
                        }

                        try
                        {
                            list.insertAfter(tmp, val);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
                        break;

                    case ConsoleKey.D9:
                        try
                        {
                            list.removeFront();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
                        break;
                    case ConsoleKey.D0:
                        try
                        {
                            list.removeBack();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
                        break;


                    case ConsoleKey.A:
                        Console.WriteLine("Input index: ");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }

                        try
                        {
                            list.removeBefore(tmp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
                        break;

                    case ConsoleKey.B:
                        Console.WriteLine("Input index: ");
                        Console.Write(">>> ");
                        try
                        {
                            tmp = readInt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }

                        try
                        {
                            list.removeAfter(tmp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                        Console.WriteLine("    done");
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
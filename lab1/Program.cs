using System;

namespace Program
{
    public class RecursionLab
    {
        public static void Main()
        {
            bool running = true;
            string? input;
            uint N;

            Console.WriteLine("This program calculates the sum of digits of a number.");
            Console.WriteLine("Write 'q' or Ctrl-D to quit.");
            
            while(running)
            {
                Console.Write(">>> ");
                try
                {
                    input = Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Received ctrl-d. quitting");
                    break;
                }

                if(input == null || input.Equals("q"))
                {
                    break;
                }

                if(input.Equals(""))
                {
                    continue;
                }

                try
                {
                    N = UInt32.Parse(input);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid input! (should be unsigned integer)");
                    Console.WriteLine(e.ToString());
                    continue;
                }

                Console.WriteLine(sumDigits(N));
            }


        }

        static uint sumDigits(uint N)
        {
            if(N == 0)
            {
                return 0;
            }

            return (N % 10) + sumDigits(N / 10);
        }
    }
}

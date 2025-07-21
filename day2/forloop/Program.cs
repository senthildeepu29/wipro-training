using System;

namespace LoopExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For loop printing numbers from 1 to 10:");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey(); // Wait for a key press before closing
        }
    }
}

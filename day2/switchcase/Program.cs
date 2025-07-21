using System;

namespace SwitchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number (1-3):");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("You entered One.");
                    break;
                case "2":
                    Console.WriteLine("You entered Two.");
                    break;
                case "3":
                    Console.WriteLine("You entered Three.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

            Console.ReadKey(); // Wait for key press before closing
        }
    }
}

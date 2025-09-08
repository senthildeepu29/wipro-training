using System;

namespace ArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize an array of names
            string[] names = new string[] { "Alice", "Bob", "Charlie", "Diana", "Ethan" };

            Console.WriteLine("Names in the array:");

            // Loop through the array and print each name
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Name at index {i}: {names[i]}");
            }

            Console.ReadKey(); // Wait for a key press before closing

        }
    }
}

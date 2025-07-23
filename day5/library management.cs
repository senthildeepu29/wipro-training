using System;
using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;
    public string ISBN;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
}

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter book title:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter book author:");
                string author = Console.ReadLine();

                Console.WriteLine("Enter book ISBN:");
                string isbn = Console.ReadLine();

                books.Add(new Book(title, author, isbn));
                Console.WriteLine("Book added successfully.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter ISBN of book to remove:");
                string isbn = Console.ReadLine();

                bool removed = false;
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == isbn)
                    {
                        books.RemoveAt(i);
                        Console.WriteLine("Book removed successfully.");
                        removed = true;
                        break;
                    }
                }
                if (!removed)
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Listing all books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
                }
            }
            else if (choice == "4")
            {
                // Exit immediately without printing anything else
                break;
            }
            else
            {
                // No error message or output here per your spec
            }
        }
    }
}


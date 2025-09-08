using Microsoft.Data.Sqlite;
using BookstoreApp.Models;

namespace BookstoreApp.DAL;

public class BookDAL {
    private readonly string _conn = "Data Source=bookstore.db";

    public List<Book> GetBooks() {
        var books = new List<Book>();
        using var conn = new SqliteConnection(_conn);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Books";
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) {
            books.Add(new Book {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Author = reader.GetString(2),
                Price = (decimal)reader.GetDouble(3),
                Genre = reader.GetString(4)
            });
        }
        return books;
    }

    public Book? GetBookById(int id) {
        using var conn = new SqliteConnection(_conn);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Books WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read()) {
            return new Book {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Author = reader.GetString(2),
                Price = (decimal)reader.GetDouble(3),
                Genre = reader.GetString(4)
            };
        }
        return null;
    }

    public void AddBook(Book book) {
        using var conn = new SqliteConnection(_conn);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Books (Title, Author, Price, Genre) VALUES (@t, @a, @p, @g)";
        cmd.Parameters.AddWithValue("@t", book.Title);
        cmd.Parameters.AddWithValue("@a", book.Author);
        cmd.Parameters.AddWithValue("@p", book.Price);
        cmd.Parameters.AddWithValue("@g", book.Genre);
        cmd.ExecuteNonQuery();
    }

    public void UpdateBook(Book book) {
        using var conn = new SqliteConnection(_conn);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE Books SET Title=@t, Author=@a, Price=@p, Genre=@g WHERE Id=@Id";
        cmd.Parameters.AddWithValue("@Id", book.Id);
        cmd.Parameters.AddWithValue("@t", book.Title);
        cmd.Parameters.AddWithValue("@a", book.Author);
        cmd.Parameters.AddWithValue("@p", book.Price);
        cmd.Parameters.AddWithValue("@g", book.Genre);
        cmd.ExecuteNonQuery();
    }

    public void DeleteBook(int id) {
        using var conn = new SqliteConnection(_conn);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Books WHERE Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}

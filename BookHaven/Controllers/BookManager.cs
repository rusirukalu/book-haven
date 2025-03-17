using System;
using System.Collections.Generic;
using System.Data;
using BookHaven.Models;
using BookHaven.Utilities;
using MySql.Data.MySqlClient;

namespace BookHaven.Controllers
{
    public class BookManager
    {
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM books";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                BookID = Convert.ToInt32(reader["book_id"]),
                                Title = reader["title"].ToString(),
                                Author = reader["author"].ToString(),
                                ISBN = reader["isbn"].ToString(),
                                Genre = reader["genre"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                StockQuantity = Convert.ToInt32(reader["stock_quantity"])
                            };

                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving books: " + ex.Message);
            }

            return books;
        }

        public void AddBook(Book book)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO books (title, author, isbn, genre, price, stock_quantity) " +
                                  "VALUES (@title, @author, @isbn, @genre, @price, @stock)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                    cmd.Parameters.AddWithValue("@genre", book.Genre);
                    cmd.Parameters.AddWithValue("@price", book.Price);
                    cmd.Parameters.AddWithValue("@stock", book.StockQuantity);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book: " + ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE books SET title = @title, author = @author, isbn = @isbn, " +
                                  "genre = @genre, price = @price, stock_quantity = @stock " +
                                  "WHERE book_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                    cmd.Parameters.AddWithValue("@genre", book.Genre);
                    cmd.Parameters.AddWithValue("@price", book.Price);
                    cmd.Parameters.AddWithValue("@stock", book.StockQuantity);
                    cmd.Parameters.AddWithValue("@id", book.BookID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book: " + ex.Message);
            }
        }

        public void DeleteBook(int bookId)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM books WHERE book_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", bookId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book: " + ex.Message);
            }
        }
    }
}

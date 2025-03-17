using System;
using System.Collections.Generic;
using System.Data;
using BookHaven.Models;
using BookHaven.Utilities;
using MySql.Data.MySqlClient;

namespace BookHaven.Controllers
{
    public class SaleManager
    {
        public int CreateSale(Sale sale)
        {
            int saleId = 0;
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                // Begin transaction
                transaction = conn.BeginTransaction();

                // Insert sale record
                string saleQuery = "INSERT INTO sales (customer_id, sale_date, total_amount) " +
                                 "VALUES (@customerId, @saleDate, @totalAmount); " +
                                 "SELECT LAST_INSERT_ID();";

                MySqlCommand saleCmd = new MySqlCommand(saleQuery, conn);
                saleCmd.Transaction = transaction;
                saleCmd.Parameters.AddWithValue("@customerId", sale.CustomerID);
                saleCmd.Parameters.AddWithValue("@saleDate", sale.SaleDate);
                saleCmd.Parameters.AddWithValue("@totalAmount", sale.TotalAmount);

                saleId = Convert.ToInt32(saleCmd.ExecuteScalar());

                // Insert sale items
                foreach (SaleItem item in sale.SaleItems)
                {
                    string itemQuery = "INSERT INTO sale_items (sale_id, book_id, price, quantity) " +
                                    "VALUES (@saleId, @bookId, @price, @quantity)";

                    MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn);
                    itemCmd.Transaction = transaction;
                    itemCmd.Parameters.AddWithValue("@saleId", saleId);
                    itemCmd.Parameters.AddWithValue("@bookId", item.BookID);
                    itemCmd.Parameters.AddWithValue("@price", item.Price);
                    itemCmd.Parameters.AddWithValue("@quantity", item.Quantity);

                    itemCmd.ExecuteNonQuery();

                    // Update book inventory
                    string updateBookQuery = "UPDATE books SET stock_quantity = stock_quantity - @quantity " +
                                          "WHERE book_id = @bookId";

                    MySqlCommand updateBookCmd = new MySqlCommand(updateBookQuery, conn);
                    updateBookCmd.Transaction = transaction;
                    updateBookCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                    updateBookCmd.Parameters.AddWithValue("@bookId", item.BookID);

                    updateBookCmd.ExecuteNonQuery();
                }

                // Commit transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback transaction if an error occurs
                if (transaction != null)
                    transaction.Rollback();

                ExceptionHandler.HandleException(ex, "creating sale");
                throw new Exception("Error creating sale: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return saleId;
        }
    }
}

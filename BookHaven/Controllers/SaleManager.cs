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

        // Add the GetAllSales method to retrieve all sales from the database
        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // First query: Get all sales with customer information
                    string salesQuery = @"
                        SELECT s.sale_id, s.customer_id, 
                               CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
                               s.sale_date, s.total_amount
                        FROM sales s
                        LEFT JOIN customers c ON s.customer_id = c.customer_id
                        ORDER BY s.sale_date DESC";

                    MySqlCommand salesCmd = new MySqlCommand(salesQuery, conn);

                    using (MySqlDataReader salesReader = salesCmd.ExecuteReader())
                    {
                        while (salesReader.Read())
                        {
                            Sale sale = new Sale
                            {
                                SaleID = Convert.ToInt32(salesReader["sale_id"]),
                                CustomerID = salesReader["customer_id"] != DBNull.Value ?
                                    Convert.ToInt32(salesReader["customer_id"]) : 0,
                                CustomerName = salesReader["customer_name"].ToString(),
                                SaleDate = Convert.ToDateTime(salesReader["sale_date"]),
                                TotalAmount = Convert.ToDecimal(salesReader["total_amount"]),
                                SaleItems = new List<SaleItem>()
                            };

                            sales.Add(sale);
                        }
                    }

                    // Second query: Get all sale items for each sale
                    foreach (Sale sale in sales)
                    {
                        string itemsQuery = @"
                            SELECT si.sale_item_id, si.sale_id, si.book_id, 
                                   b.title AS book_title, si.price, si.quantity
                            FROM sale_items si
                            JOIN books b ON si.book_id = b.book_id
                            WHERE si.sale_id = @SaleId";

                        MySqlCommand itemsCmd = new MySqlCommand(itemsQuery, conn);
                        itemsCmd.Parameters.AddWithValue("@SaleId", sale.SaleID);

                        using (MySqlDataReader itemsReader = itemsCmd.ExecuteReader())
                        {
                            while (itemsReader.Read())
                            {
                                SaleItem item = new SaleItem
                                {
                                    SaleItemID = Convert.ToInt32(itemsReader["sale_item_id"]),
                                    SaleID = Convert.ToInt32(itemsReader["sale_id"]),
                                    BookID = Convert.ToInt32(itemsReader["book_id"]),
                                    BookTitle = itemsReader["book_title"].ToString(),
                                    Price = Convert.ToDecimal(itemsReader["price"]),
                                    Quantity = Convert.ToInt32(itemsReader["quantity"])
                                };

                                sale.SaleItems.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "retrieving sales");
                throw new Exception("Error retrieving sales: " + ex.Message);
            }

            return sales;
        }
    }
}

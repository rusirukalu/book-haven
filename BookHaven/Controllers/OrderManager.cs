using System;
using System.Collections.Generic;
using System.Data;
using BookHaven.Models;
using BookHaven.Utilities;
using MySql.Data.MySqlClient;

namespace BookHaven.Controllers
{
    public class OrderManager
    {
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT o.*, 
                                   CONCAT(c.first_name, ' ', c.last_name) AS customer_name 
                                   FROM orders o
                                   LEFT JOIN customers c ON o.customer_id = c.customer_id
                                   ORDER BY o.order_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderID = Convert.ToInt32(reader["order_id"]),
                                CustomerID = reader["customer_id"] != DBNull.Value ? Convert.ToInt32(reader["customer_id"]) : 0,
                                CustomerName = reader["customer_name"].ToString(),
                                OrderDate = Convert.ToDateTime(reader["order_date"]),
                                DeliveryDate = reader["delivery_date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["delivery_date"]) : null,
                                Status = reader["status"].ToString(),
                                TotalAmount = Convert.ToDecimal(reader["total_amount"])
                            };

                            orders.Add(order);
                        }
                    }

                    // Load order items for each order
                    foreach (Order order in orders)
                    {
                        order.OrderItems = GetOrderItems(order.OrderID, conn);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders: " + ex.Message);
            }

            return orders;
        }

        private List<OrderItem> GetOrderItems(int orderId, MySqlConnection conn)
        {
            List<OrderItem> items = new List<OrderItem>();

            string query = @"SELECT oi.*, b.title AS book_title
                           FROM order_items oi
                           JOIN books b ON oi.book_id = b.book_id
                           WHERE oi.order_id = @orderId";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderId", orderId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    OrderItem item = new OrderItem
                    {
                        OrderItemID = Convert.ToInt32(reader["order_item_id"]),
                        OrderID = orderId,
                        BookID = Convert.ToInt32(reader["book_id"]),
                        BookTitle = reader["book_title"].ToString(),
                        Price = Convert.ToDecimal(reader["price"]),
                        Quantity = Convert.ToInt32(reader["quantity"])
                    };

                    items.Add(item);
                }
            }

            return items;
        }

        public int CreateOrder(Order order)
        {
            int orderId = 0;

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Begin transaction
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert order record
                        string orderQuery = @"INSERT INTO orders 
                                           (customer_id, order_date, status, total_amount) 
                                           VALUES (@customerId, @orderDate, @status, @totalAmount);
                                           SELECT LAST_INSERT_ID();";

                        MySqlCommand orderCmd = new MySqlCommand(orderQuery, conn);
                        orderCmd.Parameters.AddWithValue("@customerId", order.CustomerID);
                        orderCmd.Parameters.AddWithValue("@orderDate", order.OrderDate);
                        orderCmd.Parameters.AddWithValue("@status", order.Status);
                        orderCmd.Parameters.AddWithValue("@totalAmount", order.TotalAmount);

                        orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                        // Insert order items
                        foreach (OrderItem item in order.OrderItems)
                        {
                            string itemQuery = @"INSERT INTO order_items 
                                              (order_id, book_id, price, quantity) 
                                              VALUES (@orderId, @bookId, @price, @quantity)";

                            MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn);
                            itemCmd.Parameters.AddWithValue("@orderId", orderId);
                            itemCmd.Parameters.AddWithValue("@bookId", item.BookID);
                            itemCmd.Parameters.AddWithValue("@price", item.Price);
                            itemCmd.Parameters.AddWithValue("@quantity", item.Quantity);

                            itemCmd.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if an error occurs
                        transaction.Rollback();
                        throw new Exception("Error processing order: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating order: " + ex.Message);
            }

            return orderId;
        }

        public void UpdateOrderStatus(int orderId, string status, DateTime? deliveryDate = null)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE orders SET status = @status";

                    if (deliveryDate.HasValue)
                    {
                        query += ", delivery_date = @deliveryDate";
                    }

                    query += " WHERE order_id = @orderId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    if (deliveryDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order status: " + ex.Message);
            }
        }
    }
}

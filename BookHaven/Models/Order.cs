using System;
using System.Collections.Generic;

namespace BookHaven.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }  
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }  // Pending, Processing, Completed, Cancelled
        public string TransactionType { get; set; } = "Order";
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }

    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get { return Price * Quantity; } }
    }
}

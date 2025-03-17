using System;
using System.Collections.Generic;

namespace BookHaven.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }

    public class StockOrder
    {
        public int StockOrderID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }  // For display purposes
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }  // Pending, Received, Cancelled
        public decimal TotalAmount { get; set; }
        public List<StockOrderItem> OrderItems { get; set; }

        public StockOrder()
        {
            OrderItems = new List<StockOrderItem>();
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }

    public class StockOrderItem
    {
        public int StockOrderItemID { get; set; }
        public int StockOrderID { get; set; }
        public int BookID { get; set; }
        public string BookTitle { get; set; }  // For display purposes
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get { return UnitCost * Quantity; } }
    }
}

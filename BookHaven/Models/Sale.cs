using System;
using System.Collections.Generic;

namespace BookHaven.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }  // For display purposes
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleItem> SaleItems { get; set; }

        public Sale()
        {
            SaleItems = new List<SaleItem>();
            SaleDate = DateTime.Now;
        }
    }

    public class SaleItem
    {
        public int SaleItemID { get; set; }
        public int SaleID { get; set; }
        public int BookID { get; set; }
        public string BookTitle { get; set; }  // For display purposes
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get { return Price * Quantity; } }
    }
}

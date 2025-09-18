using System;

namespace CustomerOrderManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public string ProductName { get; set; } = string.Empty; 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}

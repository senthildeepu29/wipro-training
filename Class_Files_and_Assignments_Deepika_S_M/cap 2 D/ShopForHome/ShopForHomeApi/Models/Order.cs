using System;

namespace ShopForHomeApi.Models {
    public class Order {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

using System;

namespace ShopForHomeApi.Models {
    public class Coupon {
        public int Id { get; set; }
        public string? Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int? AssignedUserId { get; set; } // optional
    }
}

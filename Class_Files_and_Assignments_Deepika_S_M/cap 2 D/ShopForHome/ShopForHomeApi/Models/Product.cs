using System.ComponentModel.DataAnnotations;

namespace ShopForHomeApi.Models {
    public class Product {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public double Rating { get; set; }
    }
}

namespace ShopForHomeApi.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }   // navigation property

        // Foreign key for Product
        public int ProductId { get; set; }
        public Product? Product { get; set; }   // navigation property

        // Quantity of product in cart
        public int Quantity { get; set; }
    }
}

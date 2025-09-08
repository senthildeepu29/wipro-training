namespace ShopForHome.Api.Models.Dto
{
    public class OrderDto
{
    public string? FullName { get; set; }
    // public int UserId { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public string? PaymentMethod { get; set; }
    public List<OrderItemDto>? Items { get; set; }
    public decimal TotalAmount { get; set; }
}

public class OrderItemDto
{
    public int ProductId { get; set; }       // productId
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

}

namespace shopping.DTOs.Orders;


public class CreateOrderRequest
{
    public int UserId { get; set; }
    public IEnumerable<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();
}

public class OrderItemRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
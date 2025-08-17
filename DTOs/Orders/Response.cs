namespace shopping.DTOs.Orders;

public class OrderResponse
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public ICollection<OrderItemResponse> Items { get; set; } = new List<OrderItemResponse>();
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
}

public class OrderItemResponse
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

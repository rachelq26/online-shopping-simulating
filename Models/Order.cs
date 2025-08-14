namespace ShoppingApp.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public ICollection<Product> Items { get; set; } = new List<Product>();
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}

public enum OrderStatus
{
    Pending = 0,
    Processing = 1,
    Shipped = 2,
    Delivered = 3,
    Cancelled = 4
}


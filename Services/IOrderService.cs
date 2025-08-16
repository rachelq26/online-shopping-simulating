using shopping.Models;

namespace shopping.Services;

public interface IOrderService
{
    Task<Order> CreateOrderFromCartAsync(int userId, IEnumerable<OrderItem> items);
    Task<Order> UpdateOrderStatusAsync(Order order);
}
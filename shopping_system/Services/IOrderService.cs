using shopping.Models;
using shopping.DTOs.Orders;

namespace shopping.Services;

public interface IOrderService
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderFromCartAsync(int userId, IEnumerable<OrderItemRequest> items);
    Task<Order> UpdateOrderStatusAsync(Order order);
}
using shopping.Models;
using shopping.Repositories;

namespace shopping.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<Order> UpdateOrderStatusAsync(Order order)
    {
        return order;
    }

    public async Task<Order> CreateOrderFromCartAsync(int userId, IEnumerable<OrderItem> items)
    {
        return null;
    }
}

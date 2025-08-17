using shopping.Models;
using shopping.Repositories;
using shopping.DTOs.Orders;

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

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<Order> UpdateOrderStatusAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }

    public async Task<Order> CreateOrderFromCartAsync(int userId, IEnumerable<OrderItemRequest> items)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found");
            }

            decimal totalAmount = 0;
            foreach (var item in items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {item.ProductId} not found");
                }
                totalAmount += product.Price * item.Quantity;
            }

            var order = new Order
            {
                UserId = userId,
                Items = items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList(),
                TotalAmount = totalAmount,
            };

            var result = await _orderRepository.AddAsync(order);
            Console.WriteLine($"Order saved with ID: {result.Id}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in CreateOrderFromCartAsync: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            throw;
        }
    }
}

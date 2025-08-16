using shopping.Models;

namespace shopping.Repositories;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);
    Task<Order> UpdateAsync(Order order);
}

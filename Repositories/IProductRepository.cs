using shopping.Models;

namespace shopping.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}
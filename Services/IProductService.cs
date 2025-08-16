using shopping.Models;

namespace shopping.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
}

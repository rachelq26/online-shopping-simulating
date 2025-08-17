using shopping.Models;

namespace shopping.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
}

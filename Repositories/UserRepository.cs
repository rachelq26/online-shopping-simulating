using Microsoft.EntityFrameworkCore;
using shopping.Data;
using shopping.Models;

namespace shopping.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

}

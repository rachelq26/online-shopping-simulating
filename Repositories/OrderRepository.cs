using Microsoft.EntityFrameworkCore;
using shopping.Data;
using shopping.Models;

namespace shopping.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
}

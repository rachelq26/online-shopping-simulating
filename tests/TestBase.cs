using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopping.Data;
using shopping.Models;
using shopping.Repositories;
using shopping.Services;

namespace tests;

public abstract class TestBase : IDisposable
{
    protected ServiceProvider ServiceProvider { get; private set; } = null!;
    protected AppDbContext DbContext => ServiceProvider.GetRequiredService<AppDbContext>();
    protected IProductRepository ProductRepository => ServiceProvider.GetRequiredService<IProductRepository>();
    protected IOrderRepository OrderRepository => ServiceProvider.GetRequiredService<IOrderRepository>();
    protected IUserRepository UserRepository => ServiceProvider.GetRequiredService<IUserRepository>();
    protected IProductService ProductService => ServiceProvider.GetRequiredService<IProductService>();
    protected IOrderService OrderService => ServiceProvider.GetRequiredService<IOrderService>();

    protected TestBase()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();

        ServiceProvider = services.BuildServiceProvider();

        SeedTestData();
    }

    private void SeedTestData()
    {
        var products = new List<Product>
        {
            new Product { Name = "Apple", Price = 5, Description = "Red apple" },
            new Product { Name = "Peach", Price = 5, Description = "Juicy peach" },
            new Product { Name = "Banana", Price = 2, Description = "Yellow banana" }
        };
        DbContext.Products.AddRange(products);

        var user = new User { Email = "test@nexi.com", Name = "Test Nexi" };
        DbContext.Users.Add(user);

        DbContext.SaveChanges();
    }

    public void Dispose()
    {
        DbContext.Dispose();
        ServiceProvider.Dispose();
    }
}

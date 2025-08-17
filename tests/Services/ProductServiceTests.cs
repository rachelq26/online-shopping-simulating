using shopping.DTOs.Orders;
using shopping.Services;

namespace tests.Services;

public class ProductServiceTests : TestBase
{
    [Fact]
    public async Task Get_All_Products_Should_Return_All_Products()
    {
        // Act
        var products = await ProductService.GetAllProductsAsync();

        // Assert
        products.Should().HaveCount(3);
        products.Should().Contain(p => p.Name == "Apple");
        products.Should().Contain(p => p.Name == "Banana");
        products.Should().Contain(p => p.Name == "Peach");
    }
}

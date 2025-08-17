using shopping.DTOs.Orders;
using shopping.Services;

namespace tests.Services;

public class OrderServiceTests : TestBase
{
    [Fact]
    public async Task Create_Order_with_Valid_Data_Should_Create_Order()
    {
        // Arrange
        var user = DbContext.Users.First();
        var appleProduct = DbContext.Products.First(p => p.Name == "Apple");
        var bananaProduct = DbContext.Products.First(p => p.Name == "Banana");

        var orderItems = new List<OrderItemRequest>
        {
            new OrderItemRequest { ProductId = appleProduct.Id, Quantity = 2, Price = appleProduct.Price },
            new OrderItemRequest { ProductId = bananaProduct.Id, Quantity = 3, Price = bananaProduct.Price }
        };

        // Act
        var order = await OrderService.CreateOrderFromCartAsync(user.Id, orderItems);

        // Assert
        order.Id.Should().BeGreaterThan(0);
        order.UserId.Should().Be(user.Id);
        order.Status.Should().Be(OrderStatus.Created);
        order.Items.Should().HaveCount(2);
    }

    [Fact]
    public async Task Create_Order_With_Invalid_User_Id_Should_Throw_Argument_Exception()
    {
        // Arrange
        var appleProduct = DbContext.Products.First(p => p.Name == "Apple");
        var orderItems = new List<OrderItemRequest>
        {
            new OrderItemRequest { ProductId = appleProduct.Id, Quantity = 1, Price = appleProduct.Price }
        };

        var action = () => OrderService.CreateOrderFromCartAsync(999, orderItems);
        await action.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*User with ID 999 not found*");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopping.Controllers;
using shopping.Data;
using shopping.DTOs.Orders;
using shopping.Services;

namespace tests.Controllers;

public class OrderControllerTests : TestBase
{
    private readonly OrderController _controller;

    public OrderControllerTests()
    {
        _controller = new OrderController(OrderService);
    }

    [Fact]
    public async Task Create_Order_With_Valid_Request_Should_Return_Order()
    {
        // Arrange
        var user = DbContext.Users.First();
        var appleProduct = DbContext.Products.First(p => p.Name == "Apple");
        
        var request = new CreateOrderRequest
        {
            UserId = user.Id,
            Items = new List<OrderItemRequest>
            {
                new OrderItemRequest { ProductId = appleProduct.Id, Quantity = 2, Price = appleProduct.Price }
            }
        };

        // Act
        var result = await _controller.CreateOrder(request);

        // Assert
        var createdAtResult = result.Result as CreatedAtActionResult;
        createdAtResult.Should().NotBeNull();

        var orderResponse = createdAtResult!.Value as OrderResponse;
        orderResponse.Should().NotBeNull();
        orderResponse!.Items.Should().HaveCount(1);
    }

    [Fact]
    public async Task Create_Order_With_Empty_Items_Should_Return_BadRequest()
    {
        // Arrange
        var user = DbContext.Users.First();
        var request = new CreateOrderRequest
        {
            UserId = user.Id,
            Items = new List<OrderItemRequest>()
        };

        // Act
        var result = await _controller.CreateOrder(request);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

}

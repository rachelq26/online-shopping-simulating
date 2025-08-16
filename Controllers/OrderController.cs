using Microsoft.AspNetCore.Mvc;
using shopping.Models;
using shopping.Services;

namespace shopping.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    [HttpPost("create")]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderRequest request)
    {
        return Ok(request);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        var updatedOrder = await _orderService.UpdateOrderStatusAsync(order);
        return Ok(updatedOrder);
    }
}

public class CreateOrderRequest
{
    public int UserId { get; set; }
    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
}

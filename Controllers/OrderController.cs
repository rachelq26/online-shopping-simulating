using Microsoft.AspNetCore.Mvc;
using shopping.Models;
using shopping.Services;
using shopping.DTOs.Orders;
using shopping.Mappers;

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
    public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            if (request.Items == null || !request.Items.Any())
            {
                return BadRequest(new { message = "No items in the order" });
            }

            if (request.UserId == 0)
            {
                return BadRequest(new { message = "User ID is required" }   );
            }

            var order = await _orderService.CreateOrderFromCartAsync(request.UserId, request.Items);
            var orderResponse = OrderMapper.ToResponse(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderResponse);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return StatusCode(500, new { message = "An unexpected error occurred while creating the order" });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        var orderResponse = OrderMapper.ToResponse(order);
        return Ok(orderResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        var updatedOrder = await _orderService.UpdateOrderStatusAsync(order);
        var orderResponse = OrderMapper.ToResponse(updatedOrder);
        return Ok(orderResponse);
    }
}

using shopping.Models;
using shopping.DTOs.Orders;

namespace shopping.Mappers;

public static class OrderMapper
{
    public static OrderResponse ToResponse(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        return new OrderResponse
        {
            OrderId = order.Id,
            UserName = order.User?.Name ?? "customer",
            Items = order.Items.Select(item => new OrderItemResponse
            {
                ProductName = item.Product?.Name ?? "Unknown",
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList(),
            Status = order.Status.ToString(),
            CreatedDate = order.CreatedDate,
            TotalAmount = order.TotalAmount,
            PaymentMethod = order.PaymentMethod,
            ShippingAddress = order.ShippingAddress
        };
    }
}
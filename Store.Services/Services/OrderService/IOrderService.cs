using Store.Data.Entities;
using Store.Services.Services.OrderService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDetailsDto> CreateOrderAsync(OrderDto orderId);
        Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderForUserAsync(string buyerEmail);
        Task<OrderDetailsDto> GetOrderByIdAsync(Guid Id);
        Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodsAsync(); 
    }
}

using ECommerceApi.Dtos;
using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderCreateDto dto);
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
    }
}

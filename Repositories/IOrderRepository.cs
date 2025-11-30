using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
    }
}

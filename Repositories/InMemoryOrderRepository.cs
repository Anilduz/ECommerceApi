using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        public Task AddAsync(Order order)
        {
            order.Id = InMemoryDataStore.GetNextOrderId();
            InMemoryDataStore.Orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return Task.FromResult(InMemoryDataStore.Orders.Where(o => o.UserId == userId).AsEnumerable());
        }
    }
}

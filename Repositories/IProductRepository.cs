using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product); // Stok güncellemesi için
    }
}

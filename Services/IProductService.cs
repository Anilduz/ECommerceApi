using ECommerceApi.Dtos;
using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface IProductService
    {
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddProductAsync(ProductCreateDto dto);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task UpdateProductStockAsync(int productId, ProductStockUpdateDto dto);
    }
}

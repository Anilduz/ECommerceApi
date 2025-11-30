using ECommerceApi.Dtos;
using ECommerceApi.Entities;
using ECommerceApi.Exceptions;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
        public async Task<Product> AddProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            await _productRepository.AddAsync(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task UpdateProductStockAsync(int productId, ProductStockUpdateDto dto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new NotFoundException("Ürün", productId);
            }

            if (dto.Stock < 0)
            {
                throw new ArgumentException("Stok miktarı negatif olamaz.");
            }

            product.Stock = dto.Stock;
            await _productRepository.UpdateAsync(product);
        }
    }
}

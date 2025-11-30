using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        public Task<Product?> GetByIdAsync(int id)
        {
            return Task.FromResult(InMemoryDataStore.Products.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(InMemoryDataStore.Products);
        }

        public Task AddAsync(Product product)
        {
            product.Id = InMemoryDataStore.GetNextProductId();
            InMemoryDataStore.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            var existing = InMemoryDataStore.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Stock = product.Stock; // Tam güncelleme (stock için yeterli)
            }
            return Task.CompletedTask;
        }
    }
}

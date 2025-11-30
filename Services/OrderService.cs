using ECommerceApi.Dtos;
using ECommerceApi.Entities;
using ECommerceApi.Exceptions;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IProductRepository productRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(OrderCreateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                throw new NotFoundException("Kullanıcı", dto.UserId);
            }

            var product = await _productRepository.GetByIdAsync(dto.ProductId);
            if (product == null)
            {
                throw new NotFoundException("Ürün", dto.ProductId);
            }

            if (product.Stock < dto.Quantity)
            {
                throw new InsufficientStockException($"Ürün: {product.Name}. İstenen: {dto.Quantity}, Stok: {product.Stock}");
            }

            product.Stock -= dto.Quantity;
            await _productRepository.UpdateAsync(product);

            var order = new Order
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = product.Price * dto.Quantity, // TotalPrice hesaplama
                CreateDate = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("Kullanıcı", userId);
            }

            return await _orderRepository.GetByUserIdAsync(userId);
        }
    }
}

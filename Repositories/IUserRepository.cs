using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}

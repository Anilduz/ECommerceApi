using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public Task<User?> GetByIdAsync(int id)
        {
            return Task.FromResult(InMemoryDataStore.Users.FirstOrDefault(u => u.Id == id));
        }

        public Task AddAsync(User user)
        {
            user.Id = InMemoryDataStore.GetNextUserId();
            InMemoryDataStore.Users.Add(user);
            return Task.CompletedTask;
        }
        public Task<User?> GetByEmailAsync(string email)
        {
            var user = InMemoryDataStore.Users
                .FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(user);
        }
    }
}

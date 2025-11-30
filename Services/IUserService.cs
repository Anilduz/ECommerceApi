using ECommerceApi.Dtos;
using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface IUserService
    {
        Task<UserReadDto> AddUserAsync(UserCreateDto dto);
        Task<UserReadDto> GetUserByIdAsync(int id);
    }
}

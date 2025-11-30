using ECommerceApi.Dtos;
using ECommerceApi.Entities;
using ECommerceApi.Exceptions;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> AddUserAsync(UserCreateDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new DuplicateEmailException($"'{dto.Email}' e-posta adresi sistemde zaten kayıtlı.");
            }

            var userEntity = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            await _userRepository.AddAsync(userEntity);

            return new UserReadDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public async Task<UserReadDto?> GetUserByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);

            if (userEntity == null)
            {
                return null;
            }

            return new UserReadDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }
    }
}
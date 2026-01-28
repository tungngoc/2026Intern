using AutoMapper;
using FirstProjet.DTOs.Request;
using FirstProjet.Models;
using FirstProjet.Repository;
using System.Threading.Tasks;

namespace FirstProjet.Services.Implementations
{
    public class UserService(
        IUserRepository _userRepository,
        IMapper _userMapper
    ) : IUserService
    {

        public async Task<User> createUser(UserCreateRequest request)
        {
            var user = _userMapper.Map<User>(request);
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return user;
        }

        public async Task<List<User>> getAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }
    }
}

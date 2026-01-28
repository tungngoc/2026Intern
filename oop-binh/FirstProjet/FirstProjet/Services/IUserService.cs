using FirstProjet.DTOs.Request;
using FirstProjet.Models;

namespace FirstProjet.Services
{
    public interface IUserService
    {
        public Task<User> getUserById(int id);
        public Task<List<User>> getAllUsers();
        public Task<User> createUser(UserCreateRequest request);
    }
}

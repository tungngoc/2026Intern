
using FirstProjet.Models;
using FirstProjet.Repository;

namespace FirstProjet.Services.Implementations
{
    public class AuthService(
        IUserRepository _userRepository
    ) : IAuthService
    {
        
        public async Task<User?> Login(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);
            return !BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password) ? throw new UnauthorizedAccessException() : user;
        }

        public Task Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}

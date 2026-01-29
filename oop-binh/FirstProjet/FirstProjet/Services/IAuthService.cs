using FirstProjet.Models;

namespace FirstProjet.Services
{
    public interface IAuthService
    {
        Task<User?> Login(string username, string password);
        Task Register(string username, string password);
    }
}

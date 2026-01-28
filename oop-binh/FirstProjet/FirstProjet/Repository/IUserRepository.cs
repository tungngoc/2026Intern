using FirstProjet.Models;

namespace FirstProjet.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsername(string username);
    }
}

using FirstProjet.Data;
using FirstProjet.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjet.Repository.Implementations
{
    public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User> GetByUsername(string username)
        {
            var user = await _context.Users
                .Where(m => m.Username == username)
                .FirstOrDefaultAsync();
            return user;
        }
    }
}

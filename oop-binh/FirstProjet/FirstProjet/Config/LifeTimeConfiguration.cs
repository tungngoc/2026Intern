using FirstProjet.Repository;
using FirstProjet.Repository.Implementations;
using FirstProjet.Services;
using FirstProjet.Services.Implementations;

namespace FirstProjet.Config
{
    public class LifeTimeConfiguration
    {
        public static void addLifeTime(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
        }
    }
}

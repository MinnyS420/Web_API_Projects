using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess;
using MoviesApp.DataAccess.Abstraction;
using MoviesApp.DataAccess.EntityImplementation;
using MoviesApp.Domain.Models;
using MoviesApp.Services.Abstraction;
using MoviesApp.Services.Implementation;

namespace MoviesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MoviesAppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MoviesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

         public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMovieSevice, MovieService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}

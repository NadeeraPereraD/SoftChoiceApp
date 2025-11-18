using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Repositories.UserManagement;
using SoftChoiceApp.API.Services.UserManagement;

namespace SoftChoiceApp.API.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRolesRepository, UserRolesRepository>();
            repositories.AddScoped<IUsersRepository, UsersRepository>();
            return repositories;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRolesService, UserRolesServices>();
            services.AddScoped<IUsersService, UsersServices>();
            return services;
        }
    }
}

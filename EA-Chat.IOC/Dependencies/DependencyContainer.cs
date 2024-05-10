using EA_Chat.Application.Services.Implementations.UserServices;
using EA_Chat.Application.Services.Interfaces.IUserServices;
using EA_Chat.Data.Repositories.UserRepositories;
using EA_Chat.Domain.Interfaces.IUserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace EA_Chat.IOC.Dependencies;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<IUserService, UserService>();

        #endregion

        #region Repository

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion
    }
}
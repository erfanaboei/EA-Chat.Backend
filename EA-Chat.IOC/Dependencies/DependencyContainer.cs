using EA_Chat.Application.Convertors;
using EA_Chat.Application.Security.PasswordHelper;
using EA_Chat.Application.Security.Token;
using EA_Chat.Application.Senders.Mail;
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
        services.AddScoped<ISendMail, SendMail>();
        // services.AddScoped<IViewRender, RenderViewToString>();
        services.AddScoped<IPasswordHelper, PasswordHelper>();
        services.AddScoped<ITokenService, TokenService>();
        
        #endregion

        #region Repository

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion
    }
}
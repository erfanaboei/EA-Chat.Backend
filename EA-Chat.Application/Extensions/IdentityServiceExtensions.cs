using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EA_Chat.Application.Extensions;

public static class IdentityServiceExtensions
{
    public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        #region Add Authentication

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("TokenKey").ToString())),
                ValidateIssuer = true,
                ValidateAudience = false
            };
        });

        #endregion
    }
}
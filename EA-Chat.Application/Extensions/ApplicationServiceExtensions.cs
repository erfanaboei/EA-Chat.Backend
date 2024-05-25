using EA_Chat.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EA_Chat.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        #region AddDbContext

        services.AddDbContext<EAChatContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("EA-Chat-ConnectionString"));
        });

        #endregion

    }
}
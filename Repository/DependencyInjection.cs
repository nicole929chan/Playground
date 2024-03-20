using Microsoft.Extensions.DependencyInjection;
using Repository.SqlServer;

namespace Repository;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbContext, SqlServerConnection>();

        return services;
    }
}

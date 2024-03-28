using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.SqlServer;

namespace Repository;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbContext, SqlServerConnection>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}

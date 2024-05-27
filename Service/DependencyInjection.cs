using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Service;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPriceLogService, PriceLogService>();
        //services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<MementoService>();

        return services;
    }
}

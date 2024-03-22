﻿using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Service;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
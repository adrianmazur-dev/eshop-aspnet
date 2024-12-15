using EShop.Core.Interfaces.Repositories;
using EShop.Core.Interfaces.Services;
using EShop.Core.Services;
using EShop.Infrastructure.Repositories;

namespace EShop.Web.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
        services.AddScoped<ICatalogRepository, CatalogRepository>();

        services.AddScoped<ICatalogItemService, CatalogItemService>();
        services.AddScoped<ICatalogService, CatalogService>();
        return services;
    }
}
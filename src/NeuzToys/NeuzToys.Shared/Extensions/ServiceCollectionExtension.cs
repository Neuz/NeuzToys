using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Shared.Services;

namespace NeuzToys.Shared.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InitModule<T>(this IServiceCollection services, MenuService menuService)
        where T : IModule, new()
    {
        var module = new T();
        services = module.ConfigureServices(services);
        module.ConfigureMenuService(menuService);
        return services;
    }
}
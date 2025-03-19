using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Shared.Services;

namespace NeuzToys.Shared;

public interface IModule
{
    IServiceCollection ConfigureServices(IServiceCollection services);
    void ConfigureMenuService(MenuService menuService);
}
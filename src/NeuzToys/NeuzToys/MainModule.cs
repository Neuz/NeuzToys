using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Services;
using NeuzToys.Shared;
using NeuzToys.Shared.Services;
using NeuzToys.ViewModels;

namespace NeuzToys;

public class MainModule:IModule
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services.AddSingleton<AppService>()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<TitleBarViewModel>();
    }

    public void ConfigureMenuService(MenuService menuService)
    {
        
    }
}
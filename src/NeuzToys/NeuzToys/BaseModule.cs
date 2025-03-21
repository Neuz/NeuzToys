using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Services;
using NeuzToys.Shared;
using NeuzToys.Shared.Models;
using NeuzToys.Shared.Services;
using NeuzToys.ViewModels;

namespace NeuzToys;

public class BaseModule : IModule
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
            .AddSingleton<AppService>()
            .AddSingleton<IconService>()
            .AddSingleton<WelcomeWindowViewModel>()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<TitleBarViewModel>()
            .AddSingleton<MenuViewModel>()
            .AddSingleton<SettingsWindowViewModel>()
            .AddSingleton<ContentViewModel>()
            ;
    }

    public void ConfigureMenuService(MenuService menuService)
    {
    }
}
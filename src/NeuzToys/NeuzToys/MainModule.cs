﻿using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Services;
using NeuzToys.Shared;
using NeuzToys.Shared.Services;
using NeuzToys.ViewModels;

namespace NeuzToys;

public class MainModule : IModule
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
            .AddSingleton<AppService>()
            .AddSingleton<IconService>()
            .AddSingleton<MenuService>()
            .AddSingleton<WelcomeWindowViewModel>()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<TitleBarViewModel>()
            .AddSingleton<MenuViewModel>()
            .AddSingleton<SettingsWindowViewModel>()
            ;
    }

    public void ConfigureMenuService(MenuService menuService)
    {
    }
}
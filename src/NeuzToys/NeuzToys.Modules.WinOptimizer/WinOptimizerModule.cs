using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Modules.WinOptimizer.Services;
using NeuzToys.Modules.WinOptimizer.ViewModels;
using NeuzToys.Modules.WinOptimizer.Views;
using NeuzToys.Shared;
using NeuzToys.Shared.Models;
using NeuzToys.Shared.Services;

namespace NeuzToys.Modules.WinOptimizer;

public class WinOptimizerModule : IModule
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
            .AddSingleton<WmiService>()
            .AddSingleton<SystemInfoViewModel>();
    }

    public void ConfigureMenuService(MenuService menuService)
    {
        menuService.AddMenu(new MenuItem
        {
            Key = "WinOptimizer",
            Name = "系统优化",
            Icon = NeuzIcons.CommonKeys.Windows,
            Children =
            [
                new MenuItem
                {
                    Key = "WinOptimizer_SystemInformation",
                    Name = "系统信息",
                    Icon = NeuzIcons.CommonKeys.Information,
                    ViewType = typeof(SystemInfoView),
                    ViewModelType = typeof(SystemInfoViewModel)
                },
                new MenuItem
                {
                    Key = "WinOptimizer_Performance",
                    Name = "性能",
                    Icon = NeuzIcons.CommonKeys.Performance
                }
            ]
        });
    }
}